using System;
using System.Security.Cryptography;
using System.Text;

namespace psteg.Crypto.KeyDerivation {
    public sealed class SHA512KD : KeyDerivationAlgo {
        private SHA512 h;

        public override Tuple<byte[], byte[]> GetKeyIVPair(string s, int keySize, int ivSize) {
            byte[] hash = h.ComputeHash(Encoding.UTF8.GetBytes(s));
            byte[] key = new byte[keySize], iv = new byte[ivSize];

            int i = 0;
            for (; i < 32; i++)
                key[i] = hash[i];
            for (int j = 0; j < 16; j++, i++)
                iv[j] = hash[i];

            return new Tuple<byte[], byte[]>(key, iv);
        }

        public SHA512KD() =>
            h = SHA512.Create();
        public override void Dispose() =>
            h.Dispose();
        
    }
}
