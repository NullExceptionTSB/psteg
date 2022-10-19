using System;
using System.Collections;
using System.Collections.Generic;
//file made in notepad
namespace psteg.Algorithm.Extra {
	public class BitQueue {
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
	[Obsolete]
	public class BitRingBuffer {
		private int _front = 0;
		private int _back = 0;

		private BitArray rawBuffer;
		private const int defaultBufferSz = 2048;

		public int Front { 
			get { return _front; }
			private set { _front = value % MaxLength; }
		}

		public int Back { 
			get { return _back; }
			private set { _back = value % MaxLength; }
		}
		//in BITS!!!!
		public int Length { get; private set; } = 0;
		public int MaxLength { get; private set; }
		
		public BitRingBuffer(int bufferSize = defaultBufferSz) {
			if (bufferSize < 1)
				throw new ArgumentOutOfRangeException("Ringbuffer can't be smaller than 1");
			MaxLength = bufferSize * 8;
			rawBuffer = new BitArray(bufferSize*8);
		}

		public void Push(bool bit) {
			if (Length == MaxLength)
				throw new IndexOutOfRangeException("Buffer full when attempting to push");	

			Length++;
			rawBuffer[Front++] = bit;
		}

		public void Push(byte data) {
			byte tempdata = data;
			for (int i = 0; i < 8; i++)
				Push((tempdata & (1 << (7 - i))) > 1);
		}

		//todo: optimize
		public void Push(byte[] data) {
			if (data.Length*8 > (MaxLength - Length)) 
				throw new IndexOutOfRangeException("Received too much data");

			foreach (byte b in data)
				Push(b);
		}

		public byte[] Pop(int count) {
			if (count < 0)
				throw new ArgumentOutOfRangeException("Negative array length requested");
			else if (count == 0) 
				return null;
			else if (count*8 > Length)
				throw new ArgumentOutOfRangeException("Requested too much data");
			// TODO: inefficient, replace with copyto
			byte[] retdata = new byte[count];
			for (int i = 0; i < count; i++)
				retdata[i] = Pop();

			return retdata;
		}
		
		public byte Pop() {
			byte retdata = 0;
			for (int i = 0; i < 8; i++) 
				retdata += (byte)(PopSingle() ? 1<<(7-i) : 0);
			return retdata;
		}

		public bool PopSingle() {
			if (Length == 0)
				throw new IndexOutOfRangeException("Buffer empty when attempting to pop");	
			Length--;
			return rawBuffer[Back++];
		}
	}

}