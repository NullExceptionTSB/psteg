using System;
using System.ComponentModel;
using System.IO;

using psteg.Crypto;

namespace psteg.Stegano.Engine.Encode {
    public abstract class EncoderEngine : IDisposable {
        public Stream CoverStream { get; set; }
        public Stream OutputStream { get; set; }
        public Stream DataStream { get; set; }
        public BackgroundWorker Owner { get; set; }

        public Encryption Encryption { get; set; }

        private Stream original_stream = null;

        public virtual void Prepare() {
            original_stream = DataStream;
            DataStream = Encryption.Encrypt(original_stream);
        }

        public virtual void Finish() {
            if (DataStream != original_stream) { 
                DataStream.Close();
                DataStream.Dispose();

                DataStream = original_stream;
            }
        }

        public abstract void Go();

        public virtual void Dispose() {
            CoverStream.Close();
            OutputStream.Close();
            DataStream.Close();

            CoverStream.Dispose();
            OutputStream.Dispose();
            DataStream.Dispose();

            Encryption.Dispose();
        }
        
    }
}
