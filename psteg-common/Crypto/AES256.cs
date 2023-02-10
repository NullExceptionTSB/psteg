using System;
using System.Security.Cryptography;
using System.IO;

namespace psteg.Crypto {
    public class AES256 : Encryption {
        private Aes aes;
        private ICryptoTransform d, e;

        public override Stream Encrypt(Stream data) => new CryptoStream(data, e, CryptoStreamMode.Read);
        public override Stream Decrypt(Stream data) => new CryptoStream(data, d, CryptoStreamMode.Read);
        public override Tuple<byte[], byte[]> GetKeyIVPair(string s) => KeyDerivationAlgorithm.GetKeyIVPair(s, 32, 16);

        public override int BlockSize => 16;

        public override PaddingMode PaddingMode { get => aes.Padding; set { aes.Padding=value; KeysChanged(); } }

        public override void KeysChanged() {
            try {
                aes.Key = Key;
                aes.IV = IV;

                d?.Dispose();
                e?.Dispose();

            
                d = aes.CreateDecryptor();
                e = aes.CreateEncryptor();
            }
            catch { }
        }

        public AES256() {
            aes = Aes.Create();
        }

        public override void Dispose() {
            aes.Dispose();

            d?.Dispose();
            e?.Dispose();
            
            base.Dispose();
        }
    }
}
