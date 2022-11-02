using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Algorithm.Extra {
    public static class Suffixify {
        public static string SuffixToString(long num) {
            string sufstring = string.Empty;
            if (num > 1000000000)
                sufstring += (num / 1000000000).ToString() + "G";
            else if (num > 1000000)
                sufstring += (num / 1000000).ToString() + "M";
            else if (num > 1000)
                sufstring += (num / 1000).ToString() + "K";
            else sufstring += num.ToString();
            return sufstring;
        }
    }
}
