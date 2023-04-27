using System;
using System.IO;
using System.Windows.Forms;

using psteg.UI;
using psteg.Stegano.File.Format;

namespace psteg.Stegano {
    public partial class Form1 : Form {
        private StateManager StateManager;
        public Form1() {
#if !DEBUG
            Environment.Exit(0);
#endif
            InitializeComponent();

            StateManager = new StateManager(pb_sm_test, l_sm_test);
            StateManager.StateChangeDenominator = 2;
        }

        private void button1_Click(object sender, EventArgs e) =>
            new UI.GenericEncode().Show();
        

        private void button2_Click(object sender, EventArgs e) =>
            new UI.GenericDecode().Show();
      
        private void button3_Click(object sender, EventArgs e) {
            const string f = "C:\\Users\\NullException\\Desktop\\pes.jpg";
            const string outf = "C:\\Users\\NullException\\Desktop\\pes_OUT.jpg";
            //const string f = "H:\\stegcontainers\\pes.jpg";
            //string outf = Path.GetTempFileName();
            FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream ofs = new FileStream(outf, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            JpegCodec jc = new JpegCodec(fs, ofs);
            jc.SetScanRead(0);
            jc.InitScanWrite();
            jc.CopyRestOfScan();
            jc.CloseScanWrite();

            fs.Close();
            fs.Dispose();
            ofs.Close();
            ofs.Dispose();
        }

        private void button4_Click(object sender, EventArgs e) {
            byte[] s = new byte[128];
            Huffman.BitComposer bc = new Huffman.BitComposer(new MemoryStream(s), true);
            for (int i = 0; i < 4; i++) { 
                bc.Write(true);
                bc.Write(false);
            }
            bc.Write(new Huffman.Code(9, 0x1AF));
            bc.Dispose();
        }

        private void b_smadd_Click(object sender, EventArgs e) {
            StateManager.State = "Incrementing";
            StateManager.IncrementProgress(1);
        }

        private void b_smrm_Click(object sender, EventArgs e) {
            StateManager.State = "Decrementing";
            StateManager.IncrementProgress(-1);
        }

        private void b_indef_Click(object sender, EventArgs e) {
            StateManager.Indefinite = true;
            StateManager.State = "Indefinite";
            StateManager.UpdateDisplay();
        }

        private void b_smadd5_Click(object sender, EventArgs e) {
            StateManager.State = "Incrementing";
            StateManager.IncrementProgress(5);
        }

        private void b_smdef_Click(object sender, EventArgs e) {
            StateManager.Indefinite = false;
            StateManager.State = "Definite";
            StateManager.UpdateDisplay();
        }

        private void b_smrm5_Click(object sender, EventArgs e) {
            StateManager.State = "Decrementing";
            StateManager.IncrementProgress(-5);
        }
    }
}
