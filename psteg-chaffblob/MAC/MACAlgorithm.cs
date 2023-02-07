using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg_chaffblob.MAC {
    public abstract class MACAlgorithm : IDisposable {
        public virtual byte[] Key { get; set; }
        public abstract int MACSize { get; }
        public virtual void SetKey(string pwd) => Key = Encoding.UTF8.GetBytes(pwd);
        public abstract byte[] ComputeHash(byte[] data);
        public abstract void Dispose();
    }
}
