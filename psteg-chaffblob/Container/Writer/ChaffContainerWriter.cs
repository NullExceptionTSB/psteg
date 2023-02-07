using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using psteg.Crypto;
using psteg_chaffblob.MAC;
using psteg_chaffblob.RNGs;

//note: mac is of encrypted data
namespace psteg_chaffblob.Container.Writer {
    public abstract class ChaffContainerWriter : ChaffContainer {
        private Stream destination;
        protected List<BlobFile> FileList { get; set; }

        public RNG PRNG { get; set; }
        protected uint BlockCount { get; set; }

        protected bool WriteInitialized { get; set; }
        //protected ushort LastBlockPadding { get; set; }

        public virtual Stream Destination { get => destination; set { if (WriteInitialized) throw new Exception("Write not finalized"); else destination = value; } }

        public virtual void AddFile(Stream file, string IDKey, string CryptoKey) {
            if (file.Length == 0)
                throw new Exception("Attempt to encode empty file");

            FileList.Add(new BlobFile(file, IDKey, CryptoKey) { PRNG = PRNG });
        }

        public virtual void WriteDataBlocks() {
            long total_blks = 0;
            foreach (BlobFile bf in FileList)
                total_blks += (bf.Stream.Length / (BlockSize-1)) + 1; // i have no clue why this is wrong
            long c = 0;
            while (FileList.Count > 0) {
                BlobFile currentFile = FileList[(int)(PRNG.GetRandomU32() % FileList.Count)];
                if (currentFile.Finished) { 
                    FileList.Remove(currentFile);
                    continue;
                }

                byte[] data = currentFile.ExtractBlock(BlockSize-1);

                MemoryStream ms = new MemoryStream(data);

                Tuple<byte[], byte[]> pair = CryptoAlgorithm.GetKeyIVPair(currentFile.CryptoKey);
                CryptoAlgorithm.Key = pair.Item1;
                CryptoAlgorithm.IV = pair.Item2;

                Stream cs = CryptoAlgorithm.Encrypt(ms);

                byte[] cdata = new byte[data.Length+1];
                cs.Read(cdata, 0, cdata.Length);


                ms.Close();
                ms.Dispose();
                cs.Close();
                cs.Dispose();

                byte[] block = new byte[cdata.Length+MACAlgorithm.MACSize];
                MACAlgorithm.SetKey(currentFile.IDKey);
                MACAlgorithm.ComputeHash(cdata).CopyTo(block, 0);
                cdata.CopyTo(block, MACAlgorithm.MACSize);
                AddBlock(block);
                ReportProgress(c++, total_blks, "Writing blocks");
            }
        }

        protected virtual void AddBlock(byte[] block) {
            BlockCount++;
            Destination.Write(block, 0, block.Length);
        }

        public abstract void InitializeWrite();
        public abstract void FinalizeWrite();
        public override void Dispose() => FinalizeWrite();
        protected ChaffContainerWriter(Encryption encrypt, MACAlgorithm macalgo, Stream s) : base(encrypt, macalgo){
            Destination = s;
            FileList = new List<BlobFile>();
            InitializeWrite();
        }
    }
}
