using System;
using System.Drawing;
using System.Drawing.Imaging;

using psteg.Stegano.File;

namespace psteg.Stegano.Engine.Decode {
    public sealed class DCTDecoderEngine : DecoderEngine {
        public enum Algorithm {
            Jsteg
        }

        private const int BQ_BLOCKSIZE = 1024;
        private BitQueue bq = new BitQueue();
        public Algorithm DistributionAlgo { get; set; }

        public override void Go() {
            throw new NotImplementedException();
        }
    }
}
