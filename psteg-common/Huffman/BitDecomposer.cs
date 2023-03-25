using System;
using System.IO;

namespace psteg.Huffman {
    public sealed class BitDecomposer : IDisposable {
        private const int BUF_SIZE = 128;

        public Stream Source { get; private set; }

        private byte[] buff = new byte[BUF_SIZE];

        public int BytePosition { get; private set; } = BUF_SIZE;
        public int BitPosition { get; private set; } = 0;
        public int TotalBytePosition { get; private set; } = 0;

        private void FillBuffer() {
            //push back data
            for (int i = BytePosition; i < buff.Length; i++)
                buff[i-BytePosition] = buff[i];
            //get new data
            Source.Read(buff, BUF_SIZE-BytePosition, BytePosition);
            BytePosition = 0;
        }
        public uint Peek(int ammount) {
            FillBuffer();
            if (ammount > 32)
                throw new Exception("Block too large");

            uint d = 0;
            int byp = BytePosition, bip = BitPosition;


            for (int i = ammount-1; i >= 0; i--) {
                bool bit = (buff[BytePosition] & (uint)(1 << (7-BitPosition++))) != 0;
                d |= (uint)((bit ? 1 : 0) << i);

                BytePosition += BitPosition / 8;
                BitPosition %= 8;
            }

            BitPosition = bip;
            BytePosition = byp;
            
            return d;
        }

        public uint Read(int ammount) {
            FillBuffer();
            if (ammount > 32)
                throw new Exception("Block too large");

            uint d = 0;

            for (int i = ammount-1; i >= 0; i--) {
                bool bit = (buff[BytePosition] & (uint)(1 << (7-BitPosition++))) != 0;
                d |= (uint)((bit ? 1 : 0) << i);

                BytePosition += BitPosition / 8;
                TotalBytePosition += BitPosition / 8;
                BitPosition %= 8;
            }

            
            return d;
        }

        public void Skip(int ammount) {
            FillBuffer();
            if (ammount > 32)
                throw new Exception("Block too large");

            BitPosition += ammount;
            BytePosition += BitPosition / 8;
            TotalBytePosition += BitPosition / 8;
            BitPosition %= 8;
        }

        public void Dispose() => Source.Dispose();

        public BitDecomposer(Stream src) {
            Source = src;
            FillBuffer();
        }
    }
}
