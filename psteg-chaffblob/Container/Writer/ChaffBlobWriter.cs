using System;
using System.IO;

using psteg.Crypto;
using psteg_chaffblob.MAC;

namespace psteg_chaffblob.Container.Writer {
    public sealed class ChaffBlobWriter : ChaffContainerWriter {
        private ChaffBlobHeader blobHeader;
        private bool writeInitialized = false;

        public override void InitializeWrite() {
            FileList.Clear();
            if (writeInitialized) return;

            blobHeader = new ChaffBlobHeader {
                MacAlgorithm = MacMap[MACAlgorithm.GetType()],
                CryptoAlgorithm = CryptMap[CryptoAlgorithm.GetType()],
                Magic = KnownMagicNumbers.Chaffblock, //0xCAFFB70B
                BlockSize = BlockSize
            };

            byte[] bhd = blobHeader.GetData();
            Destination.Write(bhd, 0, bhd.Length);
        }

        public override void FinalizeWrite() {
            long pos = Destination.Position;
            blobHeader.BlockTotal = BlockCount;
            Destination.Seek(4, SeekOrigin.Begin);
            Destination.Write(BitConverter.GetBytes(blobHeader.BlockTotal), 0, 4);
        }

        public ChaffBlobWriter(Encryption encrypt, MACAlgorithm macalgo, Stream s) : base(encrypt, macalgo, s) { }
    }
}
