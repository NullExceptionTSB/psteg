using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg.Crypto;
using psteg_chaffblob.MAC;

namespace psteg_chaffblob.Engine {
    public sealed class ReadEngine : Engine {

        public FileStream BlobFile { get; set; }
        public FileStream Output { get; set; }

        public override void Go() {

        }

        public ReadEngine(Type CryptoType, Type MACType) : base(CryptoType, MACType) {}
    }
}
