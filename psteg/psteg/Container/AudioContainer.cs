using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Container {
    public enum Channels {
        Mono = 1, Stereo
    }

    public abstract class AudioContainer {
        public virtual byte[] RawData { get; protected set; }
        public virtual bool IsValid { get { return true; }; }
        public int SampleRate { get; protected set; }
        public int BytesPerSample { get; protected set; }
        public Channels Channels { get; protected set; }

        protected abstract void Parse(byte[] rawdata);

        protected AudioContainer(byte[] RawData) {
            Parse(RawData);
        }
    }
}
