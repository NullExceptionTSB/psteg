using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Stegano.File {
    public abstract class AudioEncode : IDisposable {
        public abstract void PutSamples(byte[] Buffer);
        public abstract void PutSamples(ushort[] Buffer);
        public abstract void Dispose();

        public FileStream Stream { get; protected set; }
    }
}
