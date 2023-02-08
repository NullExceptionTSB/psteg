using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using psteg.Crypto;
using psteg.Stegano.Engine;
using psteg.Stegano.Engine.Encode;
using psteg.Stegano.File;
using psteg.Stegano.UI.LSBExtra;

namespace psteg.Stegano.UI {
    public partial class LSBEncode : Form {
        FileID CoverID = null;

        Size FormerClientSize;
        UserControl ExtraOptions = null;

        private ImageFormat GetImageFormat() {
            switch(CoverID.FileFormat) {
                case FileFormat.BMP: return ImageFormat.Bmp;
                case FileFormat.PNG: return ImageFormat.Png;
                case FileFormat.GIF: return ImageFormat.Gif;
                default: return ImageFormat.Png;
            }
        }

        public LSBEncode() {
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
                    Controls.Remove(ExtraOptions);
                    ExtraOptions?.Dispose();
                    ExtraOptions = new ExtraImage() {
                        Location = new Point(FormerClientSize.Width, gb_cover.Top)
                    };
                }
                ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width, FormerClientSize.Height);
                Controls.Add(ExtraOptions);
                ExtraOptions.Parent = this;
                //b_start.Enabled = true;
                b_setOutput.Enabled = true;
                b_browseOutput.Enabled = true;

