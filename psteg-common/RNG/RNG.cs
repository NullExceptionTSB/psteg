using System;
using System.Security.Cryptography;
using System.Text;

namespace psteg.RNG {
    public abstract class PRNG {
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

        public void Reseed(string seed) {
            MD5 md5 = MD5.Create();
            byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(seed));
            md5.Dispose();

            byte[] s = new byte[8];
            for (int i = 0; i < 8; i++)
                s[i] = 0;
            for (int i = 0; i < b.Length; i++)
                s[i%8] ^= b[i];

            State64 = BitConverter.ToUInt64(b, 0);
        }
    }
}
