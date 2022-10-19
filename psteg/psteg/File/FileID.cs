using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace psteg.File {
    public enum FileType {
        LosslessAudio, LosslessImage, Jpeg, Other
    }
    public static class FileID {
        public static ImageFormat DefaultImageFormat = ImageFormat.Png;

        public static ImageFormat PathToFormat(string path) {
            FileInfo fi = new FileInfo(path);
            switch (fi.Extension) {
                case ".png":
                    return ImageFormat.Png;
                case ".gif":
                    return ImageFormat.Gif;
                case ".tif":
                case ".tiff":
                    return ImageFormat.Tiff;
                case ".jpeg":
                case ".jpg":
                case ".jfif":
                case ".jpe":
                    return ImageFormat.Jpeg;
                case ".bmp":
                case ".dib":
                    return ImageFormat.Bmp;
            }
            return DefaultImageFormat;
        }
        public static FileType IdentifyFile(Stream fileStream) {
            byte[] magic = new byte[16];
            fileStream.Read(magic, 0, 16);
            fileStream.Seek(0, SeekOrigin.Begin);

            byte[] smallmagic = new byte[4];
            for (int i = 0; i < 4; i++) smallmagic[i] = magic[i];

            //if (BitConverter.IsLittleEndian)
            //    Array.Reverse(smallmagic);

            ushort twobyteMagic = BitConverter.ToUInt16(smallmagic, 2);
            uint fourbyteMagic = BitConverter.ToUInt32(smallmagic, 0);

            switch (twobyteMagic) {
                case 0x4D42: //BM - DIB BMP
                    return FileType.LosslessImage;
            }

            switch (fourbyteMagic) {
                case 0x474E5089U: //‰PNG - PNG (TECHNICALLY INCORRECT)
                    return FileType.LosslessImage;
                case 0x46464952U: //RIFF - RIFF Container formats, may be WAVE
                    for (int i = 0; i < 4; i++) smallmagic[i] = magic[i+8];
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(smallmagic);
                    fourbyteMagic = BitConverter.ToUInt32(smallmagic, 0);

                    if (fourbyteMagic == 0x45564157)
                        return FileType.LosslessAudio; //RIFF - WAVE
                    break;
                case 0xE0FFD8FFU: //JPEG - JPEG
                    return FileType.Jpeg;
                case 0x38464947U: //GIF8 - GIF (TECHNICALLY INCORRECT)
                    return FileType.LosslessImage; 
            }

            byte?[,] jpegMagics = new byte?[,] { { 0xFF, 0xD8,  0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01}, 
                                                 { 0xFF, 0xD8, 0xFF, 0xE1, null, null, 0x45, 0x78, 0x69, 0x66, 0x00, 0x00} };
            bool matches = true;
            for (int i = 0; i < jpegMagics.GetLength(0); i++) { 
                for (int j = 0; j < Math.Min(jpegMagics.GetLength(1), 16); j++)
                    if (jpegMagics[i,j] != magic[j] && jpegMagics[i,j] != null) {
                        matches = false;
                        break;
                    }
                if (matches) return FileType.Jpeg;
            }


            return FileType.Other;
        }

        public static long GetNumBlocks(FileType type, FileStream streamSz) {
            switch (type) {
                case FileType.LosslessImage:
                    Bitmap b = new Bitmap(streamSz.Name);
                    long bcount = b.Width * b.Height * 4;
                    b.Dispose();
                    return bcount;
                default: return 0;
            }
        }
    }
}
