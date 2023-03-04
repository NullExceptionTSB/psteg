using System;
using System.Drawing;
using System.Drawing.Imaging;

using psteg.Stegano.File;
using psteg.Stegano.Engine.Util;

namespace psteg.Stegano.Engine.Encode {
    public sealed class LSBEncoderEngine : EncoderEngine{
        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();

        public LSB.Mode EngineMode { get; set; }

        public bool ReverseBitOrder { get; set; }
        public bool AdaptiveDistribution { get; set; }
        public int? IV { get; set; }

        public LSB.SpecificOptions.Img ImageSpecificOptions { get; set; }
        public LSB.SpecificOptions.Audio AudioSpecificOptions { get; set; }
        

        private bool PopulateBq() {
            int d = DataStream.ReadByte();
            if (d == -1)
                return false;

            bq.Push(LSB.ReverseBits((byte)d, !ReverseBitOrder));

            while (bq.Length < BQ_BLOCKSIZE) {
                d = DataStream.ReadByte();
                if (d == -1)
                    break;
                bq.Push(LSB.ReverseBits((byte)d, !ReverseBitOrder));
            }
            return true;
        }

        private void EncodeImage() {
            Bitmap bmp = new Bitmap(CoverStream);
            BitmapData bmpd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ImgSerialize state = new ImgSerialize(ImageSpecificOptions.RowReadMode, IV != null ? (int)IV : 0, ImageSpecificOptions.Channels, bmpd);

            byte cover_mask = (byte)~(((1 << ImageSpecificOptions.BitWidth) - 1));
            //used for bq block filling
            bool data_in_stream = DataStream.Position < DataStream.Length;
            bool data_in_bq = bq.Length > 128; //128 has been chosen as a treshold arbitrarily, but it's big enough
            //used only in progress reporting
            int block = 0;
            int total_blks = (int)(DataStream.Length/BQ_BLOCKSIZE);

            while (data_in_bq || data_in_stream) {
                if (!data_in_bq) {
                    Owner.ReportProgress(1, new ProgressState(++block, total_blks, "Encoding"));
                    if (!PopulateBq())
                        break; //out of data, finish
                }

                byte d = state.Get();
                d = LSB.Mix(d, (byte)LSB.WidthPop(ImageSpecificOptions.BitWidth, bq), cover_mask);
                state.Set(d);

                state.Next();

                data_in_stream = DataStream.Position < DataStream.Length;
                data_in_bq = bq.Length > 0;
            }

            Owner.ReportProgress(1, new ProgressState(1, 1, "Outputting", true));
            bmp.UnlockBits(bmpd);
            bmp.Save(OutputStream, ImageSpecificOptions.OutputFormat);
            bmp.Dispose();
        }
        //todo: refactor much of the audio encoder

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
                    smp_buffer[smp_buffer_pos] = LSB.Mix(smp_buffer[smp_buffer_pos++], (byte)LSB.WidthPop(AudioSpecificOptions.BitWidth, bq), cover_mask);
                else {
                    if (AudioSpecificOptions.Channels['L'])
                        smp_buffer[smp_buffer_pos] = LSB.Mix(smp_buffer[smp_buffer_pos], (byte)LSB.WidthPop(AudioSpecificOptions.BitWidth, bq), cover_mask);
                    if (AudioSpecificOptions.Channels['R'])
                        smp_buffer[smp_buffer_pos+1] = LSB.Mix(smp_buffer[smp_buffer_pos+1], (byte)LSB.WidthPop(AudioSpecificOptions.BitWidth, bq), cover_mask);
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
                    smp_buffer[smp_buffer_pos] = LSB.Mix(smp_buffer[smp_buffer_pos++], (ushort)LSB.WidthPop(AudioSpecificOptions.BitWidth, bq), cover_mask);
                else {
                    if (AudioSpecificOptions.Channels['L'])
                        smp_buffer[smp_buffer_pos] = LSB.Mix(smp_buffer[smp_buffer_pos], (ushort)LSB.WidthPop(AudioSpecificOptions.BitWidth, bq), cover_mask);
                    if (AudioSpecificOptions.Channels['R'])
                        smp_buffer[smp_buffer_pos+1] = LSB.Mix(smp_buffer[smp_buffer_pos+1], (ushort)LSB.WidthPop(AudioSpecificOptions.BitWidth, bq), cover_mask);
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

            if (EngineMode == LSB.Mode.Audio)
                EncodeAudio();
            else if (EngineMode == LSB.Mode.Image)
                EncodeImage();
            else
                throw new NotImplementedException();

            Finish();
        }

    }
}
