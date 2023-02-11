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

        private void DecodeJpeg() {
            byte[] wnd = new byte[4];
            byte n = 0;

            CoverStream.Seek(2, SeekOrigin.Begin);
            if (JpegMarker == Jpeg.Marker.EOI) {
                ushort next = 0;
                do {
                    CoverStream.Seek(next, SeekOrigin.Current);
                    CoverStream.Read(wnd, 0, 4);

                    n = wnd[2];
                    wnd[2] = wnd[3];
                    wnd[3] = n;

                    next = BitConverter.ToUInt16(wnd, 2);
                } while (BitConverter.ToUInt16(wnd, 0) != (ushort)JpegMarker);

                CoverStream.CopyTo(OutputStream);
                return;
            }


            byte[] buff = new byte[ushort.MaxValue];
            do {
                CoverStream.Read(wnd, 0, 4);
                n = wnd[2];
                wnd[2] = wnd[3];
                wnd[3] = n;

                ushort marker = BitConverter.ToUInt16(wnd, 0);
                ushort len = BitConverter.ToUInt16(wnd, 2);
                if (marker != (ushort)JpegMarker || marker == (ushort)Jpeg.Marker.EOI) {
                    CoverStream.Seek(len-2, SeekOrigin.Current);
                    continue;
                }

                CoverStream.Read(buff, 0, len);
                OutputStream.Write(buff, 0, len);
            } while (CoverStream.Length < CoverStream.Position);
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
