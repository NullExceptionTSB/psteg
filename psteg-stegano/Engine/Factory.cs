using System;
using System.ComponentModel;
using System.IO;

using psteg.Stegano.Engine.Encode;
using psteg.Stegano.Engine.Decode;
using psteg.Crypto;

namespace psteg.Stegano.Engine {
    public enum Methods {
        LSB, DCT, Metadata
    }

    public sealed class EncoderFactory {    
        private EncoderEngine Engine { get; set; }

        public static EncoderFactory Create(Methods method, object extra = null) {
            EncoderFactory ef = new EncoderFactory();
            Type et = extra.GetType();
            switch (method) {
                case Methods.DCT:
                    ef.Engine = (EncoderEngine)Activator.CreateInstance(et.GetType().MakeGenericType(typeof(JpegCoderOptions)), new object[] { extra });
                    break;
                case Methods.Metadata:
                    ef.Engine = new MetadataEncoderEngine();
                    break;
                case Methods.LSB:
                    ef.Engine = new LSBEncoderEngine();
                    break;
            }
            return ef;
        }

        public EncoderFactory OpenInput(string path) {
            Engine.DataStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return this;
        }

        public EncoderFactory OpenOutput(string path) {
            Engine.OutputStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            return this;
        }

        public EncoderFactory OpenCover(string path) {
            Engine.CoverStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return this;
        }

        public EncoderFactory SetCryptography(Encryption crypto) {
            Engine.Encryption = crypto;
            return this;
        }

        public EncoderFactory SetCryptoKey(string key) {
            Tuple <byte[],byte[]> pair = Engine.Encryption.GetKeyIVPair(key);
            Engine.Encryption.Key = pair.Item1;
            Engine.Encryption.IV = pair.Item2;
            return this;
        }

        public EncoderFactory SetBackWork(BackgroundWorker bw) {
            Engine.Owner = bw;
            return this;
        }
        public EncoderEngine Finish() {
            if (Engine.Encryption == null)
                Engine.Encryption = new NullEncrypt();
            return Engine;
        }

        private EncoderFactory() { }
    }

    public sealed class DecoderFactory {
        private DecoderEngine Engine { get; set; }

        public static DecoderFactory Create(Methods method) {
            DecoderFactory ef = new DecoderFactory();
            switch (method) {
                case Methods.Metadata:
                    ef.Engine = new MetadataDecoderEngine();
                    break;
                case Methods.DCT:
                    throw new NotImplementedException();
                case Methods.LSB:
                    ef.Engine = new LSBDecoderEngine();
                    break;
            }
            return ef;
        }

        public DecoderFactory OpenOutput(string path) {
            Engine.OutputStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            return this;
        }

        public DecoderFactory OpenCover(string path) {
            Engine.CoverStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return this;
        }

        public DecoderFactory SetCryptography(Encryption crypto) {
            Engine.Encryption = crypto;
            return this;
        }

        public DecoderFactory SetCryptoKey(string key) {
            Tuple<byte[], byte[]> pair = Engine.Encryption.GetKeyIVPair(key);
            Engine.Encryption.Key = pair.Item1;
            Engine.Encryption.IV = pair.Item2;
            return this;
        }

        public DecoderFactory SetDataLength(int len) {
            Engine.DataSize = len;
            return this;
        }

        public DecoderFactory SetBackWork(BackgroundWorker bw) {
            Engine.Owner = bw;
            return this;
        }
        public DecoderEngine Finish() {
            if (Engine.Encryption == null)
                Engine.Encryption = new NullEncrypt();
            return Engine;
        }

        private DecoderFactory() { }
    }


}
