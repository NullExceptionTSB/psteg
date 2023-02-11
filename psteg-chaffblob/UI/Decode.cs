using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg;
using psteg_chaffblob.Container.Reader;

namespace psteg_chaffblob.UI {
    public partial class Decode : Form {
        public Decode() =>
            InitializeComponent();
        

        private void cb_showIdKey_CheckedChanged(object sender, EventArgs e) =>
            tb_idKey.UseSystemPasswordChar = !cb_showIdKey.Checked;
        private void cb_showCryptoKey_CheckedChanged(object sender, EventArgs e) =>
            tb_encKey.UseSystemPasswordChar = !cb_showCryptoKey.Checked;

        private void b_browseInput_Click(object sender, EventArgs e) {
            if (ofd_input.ShowDialog() == DialogResult.OK)
                tb_input.Text=ofd_input.FileName;
        }

        private void b_browseOutput_Click(object sender, EventArgs e) {
            if (sfd_output.ShowDialog() == DialogResult.OK)
                tb_output.Text=sfd_output.FileName;
        }

        private void b_start_Click(object sender, EventArgs e) {
            FileStream Input, Output;
            
            try {
                Input = new FileStream(tb_input.Text, FileMode.Open, FileAccess.Read, FileShare.Read);
            } catch (Exception ex) {
                MessageBox.Show("Failed to open input file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                Output = new FileStream(tb_output.Text, FileMode.Create, FileAccess.Write, FileShare.None);
            }
            catch (Exception ex) {
                Input?.Dispose();
                Input?.Close();
                MessageBox.Show("Failed to open output file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ChaffContainerReader cr = null;
            try { 
                cr = ChaffContainerReader.FromFile(Input, Output);
                cr.ReportsTo = bw_process;
            } catch (Exception ex) {
                MessageBox.Show("Failed to open reader: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string f = Output.Name;

                Input?.Close();
                Output?.Close();
                Input?.Dispose();
                Output?.Dispose();
                cr?.Dispose();
                if (f != null)
                    File.Delete(f);
                return;
            }
            bw_process.RunWorkerAsync(cr);
                
        }

        private void bw_process_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            try {
                Exception ex = (Exception)e.UserState;
                MessageBox.Show("Decoder error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch { }

            if (e.ProgressPercentage == 100) {
                l_state.Text = "Done";
                pb_progress.Style = ProgressBarStyle.Continuous;
                pb_progress.Maximum = 1;
                pb_progress.Value = 1;
                return;
            }

            ProgressState ps = (ProgressState)e.UserState;

            if (ps.IndefProgress) {
                l_state.Text = ps.State + "...";
                pb_progress.Style = ProgressBarStyle.Marquee;
                return;
            }

            pb_progress.Style = ProgressBarStyle.Continuous;
            try { 
                pb_progress.Maximum = ps.Maximum;
                pb_progress.Value = ps.Current;
                
            } catch { }
            l_state.Text = ps.State + ": " + ps.Current +"/"+ps.Maximum;
            l_state.Refresh();
        }

        ChaffContainerReader _cr = null;
        Stream _s1, _s2 = null;

        private void bw_process_DoWork(object sender, DoWorkEventArgs e) {
            //backgroundworker my beloved
            ChaffContainerReader cr = (ChaffContainerReader)e.Argument;
            Stream s1 = cr.InputFile, s2 = cr.OutputFile;
            _cr = cr;
            _s1 = s1;
            _s2 = s2;

            cr.ReadFile(tb_idKey.Text, tb_encKey.Text);

            bw_process.ReportProgress(99, new ProgressState(1, 1, "Finalizing", true));
        }

        private void bw_process_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            _cr?.Dispose();

            string name = ((FileStream)_s2)?.Name;
            long sz = _s2.Length;

            _s1.Close();
            _s2.Close();

            _s1.Dispose();
            _s2.Dispose();

            if (name != null && sz == 0) {
                MessageBox.Show("Decoding successful but output file empty. This may indicate an incorrect ID key. Deleting empty output file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.Delete(name);
            }

            Invoke(new Action(() => bw_process_ProgressChanged(null, new ProgressChangedEventArgs(100, e.Error))));
        }
    }
}
