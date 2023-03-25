using System;
using System.IO;
using System.Windows.Forms;

using psteg.Stegano.File.Format;

namespace psteg.Stegano {
    public partial class Form1 : Form {
        public Form1() {
#if !DEBUG
            Environment.Exit(0);
#endif
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) =>
            new UI.GenericEncode().Show();
        

        private void button2_Click(object sender, EventArgs e) =>
            new UI.GenericDecode().Show();
      
        private void button3_Click_1(object sender, EventArgs e) {
            const string f = "C:\\Users\\NullException\\Desktop\\pes.jpg";
            //const string f = "H:\\stegcontainers\\pes.jpg";
            string outf = Path.GetTempFileName();
            FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream ofs = new FileStream(outf, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            JpegCodec jc = new JpegCodec(fs, ofs);
            jc.SetScan(0);
            for (; ;) jc.GetNextCode();

            fs.Close();
            fs.Dispose();
        }

        private void button4_Click(object sender, EventArgs e) {
            Huffman.BitComposer bc = new Huffman.BitComposer();

        }
    }
}
