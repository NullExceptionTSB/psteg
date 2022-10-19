using System;
using System.IO;
using System.Windows.Forms;

using psteg.File.Image;

namespace psteg.File {
    public abstract class StegFile : IDisposable {
        public abstract FileType FileType { get; }
        public FileStream Stream { get; protected set; }
        public long Size { get; protected set; }
        public string Path { get; set; }

        //public long IOBlockSize { get; set; } = 512;

        public abstract Stream GetRawData();
        public abstract byte[] GetRawData(long ammount);
        public abstract void SetRawData(Stream data);
        public abstract void SetRawData(byte[] data);

        public static StegFile Open(string path) {
            try { 
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                FileType fileType = FileID.IdentifyFile(fileStream);
                switch (fileType) {
                    case FileType.LosslessImage:
                        return new LosslessImg(fileStream);
                    default: return new FileRaw(fileStream);
                }
            } 
            catch (Exception ex) {
                MessageBox.Show($"StegFile.Open failed: {ex.Message}", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static StegFile Create(string path, FileType type) {
            try {
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                switch (type) {
                    case FileType.LosslessImage:
                        return new LosslessImg(fileStream);
                    default: return new FileRaw(fileStream);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"StegFile.Open failed: {ex.Message}", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void Dispose() {
            Stream.Close();
            Stream.Dispose();
        }
    }
}
