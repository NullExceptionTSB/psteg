using System.Collections.Generic;
using System.Drawing.Imaging;

using psteg.Stegano.File;

namespace psteg.Stegano.Engine.Util {
    public static class LSB {
        public static byte ReverseBits(byte b, bool reverse = true) =>
            reverse?(byte)(((b * 0x80200802ul) & 0x0884422110ul) * 0x0101010101ul >> 32):b;

        public static byte Mix(byte cover, byte data, byte cover_mask) => (byte)((cover & cover_mask) | (data & ~cover_mask));
        public static ushort Mix(ushort cover, ushort data, ushort cover_mask) => (ushort)((cover & cover_mask) | (data & ~cover_mask));
        public static void UnmixPush(int data, int width, BitQueue bq) {
            for (int i = 0; i < width; i++)
                bq.Push((data&(1<<i))>0);
        }

        public static int WidthPop(int depth, BitQueue bq) {
            int r = 0;
            for (int i = 0; i < depth; i++)
                r |= ((bq.PopSingle() ? 1 : 0) << i);
            return r;
        }

        public static class SpecificOptions {
            public struct Img {
                public Dictionary<char, bool> Channels;
                public int BitWidth;
                public bool RowReadMode;
                public ImageFormat OutputFormat;
            }

            public struct Audio {
                public AudioFileID ID;
                public int BitWidth;
                public Dictionary<char, bool> Channels;

                public AudioDecode Decoder;
                public AudioEncode Encoder;
            }
        }

        public enum Mode {
            Audio, Image
        }
    }
}
