namespace psteg_chaffblob.RNGs {
    public sealed class Xorshift : RNG {

        private ulong Cycle() {
            State64 ^= State64 >> 13;
            State64 ^= State64 << 7;
            State64 ^= State64 >> 17;
            return State64;
        }

        public override byte[] GetRandomBytes(int n) {
            byte[] bytes = new byte[n];
            for (int i = 0; i < n; i++) {
                ulong num = GetRandomU64();
                for (int j = 0; i < n && j < 8; i++, j++) { bytes[i] = (byte)num; num >>= 8; }
            }
            return bytes;
        }

        public override int GetRandomS32() => (int)((Cycle()) >> 32);
        public override long GetRandomS64() => (long)Cycle();
        public override uint GetRandomU32() => (uint)((Cycle()) >> 32);
        public override ulong GetRandomU64() => Cycle();

        public Xorshift() => Reseed();
    }

    public sealed class XorshiftS : RNG {
        private const ulong Multiplier = 0x2545F4914F6CDD1DUL;

        private ulong Cycle() {
            State64 ^= State64 >> 12;
            State64 ^= State64 << 25;
            State64 ^= State64 >> 27;
            return State64;
        }

        public override byte[] GetRandomBytes(int n) {
            byte[] bytes = new byte[n];
            for (int i = 0; i < n; i++) {
                ulong num = GetRandomU64();
                for(int j=0;i<n&&j<8;i++,j++){bytes[i]=(byte)num;num>>=8;}
            }
            return bytes;
        }

        public override int GetRandomS32() => (int)((Cycle()*Multiplier)>>32);
        public override long GetRandomS64() => (long)(Cycle()*Multiplier);
        public override uint GetRandomU32() => (uint)((Cycle()*Multiplier)>>32);
        public override ulong GetRandomU64() => Cycle()*Multiplier;
        
        public XorshiftS() => Reseed();
    }
}
