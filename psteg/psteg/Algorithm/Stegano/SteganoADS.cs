using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

using psteg.File;
using psteg.UI.SettingsForms.Stegano;


namespace psteg.Algorithm.Stegano {
    internal static class AdsInternal {
        //function signature from pinvoke.net @ https://www.pinvoke.net/default.aspx/kernel32.CreateFile
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern SafeFileHandle CreateFileW(
            [MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile);
    }

    public sealed class SteganoADS : SteganoAlgorithm {
        public override StegMethod MethodEnum { get { return StegMethod.ADS; } }
        public static string AlgoDisplayName { get { return "Alternate Data Stream (ADS)"; } }
        public override string DisplayName { get { return AlgoDisplayName; } }
        public override FileType[] SupportedFileTypes { get { return (FileType[])Enum.GetValues(typeof(StegMethod)); } }
        public override Form SettingsForm { get { return new ADSSettings(this); } }

        public string StreamName { get; set; } = "SteganoStream";

        public override long CalculateCapacity(long ContainerSize) {
            return -1;
        }

        private void EncodeSingle(StegFile container) {
            container.Stream.CopyTo(EncodedData);
            EncodedData.Seek(0, SeekOrigin.Begin);

            SafeFileHandle Handle = AdsInternal.CreateFileW(EncodedPath + ":" + StreamName, FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Create, FileAttributes.Normal, IntPtr.Zero);
            FileStream fs = new FileStream(Handle, FileAccess.ReadWrite);

            try {
                RawData.CopyTo(fs);

                fs.Close();
                fs.Dispose();
                Handle.Close();
                Handle.Dispose();
            } catch (Exception e) { throw new Exception("File access error: " + e.Message, e); }
        }

        private void DecodeSingle(StegFile container) {
            try {
                using (FileRaw data = new FileRaw(new FileStream(EncodedPath+ ":" + StreamName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))) {
                    RawData.CopyTo(data.Stream);
                }
            } catch (Exception e) { throw new Exception("File access error: " + e.Message, e); }
        }

        public override void Encode() {
            if (Containers.Count == 1)
                EncodeSingle(Containers[0]);
            else
                throw new NotImplementedException();
        }

        public override void Decode() {
            if (Containers.Count == 1)
                DecodeSingle(Containers[0]);
            else
                throw new NotImplementedException();
        }

        public SteganoADS() {
            MessageBox.Show("WARNING! This algorithm only reliably works on Microsoft Windows and may crash on other systems (running under mono). It will also not work on non-NTFS file systems as it utilises its features.", "Compatibility Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
