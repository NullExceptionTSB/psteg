using System;
using System.Drawing;
using System.Drawing.Imaging;

using psteg.Stegano.File;
using psteg.Stegano.Engine.Util;

namespace psteg.Stegano.Engine.Decode {
    public sealed class LSBDecoderEngine : DecoderEngine {

        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();

        public bool ReverseBitOrder { get; set; }
        public bool AdaptiveDistribution { get; set; }
        public int? IV { get; set; }

        public int BitWidth { get; set; }

        public LSB.Mode EngineMode { get; set; }

        public LSB.SpecificOptions.Img ImageSpecificOptions { get; set; }
        public LSB.SpecificOptions.Audio AudioSpecificOptions { get; set; }

        private void Lint() {
            if (CoverStream == null)
                throw new Exception("Cover stream null");
            if (OutputStream == null)
                throw new Exception("Output stream null");
        }

        public void DecodeImage() {
            Bitmap bmp = new Bitmap(CoverStream);
            BitmapData bmpd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            LinearImageSerializer state = new LinearImageSerializer(ImageSpecificOptions.RowReadMode, IV != null ? (int)IV : 0, ImageSpecificOptions.ChannelString, bmpd);

            long written = 0;

            while (written < DataSize) {
                byte s = state.Get();
                LSB.UnmixPush(s, BitWidth, bq);

                if (bq.Length >= 8) { 
                    OutputStream.WriteByte(LSB.ReverseBits(bq.Pop(), !ReverseBitOrder));
                    written++;
                }
                //so that out of range cases get handled properly
                try { 
                    state.Next();
                } catch (Exception e) {
                    bmp.UnlockBits(bmpd);
                    bmp.Dispose();
                    Finish();
                    throw e;
                }
            }

            bmp.UnlockBits(bmpd);
            bmp.Dispose();
        }

        public void DecodeAudio8() {
            AudioDecode decoder = AudioSpecificOptions.Decoder;
            byte[] buffer = new byte[BQ_BLOCKSIZE];
            int smp_count = 0;

            bool mono = AudioSpecificOptions.ID.Channels == 1;
            do {
                smp_count = decoder.GetSamples8(buffer);

                if (mono)
                    for (int i = 0; i < buffer.Length; i++)
                        LSB.UnmixPush(buffer[i], BitWidth, bq);
                else 
                    for (int i = 0; i < buffer.Length; i+=2) {
                        if (AudioSpecificOptions.Channels['L'])
                            LSB.UnmixPush(buffer[i], BitWidth, bq);
                        if (AudioSpecificOptions.Channels['R'])
                            LSB.UnmixPush(buffer[i+1], BitWidth, bq);
                    }
                while (bq.Length / 8 > 0) {
                    OutputStream.WriteByte(LSB.ReverseBits(bq.Pop(),!ReverseBitOrder));
                    if (OutputStream.Position == DataSize)
                        goto eol;
                }
            } while (smp_count != 0);
        eol:
            return;
        }

        public void DecodeAudio16() {
            AudioDecode decoder = AudioSpecificOptions.Decoder;
            ushort[] buffer = new ushort[BQ_BLOCKSIZE];
            int smp_count = 0;

            bool mono = AudioSpecificOptions.ID.Channels == 1;
            do {
                smp_count = decoder.GetSamples16(buffer);

                if (mono)
                    for (int i = 0; i < buffer.Length; i++)
                        LSB.UnmixPush(buffer[i], BitWidth, bq);
                else
                    for (int i = 0; i < buffer.Length; i+=2) {
                        if (AudioSpecificOptions.Channels['L'])
                            LSB.UnmixPush(buffer[i], BitWidth, bq);
                        if (AudioSpecificOptions.Channels['R'])
                            LSB.UnmixPush(buffer[i+1], BitWidth, bq);
                    }
                while (bq.Length / 8 > 0) {
                    OutputStream.WriteByte(LSB.ReverseBits(bq.Pop(), !ReverseBitOrder));
                    if (OutputStream.Position == DataSize) 
                        goto eol;
                }
            } while (smp_count != 0);
        eol:
            return;
        }

        public void DecodeAudio() {
            if (AudioSpecificOptions.ID.SampleSize == 8)
                DecodeAudio8();
            else if (AudioSpecificOptions.ID.SampleSize == 16)
                DecodeAudio16();
            else
                throw new NotImplementedException();
        }

        public override void Go() {
            Lint();
            Prepare();

            Owner.ReportProgress(1, new ProgressState(1, 2, "Initializing", true));
            
            bq = new BitQueue();
            if (EngineMode == LSB.Mode.Audio)
                DecodeAudio();
            else if (ImageSpecificOptions.RowReadMode)
                DecodeImage();
            else
                throw new NotImplementedException();

            Finish();
        }
    }
}
