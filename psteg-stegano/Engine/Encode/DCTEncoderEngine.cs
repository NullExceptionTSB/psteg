using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using psteg.Stegano.File;
using psteg.Stegano.File.Format;
using psteg.Stegano.Engine.Util;

namespace psteg.Stegano.Engine.Encode {
    public sealed class DCTDecoderEngine : EncoderEngine {
        public enum Algorithm {
            Jsteg
        }

        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();
        private JpegDecode je;
        private int[,][][] scan;

        public Algorithm DistributionAlgo { get; set; }
        public string Seed { get; set; }
        public bool ReverseBitOrder { get; set; }

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

        public bool JstegEncode() {
            for (int x = 0; x < scan.GetLength(0); x++) { 
                for (int y = 0; y < scan.GetLength(1);y++)
                    for (int i = 0; i < scan[x,y].Length; i++) 
                        for (int j = 0; j < 64; j++) {
                            scan[x, y][i][j] &= ~1;
                            scan[x, y][i][j] |= bq.PopSingle()?1:0;
                        }
                PopulateBq();
                if (bq.Length == 0) 
                    return true;
            }
            return false;
        }

        public void JpegCrosscode() {
            JpegEncode jp = new JpegEncode((FileStream)OutputStream);
            jp.RescaleQuantizationTables(75);
        }

        public override void Go() {
            je = new JpegDecode(CoverStream);
            scan = je.DecodeScan(0);

            bool succ = false;
            switch (DistributionAlgo) {
                case Algorithm.Jsteg:
                    succ = JstegEncode();
                    break;
            }

            if (!succ) 
                 throw new Exception("Data too big or other encoder failure");

            JpegCrosscode();
        }
    }
}
