using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg.File;
namespace psteg.File {
    class FileRaw : StegFile {
        public override FileType FileType { get { return FileType.Other; } }

        public override Stream GetRawData() {
            return Stream;
        }
        public override byte[] GetRawData(long ammount) {
            throw new NotImplementedException();
        }

        public override void SetRawData(byte[] data) {
            Stream.Write(data, 0, data.Length);
        }

        public override void SetRawData(Stream data) {
            data.CopyTo(Stream);
        }

        public FileRaw(FileStream stream) {
            Path = stream.Name;
            Stream = stream;
            Size = stream.Length;
        }
    }
}
