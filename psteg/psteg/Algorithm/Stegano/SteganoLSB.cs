using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Algorithm.Extra;
using psteg.File;
using psteg.SettingsForms.Stegano;


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

    public class SteganoLSB : SteganoAlgorithm {
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
        public static string DisplayName { get { return "Least Significant Bit (LSB)"; } }
        #endregion
        public SteganoLSB() : base() {
            settingsFormInstance = new LSBSettings(this);
        }

        public bool EncodeImage() {
            const int dataThreshold = BlockSize/2;
            StegFile container = Containers[0];

            long capacity = CalculateCapacity(container.Size);

            if (RawData.Length > capacity)
                throw new Exception("Too much data to encode");

            Stream contStream = container.GetRawData();
            byte[] buffer = new byte[BlockSize * 8],
                   contBuffer = new byte[BlockSize];
            int cbread = 0;
            BitRingBuffer bitRBuffer = new BitRingBuffer(buffer.Length * 2);
            while ((contStream.Length - contStream.Position) > 0) {
                cbread = contStream.Read(contBuffer, 0, contBuffer.Length);
                if ((RawData.Length - RawData.Position) > 0) {
                    if (bitRBuffer.Length < dataThreshold * 8) {
                        RawData.Read(buffer, 0, BlockSize * 8);
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
                            channels[channel] &= (byte)~((1 << BitWidth) - 1);
                            //byte bitdata = 0;
                            for (int bit = 0; bit < BitWidth; bit++)
                                channels[channel] |= (byte)((bitRBuffer.PopSingle() ? 1 : 0) << bit);
                        }
                        idx = 0;

                        EncodedData.WriteByte(bf ? channels[idx++] : b);
                        EncodedData.WriteByte(gf ? channels[idx++] : g);
                        EncodedData.WriteByte(rf ? channels[idx++] : r);
                        EncodedData.WriteByte(af ? channels[idx++] : a);
                    }
                }
                else {
                    EncodedData.Write(contBuffer, 0, cbread);
                }
                WorkerReport(1, new Tuple<long, long>(EncodedData.Position, EncodedData.Length));
            }
            EncodedData.Seek(0, SeekOrigin.Begin);
            return true;
        }

        private void WorkerReport(int percent, object state) {
            try { BackgroundWorker?.ReportProgress(percent, state); } catch { }
        }


        public override bool Encode() {
            if (Containers.Count == 1) {
                StegFile container = Containers[0];
                if (container.FileType != FileType.LosslessImage)
                    throw new NotImplementedException();
                return EncodeImage();
            }
            else
                throw new NotImplementedException();
        }

        public override bool Decode() {
            throw new NotImplementedException();
        }

        public override long CalculateCapacity(long ContainerSize) {
            return ContainerSize * BitWidth / 8;
        }
    }
}
