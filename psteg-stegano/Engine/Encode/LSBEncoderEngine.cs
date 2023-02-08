using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

using psteg.Stegano.File;

namespace psteg.Stegano.Engine.Encode {
    public sealed class LSBEncoderEngine : EncoderEngine{
        public enum Mode {
            Audio, Image
        }

        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();

        public Mode EngineMode { get; set; }

        public bool ReverseBitOrder { get; set; }
        public bool AdaptiveDistribution { get; set; }
        public int? IV { get; set; }

        public struct _ImageSpecificOptions {
            public Dictionary<char, bool> Channels;
            public int BitWidth;
            public bool RowReadMode;
            public ImageFormat OutputFormat;
        }

        public struct _AudioSpecificOptions {
            public AudioFileID ID;
            public int BitWidth;
            public Dictionary<char, bool> Channels;

            public AudioDecode Decoder;
            public AudioEncode Encoder;
        }

        public _ImageSpecificOptions ImageSpecificOptions { get; set; }
        public _AudioSpecificOptions AudioSpecificOptions { get; set; }

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
                bq.Push(!ReverseBitOrder?ReverseBits((byte)d):(byte)d);
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
        private static ushort LSBMix(ushort cover, ushort data, ushort cover_mask) => (ushort)((cover & cover_mask) | (data & ~cover_mask));

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
        //copy pastin' shitty writtn' code
        private void EncodeAudio8() {
            AudioDecode decoder = AudioSpecificOptions.Decoder;
            AudioEncode encoder = AudioSpecificOptions.Encoder;

            int smp_buffer_pos = 0;
            byte[] smp_buffer = new byte[BQ_BLOCKSIZE];

            int smp_count = 0;
            byte cover_mask = (byte)~(((1 << AudioSpecificOptions.BitWidth) - 1));

            bool final = false;
            bool mono = AudioSpecificOptions.ID.Channels == 1;
            while (DataStream.Length != DataStream.Position || bq.Length > 0) {
                
                if (bq.Length < AudioSpecificOptions.BitWidth*AudioSpecificOptions.ID.Channels && !final) { 
                    if (!PopulateBq()) {
                        final = true;
                        for (int i = 0; i < 16; i++)
                            bq.Push(0);
                    }
                }

                if (smp_buffer_pos == smp_count) {
                    smp_buffer_pos = 0;
                    Owner.ReportProgress(1, new ProgressState((int)CoverStream.Position, (int)CoverStream.Length, "Encoding"));
                    if (smp_count != smp_buffer.Length) {
                        byte[] small_buffer = new byte[smp_count];
                        Array.Copy(smp_buffer, small_buffer, smp_count);
                        encoder.PutSamples(small_buffer);
                    }
                    else
                        encoder.PutSamples(smp_buffer);

                    smp_count = decoder.GetSamples8(smp_buffer);
                    if (smp_count == 0)
                        throw new Exception("Data too large");
                }

                if (mono) 
                    smp_buffer[smp_buffer_pos] = LSBMix(smp_buffer[smp_buffer_pos++], WidthPop(AudioSpecificOptions.BitWidth), cover_mask);
                else {
                    if (AudioSpecificOptions.Channels['L'])
                        smp_buffer[smp_buffer_pos] = LSBMix(smp_buffer[smp_buffer_pos], WidthPop(AudioSpecificOptions.BitWidth), cover_mask);
                    if (AudioSpecificOptions.Channels['R'])
                        smp_buffer[smp_buffer_pos+1] = LSBMix(smp_buffer[smp_buffer_pos+1], WidthPop(AudioSpecificOptions.BitWidth), cover_mask);
                    smp_buffer_pos += 2;
                }

                if (final)
                    break;

                
            }

            encoder.PutSamples(smp_buffer);

            smp_count = decoder.GetSamples8(smp_buffer);

            int blocks = 0;

            while(smp_count > 0) {
                if (blocks++ % 1024 == 0)
                    Owner.ReportProgress(1, new ProgressState((int)CoverStream.Position, (int)CoverStream.Length, "Crosscoding"));
                if (smp_count != smp_buffer.Length) {
                    byte[] small_buffer = new byte[smp_count];
                    Array.Copy(smp_buffer, small_buffer, smp_count);
                    encoder.PutSamples(small_buffer);
                }
                else
                    encoder.PutSamples(smp_buffer);

                smp_count = decoder.GetSamples8(smp_buffer);
            }
            encoder.Dispose();
        }
        private void EncodeAudio16() {
            AudioDecode decoder = AudioSpecificOptions.Decoder;
            AudioEncode encoder = AudioSpecificOptions.Encoder;

            int smp_buffer_pos = 0;
            ushort[] smp_buffer = new ushort[BQ_BLOCKSIZE];

            int smp_count = 0;
            ushort cover_mask = (ushort)~(((1 << AudioSpecificOptions.BitWidth) - 1));

            bool final = false;
            bool mono = AudioSpecificOptions.ID.Channels == 1;
            //todo: crosscode smps until iv reached


            while (DataStream.Length != DataStream.Position || bq.Length > 0) {

                if (bq.Length < AudioSpecificOptions.BitWidth*AudioSpecificOptions.ID.Channels && !final) {
                    if (!PopulateBq()) {
                        final = true;
                        for (int i = 0; i < 16; i++)
                            bq.Push(0);
                    }
                }

                if (smp_buffer_pos == smp_count) {
                    smp_buffer_pos = 0;
                    Owner.ReportProgress(1, new ProgressState((int)CoverStream.Position, (int)CoverStream.Length, "Encoding"));
                    if (smp_count != smp_buffer.Length) {
                        ushort[] small_buffer = new ushort[smp_count];
                        Array.Copy(smp_buffer, small_buffer, smp_count);
                        encoder.PutSamples(small_buffer);
                    }
                    else
                        encoder.PutSamples(smp_buffer);

                    smp_count = decoder.GetSamples16(smp_buffer);
                    if (smp_count == 0)
                        throw new Exception("Data too large");
                }

                if (mono)
                    smp_buffer[smp_buffer_pos] = LSBMix(smp_buffer[smp_buffer_pos++], WidthPop(AudioSpecificOptions.BitWidth), cover_mask);
                else {
                    if (AudioSpecificOptions.Channels['L'])
                        smp_buffer[smp_buffer_pos] = LSBMix(smp_buffer[smp_buffer_pos], WidthPop(AudioSpecificOptions.BitWidth), cover_mask);
                    if (AudioSpecificOptions.Channels['R'])
                        smp_buffer[smp_buffer_pos+1] = LSBMix(smp_buffer[smp_buffer_pos+1], WidthPop(AudioSpecificOptions.BitWidth), cover_mask);
                    smp_buffer_pos += 2;
                }

                if (final)
                    break;
            }

            encoder.PutSamples(smp_buffer);

            smp_count = decoder.GetSamples16(smp_buffer);

            int blocks = 0;

            while (smp_count > 0) {
                if (blocks++ % 1024 == 0)
                    Owner.ReportProgress(1, new ProgressState((int)CoverStream.Position, (int)CoverStream.Length, "Crosscoding"));
                if (smp_count != smp_buffer.Length) {
                    ushort[] small_buffer = new ushort[smp_count];
                    Array.Copy(smp_buffer, small_buffer, smp_count);
                    encoder.PutSamples(small_buffer);
                }
                else
                    encoder.PutSamples(smp_buffer);

                smp_count = decoder.GetSamples16(smp_buffer);
            }
            encoder.Dispose();
        }
        private void EncodeAudio() {
            if (AudioSpecificOptions.ID.SampleSize == 8)
                EncodeAudio8();
            else if (AudioSpecificOptions.ID.SampleSize == 16)
                EncodeAudio16();
            else
                throw new NotImplementedException();
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

            if (EngineMode == Mode.Audio)
                EncodeAudio();
            else if (ImageSpecificOptions.RowReadMode)     
                RowFirstEncodeImage();
            


            Finish();
        }

    }
}
