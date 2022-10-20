using System.IO;

namespace psteg.File {
    class RawFile : StegFile {
        public override FileType FileType { get { return FileType.Other; } }

        public override Stream GetRawData() {
            return Stream;
        }
        public override byte[] GetRawData(long ammount) {
            byte[] data = new byte[ammount];
            if (ammount < int.MaxValue) {
                Stream.Read(data, 0, (int)ammount);
                return data;
            }
            else 
                throw new InternalBufferOverflowException("Too much data to read");
        }

        public override void SetRawData(byte[] data) {
            Stream.Write(data, 0, data.Length);
        }

        public override void SetRawData(Stream data) {
            data.CopyTo(Stream);
        }

        public RawFile(FileStream stream) {
            Path = stream.Name;
            Stream = stream;
            Size = stream.Length;
        }
    }
}
