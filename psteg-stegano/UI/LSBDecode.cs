using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Crypto;
using psteg.Stegano.Engine;
using psteg.Stegano.Engine.Decode;
using psteg.Stegano.Engine.Encode;
using psteg.Stegano.File;
using psteg.Stegano.UI.LSBExtra;

namespace psteg.Stegano.UI {
    public partial class LSBDecode : Form {
        FileID CoverID = null;
        UserControl ExtraOptions = null;
        Size FormerClientSize;

        public LSBDecode() {
            InitializeComponent();
            FormerClientSize = ClientSize;

            foreach (string algo in Encryption.AlgoList.Keys)
                cb_crypto.Items.Add(algo);
            cb_crypto.SelectedIndex = 0;

            foreach (string algo in Encryption.KDFList.Keys)
                cb_kda.Items.Add(algo);
            cb_kda.SelectedIndex = 0;

            cb_kda.SelectedIndexChanged += cb_kda_SelectedIndexChanged;
        }

        public void MayRun() {
            b_start.Enabled = false;

            if (string.IsNullOrEmpty(tb_appOutputPath.Text))
                return;

            switch (CoverID.FileFormat) {
                case FileFormat.BMP:
                case FileFormat.PNG:
                case FileFormat.GIF:
                    break;
                default:
                    return;
            }

            b_start.Enabled = !string.IsNullOrEmpty(tb_appCoverPath.Text) &&
                    !string.IsNullOrEmpty(tb_outputPath.Text) &&
                    !string.IsNullOrEmpty(tb_dataLength.Text);
        }

        private void b_browseCover_Click(object sender, EventArgs e) {
            if (ofd_cover.ShowDialog() == DialogResult.OK)
                tb_coverPath.Text = ofd_cover.FileName;
        }

        private void b_setCover_Click(object sender, EventArgs e) {
            b_start.Enabled = false;
            FileStream fs;
            try { fs = new FileStream(tb_coverPath.Text, FileMode.Open, FileAccess.Read, FileShare.Read); }
            catch { return; }

            tb_appCoverPath.Text = tb_coverPath.Text;

            CoverID = FileID.New(fs);
            tb_coverID.Text = CoverID.ToString().Replace("\n", "\r\n");

            if (CoverID.GetType().IsSubclassOf(typeof(ImageFileID))) {
                if (ExtraOptions?.GetType() != typeof(ExtraImage)) {
                    ExtraOptions?.Dispose();
                    ExtraOptions = new ExtraImage() {
                        Location = new Point(ClientRectangle.Right, gb_cover.Top)
                    };
                }
                ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width, FormerClientSize.Height);
                Controls.Add(ExtraOptions);
                ExtraOptions.Parent = this;
                //b_start.Enabled = true;
            }
            else
                ClientSize = FormerClientSize;
            MayRun();
        }

        private void cb_kda_SelectedIndexChanged(object sender, EventArgs e) =>
            Encryption.KeyDerivationAlgorithm = (Crypto.KeyDerivation.KeyDerivationAlgo)Encryption.KDFList[cb_kda.Items[cb_kda.SelectedIndex].ToString()].GetConstructor(Type.EmptyTypes).Invoke(null);

        private void b_browseOutput_Click(object sender, EventArgs e) {
            if (sfd_destination.ShowDialog() == DialogResult.OK)
                tb_outputPath.Text = sfd_destination.FileName;
        }

        private void b_setOutput_Click(object sender, EventArgs e) {
            FileInfo fnfo;
            try {
                fnfo = new FileInfo(tb_outputPath.Text);
            }
            catch {
                MessageBox.Show("Path is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tb_appOutputPath.Text = fnfo.FullName;
            MayRun();
        }

        private void tb_dataLength_TextChanged(object sender, EventArgs e) => MayRun();
        private void cb_shpwd_CheckedChanged(object sender, EventArgs e) => tb_cryptoKey.UseSystemPasswordChar = !cb_shpwd.Checked;

        private void b_start_Click(object sender, EventArgs e) {
            LSBDecoderEngine engine = (LSBDecoderEngine)
                DecoderFactory.Create(Methods.LSB).
                OpenCover(tb_appCoverPath.Text).
                OpenOutput(tb_appOutputPath.Text).
                SetBackWork(bw_process).
                SetDataLength(int.Parse(tb_dataLength.Text)).
                SetCryptography((Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_crypto.Items[cb_crypto.SelectedIndex].ToString()])).
                SetCryptoKey(tb_cryptoKey.Text).
                Finish();

            if (CoverID.GetType().IsSubclassOf(typeof(ImageFileID))) {
                ExtraImage ei = (ExtraImage)ExtraOptions;

                engine.IV = ei.IV;
                engine.AdaptiveDistribution = ei.AdaptiveMode;
                engine.ReverseBitOrder = ei.ReverseBitOrder;
                engine.ImageSpecificOptions = new LSBEncoderEngine._ImageSpecificOptions() {
                    BitWidth = ei.BitDepth,
                    Channels = ei.ChannelAssignments,
                    RowReadMode = ei.RowReadMode
                };
            }
            else
                throw new NotImplementedException("Sound files not supported");

            bw_process.RunWorkerAsync(engine);
        }


        private void bw_process_DoWork(object sender, DoWorkEventArgs e) {
            DecoderEngine ng = (DecoderEngine)e.Argument;
            ng.Go();
            bw_process.ReportProgress(99, new ProgressState(1, 2, "Finalizing", true));
            ng.Dispose();
            bw_process.ReportProgress(100);
        }

        private void bw_process_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.ProgressPercentage == 100) {
                pb_progress.Maximum = 1;
                pb_progress.Value = 1;
                pb_progress.Style = ProgressBarStyle.Blocks;
                l_status.Text = "Done";
                return;
            }

            ProgressState ps = (ProgressState)e.UserState;

            if (ps.IndefProgress)
                pb_progress.Style = ProgressBarStyle.Marquee;
            else {
                pb_progress.Style = ProgressBarStyle.Blocks;
                pb_progress.Maximum = ps.Maximum;
                pb_progress.Value = ps.Current;
            }

            l_status.Text = ps.State?.ToString() + (ps.IndefProgress ? "..." : (": " + ps.Current + "/" + ps.Maximum));
        }

        private void tb_dataLength_KeyPress(object sender, KeyPressEventArgs e) 
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

    }
}
