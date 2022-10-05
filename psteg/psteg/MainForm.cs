using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace psteg {
    public partial class MainForm : Form {
        readonly PstegEngine engine = null;
        public MainForm() {
            InitializeComponent();
            engine = new PstegEngine();
            containerDict = new Dictionary<string, File.StegFile>();
            engine.AsyncWorker = bw_process;
        }

        private void rb_CheckedChanged(object sender, EventArgs e) {
            ClearDataPath();
            engine.SteganoOperation = rb_encode.Checked ? StegOperation.Encode : StegOperation.Decode;
        }

        private void b_dataBrowse_Click(object sender, EventArgs e) {
            FileDialog fd = rb_encode.Checked ? ofd_data : (FileDialog)sfd_data;
            if (fd.ShowDialog() == DialogResult.OK) { 
                tb_datapath.Text = fd.FileName;
                FileChanged();
            }
        }

        private void tb_datapath_Leave(object sender, EventArgs e) {
            FileChanged();
        }

        private void cb_encrypt_CheckedChanged(object sender, EventArgs e) {
            b_cryptoOptions.Enabled = cb_encrypt.Checked;
            engine.Encrypt = cb_encrypt.Checked;
        }

        private void cb_multicontainer_CheckedChanged(object sender, EventArgs e) {
            if (lv_containers.Items.Count > 0) {
                DialogResult wipe = MessageBox.Show("The container list is currently populated. Changing this option will wipe it. Do you wish to proceed ?", 
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (wipe == DialogResult.Yes)
                    lv_containers.Clear();
                else return;
            }

            b_add_set.Text = cb_multicontainer.Checked ? "Add" : "Set";
            ofd_container.Multiselect = cb_multicontainer.Checked;
        }

        private void tb_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                label1.Focus();
        }

        private void b_stegOptions_Click(object sender, EventArgs e) {
            if (!engine.ShowSteganoSettings()) MessageBox.Show("Selected algorithm has no settings", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void b_cryptoOptions_Click(object sender, EventArgs e) {
            new CryptoOpts(engine).ShowDialog();
        }

        private void b_add_set_Click(object sender, EventArgs e) {
            if (cb_multicontainer.Checked) {
                throw new NotImplementedException();
            }
            else {
                lv_containers.Clear();
                lv_containers.Items.Add(tb_container.Text);
                SetContainer();
            }
        }

        private void b_containerBrowse_Click(object sender, EventArgs e) {
            DialogResult mcRes = ofd_container.ShowDialog();
            if (mcRes != DialogResult.OK)
                return;
            tb_container.Text = ofd_container.FileName;
        }

        private void lv_containers_ItemActivate(object sender, EventArgs e) {
            ListViewItem activatedItem = lv_containers.SelectedItems[0];
            ShowContainerInfo(activatedItem.Text);
        }

        private void l_selectedMethod_TextChanged(object sender, EventArgs e) {
            Point oldLoc = l_selectedMethod.Location;
            Point newLoc = new Point(Width - l_selectedMethod.Width - 28, oldLoc.Y);
        }

        private void lv_methods_SelectedIndexChanged(object sender, EventArgs e) {
            if (lv_methods.SelectedItems.Count < 1)
                return;
            l_selectedMethod.Text = lv_methods.SelectedItems[0].Name;
            SetMethod();
        }

        private void b_start_Click(object sender, EventArgs e) {
            if (engine.SteganoOperation == StegOperation.Encode) {
                DialogResult dr = sfd_encoded.ShowDialog();
                if (dr != DialogResult.OK)
                    return;

                engine.EncodedFile = OpenFileWrite(sfd_encoded.FileName);
                if (engine.EncodedFile == null)
                    MessageBox.Show("File access error");

                engine.RawFile = OpenFileRead(tb_datapath.Text);
                if (engine.RawFile == null)
                    MessageBox.Show("File access error");
            }
            else {
                throw new NotImplementedException();
            }

            engine.Go();
        }

        private void bw_process_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            Tuple<long, long> state = (Tuple<long,long>)e.UserState;
            l_status.Text = state.Item1.ToString() + "/" + state.Item2.ToString();
            pb_status.Minimum = 0;
            pb_status.Maximum = (int)state.Item2;
            pb_status.Value = (int)state.Item1;
        }

        private void bw_process_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            l_status.Text = "DONE";
        }
    }
}
