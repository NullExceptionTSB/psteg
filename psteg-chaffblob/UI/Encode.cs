using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using psteg_chaffblob.RNGs;
using psteg.Crypto;
using psteg_chaffblob.MAC.Net;
using psteg_chaffblob.Engine;


namespace psteg_chaffblob {
    public partial class Encode : Form {

        Random random = new Random();

        private Dictionary<string, Type> RNGMap = new Dictionary<string, Type> {
            { "Xorshift64*", typeof(XorshiftS) },
            { "Xorshift64", typeof(Xorshift) }
        };

        private Dictionary<string, Type> CryptMap = new Dictionary<string, Type> {
            { "None", typeof(NullEncrypt) },
            { "AES256", typeof(AES256) }
        };


        private Dictionary<string, Type> MACMap = new Dictionary<string, Type> {
            { "MD5", typeof(MD5HMAC) },
            { "SHA1", typeof(SHA1HMAC) },
            { "SHA256", typeof(SHA256HMAC) },
            { "SHA512", typeof(SHA512HMAC) }
        };
        private List<Tuple<string, string, string>> FileList = new List<Tuple<string, string, string>>();

        public Encode() {
            InitializeComponent();
            cb_container.Items.Clear();

            foreach (string con in Enum.GetNames(typeof(WriteEngine.ContainerType)))
                cb_container.Items.Add(con);
            cb_container.SelectedIndex = 0;

            foreach (string rng in RNGMap.Keys)
                cb_prng.Items.Add(rng);
            cb_prng.SelectedIndex = 0;

            foreach (string ca in CryptMap.Keys)
                cb_cryptoalgo.Items.Add(ca);
            cb_cryptoalgo.SelectedIndex = 1;

            foreach (string mac in MACMap.Keys)
                cb_hmac.Items.Add(mac);
            cb_hmac.SelectedIndex = 3;
        }

