using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Algorithm;
using psteg.Algorithm.Stegano;
using psteg.SettingsForms.Stegano;
using psteg.File;


namespace psteg.Algorithm {

    public enum StegMethod {
        Undecided, LSB, Jsteg, ACL, ADS, Other
    }

    public abstract class SteganoAlgorithm {
        public abstract StegMethod MethodEnum { get; }
        public abstract FileType[] SupportedFileTypes { get; }
        public abstract Form SettingsForm { get; }
        //public abstract string DisplayName { get; }
        public BackgroundWorker BackgroundWorker { get; set; } = null;
        public Stream RawData { get; set; }
        public List<StegFile> Containers { get; set; }
        public Stream EncodedData { get; set; }


        public CryptoAlgorithm CryptoProvider { get; set; }

        public abstract bool Encode();

        public abstract bool Decode();

        public abstract long CalculateCapacity(long ContainerSize);

        public static SteganoAlgorithm NewByEnum(StegMethod MethodEnum) {
            switch (MethodEnum) {
                case StegMethod.LSB:
                    return new SteganoLSB();
                default: return null;
            }
        }

        public static string GetDisplayName(StegMethod MethodEnum) {
            switch (MethodEnum) {
                case StegMethod.LSB:
                    return SteganoLSB.DisplayName;
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
