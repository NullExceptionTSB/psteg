using System;
using System.IO;

using psteg.RNG;

namespace psteg.Chaffblob.Container {
    public sealed class BlobFile {
        public Stream Stream { get; set; }
        public PRNG PRNG { get; set; }
        public bool Finished { get => Stream.Length == Stream.Position; }

        public string IDKey { get; set; }
        public string CryptoKey { get; set; }

        public byte[] ExtractBlock(int bs) {
            byte[] block = new byte[bs];
            uint pad_ammt = 0u;
            uint block_payload_ammt = (uint)bs - 4;
            if (Stream.Length - Stream.Position < bs-4) {
                pad_ammt = (uint)bs-4 - (uint)(Stream.Length - Stream.Position);
            }
            BitConverter.GetBytes(pad_ammt).CopyTo(block, 0);
            Stream.Read(block, 4, (int)(block_payload_ammt-pad_ammt));
            if (pad_ammt > 0u)
                PRNG.GetRandomBytes((int)pad_ammt).CopyTo(block, 4+(block_payload_ammt-pad_ammt));
            return block;
        }

        public BlobFile(Stream Stream, string IDKey, string CryptoKey) {
            this.Stream = Stream;
            this.IDKey = IDKey;
            this.CryptoKey = CryptoKey;
        }
    }
}
