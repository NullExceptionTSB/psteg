﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Stegano.File.Format {
    public abstract class Jpeg {
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

        //todo: refactor this warcrime (again)
        protected internal sealed class HuffmanTable {
            public ushort Length { get; set; }
            public byte Type { get; set; }
            public byte Index { get; set; }

            public byte[] ValueOrder;

            public int[] ValPtr = new int[17];
            public int[] MinCode = new int[17];
            public int[] MaxCode = new int[17];

            public byte[] Bits = new byte[17];

            public int[] Sizes = new int[257];
            public int[] Codes = new int[257];
            public int[] OrderedSizes = new int[257];
            public int[] OrderedCodes = new int[257];
            //sorry, my children. for i have failed to bring you salvation from this cold, dark world.
            public HuffmanTable(byte[] section) {
                Length = GetBigEndianU16(section, 0);

                Type = (byte)(section[3] >> 4);
                Index = (byte)(section[3] & 0x0F);

                if (Type > 1)
                    Console.WriteLine("W: invalid huffman table type");
                if (Index > 3)
                    Console.WriteLine("W: invalid huffman table index");

                int ValueCount = 0;
                for (int i = 1; i <= 16; i++) { 
                    Bits[i] = section[2+i];
                    ValueCount+= Bits[i];
                }
                if (ValueCount > 19+section.Length)
                    throw new Exception("Invalid DHT section");

                ValueOrder = new byte[ValueCount];
                for (int i = 0; i < ValueCount; i++)
                    ValueOrder[i] = section[19 + i];

                int lastk;
                //my mango is to blow up
                //Figure C.1 translated from flowchart to code like a troglodyte
                { 
                    int k = 0, i = 1, j = 1;

                    do {
                        while (!(j>Bits[i])) {
                            Sizes[k] = i;
                            k++;
                            j++;
                        }
                        i++;
                        j=1;
                    } while (!(i > 16));
                    Sizes[k] = 0;
                    lastk = k;
                }

                //Figure C.2
                {
                    int k = 0, code = 0, si = Sizes[0];
                    do {
                        do {
                            Codes[k] = code;
                            code++;
                            k++;
                        } while (Sizes[k] == si);

                        if (Sizes[k] == 0)
                            break;

                        do {
                            code <<= 1; // described as SLL CODE 1 in the official JPEG docs : - ]
                            si++;
                        } while (Sizes[k] == si);

                    } while (true);
                }

                //Figure C.3
                //at this point i feel like i'm getting a colonoscopy
                {
                    int k = 0;
                    do {
                        int i = ValueOrder[k];
                        OrderedSizes[i] = Sizes[k];
                        OrderedCodes[i] = Codes[k];
                        k++;
                    } while (k < lastk);

                }

                //Figure F.15
                {
                    int i = 0, j = 0;
                    do {
                        i++;
                        if (i > 16)
                            break;
                        if (Bits[i]==0)
                            continue;
                        ValPtr[i] = j;
                        MinCode[i] = Codes[j];
                        j += Bits[i]-1;
                        MaxCode[i]= Codes[j];
                        j++;
                    } while (true);
                }

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

                Index = (byte)(section[3] & 0x0F);

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
            public byte ComponentCount;
            public SOSComponent[] ComponentInfo;
            //there are 3 more bytes which are irellevant to SOF0

            public SOSHeader(byte[] data) {
                Length = GetBigEndianU16(data, 0);
                ComponentCount = data[2];
                ComponentInfo = new SOSComponent[ComponentCount];
                for (int i = 3, j = 0; j < ComponentCount; i+=2, j++) {
                    if (i >= data.Length)
                        throw new Exception("Invalid SOS Header");
                    ComponentInfo[j] = new SOSComponent(data[i], data[i+1]);
                }
            }
        }
    }


    public sealed class JpegDecode : Jpeg {
        private Dictionary<byte, Tuple<int, int>[]> HuffmanSimple;
        private List<HuffmanTable> HuffmanTableList { get; set; }
        private Dictionary<int, HuffmanTable> HuffmanTables { get; set; }
        private List<QuantizationTable> QuantizationTableList { get; set; }
        private List<SOSHeader> ScanHeaders { get; set; }
        private List<long> ScanPointers { get; set; }
        private List<SOF0Component> Components { get; set; }
        private ushort RestartInterval { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public long ScanCount { get => ScanPointers.LongCount(); }

        public Stream Stream { get; private set; }

        private void DHTSimple(byte[] DHTSect) {
            ushort size = GetBigEndianU16(DHTSect, 0);
            byte index = DHTSect[2];
            MemoryStream ms = new MemoryStream(DHTSect);
            ms.Seek(3, SeekOrigin.Begin);
            bool ins = false;
            Tuple<int, int>[] l = new Tuple<int, int>[0x10000];
            if (!HuffmanSimple.ContainsKey(index)) 
                ins = true;

            byte[] lens = new byte[16];
            ms.Read(lens, 0, 16);

            int c = 0;

            for (int i = 1; i <= 16; i++) {
                for (int j = 0; j < lens[i-1]; j++) {
                    byte v = (byte)ms.ReadByte();
                    int x = 16-i;
                    int lo = c<<x;
                    int hi = lo | ((1<<x)-1);
                    for (int k = lo; k <= hi; k++)
                        l[k]=new Tuple<int, int>(i, v);
                    c++;
                }
                c <<= 1;
            }
            if (ins)
                HuffmanSimple.Add(index, l);
            else HuffmanSimple[index] = l;
        }

        private void DHT(byte[] DHTSect) =>
            HuffmanTableList.Add(new HuffmanTable(DHTSect));

        private void DQT(byte[] DQTsect) =>
            QuantizationTableList.Add(new QuantizationTable(DQTsect));
        

        private void SOF0(byte[] SOF0sect) {
            ushort size = GetBigEndianU16(SOF0sect, 0);

            if (SOF0sect[2] != 0x8)
                throw new Exception("JPEG unsupported (BPP!=8)");

            Width = GetBigEndianU16(SOF0sect, 3);
            Height = GetBigEndianU16(SOF0sect, 5);
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

        private void DRI(byte[] DRIsect) {
            ushort size = GetBigEndianU16(DRIsect, 0);
            if (size != 4)
                throw new Exception("Invalid DRI size");

            RestartInterval = GetBigEndianU16(DRIsect, 2);
        }

        private void SOS(byte[] SOSsect) {
            ScanHeaders.Add(new SOSHeader(SOSsect));
            ScanPointers.Add(Stream.Position);
            //whoever decided that SOS does not need a marker length field
            //i hope both sides of your pillow are forever warm

            byte[] buff = new byte[4096];
            bool eom = false;
            bool next_ff = false;


            while (!eom) { 
                int read = Stream.Read(buff, 0, buff.Length);

                for (int i = 0; i < read; i++) {
                    if (next_ff) {
                        next_ff = false;
                        if ((buff[i] >= 0xD0 && buff[i] <= 0xD7) || buff[i] == 0x00)
                            continue;
                        else {
                            eom = true;
                            Stream.Seek(i-read-1, SeekOrigin.Current);
                            break;
                        }
                    }
                    else if (buff[i] == 0xFF) 
                        next_ff = true;
                }
            }
        }


        private byte[] ReadMarkerAtHead() {
            byte[] window = new byte[2];
            Stream.Read(window, 0, 2);

            ushort len = GetBigEndianU16(window, 0);
            byte[] marker = new byte[len];

            Stream.Seek(-2, SeekOrigin.Current);
            Stream.Read(marker, 0, len);

            return marker;
        }

        private void SkipMarkerAtHead() { 
            byte[] window = new byte[2];
            Stream.Read(window, 0, 2);

            Stream.Seek(GetBigEndianU16(window, 0)-2, SeekOrigin.Current);
        }

        private void Parse() {
            bool EOI = false;
            byte[] marker_window = new byte[2];
            ushort marker = 0;

            Stream.Seek(0, SeekOrigin.Begin);

            while (Stream.Length != Stream.Position & !EOI) {
                Stream.Read(marker_window, 0, 2);
                if (marker_window[0] != 0xFF) 
                    throw new Exception("Corrupted file structure");

                marker = BitConverter.ToUInt16(marker_window, 0);

                switch (marker) {
                    case (ushort)Marker.SOI:
                        break;
                    case (ushort)Marker.DHT:
                        DHTSimple(ReadMarkerAtHead());
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
                    case (ushort)Marker.DRI:
                        DRI(ReadMarkerAtHead());
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

        private void Verify() {
            if (FileID.IdentifyFile(Stream) != FileFormat.JPEG)
                throw new FormatException("Not a JPEG file");
        }

        private int DecodeInt(int huffi, int len) =>
            huffi < (1 << (len - 1)) ? huffi - ((1 << len) - 1) : huffi;
        

        private int[] DecodeNextBlock(int table, BitDecomposer bd) {
            Tuple<int, int> hval;
            
            int[] r = new int[64];
            hval = HuffmanSimple[(byte)table][bd.Peek(16)];

            bd.Seek(16);
            int huffi = 0;

            r[0] = DecodeInt(bd.Read(hval.Item2), hval.Item2);

            for (int i = 1; i < 64; i++) {
                block = bq.Pop(2);

                hval = HuffmanSimple[(byte)(table+1)][bd.Peek(16)];
                for (int j = 0; j < hval.Item1; j++)
                    bq.PopSingle();

                switch (hval.Item2) {
                    case 0x00:
                        i = 63;
                        break;
                    case 0xF0:
                        i += 16;
                        break;
                    default:
                        i += (hval.Item2&0xF0)>>4;
                        huffi = 0;
                        for (int k = 0; k < (hval.Item2 & 0x0f); k++)
                            huffi = (huffi << 1)|(bq.PopSingle() ? 1 : 0);

                        r[Dezigzag[i]] = DecodeInt(huffi, hval.Item2 & 0x0f);
                        break;
                }
            }

            return r;
        }

        public byte[] DecodeScan(long index) {
            Stream.Seek(ScanPointers[(int)index], SeekOrigin.Begin);
            
            byte[] scan = null;
            int[][] block = new int[6][];
            int dY = 0, dCb = 0, dCr = 0;
            int xMcu = (Width + 15) / 16;
            int yMcu = (Height + 15) / 16;

            BitDecomposer bd = new BitDecomposer(Stream);

            for (int x = 0; x < xMcu; x++) for (int y = 0; y < yMcu; y++) {

                    for (int i = 0; i < 4; i++) {
                        block[i] = DecodeNextBlock(ScanHeaders[(int)index].ComponentInfo[0].ComponentID-1, bd);
                        dY = block[i][0] += dY;
                    }

                    block[4] = DecodeNextBlock(ScanHeaders[(int)index].ComponentInfo[1].ComponentID-1, bd);
                    dCb = block[4][0] += dCb;

                    block[5] = DecodeNextBlock(ScanHeaders[(int)index].ComponentInfo[2].ComponentID-1, bd);
                    dCr = block[5][0] += dCr;
                }
            return scan;
        }

        public JpegDecode(Stream Stream) {
            this.Stream = Stream;
            if (!Stream.CanSeek)
                throw new Exception("Stream must be seekable");

            HuffmanSimple = new Dictionary<byte, Tuple<int, int>[]>();
            HuffmanTableList = new List<HuffmanTable>();
            HuffmanTables = new Dictionary<int, HuffmanTable>();
            QuantizationTableList = new List<QuantizationTable>();
            ScanPointers = new List<long>();
            ScanHeaders = new List<SOSHeader>();
            Components = new List<SOF0Component>();

            Verify();
            Parse();

            foreach (HuffmanTable t in HuffmanTableList) 
                HuffmanTables.Add(t.Type << 4 | t.Index, t);
        }
    }
}
