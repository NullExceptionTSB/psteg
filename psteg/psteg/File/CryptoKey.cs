using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace psteg.File {
    public sealed class CryptoKey {
        public byte[] Key { get; private set; }
        public byte[] IV { get; private set; }

        private static RNGCryptoServiceProvider CryptoRng = new RNGCryptoServiceProvider();

        public static string Byte2Hex(byte[] bytes) {
            string hex = "";
            foreach (byte b in bytes) 
                hex += b.ToString("X2");
            return hex;
        }

        public static byte[] Hex2Byte(string hex) {
            if (hex.Length % 2 == 1)
                throw new InvalidDataException("Input not byte aligned");

            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++) {
                string sub = hex.Substring(i*2, 2);

                bytes[i] = Convert.ToByte(sub, 16);
            }

            return bytes;
        }

        public string Encode() {
            return Byte2Hex(Key) + "+" + Byte2Hex(IV);
        }

        private void Construct(Stream stream) {
            byte[] raw = new byte[stream.Length];
            stream.Read(raw, 0, raw.Length);

            string keystr = Encoding.ASCII.GetString(raw);

            string[] keyivcom = keystr.Split('+');
            if (keyivcom.Length > 2)
                throw new InvalidDataException("Selected file is not a cryptographic key");

            string key = keyivcom[0], iv = keyivcom[1];
            Key = Hex2Byte(key);
            IV = Hex2Byte(iv);
        }

        public static CryptoKey RandomKey(int keySize, int ivSize) {
            byte[] key = new byte[keySize], iv = new byte[ivSize];
            CryptoRng.GetBytes(key);
            CryptoRng.GetBytes(iv);
            return new CryptoKey(key, iv);
        }

        private CryptoKey(byte[] key, byte[] iv) {
            Key = key;
            IV = iv;
        }

        public CryptoKey(Stream stream) {
            Construct(stream);
        }

        public CryptoKey(string path) {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            Construct(fs);

            fs.Close();
            fs.Dispose();
        }

        public override string ToString() {
            return Encode();
        }
    }
}