using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using psteg.Algorithm;
using psteg.Algorithm.Crypto;
using psteg.Algorithm.Stegano;
using psteg.File;
using psteg.File.Image;

namespace psteg {
    public enum StegOperation {
        Encode,Decode
    }
    public enum KeyMode {
        Password,Key
    }

    public class PstegEngine {
        public static Dictionary<StegMethod, Type> KnownSteg = new Dictionary<StegMethod, Type>
        {
            { StegMethod.LSB, typeof(SteganoLSB) }
        };

        public static Dictionary<CryptoMethod, Type> KnownCrypto = new Dictionary<CryptoMethod, Type>
        {
            { CryptoMethod.Rijndael, typeof(CryptoRijndael) }

        };

        public BackgroundWorker AsyncWorker { get; set; }

        public SteganoAlgorithm SteganoAlgorithm { get; private set; }
        public CryptoAlgorithm CryptoAlgorithm { get; private set; }

        public StegOperation SteganoOperation { get; set; } = StegOperation.Encode;
        public KeyMode KeyMode { get; set; } = KeyMode.Password;

        public StegFile RawFile { get; set; }
        public StegFile EncodedFile { get; set; }

        public List<StegFile> Containers { get; private set; }

        public bool Encrypt { get; set; } = false;

        public bool ShowSteganoSettings() {
            SteganoAlgorithm?.SettingsForm?.ShowDialog();
            return SteganoAlgorithm?.SettingsForm != null;
        }

        public bool ShowCryptoSettings() {
            CryptoAlgorithm?.SettingsForm?.ShowDialog();
            return CryptoAlgorithm?.SettingsForm != null;
        }

        public PstegEngine(StegMethod stegMethod = StegMethod.Undecided, CryptoMethod cryptMethod = CryptoMethod.None) {
            SetAlgorithms(stegMethod, cryptMethod);
            Containers = new List<StegFile>();
        }

        public void SetAlgorithms(StegMethod stegMethod, CryptoMethod cryptMethod = CryptoMethod.None) {
            if (stegMethod != SteganoAlgorithm?.MethodEnum) { 
                if (stegMethod == StegMethod.Undecided)
                    SteganoAlgorithm = null;
                else
                    SteganoAlgorithm = SteganoAlgorithm.NewByEnum(stegMethod);
            }

            SetAlgorithms(cryptMethod);

            if (SteganoAlgorithm != null)
                SteganoAlgorithm.Containers = Containers;
        }

        public void SetAlgorithms(CryptoMethod cryptMethod) {
            if (cryptMethod == CryptoMethod.None)
                CryptoAlgorithm = null;
            else
                CryptoAlgorithm = CryptoAlgorithm.NewByEnum(cryptMethod);
        }

        private void Lint() {
            if (EncodedFile == null)
                throw new ArgumentException("No output specified");
            if (RawFile == null)
                throw new ArgumentException("No input specified");

            if (SteganoAlgorithm == null)
                throw new ArgumentException("Unspecified or unknown steganographic algorithm");
            if (CryptoAlgorithm == null && Encrypt)
                throw new ArgumentException("Encryption enabled but not specified");

        }

        private void Encode() {
            if (Encrypt)
                throw new NotImplementedException("Cryptography is not implemented");

            //ENCRYPTION GOES HERE!!!!!

            SteganoAlgorithm.Containers = Containers;
            SteganoAlgorithm.RawData = RawFile.Stream;
            SteganoAlgorithm.EncodedData = new MemoryStream();
            
            bool success = SteganoAlgorithm.Encode();
            if (!success)
                throw new Exception("Steganographic encoding error");
            

            if (Containers.Count > 1)
                throw new NotImplementedException();

            switch (Containers[0].FileType) {
                case FileType.LosslessImage:
                    ((LosslessImg)EncodedFile).NewBitmap(((LosslessImg)Containers[0]).Resolution);
                    break;
                default:
                    throw new NotImplementedException();
            }
            
            EncodedFile.SetRawData(SteganoAlgorithm.EncodedData);
            //cleanup
            SteganoAlgorithm.EncodedData.Dispose();
            SteganoAlgorithm.EncodedData = null;
            EncodedFile.Dispose();
        }

        private void Decode() {

        }

        private void bwgo(object sender, DoWorkEventArgs e) {
            if (SteganoOperation == StegOperation.Encode) Encode();
            else Decode();
        }

        public void Go() {
            Lint();

            SteganoAlgorithm.BackgroundWorker = AsyncWorker;
            AsyncWorker.DoWork += bwgo;
            AsyncWorker.RunWorkerAsync();
        }
    }
}
