namespace psteg.Huffman {
    public struct Code {
        public int Length { get; set; }
        public int Value { get; set; }

        public Code(int len, int code) {
            Length=len;
            Value=code;
            JpegIsAC=false;
        }
        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(Code))
                return (Code)obj == this;
            else
                return base.Equals(obj);
        }

        public bool JpegIsAC;
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(Code c1, Code c2) => (c1.Length == c2.Length) && (c1.Value == c2.Value);
        public static bool operator !=(Code c1, Code c2) => !(c1==c2);
    }
}
