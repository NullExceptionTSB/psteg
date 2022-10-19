﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

using psteg.UI;
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
            cb_encrypt.Text = rb_encode.Checked ? "Encrypt" : "Decrypt";
        }

        private void b_dataBrowse_Click(object sender, EventArgs e) {
            FileDialog fd = rb_encode.Checked ? ofd_data : (FileDialog)sfd_data;
            if (fd.ShowDialog() == DialogResult.OK)
                tb_datapath.Text = fd.FileName;
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
                engine.RawFile = OpenFileWrite(tb_datapath.Text);
                if (engine.RawFile == null)
                    MessageBox.Show("File access error");
            }

            l_status.Text = "Working";

            SetEnabled(false);

            try { 
                engine.Go();
            } catch (Exception ex) {
                SetEnabled(true);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_process_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            Tuple<long, long> state = (Tuple<long,long>)e.UserState;
            l_status.Invoke((MethodInvoker)delegate { l_status.Text = state.Item1.ToString() + "/" + state.Item2.ToString(); });
            pb_status.Minimum = 0;
            pb_status.Maximum = (int)state.Item2;
            pb_status.Value = (int)state.Item1;
        }

        private void bw_process_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            SetEnabled(true);

            if (e.Error != null) {
                MessageBox.Show("STEGANOGRAPHIC ENCODING FAILED: " + e.Error.Message + ", Data may be invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                l_status.Text = "ERROR";
            }
            else
                l_status.Text = "DONE";

            engine.RawFile?.Dispose();
            engine.EncodedFile?.Dispose();

            engine.EncodedFile = null;
            engine.RawFile = null;


        }

        private void lv_methods_ItemActivate(object sender, EventArgs e) {
            if (lv_methods.SelectedItems.Count < 1)
                return;
            l_selectedMethod.Text = lv_methods.SelectedItems[0].Name;
            SetMethod();
        }
    }
}