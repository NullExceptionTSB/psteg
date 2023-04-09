// this has been rewritten (i think) 4 times
// so far this is the most readable and best working version
// decoder internally known as jpegmicro as it does only the bare minimum
// needed for steganography

using System;
using System.Collections.Generic;
using System.IO;

using psteg.Huffman;

namespace psteg.Stegano.File.Format {
    public abstract class JpegCommon {
        public enum Marker : ushort {
            //SOF MARKERS
            SOF0 = 0xC0FF,  //baseline dct
            SOF1 = 0xC1FF,  //extended seq dct
            SOF2 = 0xC2FF,  //progressive dct
            SOF3 = 0xC3FF,  //lossless seq 
            DHT = 0xC4FF,   //define huffman table
            SOF5 = 0xC5FF,  //differential seq dct
            SOF6 = 0xC6FF,  //differential prog dct
            SOF7 = 0xC7FF,  //differential seq lossless
            JPG = 0xC8FF,   //jpeg extensions
            SOF9 = 0xC9FF,  //ex seq dct arithmetic
            SOF10 = 0xCAFF, //ex prog dct arithmetic
            SOF11 = 0xCBFF, //loss seq arithmetic
            DAC = 0xCCFF,   //define arithmetic coding
            SOF13 = 0xC9FF, //diff seq dct arithmetic
            SOF14 = 0xCAFF, //diff prog dct arithmetic
            SOF15 = 0xCBFF, //diff loss seq arithmetic
                            //RST MARKERS
            RST0 = 0xD0FF,
            RST1 = 0xD1FF,
            RST2 = 0xD2FF,
            RST3 = 0xD3FF,
            RST4 = 0xD4FF,
            RST5 = 0xD5FF,
            RST6 = 0xD6FF,
            RST7 = 0xD7FF,
            //STATE MARKERS
            SOI = 0xD8FF,   //start of image
            EOI = 0xD9FF,   //end of image
            SOS = 0xDAFF,   //start of scan
            DQT = 0xDBFF,   //define quantization table
            DNL = 0xDCFF,   //define number of lines
            DRI = 0xDDFF,   //define restart interval
            DHP = 0xDEFF,   //define hirearchal progression
            EXP = 0xDFFF,   //expand reference component
                            //APP MARKERS
            APP0 = 0xE0FF,  //JFIF - JPEG image, AVI1 - animated (not supported)
            APP1 = 0xE1FF,  //EXIF, TIFF IFD, JPEG Thumbnail, Adobe XMP
            APP2 = 0xE2FF,  //ICC, FlashPix
            APP3 = 0xE3FF,  //stereoscopic
            APP4 = 0xE4FF,  //reserved
            APP5 = 0xE5FF,  //reserved
            APP6 = 0xE6FF,  //NITF lossless profile
            APP7 = 0xE7FF,  //reserved
            APP8 = 0xE8FF,  //reserved
            APP9 = 0xE9FF,  //reserved
            APP10 = 0xEAFF, //ActiveObject
            APP11 = 0xEBFF, //HELIOS JPEG
            APP12 = 0xECFF, //picture info, photoshop save for web
            APP13 = 0xEDFF, //photoshop IRB, 8BIM, IPTC
            APP14 = 0xEEFF, //reserved
            APP15 = 0xEFFF, //reserved
                            //JPG MARKERS (most decoders don't recognize these)
            JPG0 = 0xF0FF,  //reserved
            JPG1 = 0xF1FF,  //reserved
            JPG2 = 0xF2FF,  //reserved
            JPG3 = 0xF3FF,  //reserved
            JPG4 = 0xF4FF,  //reserved
            JPG5 = 0xF5FF,  //reserved
            JPG6 = 0xF6FF,  //reserved
            JPG7 = 0xF7FF,  //lossless JPEG
            JPG8 = 0xF8FF,  //lossless JPEG extension
            JPG9 = 0xF9FF,  //reserved
            JPG10 = 0xFAFF, //reserved
            JPG11 = 0xFBFF, //reserved
            JPG12 = 0xFCFF, //reserved
            JPG13 = 0xFDFF, //reserved
                            //COMMENT
            COM = 0xFEFF    //comment
        }

        private static readonly byte[] swabuff = new byte[2];
        public static ushort GetBigEndianU16(byte[] arr, int idx) {
            swabuff[0] = arr[idx+1];
            swabuff[1] = arr[idx];
            return BitConverter.ToUInt16(swabuff, 0);
        }
        public static byte[] BigEndianU16ToByte(ushort n) {
            byte[] b = new byte[2];
            byte[] r = BitConverter.GetBytes(n);
            b[0] = r[1];
            b[1] = r[0];
            return b;
        }

