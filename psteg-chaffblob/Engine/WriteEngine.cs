using System;
using System.Collections.Generic;
using System.IO;

using psteg_chaffblob.RNGs;
using psteg_chaffblob.Container.Writer;
using System.Text;

namespace psteg_chaffblob.Engine {
    public sealed class InputFile {
        public string IDKey { get; set; }
        public string CryptKey { get; set; }
        public Stream Stream { get; set; }

        public InputFile(Stream s) => Stream = s;
        public InputFile(Stream s, string ID, string CKey) : this(s) {
            IDKey = ID;
            CryptKey = CKey;
        }
    }

    public sealed class WriteEngine : Engine{
        public enum ContainerType {
            ChaffBlob,
            Tar
        }

        private readonly RNG rng;

        public ContainerType Container { get; set; }

        public int ChaffCount { get; set; }
        public List<InputFile> InputFiles { get; private set; }
        public FileStream Output { get; set; }

        public override void Go() {
            ChaffContainerWriter cw = null;
            switch (Container) {
                case ContainerType.ChaffBlob:
                    cw = new ChaffBlobWriter(crypt, mac, Output) { ReportsTo = Owner };
                    break;
                case ContainerType.Tar:
                    cw = new TarWriter(crypt, mac, Output) { ReportsTo = Owner };
                    break;
            }
            
            cw.PRNG = rng;

            MemoryStream ChaffStream = new MemoryStream(rng.GetRandomBytes((cw.BlockSize-1)*ChaffCount));

            foreach (InputFile @if in InputFiles) 
                cw.AddFile(@if.Stream, @if.CryptKey, @if.IDKey);
            //add chaffs as a virtual file
            cw.AddFile(ChaffStream, Encoding.UTF8.GetString(rng.GetRandomBytes((int)(rng.GetRandomU32()%512))), 
                Encoding.UTF8.GetString(rng.GetRandomBytes((int)(rng.GetRandomU32()%512))));

            cw.WriteDataBlocks();

            cw.Dispose();
        }

        public WriteEngine(Type RNGType, Type CryptoType, Type MACType) : base(CryptoType, MACType) {
            InputFiles = new List<InputFile>();
            if (!(RNGType.BaseType == typeof(RNG)))
                throw new Exception("RNG type not an a RNG");
            rng = (RNG)RNGType.GetConstructor(Type.EmptyTypes).Invoke(null);
        }
    }
}
