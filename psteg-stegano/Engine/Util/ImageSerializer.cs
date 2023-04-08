using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

using psteg.RNG;
namespace psteg.Stegano.Engine.Util {
    public abstract class ImageSerializer {
        public abstract void Next();
        public abstract byte Get();
        public abstract void Set(byte b);

        protected virtual int ChanToOffset(char c) {
            switch (c) {
                case 'A':
                    return 3;
                case 'R':
                    return 2;
                case 'G':
                    return 1;
                case 'B':
                default:
                    return 0;
            }
        }

    }

    public class LinearImageSerializer : ImageSerializer {
        private int x, y, c;

        private readonly int w, h;

        private readonly string des_order;
        private readonly bool row_first;

        private readonly unsafe byte* scan0;
        private readonly unsafe int stride;

        public override unsafe void Next() {
            if (++c < des_order.Length)
                return;
            c=0;
            if (++x < w)
                return;
            x=0;
            if (++y < h)
                return;
            throw new Exception("Serialization out of range attempted (data too large or invalid IV)");
        }

        public override unsafe byte Get() =>
            scan0[4*x+stride*y+ChanToOffset(des_order[c])];


        public override unsafe void Set(byte b) =>
            scan0[4*x+stride*y+ChanToOffset(des_order[c])] = b;

        public LinearImageSerializer(bool row_first, int iv, string chanstr, BitmapData bd) {
            this.row_first = row_first;
            c = 0;

            int clampiv = iv % (bd.Width * bd.Height);
            if (row_first) {
                x = iv % bd.Width;
                y = iv / bd.Height;

            }
            else {
                x = iv / bd.Width;
                y = iv % bd.Height;
            }

            des_order = chanstr;

            w=bd.Width;
            h=bd.Height;
            stride = bd.Stride;
            unsafe { scan0 = (byte*)bd.Scan0; };
        }

        [Obsolete]
        public LinearImageSerializer(bool row_first, int iv, Dictionary<char, bool> chan, BitmapData bd) {
            this.row_first = row_first;
            c = 0;

            int clampiv = iv % (bd.Width * bd.Height);
            if (row_first) {
                x = iv % bd.Width;
                y = iv / bd.Height;

            }
            else {
                x = iv / bd.Width;
                y = iv % bd.Height;
            }

            des_order = "";
            if (chan['B'])
                des_order += 'B';
            if (chan['G'])
                des_order += 'G';
            if (chan['R'])
                des_order += 'R';
            if (chan['A'])
                des_order += 'A';

            w=bd.Width;
            h=bd.Height;

            unsafe {
                scan0 = (byte*)bd.Scan0;
                stride = bd.Stride;
            };
        }
    }

    public class PseudorandomImageSerializer<T> : ImageSerializer where T : PRNG{
        private PRNG prng;
        private int x, y, c;

        private readonly int w, h;
        private readonly unsafe byte* scan0;
        private readonly unsafe int stride;

        public override byte Get() {
            throw new NotImplementedException();
        }

        public override void Next() {
            throw new NotImplementedException();
        }

        public override void Set(byte b) {
            throw new NotImplementedException();
        }

        public PseudorandomImageSerializer(string seed, string chanstr, BitmapData bd) {
            prng = (PRNG)Activator.CreateInstance(typeof(T));
            prng.Reseed(seed);

            w = bd.Width;
            h = bd.Height;

            c=x=y=0;
            stride = bd.Stride;
            unsafe { scan0 = (byte*)bd.Scan0; }

            Next();
        }
    }
}