                sfd_destination.Filter = "Images|*.bmp;*.dib;*.gif;*.png";
            }
            else if (CoverID.GetType().IsSubclassOf(typeof(AudioFileID))) {
                Controls.Remove(ExtraOptions);
                ExtraOptions?.Dispose();
                ExtraOptions = new ExtraSound((AudioFileID)CoverID) {
                    Location = new Point(FormerClientSize.Width, gb_cover.Top)
                };

                ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width, FormerClientSize.Height);
                Controls.Add(ExtraOptions);
                ExtraOptions.Parent = this;
                b_setOutput.Enabled = true;
                b_browseOutput.Enabled = true;

                sfd_destination.Filter = "Sound Files|*.wav";
            }
            else
                ClientSize = FormerClientSize;
            MayRun();
        }
        private void b_browseCover_Click(object sender, EventArgs e) {
            if (ofd_cover.ShowDialog() == DialogResult.OK)
                tb_coverPath.Text = ofd_cover.FileName;
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

            l_status.Text = ps.State?.ToString() + (ps.IndefProgress ? "..." :(": " + ps.Current + "/" + ps.Maximum));
        }
        private void MayRun() {
            b_start.Enabled = false;

            if (string.IsNullOrEmpty(tb_appOutputPath.Text)) return;

            switch (CoverID.FileFormat) {
                case FileFormat.BMP:
                case FileFormat.PNG:
                case FileFormat.GIF:
                case FileFormat.WAV:
                    if (!CoverID.IsSupported())
                        return;
                    break;
                default:
                    return;
            }

            b_start.Enabled = !string.IsNullOrEmpty(tb_appCoverPath.Text) && !string.IsNullOrEmpty(tb_outputPath.Text);
        }
        private void b_start_Click(object sender, EventArgs e) {
            LSBEncoderEngine engine = (LSBEncoderEngine)
                EncoderFactory.Create(Methods.LSB).
                OpenOutput(tb_appOutputPath.Text).
                OpenCover(tb_appCoverPath.Text).
                OpenInput(tb_appDataPath.Text).
                SetBackWork(bw_process).
                SetCryptography((Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_crypto.Items[cb_crypto.SelectedIndex].ToString()])).
                SetCryptoKey(tb_cryptoKey.Text).
                Finish();

            if (CoverID.GetType().IsSubclassOf(typeof(ImageFileID))) {
                ExtraImage ei = (ExtraImage)ExtraOptions;
                int c = 0;
                foreach (bool b in ei.ChannelAssignments.Values)
                    if (b)
                        c++;
                if (c == 0) {
                    MessageBox.Show("No channels assigned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    engine.Dispose();
                }


                engine.EngineMode = LSBEncoderEngine.Mode.Image;
                engine.IV = ei.IV;
                engine.AdaptiveDistribution = ei.AdaptiveMode;
                engine.ReverseBitOrder = ei.ReverseBitOrder;
                engine.ImageSpecificOptions = new LSBEncoderEngine._ImageSpecificOptions() {
                    BitWidth = ei.BitDepth,
                    Channels = ei.ChannelAssignments,
                    OutputFormat = GetImageFormat(),
                    RowReadMode = ei.RowReadMode
                };
            } else if (CoverID.GetType().IsSubclassOf(typeof(AudioFileID))) {
                ExtraSound es = (ExtraSound)ExtraOptions;
                AudioFileID id = (AudioFileID)CoverID;
                AudioEncode encoder = null;
                AudioDecode decoder = null;

                int c = 0;
                foreach (bool b in es.ChannelAssignments.Values)
                    if (b)
                        c++;
                if (c == 0) {
                    MessageBox.Show("No channels assigned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    engine.Dispose();
                }

                try { 
                    decoder = new File.Format.WavDecode((FileStream)engine.CoverStream);
                    encoder = new File.Format.WavEncode((FileStream)engine.OutputStream, ((File.Format.WavDecode)decoder).WaveFormat);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    engine.Dispose();
                }

                engine.IV = es.IV;
                engine.AdaptiveDistribution = es.AdaptiveMode;
                engine.ReverseBitOrder = es.ReverseBitOrder;
                engine.AudioSpecificOptions = new LSBEncoderEngine._AudioSpecificOptions() {
                    BitWidth = es.BitDepth,
                    Channels = es.ChannelAssignments,
                    ID = id,
                    Encoder = encoder,
                    Decoder = decoder
                };
            }

            bw_process.RunWorkerAsync(engine);
        }
        private void b_setOutput_Click(object sender, EventArgs e) {
            FileInfo fnfo;
            try {
                fnfo = new FileInfo(tb_outputPath.Text);
            } catch {
                MessageBox.Show("Path is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tb_appOutputPath.Text = fnfo.FullName;
            MayRun();
        }
        private void bw_process_DoWork(object sender, DoWorkEventArgs e) {
            EncoderEngine ng = (EncoderEngine)e.Argument;
            ng.Go();
            bw_process.ReportProgress(99,new ProgressState(1, 2, "Finalizing", true));
            ng.Dispose();
            bw_process.ReportProgress(100);

        }
        private void b_setData_Click(object sender, EventArgs e) {
            if (System.IO.File.Exists(tb_dataPath.Text)) 
                tb_appDataPath.Text = tb_dataPath.Text;
            MayRun();
        }
        private void b_browseData_Click(object sender, EventArgs e) {
            if (ofd_data.ShowDialog() == DialogResult.OK)
                tb_dataPath.Text = ofd_data.FileName;
        }
        private void b_browseOutput_Click(object sender, EventArgs e) {
            if (sfd_destination.ShowDialog() == DialogResult.OK)
                tb_outputPath.Text = sfd_destination.FileName;
        }
        private void tb_coverPath_DragDrop(object sender, DragEventArgs e) =>
            tb_coverPath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
        private void tb_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.Copy;
        private void tb_dataPath_DragDrop(object sender, DragEventArgs e) =>
            tb_dataPath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
        private void cb_kda_SelectedIndexChanged(object sender, EventArgs e) =>
            Encryption.KeyDerivationAlgorithm = (Crypto.KeyDerivation.KeyDerivationAlgo)Encryption.KDFList[cb_kda.Items[cb_kda.SelectedIndex].ToString()].GetConstructor(Type.EmptyTypes).Invoke(null);
        private void cb_shpwd_CheckedChanged(object sender, EventArgs e) => tb_cryptoKey.UseSystemPasswordChar = !cb_shpwd.Checked;
    }
}
