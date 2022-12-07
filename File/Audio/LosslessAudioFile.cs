using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using psteg.Container;
using psteg.Container.Audio;

namespace psteg.File.Audio {
    public sealed class LosslessAudioFile : StegFile {
        private ContainerFormat cfmt;
        private AudioContainer container;
        private Stream datastream;

        public override FileType FileType { get { return FileType.LosslessAudio; } }

        public override Stream GetRawData() {
            return datastream;
        }

        public override byte[] GetRawData(long ammount) {
            byte[] data = new byte[ammount];
            datastream.Read(data, 0, data.Length);
            datastream.Seek(0, SeekOrigin.Begin);
            return data;
        }

        public override void SetRawData(Stream data) {
            throw new NotImplementedException();
        }

        public override void SetRawData(byte[] data) {
            throw new NotImplementedException();
        }

        public LosslessAudioFile(Stream str) {
            cfmt = AudioContainer.GetFormat(str);
            byte[] data = new byte[str.Length];
            str.Read(data, 0, data.Length);



            switch (cfmt) {
                case ContainerFormat.RIFFWAV:
                    container = new RIFFWAV(data);
                    datastream = new MemoryStream(container.RawData);
                    break;
                case ContainerFormat.FLAC:
                default: throw new FormatException("unknown audio format");
            }
        }
    }
}
