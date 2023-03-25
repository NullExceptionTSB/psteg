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

        private void panel1_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.Copy;

        private void button1_Click(object sender, EventArgs e) =>
            new UI.GenericEncode().Show();
        

        private void button2_Click(object sender, EventArgs e) =>
            new UI.GenericDecode().Show();
        
        private void panel1_DragDrop(object sender, DragEventArgs e) {
            FileStream fs = new FileStream(((string[])e.Data.GetData(DataFormats.FileDrop, false))[0], FileMode.Open, FileAccess.Read, FileShare.Read);

            fs.Close();
            fs.Dispose();
        }

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
    }
}
