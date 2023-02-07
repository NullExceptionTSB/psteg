using System;
using System.IO;
using System.Windows.Forms;

using psteg.Stegano.File.Format;

namespace psteg.Stegano {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            new UI.LSBEncode().Show();
        }

        private void button2_Click(object sender, EventArgs e) {
            new UI.LSBDecode().Show();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.Copy;

        private void panel1_DragDrop(object sender, DragEventArgs e) {
            FileStream fs = new FileStream(((string[])e.Data.GetData(DataFormats.FileDrop, false))[0], FileMode.Open, FileAccess.Read, FileShare.Read);

            JpegDecode jd = new JpegDecode(fs);

        }
    }
}
