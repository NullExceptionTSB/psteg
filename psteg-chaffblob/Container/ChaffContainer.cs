using System;
using System.Collections.Generic;
using System.ComponentModel;

using psteg.Crypto;
using psteg_chaffblob.MAC;
using psteg_chaffblob.MAC.Net;

namespace psteg_chaffblob.Container {
    public abstract class ChaffContainer : IDisposable, IReports {
        public ushort BlockSize { get => 512; }
        protected static class KnownMagicNumbers {
            public const uint Chaffblock = 0x0BB7FFCA; //0xCAFFB70B
        }

        public MACAlgorithm MACAlgorithm { get; set; }
        public Encryption CryptoAlgorithm { get; set; }

        public BackgroundWorker ReportsTo { get; set; }

        protected static Dictionary<Type, byte> MacMap = new Dictionary<Type, byte> {
            { typeof(MD5HMAC),    0x10 },
            { typeof(SHA1HMAC),   0x11 },
            { typeof(SHA256HMAC), 0x12 },
            { typeof(SHA512HMAC), 0x13 }
        };
        protected static Dictionary<Type, byte> CryptMap = new Dictionary<Type, byte> {
            { typeof(NullEncrypt), 0x00 },
            { typeof(AES256), 0x10 }
        };
        protected static MACAlgorithm GetMacById(byte id) {
            Type t = Type.Missing.GetType();
            foreach (KeyValuePair<Type, byte> kvp in MacMap)
                if (kvp.Value == id) {
                    t = kvp.Key;
                    break;
                }
            if (t == Type.Missing.GetType())
                return null;
            return (MACAlgorithm)t.GetConstructor(Type.EmptyTypes).Invoke(null);
        }
        protected static Encryption GetEncryptionById(byte id) {
            Type t = Type.Missing.GetType();
            foreach (KeyValuePair<Type, byte> kvp in CryptMap)
                if (kvp.Value == id) {
                    t = kvp.Key;
                    break;
                }
            if (t == Type.Missing.GetType())
                return null;
            return (Encryption)t.GetConstructor(Type.EmptyTypes).Invoke(null);
        }
        public void ReportProgress(long curr, long max, string state) => ReportsTo.ReportProgress(1, new Tuple<long, long, string>(curr, max, state));

        protected struct ChaffBlobHeader {
            public uint Magic;
            public uint BlockTotal;
            public ushort BlockSize;
            public byte MacAlgorithm;
            public byte CryptoAlgorithm;

            public ChaffBlobHeader(byte[] fromBytes) {
                Magic = BitConverter.ToUInt32(fromBytes, 0);
                BlockTotal = BitConverter.ToUInt32(fromBytes, 4);
                BlockSize = BitConverter.ToUInt16(fromBytes, 8);
                MacAlgorithm = fromBytes[10];
                CryptoAlgorithm = fromBytes[11];
            }

            public byte[] GetData() {
                byte[] data = new byte[12];
                BitConverter.GetBytes(Magic).CopyTo(data, 0);
                BitConverter.GetBytes(BlockTotal).CopyTo(data, 4);
                BitConverter.GetBytes(BlockSize).CopyTo(data, 8);
                data[10] = MacAlgorithm;
                data[11] = CryptoAlgorithm;
                return data;
            }
        }
        public abstract void Dispose();

        protected ChaffContainer(Encryption encrypt, MACAlgorithm macalgo) {
            MACAlgorithm = macalgo;
            CryptoAlgorithm = encrypt;
        }
    }
}
