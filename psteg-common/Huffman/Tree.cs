using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Huffman {
    public class Tree {
        public object Zero { get; set; } = null;
        public object One { get; set; } = null;

        public bool IsEmpty { get => Zero == null && One == null; }

        public void Optimize() {
            if (Zero?.GetType() == typeof(Tree)) {
                ((Tree)Zero).Optimize();
                if (((Tree)Zero).IsEmpty)
                    Zero = null;
            }
            if (One?.GetType() == typeof(Tree)) {
                ((Tree)One).Optimize();
                if (((Tree)One).IsEmpty)
                    One = null;
            }
        }
    }
}
