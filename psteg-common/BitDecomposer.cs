using System.IO;

namespace psteg {
    public sealed class BitDecomposer {
        private readonly Stream s;

        uint b = 0;
        int len = 0;

        private void Populate(int bits) {
            int todo = ((bits - len) + 7) / 8;
            for (int i = 0; i < todo; i++)
                b = (b << 8) | (uint)s.ReadByte();
            len += (todo > 0) ? todo * 8 : 0;
        }


		public int Peek(int bitCount) {
			Populate(bitCount);
			int mask = ((1 << len) - 1) ^ ((1 << (len - bitCount)) - 1);
			return (int)(b & mask) >> (len - bitCount);
		}

		public int Read(int bitCount) {
			Populate(bitCount);
			int mask = ((1 << len) - 1) ^ ((1 << (len - bitCount)) - 1);
			int val = (int)(b & mask) >> (len - bitCount);
			len -= bitCount;
			return val;
		}

		public void Seek(int bitCount) {
			Populate(bitCount);
			len -= bitCount;
		}

		public BitDecomposer(Stream s) =>
            this.s = s;
    }
}
