using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg;
namespace psteg.Stegano.Engine.Encode {
    public sealed class LSBEncoderEngine : EncoderEngine{
        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();

        public bool ReverseBitOrder { get; set; }
        public bool AdaptiveDistribution { get; set; }
        public int? IV { get; set; }

        public struct _ImageSpecificOptions {
            public Dictionary<char, bool> Channels;
            public int BitWidth;
            public bool RowReadMode;
            public ImageFormat OutputFormat;
        }

        public _ImageSpecificOptions ImageSpecificOptions { get; set; }

        public static byte ReverseBits(byte b) => 
            (byte)(((b * 0x80200802ul) & 0x0884422110ul) * 0x0101010101ul >> 32);
        

        private bool PopulateBq() {
            int d = DataStream.ReadByte();
            if (d == -1)
                return false;

            bq.Push((byte)d);
            
            while (bq.Length < BQ_BLOCKSIZE) {
                d = DataStream.ReadByte();
                if (d == -1)
                    break;
                bq.Push(ReverseBitOrder?ReverseBits((byte)d):(byte)d);
            }
            return true;
        }

        private byte WidthPop(int depth) {
            byte r = 0;
            for (int i = 0; i < depth; i++)
                r |= (byte)((bq.PopSingle() ? 1 : 0) << i);
            return r;
        }
        private static byte LSBMix(byte cover, byte data, byte cover_mask) => (byte)((cover & cover_mask) | (data & ~cover_mask));

        private void RowFirstEncodeImage() {
            Bitmap bmp = new Bitmap(CoverStream);
            BitmapData bmpd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            byte cover_mask = (byte)~(((1 << ImageSpecificOptions.BitWidth) - 1));

            int xiv = 0, yiv = 0;

            if (IV != null) {
                xiv = (int)IV % bmp.Width;
                yiv = (int)IV / bmp.Height;
            }

            if (yiv > bmp.Height)
                throw new Exception("IV too big");

            bool data_eof = false;

            int channel_count = 0;
            foreach (bool en in ImageSpecificOptions.Channels.Values)
                if (en)
                    channel_count++;
            
            unsafe {
                for (int y = yiv; y < bmp.Height; y++) {
                    if (data_eof)
                        break;
                    Owner.ReportProgress(1, new ProgressState(y * bmp.Width, bmp.Width * bmp.Height, "Encoding"));
                    for (int x = xiv; x < bmp.Width; x++) {
                        byte* p_pixel = (byte*)(bmpd.Scan0 + (4 * x) + (bmpd.Stride * y)).ToPointer();

                        byte b = p_pixel[0],
                             g = p_pixel[1],
                             r = p_pixel[2],
                             a = p_pixel[3];

                        if (ImageSpecificOptions.Channels['B'])
                            b = LSBMix(b, WidthPop(ImageSpecificOptions.BitWidth), cover_mask);
                        if (ImageSpecificOptions.Channels['G'])
                            g = LSBMix(g, WidthPop(ImageSpecificOptions.BitWidth), cover_mask);
                        if (ImageSpecificOptions.Channels['R'])
                            r = LSBMix(r, WidthPop(ImageSpecificOptions.BitWidth), cover_mask);
                        if (ImageSpecificOptions.Channels['A'])
                            a = LSBMix(a, WidthPop(ImageSpecificOptions.BitWidth), cover_mask);

                        p_pixel[0] = b;
                        p_pixel[1] = g;
                        p_pixel[2] = r;
                        p_pixel[3] = a;

                        //last block handling
                        if (bq.Length < channel_count*ImageSpecificOptions.BitWidth) { 
                            PopulateBq();
                            //oof ouch my bones
                            if (bq.Length < channel_count*ImageSpecificOptions.BitWidth) {
                                x++;
                                if (x == bmp.Width) {
                                    x = 0;
                                    y++;
                                }
                                if (y == bmp.Height)
                                    throw new Exception("FUCK");

                                data_eof = true;
                                if (bq.Length == 0)
                                    break;

                                if (ImageSpecificOptions.Channels['B'])
                                    b = LSBMix(b, WidthPop(Math.Min(ImageSpecificOptions.BitWidth, bq.Length)), cover_mask);

                                if (bq.Length == 0)
                                    break;

                                if (ImageSpecificOptions.Channels['G'])
                                    g = LSBMix(g, WidthPop(Math.Min(ImageSpecificOptions.BitWidth, bq.Length)), cover_mask);

                                if (bq.Length == 0)
                                    break;

                                if (ImageSpecificOptions.Channels['R'])
                                    r = LSBMix(r, WidthPop(Math.Min(ImageSpecificOptions.BitWidth, bq.Length)), cover_mask);

                                if (bq.Length == 0)
                                    break;

                                if (ImageSpecificOptions.Channels['A'])
                                    a = LSBMix(a, WidthPop(Math.Min(ImageSpecificOptions.BitWidth, bq.Length)), cover_mask);
                                break;
                            }
                        }
                    }
                }
            }

            if (!data_eof)
                throw new Exception("Data does not fit");



            Owner.ReportProgress(1, new ProgressState(1, 1, "Outputting", true));
            bmp.UnlockBits(bmpd);
            bmp.Save(OutputStream, ImageSpecificOptions.OutputFormat);
            bmp.Dispose();
        }

        private void Lint() {
            if (DataStream == null)
                throw new Exception("Data stream null");
            if (CoverStream == null)
                throw new Exception("Cover stream null");
            if (OutputStream == null)
                throw new Exception("Output stream null");
        }

        public override void Go() {
            Prepare();

            Owner.ReportProgress(1, new ProgressState(1, 2, "Initializing", true));
            Lint();
            bq = new BitQueue();
            PopulateBq();

            if (ImageSpecificOptions.RowReadMode)
                RowFirstEncodeImage();

            Finish();
        }

    }
}
