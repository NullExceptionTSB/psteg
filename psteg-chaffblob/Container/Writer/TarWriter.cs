using System;
using System.IO;
using System.Text;

using psteg.Crypto;
using psteg.Chaffblob.MAC;

namespace psteg.Chaffblob.Container.Writer {
    public sealed class TarWriter : ChaffContainerWriter {
        private ChaffBlobHeader blobHeader;
        public override void FinalizeWrite() {
            Destination.Seek(512+4, SeekOrigin.Begin);
            Destination.Write(BitConverter.GetBytes(BlockCount), 0, 4);
        }

        public override void InitializeWrite() {
            blobHeader = new ChaffBlobHeader {
                MacAlgorithm = MacMap[MACAlgorithm.GetType()],
                CryptoAlgorithm = CryptMap[CryptoAlgorithm.GetType()],
                Magic = KnownMagicNumbers.Chaffblock,
                BlockSize = BlockSize
            };

            byte[] bhd = blobHeader.GetData();

            WriteHeader("HEADER", (uint)bhd.Length);

            Destination.Write(bhd, 0, bhd.Length);
            for (int i = 0; i < 512 - bhd.Length; i++)
                Destination.WriteByte(0);
        }

        private byte[] TarifyInt(long integer, int len) {
            string str = Convert.ToString(integer, 8);
            str = str.PadLeft(len-1, '0');
            str+='\0';
            return Encoding.ASCII.GetBytes(str);
        }

        private void WriteHeader(string filename, uint filesize) {
            long header_start = Destination.Position;
            long sum_offset = 0;

            byte[] bfilename = new byte[100];
            string fshort = filename.Substring(0, Math.Min(99, filename.Length));
            Encoding.ASCII.GetBytes(fshort).CopyTo(bfilename,0);
            bfilename[99] = 0;
            Destination.Write(bfilename, 0, bfilename.Length);

            string uparams = "0000777\00000000\00000000\0";
            byte[] unimportant = new byte[uparams.Length];
            Encoding.ASCII.GetBytes(uparams).CopyTo(unimportant, 0);
            Destination.Write(unimportant, 0, unimportant.Length);

            byte[] b = TarifyInt(filesize, 12);
            Destination.Write(b, 0, b.Length);

            long unix_timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            b = TarifyInt(unix_timestamp, 12);
            Destination.Write(b, 0, b.Length);
            //skip over checksum for now
            sum_offset = Destination.Position;
            for (int i = 0; i < 8; i++)
                Destination.WriteByte(0x20);
            Destination.WriteByte(0x30); //link indicator

            for (int i = 0; i < 100; i++) //linked file
                Destination.WriteByte(0);

            string ustar = "ustar  \0";
            b = Encoding.ASCII.GetBytes(ustar);
            Destination.Write(b, 0, b.Length);

            for (int i = 0; i < 512 - (Destination.Position - header_start); i++)
                Destination.WriteByte(0);

            Destination.Seek(header_start, SeekOrigin.Begin);
            int sum = 123; //i have no clue
            for (int i = 0; i < 512; i++)
                sum += Destination.ReadByte();
            Destination.Seek(sum_offset, SeekOrigin.Begin);

            b = TarifyInt(sum, 7);
            Destination.Write(b, 0, b.Length);

            Destination.WriteByte(0x20);
            Destination.Seek(header_start+512, SeekOrigin.Begin);
        }

        protected override void AddBlock(byte[] block) {
            BlockCount++;
            WriteHeader(BlockCount.ToString(), (uint)block.Length);

            int pad = 512 - (block.Length % 512);

            Destination.Write(block, 0, block.Length);
            for (int i = 0; i < pad; i++)
                Destination.WriteByte(0);
        }

        public TarWriter(Encryption encrypt, MACAlgorithm macalgo, Stream s) : base(encrypt, macalgo, s) { }
    }
}
