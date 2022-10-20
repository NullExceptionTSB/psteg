using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

using psteg.Algorithm.Crypto;

namespace psteg.Algorithm {
    public enum CryptoMethod {
        None, Rijndael, Serpent, ChaCha20
    }
    public enum HashAlgo {
        SHA2_512, SHA2_256, SHA3_512, SHA3_256, Whirlpool
    }

    public abstract class CryptoAlgorithm {
        public abstract CryptoMethod MethodEnum { get; }
        public abstract bool DependsBouncyCastle { get; }
        public abstract Form SettingsForm { get; }

        public virtual int BlockSize { get { return 1; } }

        public readonly static HashAlgo[] HashingAlgorithms = new HashAlgo[]{ HashAlgo.SHA2_512, HashAlgo.SHA2_256 };

        public HashAlgo HashingAlgorithm { get; set; } = HashAlgo.SHA2_512;
        public string CryptoPasswd { get; set; }
        public Stream InputData { get; set; }
        protected RNGCryptoServiceProvider CryptoRng { get; private set; }

        public abstract Stream Encrypt();
        public abstract Stream Decrypt();
        public abstract Stream Encrypt(byte[] Key, byte[] IV);
        public abstract Stream Decrypt(byte[] Key, byte[] IV);

        public static byte[] HashString(HashAlgorithm hashAlgo, string str) {
            return hashAlgo.ComputeHash(Encoding.Unicode.GetBytes(str));
        }

        public virtual Tuple<byte[], byte[]> GetKey(string password, int keySize, int ivSize) {
            if (string.IsNullOrEmpty(password) || keySize <= 0 || ivSize < 0)
                return null;
            Tuple<byte[], byte[]> keyIvCombo = new Tuple<byte[], byte[]>(new byte[keySize], ivSize > 0 ? new byte[ivSize] : null);
            using (HashAlgorithm halgo = HashAlgoByEnum(HashingAlgorithm)) {
                if (halgo.HashSize < keySize * 8)
                    return null;

                byte[] cryptoBytes = new byte[4];
                CryptoRng.GetBytes(cryptoBytes);
                int ivOffset = (halgo.HashSize < (keySize + ivSize) * 8) ? ((halgo.HashSize/8 - ivSize)-1) : keySize;

                byte[] data = HashString(halgo, password);

                Array.Copy(data, keyIvCombo.Item1, keySize);
                if (keyIvCombo.Item2 != null) 
                    Array.Copy(data, ivOffset, keyIvCombo.Item2, 0, ivSize);
            }
            return keyIvCombo;
        }

        protected static HashAlgorithm HashAlgoByEnum(HashAlgo Enum) {
            switch (Enum) {
                case HashAlgo.SHA2_256:
                    return SHA256.Create();
                case HashAlgo.SHA2_512:
                    return SHA512.Create();
                default: return null;
            }

        }

        public static CryptoAlgorithm NewByEnum(CryptoMethod Method) {
            switch (Method) {
                case CryptoMethod.Rijndael:
                    return new CryptoRijndael();
                default: return null;
            }
        }

        protected CryptoAlgorithm() {
            CryptoRng = new RNGCryptoServiceProvider();
        }
    }

 
}
