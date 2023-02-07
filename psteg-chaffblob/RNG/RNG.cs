using System;
using System.Security.Cryptography;

namespace psteg_chaffblob.RNGs {
    public abstract class RNG {
        protected ulong State64 { get; set; }

        private static RNGCryptoServiceProvider CryptoRNG = new RNGCryptoServiceProvider();

        public abstract byte[] GetRandomBytes(int n);
        public abstract int GetRandomS32();
        public abstract long GetRandomS64();
        public abstract uint GetRandomU32();
        public abstract ulong GetRandomU64();

        public void Reseed() {
            byte[] b = new byte[8];
            CryptoRNG.GetNonZeroBytes(b);
            State64 ^= BitConverter.ToUInt64(b, 0);
            State64 ^= (ulong)DateTime.Now.Ticks;
        }
    }
}
