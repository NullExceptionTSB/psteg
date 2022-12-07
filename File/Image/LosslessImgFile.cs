using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace psteg.File.Image {
    public class LosslessImgFile : StegFile {
        private Rectangle bmpRect;
        private Bitmap bmp;

        public static bool RowFirst = true;
        public override FileType FileType { get { return FileType.LosslessImage; } }
        public bool Ready { get { return bmp != null; } }
        public Size Resolution { get; private set; }
        #region data reading
        public override Stream GetRawData() {
            if (bmp == null)
                return null;
            MemoryStream ms = new MemoryStream();
            //lockbits, while technically unsafe, is much faster than using GetPixel
            BitmapData bdata = bmp.LockBits(bmpRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            if (!RowFirst) { 
                for (int x = 0; x < bdata.Width; x++)
                    for (int y = 0; y < bdata.Height; y++) {
                        byte a, r, g, b;
                        long pxOffset = (4 * x) + (y * bdata.Stride);
                        unsafe {
                            byte* pxStart = (byte*)bdata.Scan0.ToPointer() + pxOffset;
                            b = pxStart[0];
                            g = pxStart[1];
                            r = pxStart[2];
                            a = pxStart[3];
                        }
                        ms.WriteByte(b);
                        ms.WriteByte(g);
                        ms.WriteByte(r);
                        ms.WriteByte(a);
                    }
            }
            else {
                for (int y = 0; y < bdata.Height; y++)
                    for (int x = 0; x < bdata.Width; x++) {
                        byte a, r, g, b;
                        long pxOffset = (4 * x) + (y * bdata.Stride);
                        unsafe {
                            byte* pxStart = (byte*)bdata.Scan0.ToPointer() + pxOffset;
                            b = pxStart[0];
                            g = pxStart[1];
                            r = pxStart[2];
                            a = pxStart[3];
                        }
                        ms.WriteByte(b);
                        ms.WriteByte(g);
                        ms.WriteByte(r);
                        ms.WriteByte(a);
                    }
            }
            bmp.UnlockBits(bdata);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
        //warning! buffers larger than 4GB are NOT SUPPORTED by C#!
        //hence, this function will throw if this limit is broken
        public override byte[] GetRawData(long ammount) {
            if (ammount > Int32.MaxValue)
                throw new InternalBufferOverflowException("Too much data to read");

            Stream str = GetRawData();
            byte[] data = new byte[ammount];
            str.Read(data, 0, (int)Math.Min(str.Length, ammount));
            str.Close();
            str.Dispose();
            return data;
        }
        #endregion
        #region data writing
        public override void SetRawData(byte[] data) {
            BitmapData bdata = bmp.LockBits(bmpRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int dataidx = 0;
            if (!RowFirst) {
                for (int x = 0; x < bdata.Width; x++) for (int y = 0; y < bdata.Height; y++) {
                        long pxOffset = (4 * x) + (y * bdata.Stride);
                        unsafe {
                            byte* pxStart = (byte*)bdata.Scan0.ToPointer() + pxOffset;
                            for (int i = 0; i < 4; i++)
                                pxStart[i] = data[dataidx++];
                        }
                    }
            }
            else {
                for (int y = 0; y < bdata.Height; y++) for (int x = 0; x < bdata.Width; x++) {
                        long pxOffset = (4 * x) + (y * bdata.Stride);
                        unsafe {
                            byte* pxStart = (byte*)bdata.Scan0.ToPointer() + pxOffset;
                            for (int i = 0; i < 4; i++)
                                pxStart[i] = data[dataidx++];
                        }
                    }
            }
            bmp.UnlockBits(bdata);
            bmp.Save(Stream, string.IsNullOrEmpty(Path) ? bmp.RawFormat : ImageFormat.Png);
        }
        public override void SetRawData(Stream data) {
            int sz = (int)data.Length;
            byte[] sdata = new byte[sz];
            data.Read(sdata, 0, sz);
            SetRawData(sdata);
        }
        #endregion

        public LosslessImgFile(FileStream fileStream) {
            Path = fileStream.Name;
            Stream = fileStream;
            try {
                bmp = new Bitmap(fileStream);
                bmpRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                Resolution = bmp.Size;
                Size = bmp.Width * bmp.Height * 4;
            } 
            catch {
                bmp = null;
                bmpRect = Rectangle.Empty;
                Resolution = new Size(0, 0);
                Size = 0;
            }
        }

        public LosslessImgFile(FileStream fileStream, Size size) {
            Path = fileStream.Name;
            Stream = fileStream;
            bmp = new Bitmap(size.Width, size.Height);
            bmpRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Resolution = size;
            Size = bmp.Width * bmp.Height * 4;
        }

        public void NewBitmap(Size size) {
            bmp = new Bitmap(size.Width, size.Height);
            bmpRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Resolution = bmp.Size;
            Size = bmp.Width * bmp.Height * 4;
        }

        ~LosslessImgFile() {
            bmp?.Dispose();
            Stream?.Close();
            Stream?.Dispose();
        }
    }
}
