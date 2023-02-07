using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

using psteg.Crypto;

namespace psteg.Stegano.Engine.Decode {
    public abstract class DecoderEngine : IDisposable {
        public Stream CoverStream { get; set; }
        public Stream OutputStream { get; set; }
        public BackgroundWorker Owner { get; set; }

        public Encryption Encryption { get; set; }

        private Stream original_stream = null;
        private int original_data_size = 0;

        public int DataSize { get; set; }

        public virtual void Prepare() {
            original_stream = OutputStream;
            original_data_size = DataSize;

            DataSize = DataSize + (DataSize % Encryption.BlockSize > 0 ? Encryption.BlockSize - DataSize % Encryption.BlockSize : 0);
            OutputStream = new MemoryStream(DataSize);
        }

        public virtual void Finish() {
            if (OutputStream != original_stream) {
                OutputStream.Seek(0, SeekOrigin.Begin);
                Stream decr = Encryption.Decrypt(OutputStream);
                decr.CopyTo(original_stream);

                OutputStream.Close();
                OutputStream.Dispose();

                decr.Close();
                decr.Dispose();

                OutputStream = original_stream;
                DataSize = original_data_size;
            }
        }

        public abstract void Go();

        public virtual void Dispose() {
            CoverStream.Close();
            OutputStream.Close();

            CoverStream.Dispose();
            OutputStream.Dispose();

            Encryption.Dispose();
        }
    }
}
