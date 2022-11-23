using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Container.Audio {
    internal struct wavfmt {
        internal uint dwFmtLen;
        internal ushort wFormatTag;
        internal ushort nChannels;
        internal uint dwSampleRate;
        internal uint nAvgBytesPerSec;
        internal ushort wBlockAlign;
        internal ushort wBitsPerSample;
    }

    internal enum wavtag {
        PCM  = 0x0001,
        IEEE = 0x0003,
        DRM  = 0x0009,
        MPEG = 0x0050
    }

    public sealed class RIFFWAV : AudioContainer {
        private bool _valid = false;
        public override bool IsValid { get { return _valid; } }

        //warning! inefficient. use in-place algorithm to avoid data copying.
        protected override void Parse(byte[] rawdata) {
            char[] fmtmark = Encoding.ASCII.GetChars(rawdata, 13, 4);
            if (new string(fmtmark) != "fmt ")
                throw new NotImplementedException("fmt finding n/a");

            byte[] fmtdata = new byte[20];
            for (int i = 14; i < 14 + 20; i++)
                fmtdata[i - 14] = rawdata[i];

            GCHandle h = GCHandle.Alloc(fmtdata, GCHandleType.Pinned);
            wavfmt format = (wavfmt)Marshal.PtrToStructure(h.AddrOfPinnedObject(), typeof(wavfmt));
            h.Free();

            SampleRate = (int)format.dwSampleRate;
            BytesPerSample = format.wBitsPerSample / 8;

            if (format.wFormatTag == (ushort)wavtag.PCM) { 
                _valid = true;
                return;
            }

            string datamark = new string(Encoding.ASCII.GetChars(rawdata, 13 + (int)format.dwFmtLen, 4));
            int datalen = 0;
            if (datamark == "data")
                datalen = BitConverter.ToInt32(rawdata, 13 + (int)format.dwFmtLen + 4);

            if (datalen == 0) {
                _valid = false;
                return;
            }


            RawData = new byte[datalen];
            for (int i = 0; i < RawData.Length; i++)
                RawData[i] = rawdata[(rawdata.Length - datalen) + i];
        }

        public RIFFWAV(byte[] RawData) : base(RawData) { }
    }
}
