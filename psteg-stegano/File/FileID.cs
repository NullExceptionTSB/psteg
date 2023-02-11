using System;
using System.Drawing;
using System.IO;

namespace psteg.Stegano.File {
    public enum FileFormat {
        JPEG, BMP, PNG, TIFF, GIF, WAV, FLAC, MP4, Unknown
    }
    public class FileID {
        public bool Valid { get; protected set; } = true;
        public virtual FileFormat FileFormat { get => FileFormat.Unknown; }

        public override string ToString() => "File Type: " + FileFormat.ToString();

        public static FileFormat IdentifyFile(Stream file) {
            byte[] magic = new byte[16];

            long current_position = file.Position;
            file.Seek(0, SeekOrigin.Begin);
            file.Read(magic, 0, 16);
            file.Seek(current_position, SeekOrigin.Begin);

            byte[] smallmagic = new byte[4];
            for (int i = 0; i < 4; i++)
                smallmagic[i] = magic[i];

            //if (BitConverter.IsLittleEndian)
            //    Array.Reverse(smallmagic);

            ushort twobyteMagic = BitConverter.ToUInt16(smallmagic, 0);
            uint fourbyteMagic = BitConverter.ToUInt32(smallmagic, 0);

            switch (twobyteMagic) {
                case 0xD8FF: //deduced, more accurate
                    return FileFormat.JPEG;
                case 0x4D42: //BM - DIB BMP
                    return FileFormat.BMP;
            }

            switch (fourbyteMagic) {
                case 0x474E5089U: //‰PNG - PNG (TECHNICALLY INCORRECT)
                    return FileFormat.PNG;
                case 0x46464952U: //RIFF - RIFF Container formats, may be WAVE
                    for (int i = 0; i < 4; i++)
                        smallmagic[i] = magic[i+8];

                    fourbyteMagic = BitConverter.ToUInt32(smallmagic, 0);

                    if (fourbyteMagic == 0x45564157)
                        return FileFormat.WAV; //RIFF - WAVE
                    break;
                case 0x2A004D4DU:
                case 0x002A4949U:
                    return FileFormat.TIFF;
                case 0xE0FFD8FFU: //JPEG - JPEG
                    return FileFormat.JPEG;
                    /*
                case 0x20000000U:
                    break;
                    */
                case 0x38464947U: //GIF8 - GIF (TECHNICALLY INCORRECT)
                    return FileFormat.GIF;
            }

            fourbyteMagic = BitConverter.ToUInt32(magic, 4);
            if (fourbyteMagic == 0x70797466U)
                return FileFormat.MP4;

            return FileFormat.Unknown;
        }

        public virtual bool IsSupported() => true;

        public static FileID New(Stream file) {
            FileFormat format = IdentifyFile(file);
            switch (format) {
                case FileFormat.MP4:
                    return new MP4FileID();
                case FileFormat.JPEG:
                    return new JpegFileID(file);
                case FileFormat.PNG:
                    return new PngFileID(file);
                case FileFormat.BMP:
                    return new BmpFileID(file);
                case FileFormat.GIF:
                    return new GifFileID(file);
                case FileFormat.TIFF:
                    return new TiffFileID(file);
                case FileFormat.WAV:
                    return new WavFileID(file);
            }
            return new FileID();
        }

        protected FileID() { }
    }

    public class ImageFileID : FileID {
        public uint Width { get; protected set; }
        public uint Height { get; protected set; }
        public bool HasAlpha { get; protected set; }
        public bool SupportsAlpha { get; protected set; }

        protected ImageFileID(Stream file) { }
        public override string ToString() =>
            base.ToString() + $"\nWidth: {Width}\nHeight: {Height}\nSupportsAlpha: {SupportsAlpha.ToString()}";
    }

    public class AudioFileID : FileID {
        public virtual int SampleSize { get; protected set; }
        public virtual int SampleRate { get; protected set; }
        public virtual int Channels { get; protected set; }

        protected AudioFileID(Stream file) { }
        public override string ToString() =>
            base.ToString() + $"\nSample Rate: {SampleRate}\nSample Size: {SampleSize}\nChannel Count: {Channels}";
        
    }

    public sealed class MP4FileID : FileID {
        public override FileFormat FileFormat => FileFormat.MP4;
    }

