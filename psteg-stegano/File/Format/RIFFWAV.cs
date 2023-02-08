using System;
using System.IO;
using System.Text;

namespace psteg.Stegano.File.Format {
    public class RIFFWAV {
        public enum FormatTag : ushort {
            PCM = 0x0001,
            IEEE = 0x0003,
            DRM = 0x0009,
            MPEG = 0x0050
        }

        public struct WaveFormat {
            public uint dwFmtLen;
            public FormatTag wFormatTag;
            public ushort nChannels;
            public uint dwSampleRate;
            public uint nAvgBytesPerSec;
            public ushort wBlockAlign;
            public ushort wBitsPerSample;

            public WaveFormat(ushort channels = 1, uint smprate = 44100, ushort bitspersample = 8) {
                dwFmtLen = 0x10;
                wFormatTag = FormatTag.PCM;
                nChannels = channels;
                dwSampleRate = smprate;
                nAvgBytesPerSec = (uint)(smprate * (channels * bitspersample) / 8);
                wBlockAlign = (ushort)(channels * bitspersample / 8);
                wBitsPerSample = bitspersample;
            }

            public WaveFormat(byte[] data) {
                dwFmtLen = BitConverter.ToUInt32(data, 0);
                wFormatTag = (FormatTag)BitConverter.ToUInt16(data, 4);
                nChannels = BitConverter.ToUInt16(data, 6);
                dwSampleRate = BitConverter.ToUInt32(data, 8);
                nAvgBytesPerSec = BitConverter.ToUInt32(data, 12);
                wBlockAlign = BitConverter.ToUInt16(data, 16);
                wBitsPerSample = BitConverter.ToUInt16(data, 18);
            }

            public byte[] GetData() {
                byte[] buff = new byte[20];
                BitConverter.GetBytes(dwFmtLen).CopyTo(buff, 0);
                BitConverter.GetBytes((ushort)wFormatTag).CopyTo(buff, 4);
                BitConverter.GetBytes(nChannels).CopyTo(buff, 6);
                BitConverter.GetBytes(dwSampleRate).CopyTo(buff, 8);
                BitConverter.GetBytes(nAvgBytesPerSec).CopyTo(buff, 12);
                BitConverter.GetBytes(wBlockAlign).CopyTo(buff, 16);
                BitConverter.GetBytes(wBitsPerSample).CopyTo(buff, 18);
                return buff;
            }
        }
        public static bool IsValid(FileStream fs) => IsValid(fs, out _, out _);
        public static bool IsValid(FileStream fs, out long fmtOffset, out long dataOffset) {
            long pos = fs.Position;
            fmtOffset = 0;
            dataOffset = 0;
            fs.Seek(0, SeekOrigin.Begin);

            bool valid = true;
            byte[] window = new byte[4];
            byte[] window2 = new byte[4];
            fs.Read(window, 0, 4);

            if (BitConverter.ToUInt32(window, 0) != 0x46464952U) {
                valid = false;
                goto end;
            }

            fs.Read(window, 0, 4);
            if (BitConverter.ToUInt32(window, 0) != fs.Length-8) {
                valid = false;
                goto end;
            }

            fs.Read(window, 0, 4);
            if (Encoding.ASCII.GetString(window, 0, 4) != "WAVE") {
                valid = false;
                goto end;
            }

            uint l = 0;
            do {
                fs.Read(window, 0, 4);
                if (Encoding.ASCII.GetString(window, 0, 4) == "data")
                    dataOffset = fs.Position;
                fs.Read(window2, 0, 4);
                l = BitConverter.ToUInt32(window2, 0);
                fs.Seek(l, SeekOrigin.Current);
                if (fs.Position == fs.Length) {
                    valid = false;
                    goto end;
                }
            } while (Encoding.ASCII.GetString(window, 0, 4) != "fmt ");

            if (l == 0) {
                valid = false;
                goto end;
            }

            fmtOffset = (fs.Position - l - 8);


        end:
            fs.Seek(pos, SeekOrigin.Begin);
            return valid;
        }
    }


    public sealed class WavDecode : AudioDecode{
        public RIFFWAV.WaveFormat WaveFormat { get; private set; }

        private long FormatOffset { get; set; }
        private long DataOffset { get; set; }
        
        public override int SampleSize { get => WaveFormat.wBitsPerSample; }
        public override int SampleRate { get => (int)WaveFormat.dwSampleRate; }