        protected internal static readonly byte[] Dezigzag = new byte[] {
                 0,  1,  8, 16,  9,  2,  3, 10,
                17, 24, 32, 25, 18, 11,  4,  5,
                12, 19, 26, 33, 40, 48, 41, 34,
                27, 20, 13,  6,  7, 14, 21, 28,
                35, 42, 49, 56, 57, 50, 43, 36,
                29, 22, 15, 23, 30, 37, 44, 51,
                58, 59, 52, 45, 38, 31, 39, 46,
                53, 60, 61, 54, 47, 55, 62, 63,
            };

        protected internal sealed class HuffmanTable {
            public ushort Length { get; set; }
            public byte Type { get; set; }
            public byte Index { get; set; }
            public byte Selector { get => (byte)((Type<<4)|Index); }

            public byte[] Bits = new byte[17];

            public byte[][] Codes = new byte[17][];
            public Dictionary<Code, int> ValuesDecode;
            public Dictionary<int, Code> ValuesEncode;

            private Tree GenerateHuffmanTree() {
                Tree Root = new Tree { Zero = new Tree(), One = new Tree() };
                Tree[] LevelRoots = new Tree[] { (Tree)Root.Zero, (Tree)Root.One };

                List<Tree> NextLevelRoots = new List<Tree>();
                for (int i = 2; i <= 16; i++) {
                    int level_vals = Codes[i].Length;
                    int level_nodes = LevelRoots.Length * 2;
                    int current_root = 0;

                    for (int j = 0; j < level_nodes; j++) {
                        if ((j % 2 == 0) && j > 0)
                            current_root++;

                        Tree lRoot = LevelRoots[current_root];
                        if (j < level_vals) {
                            if (j%2 == 1)
                                lRoot.One = Codes[i][j];
                            else
                                lRoot.Zero = Codes[i][j];
                        }
                        else {
                            Tree t = new Tree();
                            NextLevelRoots.Add(t);
                            if (j%2 == 1)
                                lRoot.One = t;
                            else
                                lRoot.Zero = t;
                        }
                    }
                    LevelRoots = NextLevelRoots.ToArray();
                    NextLevelRoots.Clear();
                }
                Root.Optimize();
                return Root;
            }

            private void GenerateValuesDictionary(Tree Root, int upper = 0, int depth = 1) {
                int n_upper = upper<<1;

                if (Root.Zero?.GetType() == typeof(Tree))
                    GenerateValuesDictionary((Tree)Root.Zero, n_upper, depth+1);
                else if (Root.Zero != null)
                    ValuesDecode.Add(new Code(depth, n_upper & ~(1)), (byte)Root.Zero);

                if (Root.One?.GetType() == typeof(Tree))
                    GenerateValuesDictionary((Tree)Root.One, n_upper | 1, depth+1);
                else if (Root.One != null)
                    ValuesDecode.Add(new Code(depth, n_upper | 1), (byte)Root.One);
            }

            public HuffmanTable(byte[] section) {
                ValuesDecode = new Dictionary<Code, int>();
                ValuesEncode = new Dictionary<int, Code>();
                Length = GetBigEndianU16(section, 0);

                Type = (byte)(section[2] >> 4);
                Index = (byte)(section[2] & 0x0F);

                if (Type > 1)
                    Console.WriteLine("W: invalid huffman table type");
                if (Index > 3)
                    Console.WriteLine("W: invalid huffman table index");

                const int bits_offset = 3;
                const int codes_offset = bits_offset+16;
                //generate bits table
                for (int i = 1; i <= 16; i++)
                    Bits[i] = section[bits_offset+i-1];
                //generate codes table
                Codes[0] = new byte[0];
                int codes_registered = 0;
                for (int i = 1; i <= 16; i++) {
                    int vals = Bits[i];
                    Codes[i] = new byte[vals];
                    for (int j = 0; j < vals; j++)
                        Codes[i][j] = section[codes_registered+codes_offset+j];
                    codes_registered += Codes[i].Length;
                }
                //generate values table (decoder dictionary)
                Tree Root = GenerateHuffmanTree();
                GenerateValuesDictionary(Root);
                foreach (KeyValuePair<Code, int> kvp in ValuesDecode)
                    ValuesEncode.Add(kvp.Value, kvp.Key);
            }  
        }

