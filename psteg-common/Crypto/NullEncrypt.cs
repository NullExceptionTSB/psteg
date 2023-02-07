using System.IO;

namespace psteg.Crypto {
    public sealed class NullEncrypt : Encryption {
        public override Stream Decrypt(Stream data) => data;
        public override Stream Encrypt(Stream data) => data;
    }
}
