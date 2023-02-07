using System.Security.Cryptography;

namespace psteg_chaffblob.MAC.Net {
    public abstract class DotnetMACAlgorithm : MACAlgorithm {
        protected HMAC mac;
        public override int MACSize { get => mac.HashSize / 8; }
        public override byte[] Key { get => mac.Key; set => mac.Key = value; }
        public override byte[] ComputeHash(byte[] data) => mac.ComputeHash(data);
        public override void Dispose() => mac.Dispose();
    }

    public sealed class MD5HMAC : DotnetMACAlgorithm { public MD5HMAC() { mac = new HMACMD5(); } }
    public sealed class SHA1HMAC : DotnetMACAlgorithm { public SHA1HMAC() { mac = new HMACSHA1(); } }
    public sealed class SHA256HMAC : DotnetMACAlgorithm { public SHA256HMAC() { mac = new HMACSHA256(); } }
    public sealed class SHA512HMAC : DotnetMACAlgorithm { public SHA512HMAC() { mac = new HMACSHA512(); } }
}
