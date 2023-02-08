using System;
using System.IO;

namespace psteg.Stegano.File {
    public abstract class AudioDecode {
        public abstract int SampleSize { get; }
        public abstract int SampleRate { get; }

        private void AssertSampleSz(int sz) {
            if (SampleSize != sz)
                throw new FormatException("Invalid decoder called for sample type");
        }

        public int GetSamples16Juggle(ushort[] Buffer, byte[] JuggleBuffer) {
            AssertSampleSz(16);
            return iGetSamples16(Buffer, JuggleBuffer);
        } //fastest
        public int GetSamples16(ushort[] Buffer) {
            AssertSampleSz(16);
            return iGetSamples16(Buffer);
        } //fast
        public int GetSamples8(byte[] Buffer) {
            AssertSampleSz(8);
            return iGetSamples8(Buffer);
        } //fastest
        public ushort[] GetSamples16(int SampleCount) {
            AssertSampleSz(16);

            ushort[] buff = new ushort[SampleCount];
            iGetSamples16(buff);
            return buff;
        } //slow
        public byte[] GetSamples8(int SampleCount) {
            AssertSampleSz(8);

            byte[] buff = new byte[SampleCount];
            iGetSamples8(buff);
            return buff;
        } //slow
        
        protected abstract int iGetSamples16(ushort[] buff, byte[] juggle = null);
        protected abstract int iGetSamples8(byte[] buff);

        public FileStream Stream { get; protected set; }
    }
}
