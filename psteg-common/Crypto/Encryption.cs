using System;
using System.Collections.Generic;
using System.IO;

using psteg.Crypto.KeyDerivation;
namespace psteg.Crypto {
    public abstract class Encryption : IDisposable {
        private byte[] _key;
        private byte[] _iV;

        private static KeyDerivationAlgo s_keyDerivationAlgorithm = new SHA512KD();

        public virtual int BlockSize { get => 1; }

        public byte[] Key { get => _key; set { _key=value; KeysChanged(); } }
        public byte[] IV { get => _iV; set { _iV=value; KeysChanged(); } }

        public abstract Stream Encrypt(Stream data);
        public abstract Stream Decrypt(Stream data);

        public static KeyDerivationAlgo KeyDerivationAlgorithm {
            get => s_keyDerivationAlgorithm;
            set {
                s_keyDerivationAlgorithm?.Dispose();
                s_keyDerivationAlgorithm=value;
            }
        }
        public virtual Tuple<byte[], byte[]> GetKeyIVPair(string s) => new Tuple<byte[], byte[]>(new byte[0], new byte[0]);
        public virtual void KeysChanged() { }

        public virtual void Dispose() {
            if (Key != null)
                for (int i = 0; i < Key.Length; i++) //against pulling key from memory
                    Key[i] = 0;
        }

        public static Dictionary<string, Type> AlgoList = new Dictionary<string, Type>() {
            { "None", typeof(NullEncrypt) },
            { "AES256", typeof(AES256) }
        };

        public static Dictionary<string, Type> KDFList = new Dictionary<string, Type>() {
            { "SHA512", typeof(SHA512KD) }
        };

    }
}
