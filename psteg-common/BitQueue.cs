using System.Collections;
using System.Collections.Generic;

namespace psteg {
	public sealed class BitQueue {
		private Queue<bool> iqueue;

		public int Length { get { return iqueue.Count; } }
        #region single bit operations
        public void Push(bool bit) {
			iqueue.Enqueue(bit);
        }

		public bool PopSingle() {
			return iqueue.Dequeue();
        }
        #endregion
        #region single byte operations
        public void Push(byte by) {
			BitArray ba = new BitArray(new byte[1] { by });
			foreach (bool b in ba)
				Push(b);
        }

		public byte Pop() {
			byte b = 0x00;
            for (byte i = 0; i < 8; i++)
                b |= (byte)((iqueue.Dequeue() ? 1 : 0) << (byte)(i));
			return b;
        }
		#endregion
		#region multi byte operations
		public void Push(byte[] bytes) {
			BitArray ba = new BitArray(bytes);
			foreach (bool b in ba)
				Push(b);
        }

		public byte[] Pop(int count) {
			byte[] bytes = new byte[count];
			for (int i = 0; i < count; i++)
				bytes[i] = Pop();
			return bytes;
        }
		#endregion
		public BitQueue() {
			iqueue = new Queue<bool>();
        }
    }
}