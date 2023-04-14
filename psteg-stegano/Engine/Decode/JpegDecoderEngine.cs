using System;

using psteg.Huffman;
using psteg.Stegano.File.Format;
using psteg.Stegano.Engine.Util;


namespace psteg.Stegano.Engine.Decode {
    public sealed class JpegDecoderEngine<T> : DecoderEngine where T : JpegCoderOptions {
        private BitQueue bq = new BitQueue();
        private JpegCodec Codec;
        private JpegCoderOptions.Algorithm DistributionAlgo;

        private JstegCoderOptions JstegOpts;

        private void DecodeJsteg() {
            while (OutputStream.Position < DataSize) {
                Code? c = Codec.GetNextCode();
                if (c == null)
                    throw new Exception("Coder error: " + Codec.ReportDecoderPos());

                Code code = (Code)c;
                int code_len = code.JpegIsAC ? code.Length&0xF : code.Length;
                int data = Math.Min(JstegOpts.MaxSubstituteDepth, code_len);

                for (int i = 0; i <data; i++)
                    bq.Push((code.Value&~(1<<i))!=0);
            }
        }

        public override void Go() {
            Codec = new JpegCodec(CoverStream, OutputStream);
            Codec.SetScanRead(0);

            Prepare();
            Exception e = null;
            try {
                switch (DistributionAlgo) {
                    case JpegCoderOptions.Algorithm.Jsteg:
                        DecodeJsteg();
                        break;
                }
            }
            catch (Exception ex) { e=ex; }
            Finish();
            if (e!=null)
                throw e;
        }

        public JpegDecoderEngine(JpegCoderOptions opts = null) : base() {
            if (typeof(T) == typeof(JstegCoderOptions)) {
                DistributionAlgo = JpegCoderOptions.Algorithm.Jsteg;
                JstegOpts = (JstegCoderOptions)opts;
            }
        }
    }

}
