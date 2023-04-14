using System;

namespace psteg.Stegano.Engine.Util {
    public abstract class JpegCoderOptions {
        public enum Algorithm {
            Jsteg
        }

        private const int DEPTH_MAX = 10;
        public const int DEFAULT_SUB_DEPTH = 4;
        public const int DEFAULT_INS_DEPTH = 2;
        public const bool ALLOW_INSERT = false;

        private int _maxSubstituteDepth = 4;
        private int _maxInsertDepth = 2;

        public int MaxSubstituteDepth {
            get => _maxSubstituteDepth;
            set {
                if (value > DEPTH_MAX)
                    throw new ArgumentException("Depth larger than maximum");
                else
                    _maxSubstituteDepth = value;
            }
        }

        public int MaxInsertDepth {
            get => _maxInsertDepth;
            set {
                if (value > DEPTH_MAX)
                    throw new ArgumentException("Depth larger than maximum");
                else
                    _maxInsertDepth = value;
            }
        }

        public bool InsertInZRL { get; set; } = false;
    }
    public sealed class JstegCoderOptions : JpegCoderOptions { }
}
