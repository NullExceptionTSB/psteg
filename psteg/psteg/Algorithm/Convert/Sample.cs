using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Algorithm.Convert {
    public static class Sample {
        public static double ToIEEE(byte s) {
            return (double)s / byte.MaxValue * 2.0 - 1.0;
        }
        public static double ToIEEE(short s) {
            return (double)s / short.MaxValue;
        }
        public static byte ToPCM8(double s) {
            return (byte)Math.Round((s + 1.0) / 2.0 * byte.MaxValue);
        }
        public static short ToPCM16(double s) {
            return (short)(s * short.MaxValue);
        }
    }
}