        public void AddFile(string path, string id, string crypt) {
            if (!System.IO.File.Exists(path)) {
                MessageBox.Show("File does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Tuple<string,string,string> f in FileList) {
                if (f.Item2 == id) { 
                    MessageBox.Show("ID Keys must be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            FileList.Add(new Tuple<string,string,string>(path, id, crypt));
            lv_files.Items.Add(new ListViewItem(new ListViewItem.ListViewSubItem[] { 
                new ListViewItem.ListViewSubItem { Text = path }, 
                new ListViewItem.ListViewSubItem { Text = cb_showKeys.Checked?id:"[censored]" }, 
                new ListViewItem.ListViewSubItem { Text = cb_showKeys.Checked?crypt:"[censored]" } }, 
                null));
        }

        public void RemoveFile(int index) {
            if (index == -1) return;
            lv_files.Items.RemoveAt(index); 
            FileList.RemoveAt(index);
        }

        public void Clear() {
            if (MessageBox.Show("Are you sure you want to reset all settings ?", 
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) 
                    != DialogResult.Yes)
                        return;

            FileList.Clear();
            lv_files.Items.Clear();
            cb_container.SelectedIndex = 0;
            cb_prng.SelectedIndex = 0;
            cb_cryptoalgo.SelectedIndex = 0;

            tb_chaffCount.Text = string.Empty;
            tb_cryptoKey.Text = string.Empty;
            tb_filename.Text = string.Empty;
            tb_idKey.Text = string.Empty;
            tb_outputFile.Text = string.Empty;

            cb_showCryptoKey.Checked = false;
            cb_showIdKey.Checked = false;
            cb_showKeys.Checked = false;
        }

        public void Start() {
            WriteEngine e = new WriteEngine(RNGMap[cb_prng.Text], CryptMap[cb_cryptoalgo.Text], MACMap[cb_hmac.Text]);
            e.Owner = bw_go;
            e.ChaffCount = int.Parse(tb_chaffCount.Text);
            e.Container = (WriteEngine.ContainerType)Enum.Parse(typeof(WriteEngine.ContainerType) ,cb_container.Items[cb_container.SelectedIndex].ToString());
            try { 
                foreach (Tuple<string, string, string> f in FileList)
                    e.InputFiles.Add(
                        new InputFile(
                                new FileStream(f.Item1, FileMode.Open, FileAccess.Read, FileShare.Read), 
                                f.Item2,
                                f.Item3
                            )
                        );
                e.Output = new FileStream(tb_outputFile.Text, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            } catch (Exception ex) {
                MessageBox.Show("Encoder initialization failed. Reason: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Finish(e, true);
                return;
            }

            bw_go.RunWorkerAsync(e);
        }
        public void Process(WriteEngine e) {
            e.Go();
            Finish(e);
        }
        public void Finish(WriteEngine e, bool err = false) {
            bw_go.ReportProgress(99, "Finalizing");

            foreach (InputFile i in e.InputFiles) { 
                i.Stream?.Close();
                i.Stream?.Dispose();
            }
            e.Output?.Close();
            e.Output?.Dispose();
            e.Dispose();
            bw_go.ReportProgress(100, err ? "Error" : "Done");
            pb_progress.Invoke(new Action(delegate {
                pb_progress.Style = ProgressBarStyle.Continuous;
                pb_progress.Maximum = 1;
                pb_progress.Value = 1;
            }));   
        }

        public void BrowseInput() {
            if (ofd_blobfile.ShowDialog() == DialogResult.OK)
                tb_filename.Text = ofd_blobfile.FileName;
        }

        public void BrowseOutput() {
            if (sfd_output.ShowDialog() == DialogResult.OK)
                tb_outputFile.Text = sfd_output.FileName;
        }

        private void cb_showCryptoKey_CheckedChanged(object sender, EventArgs e) => tb_cryptoKey.UseSystemPasswordChar = !cb_showCryptoKey.Checked;
        private void cb_showIdKey_CheckedChanged(object sender, EventArgs e) => tb_idKey.UseSystemPasswordChar = !cb_showIdKey.Checked;
        private void b_addfile_Click(object sender, EventArgs e) => AddFile(tb_filename.Text, tb_idKey.Text, tb_cryptoKey.Text);
        private void b_remove_Click(object sender, EventArgs e) => RemoveFile(lv_files.SelectedIndices.Count>0?lv_files.SelectedIndices[0]:-1);
        private void b_reset_Click(object sender, EventArgs e) => Clear();
        private void cb_showKeys_CheckedChanged(object sender, EventArgs e) {
            foreach (ListViewItem lvi in lv_files.Items) {
                lvi.SubItems[1].Text = cb_showKeys.Checked ? FileList[lvi.Index].Item2 : "[censored]";
                lvi.SubItems[2].Text = cb_showKeys.Checked ? FileList[lvi.Index].Item3 : "[censored]";
            }
        }
        private void bw_go_ProgressChangedS(object sender, ProgressChangedEventArgs e) {
            pb_progress.Style = ProgressBarStyle.Marquee;
            l_state.Text = (string)e.UserState;
        }
        private void bw_go_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.UserState.GetType() == typeof(string)) {
                bw_go_ProgressChangedS(sender, e);
                return;
            }
            pb_progress.Style = ProgressBarStyle.Continuous;
            Tuple<long, long, string> state = (Tuple<long, long, string>)e.UserState;

            bool bigmode = false;

            if (state.Item2 > int.MaxValue) bigmode = true;
            try {
                pb_progress.Minimum = 0;
                pb_progress.Maximum = bigmode ? (int)(state.Item2 >> 32) : (int)state.Item2;
                pb_progress.Value = bigmode ? (int)(state.Item1 >> 32) : (int)state.Item1;
            } catch { }
            l_state.Text = ((!string.IsNullOrEmpty(state.Item3)) ? state.Item3 : "Working") + " - " + pb_progress.Value + "/" + pb_progress.Maximum;
        }
        private void b_start_cancel_Click(object sender, EventArgs e) => Start();
        private void bw_go_DoWork(object sender, DoWorkEventArgs e) => Process((WriteEngine)e.Argument);
        private void b_browseInput_Click(object sender, EventArgs e) => BrowseInput();
        private void b_browseOutput_Click(object sender, EventArgs e) => BrowseOutput();

        private void tb_chaffCount_KeyPress(object sender, KeyPressEventArgs e) 
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        private void b_randomizeChaffCount_Click(object sender, EventArgs e) =>
            tb_chaffCount.Text = random.Next(16, 4096).ToString();
        
    }
}
