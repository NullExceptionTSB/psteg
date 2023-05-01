using System;

using psteg.Huffman;
using psteg.Stegano.File.Format;
using psteg.Stegano.Engine.Util;

namespace psteg.Stegano.Engine.Encode {
    public sealed class JpegEncoderEngine<T> : EncoderEngine where T : JpegCoderOptions  {
        private BitQueue bq = new BitQueue();

        public JpegCoderOptions.Algorithm DistributionAlgo { get; private set; }
        public string Seed { get; set; }
        public bool ReverseBitOrder { get; set; }

        private JstegCoderOptions JstegOpts;

        private JpegCodec Codec;

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

        //modifies dest
        private Code CodeMix(Code dest, int data, int data_bits) {
            byte len = (byte)(dest.JpegIsAC ? dest.Length&0x0F : dest.Length);
            if (len < data_bits)
                throw new Exception("Attemted to mix more bits than value size");

            for (int i = 0; i < data_bits; i++) { 
                dest.Value &= ~(1<<i);
                dest.Value |= data&(~(1<<i));
            }
            return dest;
        }

        private Code CodeGen(int data, int data_bits) => new Code(data_bits, data);

        public void JstegEncode() {
            bool pop_bq_ret;
            int zrl_ammt = 0;
            while ((pop_bq_ret = PopulateBq()) || (bq.Length > 0)) {
                if (zrl_ammt > 0) {
                    zrl_ammt--;
                    Codec.WriteNextCode(CodeGen(LSB.WidthPop(JstegOpts.MaxInsertDepth, bq), JstegOpts.MaxInsertDepth));
                    continue;
                }

                Code? nextCode = null;

                if ((nextCode = Codec.GetNextCode()) == null)
                    throw new Exception("Coder error: " + Codec.ReportDecoderPos());

                Code code = (Code)nextCode;

                if (code.JpegIsAC) {
                    byte zrl = (byte)((code.Length & 0xF0) >> 4),
                         len = (byte) (code.Length & 0x0F);

                    if (JstegOpts.InsertInZRL && zrl > 0) { 
                        zrl_ammt = zrl;
                        code.Length &= 0x0F;
                    }

                    if (len > 0) {
                        //lsb substitute
                        int sublen = Math.Min(JstegOpts.MaxSubstituteDepth, len);
                        Codec.WriteNextCode(CodeMix(code, LSB.WidthPop(sublen, bq), sublen));
                    }
                    else
                        Codec.WriteNextCode(code);

                    if (zrl_ammt > 0) continue; 
                } else {
                    if (code.Length > 0) {
                        //lsb substitute
                        int sublen = Math.Min(JstegOpts.MaxSubstituteDepth, code.Length);
                        Codec.WriteNextCode(CodeMix(code, LSB.WidthPop(sublen, bq), sublen));
                    } else
                        Codec.WriteNextCode(code);
                }
            }

            if (zrl_ammt > 0) 
                Codec.WriteNextCode(new Code(zrl_ammt<<4, 0));
        }

        public override void Go() {

            Codec = new JpegCodec(CoverStream, OutputStream);
            Codec.SetScanRead(0);
            Codec.InitScanWrite();

            Prepare();
            Exception e=null;
            try { 
                switch (DistributionAlgo) {
                    case JpegCoderOptions.Algorithm.Jsteg:
                        JstegEncode();
                        break;
                }
                Codec.CopyRestOfScan();
            } catch (Exception ex) { e=ex; }

            Codec.CloseScanWrite();
            Finish();

            if (e != null)
                throw e;
        }

        public JpegEncoderEngine(JpegCoderOptions opts = null) : base() {
            if (typeof(T) == typeof(JstegCoderOptions)) { 
                DistributionAlgo = JpegCoderOptions.Algorithm.Jsteg;
                JstegOpts = (JstegCoderOptions)opts;
            }
        }
    }
}
