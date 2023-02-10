using psteg.Crypto;
using psteg_chaffblob.MAC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg_chaffblob.Container.Reader {
    public sealed class ChaffBlobReader : ChaffContainerReader {
        private ChaffBlobHeader cbh;

        public override void InitializeRead() {
            InputFile.Seek(0, SeekOrigin.Begin);

            byte[] header_buffer = new byte[12];
            InputFile.Read(header_buffer, 0, 12);
            cbh = new ChaffBlobHeader(header_buffer);
            BlockCount = cbh.BlockTotal;
        }
        public override void FinalizeRead() { }

        public override byte[] FetchNextBlock() {
            if (InputFile.Length == InputFile.Position)
                return null;
            byte[] block = new byte[cbh.BlockSize+MACAlgorithm.MACSize];
            InputFile.Read(block, 0, block.Length);
            return block;
        }

        new public static ChaffBlobReader FromFile(FileStream file, FileStream output) {
            file.Seek(0, SeekOrigin.Begin);

            byte[] header_buffer = new byte[12];
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

            return new ChaffBlobReader((Encryption)Activator.CreateInstance(crypt), (MACAlgorithm)Activator.CreateInstance(mac), file, output);
        }

        private ChaffBlobReader(Encryption encrypt, MACAlgorithm macalgo, Stream s, Stream s2) : base(encrypt, macalgo, s, s2) { }
    }
}