        protected internal sealed class QuantizationTable {
            public byte[] Table { get; private set; }
            public byte Index { get; private set; }
            public ushort Length { get; private set; }

            public QuantizationTable(byte[] section) {
                Length = GetBigEndianU16(section, 0);

                if (Length != 67)
                    throw new Exception("DQT length != 67 !!");

                Index = (byte)(section[2] & 0x0F);

                Table = new byte[64];

                for (int i = 0; i < 64; i++)
                    Table[i] = section[i+3];
            }
        }

        protected internal struct SOF0Component {
            public byte ComponentID;
            public byte SamplingFactor;
            public byte QtNumber;
            public SOF0Component(byte id, byte sf, byte qt) {
                ComponentID = id;
                SamplingFactor = sf;
                QtNumber = qt;
            }
        }

        protected internal struct SOSHeader {
            public struct SOSComponent {
                public byte ComponentID;
                public byte TableIndex;
                public SOSComponent(byte id, byte ti) {
                    ComponentID = id;
                    TableIndex = ti;
                }
            }

            public ushort Length;
            public ulong ScanLen;
            public byte ComponentCount;
            public SOSComponent[] ComponentInfo;
            public byte r1, r2, r3;

            public SOSHeader(byte[] data) {
                Length = GetBigEndianU16(data, 0);
                ComponentCount = data[2];
                ComponentInfo = new SOSComponent[ComponentCount];
                for (int i = 3, j = 0; j < ComponentCount; i+=2, j++) {
                    if (i >= data.Length)
                        throw new Exception("Invalid SOS Header");
                    ComponentInfo[j] = new SOSComponent(data[i], data[i+1]);
                }
                r1 = r3 = 0;
                r2 = 0x3F;
                ScanLen = 0;
            }
        }
    }

    public sealed class JpegCodec : JpegCommon {
        private sealed class CoderState {
            private int _imcuPos;

            public int IntraSmpPosition {
                get => _imcuPos;
                set {
                    _imcuPos = value%64;
                    SamplePosition += value/64;
                }
            }

            public int HuffmanTable { get => SmpHufftabs[SamplePosition%SmpPerMcu] | (IsAC ? 0x10 : 0); }

            public int SamplePosition { get; set; }
            public int MCUPosition { get => SamplePosition / SmpPerMcu; }

            public int[] SmpChan { get; set; }
            public int SmpPerMcu { get; set; }
            public int[] SmpHufftabs { get; set; }

            public bool IsAC { get => IntraSmpPosition != 0; }

            public void Reset() {
                SamplePosition = 0;
                IntraSmpPosition = 0;
            }

            public void SetChannelInformation(List<SOF0Component> c, SOSHeader sos) {
                SmpChan = new int[c.Count];
                SmpPerMcu = 0;
                for (int i = 0; i < c.Count; i++) {
                    SmpChan[i] = (c[i].SamplingFactor & 0x0F) * (c[i].SamplingFactor >> 4);
                    SmpPerMcu += SmpChan[i];
                }

                SmpHufftabs = new int[SmpPerMcu];
                int jc = 0;
                for (int i = 0; i < c.Count; i++)
                    for (int j = 0; j < SmpChan[i]; j++, jc++)
                        SmpHufftabs[jc] = sos.ComponentInfo[i].TableIndex&0x0F;
            }
        }

        private Dictionary<int, QuantizationTable> QuantizationTableList { get; set; }
        private Dictionary<int, HuffmanTable> HuffmanTables { get; set; }
        private List<SOSHeader> ScanHeaders { get; set; }
        private List<long> ScanPointers { get; set; }
        private List<long> OutputScanPointers { get; set; }
        private List<SOF0Component> Components { get; set; }

        private BitDecomposer BitDecomposer { get; set; }
        private BitComposer BitComposer { get; set; }

        public int CurrentScan { get; private set; } = -1;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public int ScanCount { get => ScanPointers.Count; }

        public Stream InputStream { get; private set; }
        public Stream OutputStream { get; private set; }

        private CoderState DecState;
        private CoderState EncState;

