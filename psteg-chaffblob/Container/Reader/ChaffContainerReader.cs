using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg;
using psteg.Crypto;
using psteg_chaffblob.MAC;

namespace psteg_chaffblob.Container.Reader {
    public abstract class ChaffContainerReader : ChaffContainer{

        public virtual Stream InputFile { get; set; }
        public virtual Stream OutputFile { get; set; }

        public uint BlockCount { get; protected set; }

        public virtual void ReadFile(string IDKey, string CryptoKey) {
            InitializeRead();
            byte[] block = FetchNextBlock();
            MACAlgorithm.SetKey(IDKey);

            Tuple<byte[], byte[]> key_iv_pair = CryptoAlgorithm.GetKeyIVPair(CryptoKey);
            CryptoAlgorithm.Key = key_iv_pair.Item1;
            CryptoAlgorithm.IV = key_iv_pair.Item2;

            byte[] mac = new byte[MACAlgorithm.MACSize];
            int bc = 0;
            while (block != null) {
                bc++;
                ReportsTo.ReportProgress(1, new ProgressState(bc, (int)BlockCount, "Parsing blocks"));
                for (int i = 0; i < mac.Length; i++)
                    mac[i] = block[i];
                
                byte[] data = new byte[block.Length - mac.Length];

                for (int i = 0; i < data.Length; i++)
                    data[i] = block[i+mac.Length];

                byte[] realmac = MACAlgorithm.ComputeHash(data);

                bool mac_match = true;
                for (int i = 0; i < realmac.Length; i++) 
                    if (mac[i] != realmac[i]) {
                        mac_match = false;
                        break;
                    }

                if (!mac_match) {
                    block = FetchNextBlock();
                    continue;
                }

                MemoryStream ms = new MemoryStream(data);
                byte[] raw_block = new byte[data.Length];

                Stream cs = CryptoAlgorithm.Decrypt(ms);
                int real_bs = cs.Read(raw_block, 0, raw_block.Length);

                uint padding_ammt = BitConverter.ToUInt32(raw_block, 0);

                byte[] block_data = new byte[real_bs - 4 - padding_ammt];

                for (int i = 0; i < block_data.Length; i++)
                    block_data[i] = raw_block[i+4];

                OutputFile.Write(block_data, 0, block_data.Length);

                block = FetchNextBlock();
            }
        }

        public static ChaffContainerReader FromFile(FileStream file, FileStream output) {
            long pos = file.Position;
            file.Seek(0, SeekOrigin.Begin);

            byte[] magic_buff = new byte[4];
            file.Read(magic_buff, 0, 4);

            uint magic = BitConverter.ToUInt32(magic_buff, 0);

            ChaffContainerReader cr = null;

            switch (magic) {
                case KnownMagicNumbers.Chaffblock:
                    cr = ChaffBlobReader.FromFile(file, output);
                    break;
                default:
                    throw new Exception("File format not recognized");
            }

            file.Seek(pos, SeekOrigin.Begin);
            return cr;
        }

        public abstract byte[] FetchNextBlock();
        public abstract void InitializeRead();
        public abstract void FinalizeRead();
        public override void Dispose() => FinalizeRead();

        protected ChaffContainerReader(Encryption encrypt, MACAlgorithm macalgo, Stream input, Stream output) : base(encrypt, macalgo) {
            OutputFile = output;
            InputFile = input;
        }
    }
}
