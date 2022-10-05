using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

using psteg.Algorithm;
using psteg.SettingsForms.Crypto;

namespace psteg.Algorithm.Crypto {
    public class CryptoRijndael : CryptoAlgorithm {
        private readonly Aes aes;
        private bool byKey = false;
        //private readonly Form settingsFormInstance = null;

        public override CryptoMethod MethodEnum { get { return CryptoMethod.Rijndael; } }
        public override bool DependsBouncyCastle { get { return false; } }
        public override Form SettingsForm { get { return new RijndaelSettings(this); } }

        public override byte[] Decrypt() {
            if (string.IsNullOrEmpty(CryptoPasswd) && !byKey)
                return null;

            throw new NotImplementedException();
        }

        public override byte[] Encrypt() {
            throw new NotImplementedException();
        }

        public override byte[] Decrypt(byte[] Key, byte[] IV) {
            aes.Key = Key;
            aes.IV = IV;
            byKey = true;
            byte[] rawdata = Decrypt();

            byKey = false;
            return rawdata;
        }
        public override byte[] Encrypt(byte[] Key, byte[] IV) {
            aes.Key = Key;
            aes.IV = IV;
            byKey = true;
            byte[] rawdata = Encrypt();

            byKey = false;
            return rawdata;
        }

        public CryptoRijndael() {
            aes = Aes.Create();
            //            settingsFormInstance = new Rijndael256Settings(this);
        }

        ~CryptoRijndael() {
            aes?.Dispose();
            //settingsFormInstance?.Close();
            //settingsFormInstance?.Dispose();
        }
    }
}