        private void Parse() {
            long pos = Stream.Position;
            Stream.Seek(12, SeekOrigin.Begin);
            byte[]  window = new byte[4],
                    window2 = new byte[4];

            long last_pos = -1;
            if (DataOffset == 0 || FormatOffset == 0)
                do {
                    if (last_pos == Stream.Position) {
                        Stream.Seek(pos, SeekOrigin.Begin);
                        throw new FormatException("Corrupted file detected");
                    }
                    last_pos = Stream.Position;
                    Stream.Read(window, 0, 4);
                    Stream.Read(window2, 0, 4);

                    if (Encoding.ASCII.GetString(window, 0, 4) == "data") 
                        DataOffset = Stream.Position;
                    else if (Encoding.ASCII.GetString(window, 0, 4) == "fmt ") 
                        FormatOffset = Stream.Position - 4;
                    else
                        Console.WriteLine("W: unrecognized RIFFWAVE marker: " + Encoding.ASCII.GetString(window, 0, 4));

                    Stream.Seek(BitConverter.ToUInt32(window2, 0), SeekOrigin.Current);
                } while (Stream.Position != Stream.Length);

            if (DataOffset == 0 || FormatOffset == 0) {
                Stream.Seek(pos, SeekOrigin.Begin);
                throw new FormatException("Invalid RIFFWAVE file, missing mandatory markers");
            }

            byte[] riffhdr = new byte[20];
            Stream.Seek(FormatOffset, SeekOrigin.Begin);
            Stream.Read(riffhdr, 0, 20);

            WaveFormat = new RIFFWAV.WaveFormat(riffhdr);

            switch (WaveFormat.wFormatTag) {
                case RIFFWAV.FormatTag.PCM:
                    break;
                default:
                    Stream.Seek(pos, SeekOrigin.Begin);
                    throw new NotImplementedException("Wave format not implemented: " + WaveFormat.wFormatTag.ToString());
            }

            Stream.Seek(pos, SeekOrigin.Begin);
        }

        protected override int iGetSamples16(ushort[] buff, byte[] juggle) {
            byte[] b = juggle??(new byte[buff.Length*2]);
            int realln = Stream.Read(b, 0, b.Length);
            realln /= 2;
            for (int i = 0; i < realln; i++)
                buff[i] = (ushort)(b[i*2] | (b[i*2+1] << 8)); //faster than bitconverter, expecting high data volumes
            return realln;
        }

        protected override int iGetSamples8(byte[] buff) =>
            Stream.Read(buff, 0, buff.Length);

        private static bool IsValid(FileStream fs, out long fmtOffset, out long dataOffset) => RIFFWAV.IsValid(fs, out fmtOffset, out dataOffset);

        public WavDecode(FileStream fs) {
            long fmtOffset = 0;
            long dataOffset = 0;
            Stream = fs;
            if (!IsValid(fs, out fmtOffset, out dataOffset))
                throw new FormatException("Not valid WAV file");

            DataOffset = dataOffset;
            FormatOffset = fmtOffset;

            Parse();
            Stream.Seek(DataOffset, SeekOrigin.Begin);
        }
    }

    public sealed class WavEncode : AudioEncode {
        public RIFFWAV.WaveFormat WaveFormat { get; private set; }
        //using constant offsets because i have full control over this file
        public override void Dispose() {
            if (Stream.Length > (uint.MaxValue-8))
                throw new Exception("File too big to encode in RIFFWAV format");

            uint DataSize = (uint)(Stream.Length - 44),
                 FileSize = (uint)(Stream.Length - 8);

            Stream.Seek(4, SeekOrigin.Begin);
            Stream.Write(BitConverter.GetBytes(FileSize), 0, 4);
            Stream.Seek(40, SeekOrigin.Begin);
            Stream.Write(BitConverter.GetBytes(DataSize), 0, 4);
        }

        public override void PutSamples(byte[] Buffer) =>
            Stream.Write(Buffer, 0, Buffer.Length);
        

        public override void PutSamples(ushort[] Buffer) {
            for (int i = 0; i < Buffer.Length; i++) {
                Stream.WriteByte((byte)(Buffer[i]&0xFF));
                Stream.WriteByte((byte)(Buffer[i]>>8));
            }
        }

        public WavEncode(FileStream fs, RIFFWAV.WaveFormat? WaveFormat) {
            if (WaveFormat == null)
                throw new NotImplementedException("Autoformat not implemented");

            this.WaveFormat = (RIFFWAV.WaveFormat)WaveFormat;
            Stream = fs;
            string head = "RIFF\0\0\0\0WAVEfmt ";
            fs.Write(Encoding.ASCII.GetBytes(head), 0, 16);
            fs.Write(this.WaveFormat.GetData(), 0, 20);
            fs.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
            fs.Seek(4, SeekOrigin.Current);
        }
    }
}
