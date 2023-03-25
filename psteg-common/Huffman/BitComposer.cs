using System;
using System.IO;

namespace psteg.Huffman {
    public sealed class BitComposer : IDisposable {
        private const int BUF_SIZE = 128;

        private readonly bool disp_s = false;
        private readonly byte[] buff = new byte[BUF_SIZE];

        public Stream Destination { get; private set; }

        public int BytePosition { get; private set; } = 0;
        public int BitPosition { get; private set; } = 0;
        public int TotalBytePosition { get; private set; } = 0;
        #region Flush
        public void Flush() {
            if (BytePosition == 0)
                return;

            for (int i = 0; i < BytePosition; i++)
                Destination.WriteByte(buff[i]);

            buff[0] = buff[BytePosition];
        }

        public void FullFlush() {
            Flush();
            byte last_byte = 0;
            for (int i = 0; i < 8; i++) 
                last_byte |= (byte)(((buff[0]&(1<<i)-1)!=0 ? 1 : 0)<<(7-i));
            Destination.WriteByte(last_byte);
            BitPosition = 0;
            buff[0] = 0;
        }
        #endregion
        #region Internal
        private void WriteNoflush(bool bit) {
            buff[BytePosition] |= (byte)((bit ? 1 : 0) << (7-BitPosition++));

            BytePosition += BitPosition / 8;
            TotalBytePosition += BitPosition / 8;
            BitPosition %= 8;
        }
        #endregion
        #region Write
        public void Write(Code code) {
            Flush();
            for (int i = 0; i < code.Length; i++) 
                WriteNoflush((code.Value & ((1 << (i-code.Length))-1)) != 0);
        }

        public void Write(bool bit) {
            Flush();
            WriteNoflush(bit);
        }
        #endregion
        public void Dispose() {
            FullFlush();
            if (disp_s) {
                Destination.Close();
                Destination.Dispose();
            }
        }

        public BitComposer(Stream s, bool dispose_stream) { 
            Destination = s;
            disp_s = dispose_stream;
        }

    }
}
