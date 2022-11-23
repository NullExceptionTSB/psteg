using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Algorithm.Convert {
    public struct YCbCr {
        public byte Y, Cb, Cr;
    }

    public struct RGB {
        public byte R, G, B;
    }

    public static class Colour {
        public static YCbCr ToYCbCr(RGB rgb) {
            YCbCr ycbcr = new YCbCr();
            ycbcr.Y = (byte)(0 + (0.299 * rgb.R) + (0.587 * rgb.G) + (0.114 * rgb.B));
            ycbcr.Cb = (byte)(128 - (0.168736 * rgb.R) - (0.331264 * rgb.G) + (0.500 * rgb.B));
            ycbcr.Cr = (byte)(128 + (0.500 * rgb.R) - (0.418688 * rgb.G) - (0.081312 * rgb.B));
            return ycbcr;
        }
    }
}
