using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg.Stegano.File.Format;
using psteg.Stegano.File;

namespace psteg.Stegano.Engine.Decode {
    public sealed class MetadataDecoderEngine : DecoderEngine {

        public string MP4BoxName { get; set; }
        public Jpeg.Marker JpegMarker { get; set; }

        private void JpegSkipSOS() {
            long start = CoverStream.Position;
            byte[] buff = new byte[4096];
            bool eom = false;
            bool next_ff = false;

            while (!eom) {
                int read = CoverStream.Read(buff, 0, buff.Length);

                for (int i = 0; i < read; i++) {
                    if (next_ff) {
                        next_ff = false;
                        if ((buff[i] >= 0xD0 && buff[i] <= 0xD7) || buff[i] == 0x00)
                            continue;
                        else {
                            eom = true;
                            CoverStream.Seek(i-read-1, SeekOrigin.Current);
                            break;
                        }
                    }
                    else if (buff[i] == 0xFF)
                        next_ff = true;
                }
            }
        }

        private void DecodeJpeg() {
            byte[] wnd = new byte[4];

            CoverStream.Seek(2, SeekOrigin.Begin);
            if (JpegMarker == Jpeg.Marker.EOI) {
                ushort next = 0;
                CoverStream.Read(wnd, 0, 4);
                do {
                    next = Jpeg.GetBigEndianU16(wnd, 2);
                    CoverStream.Seek(next-2, SeekOrigin.Current);
                    if (BitConverter.ToUInt16(wnd, 0) == ((ushort)Jpeg.Marker.SOS))
                        JpegSkipSOS();

                    CoverStream.Read(wnd, 0, 4);
                } while (BitConverter.ToUInt16(wnd, 0) != (ushort)JpegMarker);

                CoverStream.Seek(-2, SeekOrigin.Current);
                CoverStream.CopyTo(OutputStream);
                return;
            }


            byte[] buff = new byte[ushort.MaxValue];
            do {
                CoverStream.Read(wnd, 0, 4);

                ushort marker = BitConverter.ToUInt16(wnd, 0);
                ushort len = Jpeg.GetBigEndianU16(wnd, 2);

                if (marker == (ushort)Jpeg.Marker.EOI)
                    break;

                if (marker != ((ushort)JpegMarker)) {
                    CoverStream.Seek(len-2, SeekOrigin.Current);
                    if (marker == ((ushort)Jpeg.Marker.SOS))
                        JpegSkipSOS();

                    continue;
                }

                CoverStream.Read(buff, 0, len-2);
                OutputStream.Write(buff, 0, len-2);
            } while (CoverStream.Length > CoverStream.Position);
        }

        private void DecodeMP4() {
            CoverStream.Seek(0, SeekOrigin.Begin);
            byte[] wnd = new byte[8];
            byte[] buff = new byte[short.MaxValue];
            MP4BoxName.PadRight(4, '\0');
            uint next = 0;
            do {
                CoverStream.Read(wnd, 0, 8);

                byte b = wnd[0];
                wnd[0] = wnd[3];
                wnd[3] = b;
                b = wnd[1];
                wnd[1] = wnd[2];
                wnd[2] = b;

                next = BitConverter.ToUInt32(wnd, 0);
                string s = Encoding.ASCII.GetString(wnd, 4, 4);
                if (Encoding.ASCII.GetString(wnd, 4, 4) != MP4BoxName) {
                    CoverStream.Seek(next-8, SeekOrigin.Current);
                    continue;
                }

                uint tocpy = next-8;

                while (tocpy > 0) {
                    int movd = CoverStream.Read(buff, 0, (int)Math.Min(buff.Length, tocpy));
                    OutputStream.Write(buff, 0, movd);
                    tocpy -= (uint)movd;
                }
            } while (CoverStream.Position < CoverStream.Length);
        }

        public override void Go() {
            FileFormat ff = FileID.IdentifyFile(CoverStream);

            switch (ff) {
                case FileFormat.JPEG:
                    DecodeJpeg();
                    break;
                case FileFormat.MP4:
                    DecodeMP4();
                    break;
            }
        }
    }
}
