using System;
using System.IO;

//NOTE: Move implementation from UI to ReadEngine
namespace psteg.Chaffblob.Engine {
    public sealed class ReadEngine : Engine {

        public FileStream BlobFile { get; set; }
        public FileStream Output { get; set; }

        public override void Go() {

        }

        public ReadEngine(Type CryptoType, Type MACType) : base(CryptoType, MACType) {}
    }
}
