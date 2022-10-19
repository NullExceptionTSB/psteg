using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Algorithm.Extra {
    public static class Maths {
        public static int Log2(int x) {
            int tx = x, log = 0;
            if (x <= 0) return int.MinValue;

            do {
                tx <<= 1;
                log++;
            } while (tx != 0);
            return tx;
        }
    }
}
