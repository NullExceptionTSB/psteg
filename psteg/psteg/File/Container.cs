using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using psteg.Algorithm;

namespace psteg.File {
    [Obsolete]
    public class Container {
        public StegFile File { get; private set; }
        public FileType FileType { get; private set; }
        public StegMethod[] SupportedMethods { get; private set; }
        public Stream DataStream { get; private set; }
        public long Size { get; private set; }
        public string FileName { get; private set; }

        public Container(Stream stream) {
            FileType = FileID.IdentifyFile(stream);

            if (stream.GetType() == typeof(FileStream)) { 
                FileName = ((FileStream)stream).Name;
                File = StegFile.Open(((FileStream)stream).Name);
                Size = FileID.GetNumBlocks(FileType, (FileStream)stream);
            }

            DataStream = stream;
            SupportedMethods = SteganoAlgorithm.AvailableMethods(new FileType[] { FileType });
        }
    }
}
