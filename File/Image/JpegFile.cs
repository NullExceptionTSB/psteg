using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.File.Image {
    class JpegFile : StegFile {
        public override FileType FileType { get { return FileType.Jpeg; } }

        //jpeg files return **QUANTIZED DCT TABLES BY DEFAULT**

        public override Stream GetRawData() {
            throw new NotImplementedException();
        }

        public override byte[] GetRawData(long ammount) {
            throw new NotImplementedException();
        }

        public override void SetRawData(Stream data) {
            throw new NotImplementedException();
        }

        public override void SetRawData(byte[] data) {
            throw new NotImplementedException();
        }
    }
}
