using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

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

        public StegFile FileRaw { get; set; }
        public StegFile EncodedFile { get; set; }

        public List<StegFile> Containers { get; private set; }

        public bool Encrypt { get; set; } = false;
        public bool AllBlockEncryption { get; set; } = false;

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

        public void SetAlgorithms(StegMethod stegMethod, CryptoMethod cryptMethod) {
            SetAlgorithms(stegMethod);
            SetAlgorithms(cryptMethod);
        }

        public void SetAlgorithms(StegMethod stegMethod) {
            if (SteganoAlgorithm?.MethodEnum != stegMethod) { 
                if (stegMethod == StegMethod.Undecided)
                    SteganoAlgorithm = null;
                else
                    SteganoAlgorithm = SteganoAlgorithm.NewByEnum(stegMethod);
            }
        }

        public void SetAlgorithms(CryptoMethod cryptMethod) {
            if (CryptoAlgorithm?.MethodEnum != cryptMethod) { 
                if (cryptMethod == CryptoMethod.None)
                    CryptoAlgorithm = null;
                else
                    CryptoAlgorithm = CryptoAlgorithm.NewByEnum(cryptMethod);
            }
        }

        private void Lint() {
            if (EncodedFile == null && SteganoOperation == StegOperation.Encode)
                throw new ArgumentException("No output specified");
            if (FileRaw == null)
                throw new ArgumentException("No input specified");

            if (SteganoAlgorithm == null)
                throw new ArgumentException("Unspecified or unknown steganographic algorithm");
            if (CryptoAlgorithm == null && Encrypt)
                throw new ArgumentException("Encryption enabled but no method specified");
        }

        private void Encode() {
            Stream inputData = FileRaw.Stream;

            if (Encrypt) {
                if (AllBlockEncryption)
                    throw new NotImplementedException("Full-Block Encryption not supported");
                else
                    CryptoAlgorithm.InputData = FileRaw.Stream;

                if (KeyMode == KeyMode.Password) {
                    inputData = new MemoryStream();
                    Stream cstream = CryptoAlgorithm.Encrypt();
                    cstream.CopyTo(inputData);
                    cstream.Dispose();

                    inputData.Seek(0, SeekOrigin.Begin);
                }   
                else
                    throw new NotImplementedException("Cryptography password only");

            }

            SteganoAlgorithm.Containers = Containers;
            SteganoAlgorithm.RawData = inputData;
            SteganoAlgorithm.EncodedData = new MemoryStream();
            
            SteganoAlgorithm.Encode();

            if (Containers.Count > 1)
                throw new NotImplementedException();

            switch (Containers[0].FileType) {
                case FileType.LosslessImage:
                    ((LosslessImgFile)EncodedFile).NewBitmap(((LosslessImgFile)Containers[0]).Resolution);
                    break;
                default:
                    throw new NotImplementedException();
            }
            
            EncodedFile.SetRawData(SteganoAlgorithm.EncodedData);
            //cleanup
            if (Encrypt) {
                inputData?.Close();
                inputData?.Dispose();
            }
            SteganoAlgorithm.EncodedData.Dispose();
            SteganoAlgorithm.EncodedData = null;
            EncodedFile.Dispose();
        }

        private void Decode() {
            Stream rawStream = FileRaw.Stream;
            long? prevdata = SteganoAlgorithm.DecodedDataLength;
            
            if (Encrypt) {
                //block-align decoded data size for block cryptographic algorithms (they scream about padding otherwise)
                if ((SteganoAlgorithm.DecodedDataLength % CryptoAlgorithm.BlockSize) != 0)
                    SteganoAlgorithm.DecodedDataLength += (CryptoAlgorithm.BlockSize) - (SteganoAlgorithm.DecodedDataLength % CryptoAlgorithm.BlockSize);
                if (AllBlockEncryption)
                    throw new NotImplementedException("Full-Block Encryption not supported");
                rawStream = new MemoryStream();
            }

            

            SteganoAlgorithm.Containers = Containers;
            SteganoAlgorithm.RawData = rawStream;

            SteganoAlgorithm.EncodedData?.Dispose();
            SteganoAlgorithm.EncodedData = null;

            SteganoAlgorithm.Decode();

            if (Encrypt) {
                if (KeyMode == KeyMode.Password) {
                    rawStream.Seek(0, SeekOrigin.Begin);
                    CryptoAlgorithm.InputData = rawStream;
                    Stream cstream = CryptoAlgorithm.Decrypt();
                    try { 
                        cstream.CopyTo(FileRaw.Stream);
                    } catch (Exception e) {
                        throw new Exception("Cryptographic exception, likely incorrect key or steganographic parameters", e);
                    } finally {
                        SteganoAlgorithm.DecodedDataLength = prevdata;

                        cstream.Close();
                        cstream.Dispose();

                        rawStream.Close();
                        rawStream.Dispose();
                    }
                }
                else 
                    throw new NotImplementedException("Cryptography password only");
            }
        }
        //lock to prevent winforms firing the event 4 times for no fucking reason
        private bool @lock = false;
        private void bwgo(object sender, DoWorkEventArgs e) {
            if (!@lock) {
                @lock = true;
                if (SteganoOperation == StegOperation.Encode) Encode();
                else Decode();
            }
        }

        public void Go() {
            @lock = false;
            Lint();

            SteganoAlgorithm.BackgroundWorker = AsyncWorker;
            AsyncWorker.DoWork += bwgo;
            AsyncWorker.RunWorkerAsync();
            AsyncWorker.DoWork -= bwgo;
        }
    }
}
