using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

using psteg.UI.SettingsForms.Crypto;


namespace psteg.Algorithm.Crypto {
    public class CryptoRijndael : CryptoAlgorithm {
        private const int IVSize = 16;

        private readonly Aes aes;
        private bool byKey = false;

        public override CryptoMethod MethodEnum { get { return CryptoMethod.Rijndael; } }
        public override bool DependsBouncyCastle { get { return false; } }
        public override Form SettingsForm { get { return new RijndaelSettings(this); } }

        public int KeySize { get { return aes.KeySize; } set { aes.KeySize = value; } }
        public override int BlockSize { get { return aes.BlockSize / 8; } }
        public PaddingMode PaddingMode { get { return aes.Padding; } set { aes.Padding = value; } }
        public CipherMode CipherMode { get { return aes.Mode; } set { aes.Mode = value; } }

        public KeySizes[] ValidKeySizes { get { return aes.LegalKeySizes; } }
        public KeySizes[] ValidBlockSizes { get { return aes.LegalBlockSizes; } }
        public CipherMode[] ValidCipherModes { get { return (CipherMode[])Enum.GetValues(typeof(CipherMode)); } }
        public PaddingMode[] ValidPaddingModes { get { return (PaddingMode[])Enum.GetValues(typeof(PaddingMode)); } }

        public void SetBlockSize(int bs) {
            aes.BlockSize = bs;
        }

        public override Stream Decrypt() {
            if (string.IsNullOrEmpty(CryptoPasswd) && !byKey)
                return null;

            if (!byKey) {
                Tuple<byte[], byte[]> keyPair = GetKey(CryptoPasswd, aes.KeySize / 8, IVSize);
                aes.Key = keyPair.Item1;
                aes.IV = keyPair.Item2;
            }

            return new CryptoStream(InputData, aes.CreateDecryptor(), CryptoStreamMode.Read);
        }

        public override Stream Encrypt() {
            if (string.IsNullOrEmpty(CryptoPasswd) && !byKey)
                return null;

            if (!byKey) {
                Tuple<byte[], byte[]> keyPair = GetKey(CryptoPasswd, aes.KeySize / 8, IVSize);
                aes.Key = keyPair.Item1;
                aes.IV = keyPair.Item2;
            }

            return new CryptoStream(InputData, aes.CreateEncryptor(), CryptoStreamMode.Read);
        }

        public override Stream Decrypt(byte[] Key, byte[] IV) {
            aes.Key = Key;
            aes.IV = IV;
            byKey = true;
            Stream rawdata = Decrypt();

            byKey = false;
            return rawdata;
        }
        public override Stream Encrypt(byte[] Key, byte[] IV) {
            aes.Key = Key;
            aes.IV = IV;
            byKey = true;
            Stream rawdata = Encrypt();

            byKey = false;
            return rawdata;
        }

        public CryptoRijndael() {
            aes = Aes.Create();
            
        }

        ~CryptoRijndael() {
            aes?.Dispose();
        }
    }
}