        #region Marker writing
        private void WriteMarker(Marker m) => OutputStream.Write(BitConverter.GetBytes((ushort)m), 0, 2);
        private void WriteBE16(ushort n) => OutputStream.Write(BigEndianU16ToByte(n), 0, 2);
        //takes parsed markers and copies them into the output stream
        private void WriteQuantTable(QuantizationTable qt) {
            WriteMarker(Marker.DQT);
            WriteBE16(qt.Length);
            OutputStream.WriteByte(qt.Index);
            OutputStream.Write(qt.Table, 0, qt.Table.Length);
        }
        private void WriteHuffTable(HuffmanTable ht) {
            WriteMarker(Marker.DHT);
            WriteBE16(ht.Length);
            OutputStream.WriteByte(ht.Selector);
            for (int i = 1; i <= 16; i++)
                OutputStream.WriteByte(ht.Bits[i]);
            for (int i = 1; i < ht.Codes.Length; i++)
                for (int j = 0; j < ht.Codes[i].Length; j++) 
                    OutputStream.WriteByte(ht.Codes[i][j]);
        }

        private void WriteSOSHeader(SOSHeader sos) {
            WriteMarker(Marker.SOS);
            WriteBE16(sos.Length);
            OutputStream.WriteByte(sos.ComponentCount);
            foreach (SOSHeader.SOSComponent c in sos.ComponentInfo) {
                OutputStream.WriteByte(c.ComponentID);
                OutputStream.WriteByte(c.TableIndex);
            }

            OutputStream.WriteByte(sos.r1);
            OutputStream.WriteByte(sos.r2);
            OutputStream.WriteByte(sos.r3);
        }

        private void WriteSOF0Header() {
            WriteMarker(Marker.SOF0);
            WriteBE16((ushort)(8+3*Components.Count));
            OutputStream.WriteByte(8);
            WriteBE16((ushort)Height);
            WriteBE16((ushort)Width);
            OutputStream.WriteByte((byte)Components.Count);
            foreach (SOF0Component c in Components) {
                OutputStream.WriteByte(c.ComponentID);
                OutputStream.WriteByte(c.SamplingFactor);
                OutputStream.WriteByte(c.QtNumber);
            }
        }

        private void WriteSOSHeader(long position, int index) {
            if (position != -1)
                OutputStream.Seek(position, SeekOrigin.Begin);
            WriteSOSHeader(ScanHeaders[index]);
        }

        public void CloneMarkers() {
            WriteMarker(Marker.SOI);
            //write quantization tables
            foreach (QuantizationTable qt in QuantizationTableList.Values)
                WriteQuantTable(qt);
            //write sof header
            WriteSOF0Header();
            //write huffman tables
            foreach (HuffmanTable ht in HuffmanTables.Values)
                WriteHuffTable(ht);
        }

        #endregion  
        #region Marker parsing
        private void DHT(byte[] DHTSect) {
            HuffmanTable ht = new HuffmanTable(DHTSect);
            HuffmanTables.Add(ht.Selector, ht);
        }

        private void DQT(byte[] DQTsect) {
            QuantizationTable qt = new QuantizationTable(DQTsect);
            QuantizationTableList.Add(qt.Index, qt);
        }

        private void SOF0(byte[] SOF0sect) {
            ushort size = GetBigEndianU16(SOF0sect, 0);

            if (SOF0sect[2] != 0x8)
                throw new Exception("JPEG unsupported (BPP!=8)");

            Width = GetBigEndianU16(SOF0sect, 5);
            Height = GetBigEndianU16(SOF0sect, 3);
            if (SOF0sect[7] != 3) {
                if (SOF0sect[7] == 1)
                    throw new Exception("Greyscale JPEGs not supported");
                else
                    throw new Exception("Invalid component count");
            }

            for (int i = 8; i < size; i+=3) {
                if (i > size)
                    throw new Exception("Invalid SOF0 marker");
                Components.Add(new SOF0Component(SOF0sect[i], SOF0sect[i+1], SOF0sect[i+2]));
            }
        }

        private void SOS(byte[] SOSsect) {
            SOSHeader h = new SOSHeader(SOSsect);

            ScanPointers.Add(InputStream.Position);
            //whoever decided that SOS does not need a marker length field
            //i hope both sides of your pillow are forever warm

            long start = InputStream.Position;
            byte[] buff = new byte[4096];
            bool eom = false;
            bool next_ff = false;

            while (!eom) {
                int read = InputStream.Read(buff, 0, buff.Length);

                for (int i = 0; i < read; i++) {
                    if (next_ff) {
                        next_ff = false;
                        if ((buff[i] >= 0xD0 && buff[i] <= 0xD7) || buff[i] == 0x00)
                            continue;
                        else {
                            eom = true;
                            InputStream.Seek(i-read-1, SeekOrigin.Current);
                            break;
                        }
                    }
                    else if (buff[i] == 0xFF)
                        next_ff = true;
                }
            }
            h.ScanLen = (ulong)(InputStream.Position - start);
            ScanHeaders.Add(h);
        }
        
