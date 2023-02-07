using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg.Stegano.Engine.Encode;

namespace psteg.Stegano.Engine.Decode {
    public sealed class LSBDecoderEngine : DecoderEngine {
        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();

        public bool ReverseBitOrder { get; set; }
        public bool AdaptiveDistribution { get; set; }
        public int? IV { get; set; }

        public LSBEncoderEngine._ImageSpecificOptions ImageSpecificOptions { get; set; }

        public static byte ReverseBits(byte b) =>
            (byte)(((b * 0x80200802ul) & 0x0884422110ul) * 0x0101010101ul >> 32);

        private void Lint() {
            if (CoverStream == null)
                throw new Exception("Cover stream null");
            if (OutputStream == null)
                throw new Exception("Output stream null");
        }

        private void LSBUnmixPush(byte data, int width) {
            for (int i = 0; i < width; i++)
                bq.Push((data&(1<<i))>0);
        }

        public void RowFirstDecodeImage() {
            Bitmap bmp = new Bitmap(CoverStream);
            BitmapData bmpd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int xiv = 0, yiv = 0;

            if (IV != null) {
                xiv = (int)IV % bmp.Width;
                yiv = (int)IV / bmp.Height;
            }


            if (yiv > bmp.Height)
                throw new Exception("IV too big");

            bool data_eof = false;
            unsafe {
                for (int y = yiv; y < bmp.Height; y++) {
                    Owner.ReportProgress(1, new ProgressState(y * bmp.Width, bmp.Width * bmp.Height, "Decoding"));
                    if (data_eof)
                        break;
                    for (int x = xiv; x < bmp.Width; x++) {
                        byte* p_pixel = (byte*)(bmpd.Scan0 + (4 * x) + (bmpd.Stride * y)).ToPointer();

                        byte b = p_pixel[0],
                             g = p_pixel[1],
                             r = p_pixel[2],
                             a = p_pixel[3];

                        if (ImageSpecificOptions.Channels['B'])
                            LSBUnmixPush(b, ImageSpecificOptions.BitWidth);
                        if (ImageSpecificOptions.Channels['G'])
                            LSBUnmixPush(g, ImageSpecificOptions.BitWidth);
                        if (ImageSpecificOptions.Channels['R'])
                            LSBUnmixPush(r, ImageSpecificOptions.BitWidth);
                        if (ImageSpecificOptions.Channels['A'])
                            LSBUnmixPush(a, ImageSpecificOptions.BitWidth);

                        if (bq.Length / 8 > 0) {
                            OutputStream.WriteByte(bq.Pop());
                            if (OutputStream.Position == DataSize) { 
                                data_eof = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public override void Go() {
            Prepare();

            Owner.ReportProgress(1, new ProgressState(1, 2, "Initializing", true));
            Lint();
            bq = new BitQueue();

            if (ImageSpecificOptions.RowReadMode)
                RowFirstDecodeImage();

            Finish();
        }
    }
}
