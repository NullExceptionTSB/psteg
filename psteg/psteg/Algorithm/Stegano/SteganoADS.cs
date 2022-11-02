using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using psteg.File;
using psteg.UI.SettingsForms.Stegano;


namespace psteg.Algorithm.Stegano {
    public sealed class SteganoADS : WinternalSteganoAlgorithm {
        public static int ProgressReportDelay = 50;

        public static string AlgoDisplayName { get { return "Alternate Data Stream (ADS)"; } }

        public override StegMethod MethodEnum { get { return StegMethod.ADS; } }
        public override string DisplayName { get { return AlgoDisplayName; } }
        public override FileType[] SupportedFileTypes { get { return (FileType[])Enum.GetValues(typeof(StegMethod)); } }
        public override Form SettingsForm { get { return new ADSSettings(this); } }

        public string StreamName { get; set; } = "SteganoStream";

        private void EncodeSingle(StegFile container) {
            Task tCopyAsync = container.Stream.CopyToAsync(EncodedData);
            while (!tCopyAsync.IsCompleted) {
                WorkerReport(1, new Tuple<long, long>(container.Stream.Position, container.Stream.Length + RawData.Length));
                Thread.Sleep(ProgressReportDelay);
            }
            tCopyAsync.Wait();

            EncodedData.Seek(0, SeekOrigin.Begin);
            container.Stream.Seek(0, SeekOrigin.Begin);

            FileStream fs = new FileStream(CreateFileW(EncodedPath + ":" + StreamName, FileAccess.ReadWrite, FileShare.ReadWrite,
                    IntPtr.Zero, FileMode.Create, FileAttributes.Normal, IntPtr.Zero), FileAccess.ReadWrite);

            try {
                tCopyAsync = RawData.CopyToAsync(fs);
                while (!tCopyAsync.IsCompleted) {
                    WorkerReport(1, new Tuple<long, long>(container.Stream.Position + RawData.Position, container.Stream.Length + RawData.Length));
                    Thread.Sleep(ProgressReportDelay);
                }
                WorkerReport(1, new Tuple<long, long>(container.Stream.Position + RawData.Position, container.Stream.Length + RawData.Length));
                tCopyAsync.Wait();

                fs.SafeFileHandle.Close();
                //fs.SafeFileHandle.Dispose(); explodes
                fs.Close();
                fs.Dispose();
            } catch (Exception e) { throw new Exception("File access error: " + e.Message, e); }
        }

        private void DecodeSingle(StegFile container) {
            FileStream fs = new FileStream(CreateFileW(container.Path + ":" + StreamName, FileAccess.ReadWrite, FileShare.ReadWrite,
                IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero), FileAccess.ReadWrite);

            try {
                Task tCopyAsync = fs.CopyToAsync(RawData);
                while (!tCopyAsync.IsCompleted) {
                    WorkerReport(1, new Tuple<long, long>(fs.Position, fs.Length));
                    Thread.Sleep(ProgressReportDelay);
                }
                WorkerReport(1, new Tuple<long, long>(fs.Position, fs.Length));
                tCopyAsync.Wait();

                fs.SafeFileHandle.Close();
                fs.Close();
                fs.Dispose();
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
    }
}
