using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.Win32.SafeHandles;

namespace psteg.Algorithm {
    public abstract class WinternalSteganoAlgorithm : SteganoAlgorithm {
        //function signature from pinvoke.net @ https://www.pinvoke.net/default.aspx/kernel32.CreateFile
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        protected internal static extern SafeFileHandle CreateFileW(
            string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile
        );

        [DllImport("kernel32.dll")]
        protected internal static extern int GetLastError();

        public WinternalSteganoAlgorithm() : base() {
            MessageBox.Show("WARNING! This algorithm only reliably works on Microsoft Windows and may crash on other systems (running under mono). It will also not work on non-NTFS file systems as it utilises its features.", 
                "Compatibility Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
