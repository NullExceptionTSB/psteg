using System;
using System.Text;

namespace psteg.Chaffblob.MAC {
    public abstract class MACAlgorithm : IDisposable {
        public virtual byte[] Key { get; set; }
        public abstract int MACSize { get; }
        public virtual void SetKey(string pwd) => Key = Encoding.UTF8.GetBytes(pwd);
        public abstract byte[] ComputeHash(byte[] data);
        public abstract void Dispose();
    }
}
