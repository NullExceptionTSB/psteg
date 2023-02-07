using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Stegano.File.Format {
    public class RIFFWAV {
        public enum wavtag {
            PCM = 0x0001,
            IEEE = 0x0003,
            DRM = 0x0009,
            MPEG = 0x0050
        }

        public struct WaveFormat {
            public uint dwFmtLen;
            public ushort wFormatTag;
            public ushort nChannels;
            public uint dwSampleRate;
            public uint nAvgBytesPerSec;
            public ushort wBlockAlign;
            public ushort wBitsPerSample;

            public WaveFormat(ushort channels = 1, uint smprate = 44100, ushort bitspersample = 8) {
                dwFmtLen = 0x10;
                wFormatTag = (ushort)wavtag.PCM;
                nChannels = channels;
                dwSampleRate = smprate;
                nAvgBytesPerSec = (uint)(smprate * (channels * bitspersample) / 8);
                wBlockAlign = (ushort)(channels * bitspersample / 8);
                wBitsPerSample = bitspersample;
            }

            public WaveFormat(byte[] data) {
                dwFmtLen = BitConverter.ToUInt32(data, 0);
                wFormatTag = BitConverter.ToUInt16(data, 4);
                nChannels = BitConverter.ToUInt16(data, 6);
                dwSampleRate = BitConverter.ToUInt32(data, 8);
                nAvgBytesPerSec = BitConverter.ToUInt32(data, 12);
                wBlockAlign = BitConverter.ToUInt16(data, 16);
                wBitsPerSample = BitConverter.ToUInt16(data, 18);
            }

            public byte[] GetData() {
                byte[] buff = new byte[20];
                BitConverter.GetBytes(dwFmtLen).CopyTo(buff, 0);
                BitConverter.GetBytes(wFormatTag).CopyTo(buff, 4);
                BitConverter.GetBytes(nChannels).CopyTo(buff, 6);
                BitConverter.GetBytes(dwSampleRate).CopyTo(buff, 8);
                BitConverter.GetBytes(nAvgBytesPerSec).CopyTo(buff, 12);
                BitConverter.GetBytes(wBlockAlign).CopyTo(buff, 16);
                BitConverter.GetBytes(wBitsPerSample).CopyTo(buff, 18);
                return buff;
            }
        }

    }


    public sealed class WaveDecode {


    }
}
