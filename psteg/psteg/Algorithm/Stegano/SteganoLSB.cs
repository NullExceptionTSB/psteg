using System;
using System.IO;
using System.Windows.Forms;

using psteg.Algorithm.Extra;
using psteg.File;
using psteg.UI.SettingsForms.Stegano;


namespace psteg.Algorithm.Stegano {
    public enum LSBMode {
        Audio, Video, Hybrid
    }

    [Flags]
    public enum LSBImageChannels {
        None = 0,
        Alpha = 1,
        Red = 2,
        Green = 4,
        Blue = 8
    }

    public sealed class SteganoLSB : SteganoAlgorithm {
        private readonly LSBSettings settingsFormInstance = null;
        private const int BlockSize = 512;

        public long Capacity {
            get {
                long cap = 0;
                for (int i = 0; i < Containers.Count; i++)
                    cap += CalculateCapacity(Containers[i].Size);
                return cap;
            }
        }
        public int BitWidth { get; set; } = 2;
        private int ImageChannelCount { 
            get {
                int val = 0;
                LSBImageChannels[] imageChannels = (LSBImageChannels[])Enum.GetValues(typeof(LSBImageChannels));
                foreach (LSBImageChannels chan in imageChannels)
                    val += ((ImageChannels & chan) > 0) ? 1 : 0;
                return val;
            } 
        }
        public LSBImageChannels ImageChannels { get; set; } = LSBImageChannels.Red | LSBImageChannels.Green | LSBImageChannels.Blue | LSBImageChannels.Alpha;
        public LSBMode Mode { get; set; } = LSBMode.Video;
        #region consts
        public override StegMethod MethodEnum { get { return StegMethod.LSB; } }
        public override FileType[] SupportedFileTypes { get { return new FileType[] { FileType.LosslessImage, FileType.LosslessAudio }; } }
        public override Form SettingsForm { get { return settingsFormInstance; } }

        public static string AlgoDisplayName { get { return "Least Significant Bit (LSB)"; } }
        public override string DisplayName { get { return AlgoDisplayName; } }
        #endregion
        public SteganoLSB() : base() {
            settingsFormInstance = new LSBSettings(this);
        }

        public void EncodeImage() {
            byte mask = BitWidth < 8 ? (byte)~((1 << BitWidth) - 1) : (byte)0;
            const int dataThreshold = BlockSize/2;
            StegFile container = Containers[0];

            long capacity = CalculateCapacity(container.Size);

            if (RawData.Length > capacity)
                throw new Exception("Too much data to encode");

            int n = 0;

            Stream contStream = container.GetRawData();
            byte[] buffer = new byte[BlockSize * BitWidth],
                   contBuffer = new byte[BlockSize];
            int cbread = -1;
            BitQueue bitRBuffer = new BitQueue();
            while (cbread != 0) {
                cbread = contStream.Read(contBuffer, 0, contBuffer.Length);
                if ((RawData.Length - RawData.Position) > 0) {
                    if (bitRBuffer.Length < dataThreshold * 8) {
                        buffer.Initialize();
                        RawData.Read(buffer, 0, BlockSize * BitWidth);
                        bitRBuffer.Push(buffer);
                    }
                    
                    for (int i = 0; i < BlockSize / 4; i++) {
                        byte a = contBuffer[i * 4 + 3],
                             r = contBuffer[i * 4 + 2],
                             g = contBuffer[i * 4 + 1],
                             b = contBuffer[i * 4 + 0];

                        bool af = ImageChannels.HasFlag(LSBImageChannels.Alpha),
                             rf = ImageChannels.HasFlag(LSBImageChannels.Red),
                             gf = ImageChannels.HasFlag(LSBImageChannels.Green),
                             bf = ImageChannels.HasFlag(LSBImageChannels.Blue);

                        byte[] channels = new byte[ImageChannelCount];
                        int idx = 0;

                        if (bf)
                            channels[idx++] = b;
                        if (gf)
                            channels[idx++] = g;
                        if (rf)
                            channels[idx++] = r;
                        if (af)
                            channels[idx++] = a;

                        for (int channel = 0; channel < ImageChannelCount; channel++) {
                            channels[channel] &= mask;
                            //byte bitdata = 0;
                            for (int bit = 0; bit < BitWidth; bit++)
                                channels[channel] |= (byte)((bitRBuffer.PopSingle() ? 1 : 0) << bit);
                        }
                        idx = 0;

                        EncodedData.WriteByte(bf ? channels[idx++] : b);
                        EncodedData.WriteByte(gf ? channels[idx++] : g);
                        EncodedData.WriteByte(rf ? channels[idx++] : r);
                        EncodedData.WriteByte(af ? channels[idx++] : a);
                        n++;
                        if (n > ReportEveryN) {
                            WorkerReport(1, new Tuple<long, long>(contStream.Position, contStream.Length));
                        }
                    }
                }
                else {
                    EncodedData.Write(contBuffer, 0, cbread);
                }
                
            }
            EncodedData.Seek(0, SeekOrigin.Begin);
            WorkerReport(1, new Tuple<long, long>(contStream.Position, contStream.Length));
            contStream.Close();
            contStream.Dispose();
        }

        public void DecodeImage() {
            Stream ContainerData = Containers[0].GetRawData();
            ContainerData.Seek(0, SeekOrigin.Begin);
            RawData.Seek(0, SeekOrigin.Begin);

            long readLength = DecodedDataLength != null ? Math.Min((long)DecodedDataLength, ContainerData.Length) : ContainerData.Length;

            BitQueue ringBuffer = new BitQueue();
            int nbytes = 0;
            bool    geta = ImageChannels.HasFlag(LSBImageChannels.Alpha),
                    getr = ImageChannels.HasFlag(LSBImageChannels.Red),
                    getg = ImageChannels.HasFlag(LSBImageChannels.Green),
                    getb = ImageChannels.HasFlag(LSBImageChannels.Blue);

            while (RawData.Position < readLength) {
                if (ringBuffer.Length >= 8) {
                    RawData.WriteByte(ringBuffer.Pop());
                    nbytes++;
                    if (nbytes > ReportEveryN) {
                        nbytes = 0;
                        WorkerReport(1, new Tuple<long, long>(RawData.Position, readLength));
                    }
                }
                int cn = (int)(ContainerData.Position % 4);
                byte encdata = (byte)ContainerData.ReadByte();

                if ((cn == 3 && geta) || (cn == 2 && getr) || (cn == 1 && getg) || (cn == 0 && getb))
                    for (int i = 0; i < BitWidth; i++)
                        ringBuffer.Push((encdata & (1 << i)) > 0);
                
            }
            WorkerReport(1, new Tuple<long, long>(RawData.Position, readLength));
        }

        public override void Encode() {
            if (Containers.Count == 1) {
                StegFile container = Containers[0];
                switch (container.FileType) {
                    case FileType.LosslessImage:
                        EncodeImage();
                        return;
                    default:
                        throw new NotImplementedException("File type not supported: " + container.FileType.ToString());
                }
            }
            else
                throw new NotImplementedException("Multi-container mode not supported by method");
        }

        public override void Decode() {
            if (Containers.Count == 1) {
                StegFile container = Containers[0];
                switch (container.FileType) {
                    case FileType.LosslessImage:
                        DecodeImage();
                        return;
                    default: 
                        throw new NotImplementedException("File type not supported: " + container.FileType.ToString());
                }
            }
            else 
                throw new NotImplementedException("Multi-container mode not supported by method");
        }

        public override long CalculateCapacity(long ContainerSize) {
            return ContainerSize * BitWidth / 8;
        }
    }
}
