using System;
using System.ComponentModel;

using psteg.Crypto;
using psteg_chaffblob.MAC;

namespace psteg_chaffblob.Engine {
    public abstract class Engine : IDisposable {
        protected Encryption crypt;
        protected MACAlgorithm mac;

        public BackgroundWorker Owner { get; set; }

        public void SetCryptoKey(string key) {
            Tuple<byte[], byte[]> kip = crypt.GetKeyIVPair(key);
            crypt.Key = kip.Item1;
            crypt.IV = kip.Item2;
        }

        public void SetIDKey(string key) =>
            mac.SetKey(key);

        public abstract void Go();

        protected Engine(Type CryptoType, Type MACType) {
            if (!(MACType.BaseType == typeof(MACAlgorithm)) && !(MACType.BaseType == typeof(MAC.Net.DotnetMACAlgorithm)))
                throw new Exception("MAC type not a MAC algorithm");
            if (!(CryptoType.BaseType == typeof(Encryption)))
                throw new Exception("Crypto type not a crypto algorithm");

            crypt = (Encryption)CryptoType.GetConstructor(Type.EmptyTypes).Invoke(null);
            mac = (MACAlgorithm)MACType.GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public void Dispose() {
            mac.Dispose();
            crypt.Dispose();
        }
    }
}
