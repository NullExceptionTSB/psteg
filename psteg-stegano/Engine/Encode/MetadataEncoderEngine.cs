using System;
using System.IO;
using System.Text;
using psteg.Stegano.File;
using psteg.Stegano.File.Format;

namespace psteg.Stegano.Engine.Encode {
    public sealed class MetadataEncoderEngine : EncoderEngine {
        public string MP4BoxName { get; set; }
        public Jpeg.Marker JpegMarker { get; set; }

        public static Jpeg.Marker[] SupportedJpegMarkers { get; } = {
            Jpeg.Marker.COM,
            Jpeg.Marker.EOI,
            Jpeg.Marker.APP4,
            Jpeg.Marker.APP5,
            Jpeg.Marker.APP7,
            Jpeg.Marker.APP8,
            Jpeg.Marker.APP9,
            Jpeg.Marker.APP14,
            Jpeg.Marker.APP15
        };

        private void JpegSkipSOS() {
            bool eos = false;
            bool ff = false;
            while (!eos) {
                if (ff) {
                    if (CoverStream.ReadByte() != 0x00)
                        eos = true;
                    else {
                        OutputStream.WriteByte(0xFF);
                        OutputStream.WriteByte(0x00);
                    }
                    ff=false;
                } else {
                    byte b = (byte)CoverStream.ReadByte();
                    if (b == 0xFF)
                        ff = true;
                    else
                        OutputStream.WriteByte(b);
                }
            }
            CoverStream.Seek(-2, SeekOrigin.Current);
        }

        private void EncodeJpeg() {
            ushort mark = 0;
            byte[] wnd = new byte[2];
            byte[] buff = new byte[ushort.MaxValue-2];

            //note: while it is technically possible to optimize this by checking the end of the file for EOI,
            //it would be unreliable, because if the encoded data would end with an EOI marker, it would be ignored
            //and more data would be written to the end, causing the data to become mangled
            //this isn't even unlikely, as it could be achieved simply by encoding a JPEG file into another JPEG file
            if (JpegMarker == Jpeg.Marker.EOI) {
                //copy SOI
                CoverStream.Seek(0, SeekOrigin.Begin);
                OutputStream.Seek(0, SeekOrigin.Begin);
                CoverStream.Read(wnd, 0, 2);
                OutputStream.Write(wnd, 0, 2);
                //todo: rewrite this to use a "tee" function so that this looks better
                CoverStream.Read(wnd, 0, 2);
                ushort marker = BitConverter.ToUInt16(wnd, 0);
                OutputStream.Write(wnd, 0, 2);
                do {
                    Owner.ReportProgress(1, new ProgressState((int)(CoverStream.Position), (int)(CoverStream.Length), "Parsing JPEG metadata"));
                    CoverStream.Read(wnd, 0, 2);
                    ushort length = Jpeg.GetBigEndianU16(wnd, 0);
                    OutputStream.Write(wnd, 0, 2);

                    CoverStream.Read(buff, 0, length-2);
                    OutputStream.Write(buff, 0, length-2);
                    if (marker == ((ushort)Jpeg.Marker.SOS))
                        JpegSkipSOS();

                    CoverStream.Read(wnd, 0, 2);
                    marker = BitConverter.ToUInt16(wnd, 0);
                    OutputStream.Write(wnd, 0, 2);
                } while (marker != ((ushort)JpegMarker));
                Owner.ReportProgress(1, new ProgressState(1, 1, "Copying hidden data", true));
                DataStream.CopyTo(OutputStream);
                return;
            }

            bool sup = false;
            foreach (Jpeg.Marker m in SupportedJpegMarkers) 
                if (m == JpegMarker) {
                    sup = true;
                    break;
                }
            if (!sup)
                throw new Exception("invalid marker");
            
            //skip SOI
            CoverStream.Read(wnd, 0, 2);
            OutputStream.Write(wnd, 0, 2);
            //skip first marker
            CoverStream.Read(wnd, 0, 2);
            OutputStream.Write(wnd, 0, 2);
            bool sos = (BitConverter.ToUInt16(wnd, 0) == ((ushort)Jpeg.Marker.SOS));
            //load first marker length
            CoverStream.Read(wnd, 0, 2);
            //LE=>BE
            byte n = wnd[0];
            wnd[0] = wnd[1];
            wnd[1] = n;
            //copy first marker
            mark = BitConverter.ToUInt16(wnd, 0);
            CoverStream.Seek(-2, SeekOrigin.Current);
            byte[] next = new byte[mark];
            CoverStream.Read(next, 0, next.Length);
            OutputStream.Write(next, 0, next.Length);
            //handle special case SOS marker
            if (sos)
                JpegSkipSOS();
            //calculate required section count
            ulong sects_req = (uint)(DataStream.Length / ushort.MaxValue);
            if ((DataStream.Length % ushort.MaxValue) > 0)
                sects_req++;
            ulong st = sects_req;
            //write payload into sections
            do {
                ushort sz = (ushort)(Math.Min(ushort.MaxValue-2, DataStream.Length - DataStream.Position)+2);

                wnd = BitConverter.GetBytes((ushort)JpegMarker);
                OutputStream.Write(wnd, 0, 2);
                
                wnd = BitConverter.GetBytes(sz);
                n = wnd[0];
                wnd[0] = wnd[1];
                wnd[1] = n;
                OutputStream.Write(wnd, 0, 2);

                DataStream.Read(buff, 0, sz-2);
                OutputStream.Write(buff, 0, sz-2);

                Owner.ReportProgress(1, new ProgressState((int)(st-sects_req), (int)(st+1), "Encoding"));

            } while (--sects_req > 0);
            CoverStream.CopyTo(OutputStream);
        }

        private void EncodeMP4() {
            //pad box name
            CoverStream.CopyTo(OutputStream);
            MP4BoxName.PadRight(4, '\0');
            //calculate required ammount of boxes
            uint binCount = (uint)(DataStream.Length / uint.MaxValue);
            if (DataStream.Length % uint.MaxValue > 0)
                binCount++;
            uint tbin = binCount;

            //initialize buffer for block transfer (32k block size)
            byte[] buff = new byte[short.MaxValue];
            do {
                Owner.ReportProgress(1, new ProgressState((int)(tbin-binCount), (int)binCount, "Encoding"));
                uint sz = (uint)(Math.Min(uint.MaxValue-8, DataStream.Length - DataStream.Position)+8);
                byte[] wnd = BitConverter.GetBytes(sz);
                byte b = wnd[0];
                wnd[0] = wnd[3];
                wnd[3] = b;
                b = wnd[1];
                wnd[1] = wnd[2];
                wnd[2] = b;

                OutputStream.Write(wnd, 0, 4);
                OutputStream.Write(Encoding.ASCII.GetBytes(MP4BoxName.Substring(0, Math.Min(MP4BoxName.Length,4))), 0, 4);

                uint tocpy = sz-8;

                while (tocpy > 0) {
                    int movd = DataStream.Read(buff, 0, (int)Math.Min(buff.Length, tocpy));
                    OutputStream.Write(buff, 0, movd);
                    tocpy -= (uint)movd;
                }
            } while (--binCount > 0);
        }

        public override void Go() {
            Prepare();
            FileFormat ff = FileID.IdentifyFile(CoverStream);
            Exception e = null;
            try { 
                switch (ff) {
                    case FileFormat.JPEG:
                        EncodeJpeg();
                        break;
                    case FileFormat.MP4:
                        EncodeMP4();
                        break;
                }
            } catch (Exception ex) { e = ex; }
            Finish();

            if (e != null) 
                throw e;
        }
    }
}