    public sealed class JpegFileID : ImageFileID {
        public override FileFormat FileFormat => FileFormat.JPEG;
        public JpegFileID(Stream file) : base(file) {
            try {
                Bitmap b = new Bitmap(file);
                Width = (uint)b.Width;
                Height = (uint)b.Height;
                SupportsAlpha = HasAlpha = true;
                b.Dispose();
            }
            catch {
                Valid = false;
            }
        }
    }
    public sealed class PngFileID : ImageFileID{
        public override FileFormat FileFormat => FileFormat.PNG;
        public PngFileID(Stream file) : base(file) {
            try { 
                Bitmap b = new Bitmap(file);
                Width = (uint)b.Width;
                Height = (uint)b.Height;
                SupportsAlpha = HasAlpha = true;
                b.Dispose();
            } catch {
                Valid = false;
            }
        }
    }
    public sealed class TiffFileID : ImageFileID {
        public override FileFormat FileFormat => FileFormat.TIFF;
        public TiffFileID(Stream file) : base(file) {
            try {
                Bitmap b = new Bitmap(file);
                Width = (uint)b.Width;
                Height = (uint)b.Height;
                SupportsAlpha = HasAlpha = true;
                b.Dispose();
            }
            catch {
                Valid = false;
            }
        }
    }
    public sealed class BmpFileID : ImageFileID {
        public override FileFormat FileFormat => FileFormat.BMP;
        public ushort Planes { get; private set; }
        public Compression CompressionMethod { get; private set; }

        public uint XDPI { get; private set; }
        public uint YDPI { get; private set; }

        public enum Compression : uint {
            BI_RGB, BI_RLE8, BI_RLE4
        }

        public BmpFileID(Stream file) : base(file) {
            long pos = file.Position;
            byte[] buffer = new byte[4];
            uint db;
            SupportsAlpha = true;

            file.Seek(18, SeekOrigin.Begin);

            file.Read(buffer, 0, 4);
            Width = BitConverter.ToUInt32(buffer, 0);

            file.Read(buffer, 0, 4);
            Height = BitConverter.ToUInt32(buffer, 0);

            file.Read(buffer, 0, 2);
            Planes = BitConverter.ToUInt16(buffer, 0);

            file.Read(buffer, 0, 2);
            HasAlpha = BitConverter.ToUInt16(buffer, 0) == 32;

            file.Read(buffer, 0, 4);
            db = BitConverter.ToUInt32(buffer, 0);
            Valid &= Enum.IsDefined(typeof(Compression), db);
            if (Valid)
                CompressionMethod = (Compression)db;
            else
                CompressionMethod = Compression.BI_RGB;

            file.Read(buffer, 0, 4);
            db = BitConverter.ToUInt32(buffer, 0);

            switch (CompressionMethod) {
                case Compression.BI_RLE4:
                case Compression.BI_RLE8:
                    Valid &= db > 0;
                    break;
            }

            file.Read(buffer, 0, 4);
            XDPI = BitConverter.ToUInt32(buffer, 0);

            file.Read(buffer, 0, 4);
            YDPI = BitConverter.ToUInt32(buffer, 0);

            file.Seek(pos, SeekOrigin.Begin);
        }
        public override string ToString() =>
            base.ToString() + $"\nPlanes: {Planes}\nCompressionMethod: {CompressionMethod.ToString()}\nXDPI: {XDPI}\nYDPI: {YDPI}";
    }
    public sealed class GifFileID : ImageFileID {
        public override FileFormat FileFormat => FileFormat.GIF;
        public GifFileID(Stream file) : base(file) {
            long pos = file.Position;
            byte[] buffer = new byte[4];
            file.Seek(6, SeekOrigin.Begin);
            file.Read(buffer, 0, 2);
            file.Read(buffer, 2, 2);

            Width = BitConverter.ToUInt16(buffer, 0);
            Height = BitConverter.ToUInt16(buffer, 2);

            HasAlpha = SupportsAlpha = true;

            file.Seek(pos, SeekOrigin.Begin);
        }
    }

    public sealed class WavFileID : AudioFileID {
        private Format.RIFFWAV.WaveFormat wavefmt;
        public override FileFormat FileFormat => FileFormat.WAV;
        public Format.RIFFWAV.FormatTag SampleType { get => wavefmt.wFormatTag; }
        public override int SampleSize { get => wavefmt.wBitsPerSample; }
        public override int SampleRate { get => (int)wavefmt.dwSampleRate; }
        public override int Channels { get => wavefmt.nChannels; }

        public override bool IsSupported() => 
            (SampleType == Format.RIFFWAV.FormatTag.PCM && Channels < 3);

        public override string ToString() =>
            base.ToString() + $"\nSample Type: {SampleType.ToString()}";

        public WavFileID(Stream file) : base(file) {
            long fmtoffset;

            Valid = Format.RIFFWAV.IsValid((FileStream)file, out fmtoffset, out _);
            if (!Valid)
                return;
            if (fmtoffset == 0)
                throw new Exception("bababooey");

            file.Seek(fmtoffset+4, SeekOrigin.Begin);
            byte[] fmtb = new byte[20];
            file.Read(fmtb, 0, 20);
            wavefmt = new Format.RIFFWAV.WaveFormat(fmtb);
        }
    }
}