        private byte[] ReadMarkerAtHead() {
            byte[] window = new byte[2];
            InputStream.Read(window, 0, 2);

            ushort len = GetBigEndianU16(window, 0);
            byte[] marker = new byte[len];

            InputStream.Seek(-2, SeekOrigin.Current);
            InputStream.Read(marker, 0, len);

            return marker;
        }

        private void SkipMarkerAtHead() {
            byte[] window = new byte[2];
            InputStream.Read(window, 0, 2);

            InputStream.Seek(GetBigEndianU16(window, 0)-2, SeekOrigin.Current);
        }

        private void Parse() {
            bool EOI = false;
            byte[] marker_window = new byte[2];
            ushort marker = 0;

            InputStream.Seek(0, SeekOrigin.Begin);

            while (InputStream.Length != InputStream.Position & !EOI) {
                InputStream.Read(marker_window, 0, 2);
                if (marker_window[0] != 0xFF)
                    throw new Exception("Corrupted file structure");

                marker = BitConverter.ToUInt16(marker_window, 0);

                switch (marker) {
                    case (ushort)Marker.SOI:
                        break;
                    case (ushort)Marker.DHT:
                        DHT(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.DQT:
                        DQT(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.SOS:
                        SOS(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.SOF0:
                        SOF0(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.EOI:
                        EOI = true;
                        break;
                    case (ushort)Marker.DAC:
                        throw new Exception("JPEG file not supported (arithmetic coding)");
                    default:
                        Console.WriteLine("W: Skipping section: " + marker.ToString("X4") + "(" + ((Marker)marker).ToString() + ")");
                        goto case (ushort)Marker.COM;
                    case (ushort)Marker.COM:
                        SkipMarkerAtHead();
                        break;
                }

            }
        }
        #endregion
        #region Linter
        //todo: more complete linting
        private void Verify() {
            if (FileID.IdentifyFile(InputStream) != FileFormat.JPEG)
                throw new FormatException("Not a JPEG file");
        }
        #endregion
        #region Scan parser
        public byte[] PreprocessScan(ulong length) {
            byte[] b = new byte[length];

            ulong truesz = 0;

            for (; truesz < length; truesz++) {
                byte d = (byte)InputStream.ReadByte();

                if (d == 0xFF) {
                    if (InputStream.ReadByte() == 0x00)
                        b[truesz] = 0xFF;
                    else
                        break;
                }
                else
                    b[truesz]=d;
            }

            Array.Resize(ref b, (int)truesz);
            return b;
        }

        private string ReportDecoderPos() =>
            $"Scan {CurrentScan} pos {BitDecomposer.TotalBytePosition:X8}.{BitDecomposer.BitPosition} (absolute {BitDecomposer.TotalBytePosition + ScanPointers[CurrentScan]:X8}.{BitDecomposer.BitPosition})";

        public Code? GetNextCode() {
            HuffmanTable ht = HuffmanTables[DecState.HuffmanTable];
            if (BitDecomposer.EOF)
                return null;
            ushort v = (ushort)BitDecomposer.Peek(16);
            bool match = false;
            for (int i = 14; i >= 0; i--) {
                Code vc = new Code(16-i, v>>i);
                if (ht.ValuesDecode.ContainsKey(vc)) {
                    v=(ushort)ht.ValuesDecode[vc];
                    BitDecomposer.Skip(16-i);
                    match = true;
                    break;
                }
            }
            //in case of an invalid huffman code
            if (!match)
                throw new Exception("Invalid huffman value encountered @ " + ReportDecoderPos());

            //AC coefficients are handled differently than DC
            //AC coefficients consist of 2 nibbles
            //0xAB =>   A = how many AC coefficients are to be skipped
            //          B = actual data length
            Code c;
            if (DecState.IsAC) { 
                c = new Code(v, ((v&0xF) > 0) ? ((int)BitDecomposer.Read(v&0xF)) : 0);
                
                switch (v) {
                    case 0x00:
                        DecState.IntraSmpPosition = 0;
                        DecState.SamplePosition++;
                        break;
                    case 0xF0:
                        DecState.IntraSmpPosition += 16;
                        break;
                    default:
                        DecState.IntraSmpPosition += (v>>4) & 0xF;
                        DecState.IntraSmpPosition++;
                        break;
                }
            }
            else { 
                DecState.IntraSmpPosition++;
                c = new Code(v, (int)BitDecomposer.Read(v));
            }
            return c;
        }

        #endregion
        #region Scan writer
        private long _current_write_scan_begin = 0;
        public void WriteNextCode(Code c) {
            Code sc = new Code(EncState.IsAC?(c.Length&0xF):c.Length, c.Value); //short code (code with ZRL masked out)
            HuffmanTable ht = HuffmanTables[EncState.HuffmanTable];

            if (EncState.IsAC) {
                int v = c.Length;
                switch (v) {
                    case 0x00:
                        EncState.IntraSmpPosition = 0;
                        EncState.SamplePosition++;
                        break;
                    case 0xF0:
                        EncState.IntraSmpPosition += 16;
                        break;
                    default:
                        EncState.IntraSmpPosition += (v>>4) & 0xF;
                        EncState.IntraSmpPosition++;
                        break;
                }
            }
            else
                EncState.IntraSmpPosition++;

            BitComposer.Write(ht.ValuesEncode[c.Length]);
            if (sc.Length > 0)
                BitComposer.Write(sc);

        }
        public void CopyRestOfScan() {
            while (!BitDecomposer.EOF) {
                Code c = (Code)GetNextCode();
                WriteNextCode(c);
            }
            if (CurrentScan == ScanCount-1)
                WriteMarker(Marker.EOI);
        }
        #endregion
        #region Control
        public void SetScanRead(int scan_id) {
            if (scan_id >= ScanCount)
                throw new ArgumentException("Invalid scan");
            CurrentScan = scan_id;
            //reset coder states
            if (DecState == null)
                DecState = new CoderState();
            
            DecState.Reset();
            DecState.SetChannelInformation(Components, ScanHeaders[scan_id]);

            
            //reset bitdecomposer
            BitDecomposer?.Dispose();

            InputStream.Seek(ScanPointers[scan_id], SeekOrigin.Begin);
            byte[] sd = PreprocessScan(ScanHeaders[scan_id].ScanLen);

            BitDecomposer = new BitDecomposer(new MemoryStream(sd), true);

        }

        public void InitScanWrite() {
            if (CurrentScan == -1)
                throw new Exception("Scan reader not open, can't set scan parameters");

            if (EncState == null)
                EncState = new CoderState();

            EncState.Reset();
            EncState.SetChannelInformation(Components, ScanHeaders[CurrentScan]);

            _current_write_scan_begin = OutputStream.Position + ScanHeaders[CurrentScan].Length;
            OutputScanPointers.Add(OutputStream.Position);

            BitComposer?.Dispose();
            BitComposer = new BitComposer(OutputStream);

            WriteSOSHeader(ScanHeaders[CurrentScan]);
        }

        public void CloseScanWrite() {
            long len = OutputStream.Position - _current_write_scan_begin;

            if (len <= int.MaxValue) { //if file <= 2GB, do it in memory
                byte[] scan = new byte[len];
                OutputStream.Seek(_current_write_scan_begin, SeekOrigin.Begin);
                OutputStream.Read(scan, 0, (int)len);
                OutputStream.Seek(-len, SeekOrigin.Current);

                for (int i = 0; i < scan.Length; i++) {
                    OutputStream.WriteByte(scan[i]);
                    if (scan[i] == 0xFF)
                        OutputStream.WriteByte(0x00);
                }

                WriteMarker(Marker.EOI);
            }
            else {
                string temp = Path.GetTempFileName();
                throw new NotImplementedException("JPEG file too big, tempfile not implemented");
            }

        }

        public bool IsCodeSpecial(Code c) {
            switch (c.Value) {
                case 0x00:
                case 0xF0:
                    return true;
                default:
                    return false;
            }
        }
        #endregion

        private void InitializeWriter() {
            OutputScanPointers = new List<long>();
            CloneMarkers();
        }

        public JpegCodec(Stream Input, Stream Output) {
            InputStream = Input;
            if (!Input.CanSeek)
                throw new Exception("Input stream must be seekable");
            OutputStream = Output;

            HuffmanTables = new Dictionary<int, HuffmanTable>();
            QuantizationTableList = new Dictionary<int, QuantizationTable>();
            ScanPointers = new List<long>();
            ScanHeaders = new List<SOSHeader>();
            Components = new List<SOF0Component>();

            Verify();
            Parse();

            InitializeWriter();
        }
    }
}