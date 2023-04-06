using System;
using System.IO;
using System.Windows.Forms;

using psteg.Crypto;

namespace psteg_fstools {
    public partial class ADS : Form {
        InternalFile f = null;
        const string rng_allowed = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public ADS() {
            InitializeComponent();
            foreach (string algo in Encryption.AlgoList.Keys) { 
                cb_c_encryption.Items.Add(algo);
                cb_r_encryption.Items.Add(algo);
            }
            cb_c_encryption.SelectedIndex = cb_r_encryption.SelectedIndex = 0;

            foreach (string algo in Encryption.KDFList.Keys) {
                cb_c_kda.Items.Add(algo);
                cb_r_kda.Items.Add(algo);
            }
            cb_c_kda.SelectedIndex = cb_r_kda.SelectedIndex = 0;
        }

        private void RefreshStreams() {
            Tuple<string[], long[]> streamdata = null;
            try {
                streamdata = f.ListStreams();
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } finally { 
                lv_streams.Items.Clear();
            }

            for (int i = 0; i < streamdata.Item1.Length; i++)
                lv_streams.Items.Add(new ListViewItem(new ListViewItem.ListViewSubItem[] {
                    new ListViewItem.ListViewSubItem { Text = streamdata.Item1[i] },
                    new ListViewItem.ListViewSubItem { Text = streamdata.Item2[i].ToString() } },
                    null));
        }

        private void b_fileSet_Click(object sender, EventArgs e) {
            tb_appFile.Text = tb_file.Text;
            f?.Dispose();
            try { 
                f = new InternalFile(tb_appFile.Text);
            } catch (Exception ex) {
                MessageBox.Show("Failed to open file: " + ex.Message);
                return;
            }

            RefreshStreams();
        }

        private void b_fileBrowse_Click(object sender, EventArgs e) {
            if (ofd_stream.ShowDialog() == DialogResult.OK)
                tb_file.Text = ofd_stream.FileName;
        }

        private void b_c_browse_Click(object sender, EventArgs e) {
            if (ofd_data_source.ShowDialog() == DialogResult.OK)
                tb_c_dataSource.Text = ofd_data_source.FileName;
        }

        private void b_add_Click(object sender, EventArgs e) {
            FileStream src = null;
            Encryption enc = null;
            InternalFile stream = null;
            Stream estream = null;
            try { 
                stream = new InternalFile(tb_appFile.Text, tb_c_streamName.Text);

                src = new FileStream(tb_c_dataSource.Text, FileMode.Open, FileAccess.Read, FileShare.Read);
                enc = (Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_c_encryption.Items[cb_c_encryption.SelectedIndex].ToString()]);
                Tuple<byte[], byte[]> kvp = enc.GetKeyIVPair(tb_c_key.Text);
                enc.Key = kvp.Item1;
                enc.IV = kvp.Item2;

                if (Encryption.KeyDerivationAlgorithm.GetType() != Encryption.KDFList[cb_c_kda.Items[cb_c_kda.SelectedIndex].ToString()])
                    Encryption.KeyDerivationAlgorithm = (psteg.Crypto.KeyDerivation.KeyDerivationAlgo)Encryption.KDFList[cb_c_kda.Items[cb_c_kda.SelectedIndex].ToString()].GetConstructor(Type.EmptyTypes).Invoke(null);

                estream = enc.Encrypt(src);

                stream.CopyFrom(estream);
            } catch (Exception ex) {
                MessageBox.Show("Copy failed, reason: " + ex.Message);
            } finally {
                src?.Dispose();
                estream?.Close();
                estream?.Dispose();
                stream?.Dispose();
                enc?.Dispose();
            }
            RefreshStreams();
        }

        private void lv_streams_SelectedIndexChanged(object sender, EventArgs e) {
            if (lv_streams.SelectedIndices.Count == 0) return;
            tb_r_streamName.Text = lv_streams.Items[lv_streams.SelectedIndices[0]].SubItems[0].Text;
        }

        private void cb_c_showkey_CheckedChanged(object sender, EventArgs e) 
            => tb_c_key.UseSystemPasswordChar = !cb_c_showkey.Checked;
        private void cb_r_showkey_CheckedChanged(object sender, EventArgs e) 
            => tb_r_key.UseSystemPasswordChar = !cb_r_showkey.Checked;

        private void NormalizeStream() {
            if (string.IsNullOrEmpty(tb_r_streamName.Text)) return;
            if (tb_r_streamName.Text[0] != ':')
                tb_r_streamName.Text = ":" + tb_r_streamName.Text;
            if (!tb_r_streamName.Text.EndsWith(":$DATA"))
                tb_r_streamName.Text += ":$DATA";
        }

        private void b_extract_Click(object sender, EventArgs e) {
            NormalizeStream();
            if (sfd_extract.ShowDialog() != DialogResult.OK)
                return;
            FileStream dest = null;
            InternalFile src = null;
            Encryption enc = null;
            try {
                dest = new FileStream(sfd_extract.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                src = new InternalFile(tb_appFile.Text + tb_r_streamName.Text, true);
                enc = (Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_c_encryption.Items[cb_c_encryption.SelectedIndex].ToString()]);

                Tuple<byte[], byte[]> kvp = enc.GetKeyIVPair(tb_r_key.Text);
                enc.Key = kvp.Item1;
                enc.IV = kvp.Item2;

                src.Decrypt(dest, enc);


            } catch (Exception ex) {
                MessageBox.Show("Read failed, reason: " + ex.Message);
            } finally {
                dest?.Close();
                dest?.Dispose();
                src?.Dispose();
                enc?.Dispose();
            }
        }

        private void b_randsname_Click(object sender, EventArgs e) {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < 32; i++)
                s += rng_allowed[random.Next(rng_allowed.Length)];
            tb_c_streamName.Text = s;
        }

        private void tb_r_streamName_TextChanged(object sender, EventArgs e)
            => b_r_delete.Enabled = b_extract.Enabled = !string.IsNullOrEmpty(tb_r_streamName.Text);

        private void b_r_delete_Click(object sender, EventArgs e) {
            NormalizeStream();
            if (tb_r_streamName.Text == "::$DATA") {
                MessageBox.Show("You can not delete the primary stream", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InternalFile.DeleteStream(tb_appFile.Text + tb_r_streamName.Text);
            RefreshStreams();
            lv_streams.SelectedIndices.Clear();
            tb_r_streamName.Text = string.Empty;
        }

        private void tb_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.Copy;
        private void tb_file_DragDrop(object sender, DragEventArgs e) => 
            tb_file.Text = ((string[]) e.Data.GetData(DataFormats.FileDrop, false))[0];
        private void tb_c_dataSource_DragDrop(object sender, DragEventArgs e) =>
            tb_c_dataSource.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
        private void tb_appFile_DragDrop(object sender, DragEventArgs e) {
            tb_appFile.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            b_fileSet.PerformClick();
        }
        
    }
}
