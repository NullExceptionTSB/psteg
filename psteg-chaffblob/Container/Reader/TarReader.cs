using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg.Crypto;
using psteg_chaffblob.MAC;

namespace psteg_chaffblob.Container.Reader {
    public sealed class TarReader : ChaffContainerReader {
        private ChaffBlobHeader cbh;

        private static bool SeekToHeader(Stream InputFile) {
            InputFile.Seek(0, SeekOrigin.Begin);

            do {
                byte[] header = new byte[512];
                InputFile.Read(header, 0, 512);

                string filename = Encoding.ASCII.GetString(header, 0, 7);
                string ustar = Encoding.ASCII.GetString(header, 0x101, 8);

                if (ustar != "ustar  \0" && ustar != "ustar\000") {
                    InputFile.Seek(0xF8, SeekOrigin.Current);
                    continue;
                }

                int bs = GetBlockSize(header);

                if (filename == "HEADER\0") { 
                    return true;
                }
                InputFile.Seek((bs / 512 + ((bs % 512) > 0 ? 512 : 0))*512, SeekOrigin.Current);

            } while (InputFile.Position < InputFile.Length);

            return false;
        }

        private static int GetBlockSize(byte[] header) => 
            Convert.ToInt32(Encoding.ASCII.GetString(header, 0x80, 7), 8);
        

        public override byte[] FetchNextBlock() {
            byte[] sector_buffer = new byte[512];
            int read = InputFile.Read(sector_buffer, 0, 512);
            if (read == 0)
                return null;
            

            int bs = GetBlockSize(sector_buffer);
            byte[] block = new byte[bs];

            InputFile.Read(block, 0, bs);
            InputFile.Seek(512-bs%512, SeekOrigin.Current);
            return block;
        }

        public override void FinalizeRead() { }

        public override void InitializeRead() {
            byte[] header_buffer = new byte[12];

            if (!SeekToHeader(InputFile))
                throw new Exception("Encapsulated header not found");

            InputFile.Read(header_buffer, 0, 12);
            cbh = new ChaffBlobHeader(header_buffer);
            BlockCount = cbh.BlockTotal;
            InputFile.Seek(512-12, SeekOrigin.Current);
        }

        new public static TarReader FromFile(FileStream file, FileStream output) {
            file.Seek(0, SeekOrigin.Begin);

            byte[] header_buffer = new byte[12];
            if (!SeekToHeader(file))
                throw new Exception("Encapsulated header not found");

            file.Read(header_buffer, 0, 12);

            ChaffBlobHeader cbh = new ChaffBlobHeader(header_buffer);

            Type crypt = typeof(Encryption), mac = typeof(MACAlgorithm);

            foreach (KeyValuePair<Type, byte> kvp in MacMap)
                if (kvp.Value == cbh.MacAlgorithm)
                    mac = kvp.Key;

            foreach (KeyValuePair<Type, byte> kvp in CryptMap)
                if (kvp.Value == cbh.CryptoAlgorithm)
                    crypt = kvp.Key;

            if (crypt == typeof(Encryption) || mac == typeof(MACAlgorithm))
                throw new NotImplementedException("Unrecognized algorithm requested");

            return new TarReader((Encryption)Activator.CreateInstance(crypt), (MACAlgorithm)Activator.CreateInstance(mac), file, output);
        }

        private TarReader(Encryption encrypt, MACAlgorithm macalgo, Stream s, Stream s2) : base(encrypt, macalgo, s, s2) { }
    }
}
