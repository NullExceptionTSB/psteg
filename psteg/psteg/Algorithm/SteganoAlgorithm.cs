using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using psteg.Algorithm.Stegano;
using psteg.File;


namespace psteg.Algorithm {

    public enum StegMethod {
        Undecided, LSB, Jsteg, ACL, ADS, Other
    }

    public abstract class SteganoAlgorithm {
        public static int ReportEveryN { get; set; } = 1024;

        public abstract StegMethod MethodEnum { get; }
        public abstract FileType[] SupportedFileTypes { get; }
        public abstract Form SettingsForm { get; }
        public virtual bool ForceRaw { get; } = false;
        public virtual string DisplayName { get { return MethodEnum.ToString(); } }

        public long? DecodedDataLength { get; set; } = null;
        public BackgroundWorker BackgroundWorker { get; set; } = null;
        public Stream RawData { get; set; }
        public List<StegFile> Containers { get; set; }
        public Stream EncodedData { get; set; }
        public virtual string EncodedPath { get; set; }

        public CryptoAlgorithm CryptoProvider { get; set; }

        public abstract void Encode();
        public abstract void Decode();

        public virtual long CalculateCapacity(long ContainerSize) {
            return -1;
        }

        protected virtual void WorkerReport(int percent, object state) {
            try { BackgroundWorker?.ReportProgress(percent, state); } catch { }
        }

        public static SteganoAlgorithm NewByEnum(StegMethod MethodEnum) {
            switch (MethodEnum) {
                case StegMethod.LSB:
                    return new SteganoLSB();
                case StegMethod.ADS:
                    return new SteganoADS();
                default: return null;
            }
        }

        public static string GetDisplayName(StegMethod MethodEnum) {
            switch (MethodEnum) {
                case StegMethod.LSB:
                    return SteganoLSB.AlgoDisplayName;
                case StegMethod.ADS:
                    return SteganoADS.AlgoDisplayName;
                default: return MethodEnum.ToString();
            }
        }

        public static StegMethod[] AvailableMethods(FileType[] FileTypes) {
            StegMethod[] stegMethods = (StegMethod[])Enum.GetValues(typeof(StegMethod));
            for (int i = 0; i < FileTypes.Length; i++) {
                switch (FileTypes[i]) {
                    case FileType.LosslessImage:
                    case FileType.LosslessAudio:
                        stegMethods = stegMethods.Intersect(new StegMethod[] { StegMethod.LSB, StegMethod.ACL, StegMethod.ADS }).ToArray();
                        break;
                    case FileType.Jpeg:
                        stegMethods = stegMethods.Intersect(new StegMethod[] { StegMethod.Jsteg, StegMethod.ACL, StegMethod.ADS }).ToArray();
                        break;
                    case FileType.Other:
                        stegMethods = stegMethods.Intersect(new StegMethod[] { StegMethod.ACL, StegMethod.ADS }).ToArray();
                        break;
                    default: return new StegMethod[0];
                }
            }
            return stegMethods;
        }

        public virtual void SetSingleContainer(StegFile container) {
            Containers.Clear();
            Containers.Add(container);
        }

        protected SteganoAlgorithm() {
            Containers = new List<StegFile>();
        }
    }

}
