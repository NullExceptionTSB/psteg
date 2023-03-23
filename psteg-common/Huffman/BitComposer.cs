using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Huffman {
    public sealed class BitComposer {
        private const int BUF_SIZE = 128;

        public Stream Source { get; private set; }

        private byte[] buff = new byte[BUF_SIZE];

        public int BytePosition { get; private set; } = BUF_SIZE;
        public int BitPosition { get; private set; } = 0;

        public void Flush() {
            if (BytePosition == 0)
                return;

            for (int i = 0; i < BytePosition; i++)
                Source.WriteByte(buff[i]);

            buff[0] = buff[BytePosition];
        }

        public void FullFlush() {
            Flush();
            //todo: bit magic to flush bit buffer
        }

        public void Write(Code code) {
            throw new NotImplementedException();
        }
    }
}
