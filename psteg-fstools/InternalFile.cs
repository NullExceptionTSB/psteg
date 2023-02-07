using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace psteg_fstools {
    public sealed class InternalFile : IDisposable{
        public IntPtr Handle { get; private set; }

        public InternalFile(string path) {
            IntPtr h = IntPtr.Zero;
            h = Internals.CreateFileW(path, 0x80, 0x3, IntPtr.Zero, 3, 0, IntPtr.Zero);
            if (h == IntPtr.Zero)
                throw new Exception("Access failed, code " + Convert.ToString(Marshal.GetLastWin32Error(), 16));
        }

        public string[] ListStreams() {
            return null;
        }

        public void Dispose() =>
            Internals.NtClose(Handle);
    }
}
