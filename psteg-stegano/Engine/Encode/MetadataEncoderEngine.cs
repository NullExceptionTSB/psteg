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

        private void EncodeJpeg() {
            ushort mark = 0;
            byte[] wnd = new byte[2];

            if (JpegMarker == Jpeg.Marker.EOI) {
                CoverStream.CopyTo(OutputStream);
                CoverStream.Seek(-2, SeekOrigin.Current);
                CoverStream.Read(wnd, 0, 2);
                mark = BitConverter.ToUInt16(wnd, 0);
                if (mark != (ushort)Jpeg.Marker.EOI)
                    do {
                        if (CoverStream.Position == 0 || OutputStream.Position == 0) {
                            //no eoi, write it
                            OutputStream.Seek(0, SeekOrigin.End);
                            OutputStream.WriteByte(0xFF);
                            OutputStream.WriteByte(0xD9);
                            break;
                        }
                        CoverStream.Seek(-4, SeekOrigin.Current);
                        OutputStream.Seek(-4, SeekOrigin.Current);
                        CoverStream.Read(wnd, 0, 2);
                        mark = BitConverter.ToUInt16(wnd, 0);
                    } while (mark != (ushort)Jpeg.Marker.EOI);

                OutputStream.SetLength(DataStream.Position);
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

            CoverStream.Read(wnd, 0, 2);
            OutputStream.Write(wnd, 0, 2);

            CoverStream.Read(wnd, 0, 2);

            byte n = wnd[0];
            wnd[0] = wnd[1];
            wnd[1] = n;

            mark = BitConverter.ToUInt16(wnd, 0);
            CoverStream.Seek(-2, SeekOrigin.Current);
            byte[] next = new byte[mark];
            CoverStream.Read(next, 0, next.Length);
            OutputStream.Write(next, 0, next.Length);
            
            ulong sects_req = (uint)(DataStream.Length / ushort.MaxValue);
            if ((DataStream.Length % ushort.MaxValue) > 0)
                sects_req++;
            ulong st = sects_req;
            byte[] buff = new byte[ushort.MaxValue-2];

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
            CoverStream.CopyTo(OutputStream);
            MP4BoxName.PadRight(4, '\0');

            uint binCount = (uint)(DataStream.Length / uint.MaxValue);
            if (DataStream.Length % uint.MaxValue > 0)
                binCount++;
            uint tbin = binCount;

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
            FileFormat ff = FileID.IdentifyFile(CoverStream);

            switch (ff) {
                case FileFormat.JPEG:
                    EncodeJpeg();
                    break;
                case FileFormat.MP4:
                    EncodeMP4();
                    break;
            }
        }
    }
}
