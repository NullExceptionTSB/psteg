using System;
using System.Drawing;
using System.Drawing.Imaging;

using psteg.Stegano.File;
using psteg.Stegano.File.Format;
using static psteg.Stegano.Engine.Encode.LSBEncoderEngine;

namespace psteg.Stegano.Engine.Encode {
    public sealed class DCTDecoderEngine : EncoderEngine {
        public enum Algorithm {
            Jsteg
        }

        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();
        private JpegDecode je;

        public Algorithm DistributionAlgo { get; set; }
        public string Seed { get; set; }
        public bool ReverseBitOrder { get; set; }

        private bool PopulateBq() {
            int d = DataStream.ReadByte();
            if (d == -1)
                return false;

            bq.Push((byte)d);

            while (bq.Length < BQ_BLOCKSIZE) {
                d = DataStream.ReadByte();
                if (d == -1)
                    break;
                bq.Push(!ReverseBitOrder ? ReverseBits((byte)d) : (byte)d);
            }
            return true;
        }

        public void JstegEncode() {
            int[,][][] scan = je.DecodeScan(0);

            for (int x = 0; x < scan.GetLength(0); x++) { 
                for (int y = 0; y < scan.GetLength(1);y++)
                    for (int i = 0; i < scan[x,y].Length; i++) 
                        for (int j = 0; j < 64; j++) {

                        }
            }


        }

        public override void Go() {
            je = new JpegDecode(CoverStream);

            switch (DistributionAlgo) {
                case Algorithm.Jsteg:
                    JstegEncode();
                    break;
            }



            throw new NotImplementedException();
        }
    }
}
