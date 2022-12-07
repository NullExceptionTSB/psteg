using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Container {
    public enum Channels {
        Mono = 1, Stereo
    }

    public enum ContainerFormat {
        Unknown, RIFFWAV, FLAC
    }

    public abstract class AudioContainer {
        public virtual byte[] RawData { get; protected set; }
        public virtual bool IsValid { get { return true; } }
        public int SampleRate { get; protected set; }
        public int BytesPerSample { get; protected set; }
        public Channels Channels { get; protected set; }

        protected abstract void Parse(byte[] rawdata);

        protected AudioContainer(byte[] RawData) {
            Parse(RawData);
        }

        public static ContainerFormat GetFormat(Stream stream) {
            long oldPos = stream.Position;
            byte[] head = new byte[4];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(head, 0, 4);
            stream.Seek(oldPos, SeekOrigin.Begin);

            uint magic = BitConverter.ToUInt32(head, 0);
            switch (magic) {
                case 0x43614C66U: //FLAC
                    return ContainerFormat.FLAC;
                case 0x46464952U:
                    return ContainerFormat.RIFFWAV;
                default: return ContainerFormat.Unknown;
            }
        }
    }
}
