using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //OTHER
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
                            //JPG MARKERS
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
        public static class HuffConst {
            public const int RegsiterSize = 64;
            public const int FetchBits = 48;

            public const int LookupBits = 8;
            public const int LookupSize = 1<<LookupBits;
        }
        //most of this code is heavily based on F5 JPEG Steganography
        //todo: refactor this warcrime
        protected internal sealed class HuffmanTableNew {
            public ushort Length { get; set; }
            public byte Type { get; set; }
            public byte Index { get; set; }

            public uint[] HuffmanWorkspace { get; set; }
            public byte[] HuffmanCodes { get; set; }
            public byte[] HuffmanLengths { get; set; }

            public byte[] Values { get; set; } = new byte[256];
            public byte[] MaxCode { get; set; } = new byte[18];
            public byte[] ValOffset { get; set; } = new byte[19];

            public byte[] LookaheadSize { get; set; } = new byte[HuffConst.LookupSize];
            public byte[] LookaheadVals { get; set; } = new byte[HuffConst.LookupSize];

            public HuffmanTableNew(byte[] section) {
                byte[] flipbuffer = new byte[2];
                flipbuffer[0] = section[1];
                flipbuffer[1] = section[0];

                byte type_index = section[3];

                Length = BitConverter.ToUInt16(flipbuffer, 0);

                Type = (byte)(type_index >> 4);
                Index = (byte)(type_index & 0x0F);

                if (Type > 1)
                    Console.WriteLine("W: invalid huffman table type");
                if (Type > 3)
                    Console.WriteLine("W: invalid huffman table index");

                HuffmanLengths = new byte[17];
                HuffmanCodes = new byte[256];

                for (int i = 1; i < 16; i++)
                    HuffmanLengths[i] = section[2+i];

                int sum_codelength = 0;
                for (int i = 0; i < 16; i++)
                    sum_codelength += HuffmanLengths[i];

                if (sum_codelength > 256 || sum_codelength > section.Length-17)
                    throw new Exception("Huffman table invalid (too big)");


            }
        }

        protected internal sealed class HuffmanTable {
            public ushort Length { get; set; }
            public byte ValIsAC { get; set; }
            public byte Index { get; set; }

            public int[] Bits { get; set; }
            public int[] HuffmanValues { get; set; }
            public int[] HuffmanCode { get; set; }
            public int[] HuffmanSize { get; set; }
            public int[] ValuePointers { get; set; }
            public int[] CodeMaximum { get; set; }
            public int[] CodeMinimum { get; set; }
            public int[] OrderedHuffmanCode { get; set; }
            public int[] OrderedHuffmanSize { get; set; }

            private int K, I, J, LASTK, C, SI;

            private ushort GetBits(byte[] table, int start) {
                ushort bitCount = 0;

                for (int i = 1; i < 17; i++) {
                    Bits[i] = table[start+i];
                    bitCount += (ushort)Bits[i];
                }
                for (int i = 0; i < bitCount; i++)
                    HuffmanValues[i] = table[start+bitCount+i];

                return bitCount;
            }

            private void GetSizes() {
                I=1;
                J=1;
                K=0;

                for (; ; ) {
                    if (J>Bits[I]) {
                        J=1;
                        I++;
                        if (I > 16)
                            break;
                    } else {
                        HuffmanSize[K++]=I;
                        J++;
                    }
                }
                HuffmanSize[K] = 0;
                LASTK = K;
            }

            private void GetCodeTable() {
                K=0;
                C=0;
                SI=HuffmanSize[0];

                for (; ; ) {
                    HuffmanCode[K++] = C++;

                    if (HuffmanSize[K] == SI)
                        continue;
                    if (HuffmanSize[K] == 0)
                        break;

                    while (HuffmanSize[K] != SI) {
                        C <<= 1;
                        SI++;
                    }
                }
            }

            private void SortCodeTable() {
                K=0;

                while (K<LASTK) {
                    I = HuffmanValues[K];

                    OrderedHuffmanCode[I] = HuffmanCode[K];
                    OrderedHuffmanSize[I] = HuffmanSize[K++];
                }
            }

            private void GenerateDecoderTables() {
                I=J=0;

                for(; ; ) {
                    if (++I > 16)
                        return;

                    if (Bits[I] == 0)
                        CodeMaximum[I] = -1;
                    else {
                        ValuePointers[I] = J;
                        CodeMinimum[I] = HuffmanCode[J];
                        J+= Bits[I] - 1;
                        CodeMaximum[I] = HuffmanCode[J++];
                    }
                }
            }

            public void Parse(byte[] table, int i, byte idx, byte isac) {
                ValIsAC = isac;
                Index = idx;


                Length = (ushort)(19 + GetBits(table, i));

                GetSizes();
                GetCodeTable();
                SortCodeTable();
                GenerateDecoderTables();

                
            }

            public HuffmanTable() {
                HuffmanValues = new int[256];
                HuffmanCode = new int[257];
                HuffmanSize = new int[257];

                ValuePointers = new int[17];
                CodeMaximum = new int[18];
                CodeMinimum = new int[17];

                OrderedHuffmanCode = new int[HuffmanCode.Length];
                OrderedHuffmanSize = new int[HuffmanSize.Length];
                Bits = new int[17];
            }
        }

        protected internal sealed class QuantizationTable {
            public byte[] Table { get; private set; } 
            public byte Index { get; private set; }
            public ushort Length { get; private set; }

            public QuantizationTable(byte[] section) {
                byte[] flipbuf = new byte[2];
                flipbuf[0] = section[1];
                flipbuf[1] = section[0];

                Length = BitConverter.ToUInt16(flipbuf, 0);

                if (Length != 67)
                    throw new Exception("DQT length != 67 !!");

                Index = (byte)(section[3] & 0x0F);

                Table = new byte[64];

                for (int i = 0; i < 64; i++)
                    Table[i] = section[i+3];
            }
        }

        //taken from F5
        protected internal static int[] DeZigZagTable { get; } = new int[] {
            0,  1,  5,  6,  14, 15, 27, 28,
            2,  4,  7,  13, 16, 26, 29, 42,
            3,  8,  12, 17, 25, 30, 41, 43,
            9,  11, 18, 24, 31, 40, 44, 53,
            10, 19, 23, 32, 39, 45, 52, 54,
            20, 22, 33, 38, 46, 51, 55, 60,
            21, 34, 37, 47, 50, 56, 59, 61,
            35, 36, 48, 49, 57, 58, 62, 63
        };
    }


    public sealed class JpegDecode : Jpeg {
        private List<HuffmanTableNew> HuffmanTableList { get; set; }
        private List<QuantizationTable> QuantizationTableList { get; set; }
        private ushort RestartInterval { get; set; }

        public Stream Stream { get; private set; }

        private void DHT(byte[] DHTSect) {
            byte[] flipbuf = new byte[2];
            flipbuf[0] = DHTSect[1];
            flipbuf[1] = DHTSect[0];

            ushort size = BitConverter.ToUInt16(flipbuf, 0);


            byte isac = DHTSect[3];
            byte idx = (byte)(isac & 0x0F);
            isac >>= 4;

            HuffmanTableNew ht = new HuffmanTableNew(DHTSect);

            HuffmanTableList.Add(ht);
            size -= ht.Length;
            
        }

        private void DQT(byte[] DQTsect) =>
            QuantizationTableList.Add(new QuantizationTable(DQTsect));
        

        private void SOF0(byte[] SOF0sect) {
            byte[] flipbuf = new byte[2];
            flipbuf[0] = SOF0sect[1];
            flipbuf[1] = SOF0sect[0];

            ushort size = BitConverter.ToUInt16(flipbuf, 0);
        }

        private void DRI(byte[] DRIsect) {
            byte[] flipbuf = new byte[2];
            flipbuf[0] = DRIsect[1];
            flipbuf[1] = DRIsect[0];

            ushort size = BitConverter.ToUInt16(flipbuf, 0);
            if (size != 4)
                throw new Exception("Invalid DRI size");

            flipbuf[0] = DRIsect[3];
            flipbuf[2] = DRIsect[2];

            RestartInterval = BitConverter.ToUInt16(flipbuf, 0);
        }

        private byte[] ReadMarkerAtHead() {
            byte[] window = new byte[2];
            Stream.Read(window, 0, 2);

            byte i = window[0];
            window[0] = window[1];
            window[1] = i;

            ushort len = BitConverter.ToUInt16(window, 0);
            byte[] marker = new byte[len];

            Stream.Read(marker, 2, len-2);
            marker[0] = window[1];
            marker[1] = window[0];

            return marker;
        }

        private void SkipMarkerAtHead() { 
            byte[] window = new byte[2];
            Stream.Read(window, 0, 2);

            byte i = window[0];
            window[0] = window[1];
            window[1] = i;

            Stream.Seek(BitConverter.ToUInt16(window, 0)-2, SeekOrigin.Current);
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
                        DHT(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.DQT:
                        DQT(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.SOF0:
                        SOF0(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.DRI:
                        DRI(ReadMarkerAtHead());
                        break;
                    case (ushort)Marker.SOS: //start of scan = end of headers
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

        public JpegDecode(Stream Stream) {
            this.Stream = Stream;
            if (!Stream.CanSeek)
                throw new Exception("Stream must be seekable");

            HuffmanTableList = new List<HuffmanTableNew>();
            QuantizationTableList = new List<QuantizationTable>();

            Verify();
            Parse();
        }
    }
}
