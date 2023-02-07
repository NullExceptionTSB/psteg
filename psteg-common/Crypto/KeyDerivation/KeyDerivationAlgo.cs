using System;

namespace psteg.Crypto.KeyDerivation {
    public abstract class KeyDerivationAlgo : IDisposable {
        public abstract Tuple<byte[], byte[]> GetKeyIVPair(string s, int keySize, int ivSize);
        public abstract void Dispose();
    }
}
