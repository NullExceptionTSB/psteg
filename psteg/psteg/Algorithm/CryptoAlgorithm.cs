using System.Windows.Forms;
using System.IO;

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

        
        public HashAlgo HashingAlgorithm { get; set; }
        public string CryptoPasswd { get; set; }
        public Stream InputData { get; set; }

        public abstract byte[] Encrypt();
        public abstract byte[] Decrypt();
        public abstract byte[] Encrypt(byte[] Key, byte[] IV);
        public abstract byte[] Decrypt(byte[] Key, byte[] IV);

        public static CryptoAlgorithm NewByEnum(CryptoMethod Method) {
            switch (Method) {
                case CryptoMethod.Rijndael:
                    return new CryptoRijndael();
                default: return null;
            }
        }
    }

 
}
