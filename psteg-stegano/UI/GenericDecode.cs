﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using psteg.Crypto;
using psteg.Stegano.Engine;
using psteg.Stegano.Engine.Util;
using psteg.Stegano.Engine.Decode;
using psteg.Stegano.Engine.Encode;
using psteg.Stegano.File;
using psteg.Stegano.UI.LSBExtra;

namespace psteg.Stegano.UI {
    
    public partial class GenericDecode : Form {
        FileID CoverID = null;
        UserControl ExtraOptions = null;
        UserControl ExtraCrypto = null;
        Size FormerClientSize;

        public GenericDecode() {
            InitializeComponent();
            FormerClientSize = ClientSize;

            foreach (string algo in Encryption.AlgoList.Keys)
                cb_crypto.Items.Add(algo);
            cb_crypto.SelectedIndex = 0;

            foreach (string algo in Encryption.KDFList.Keys)
                cb_kda.Items.Add(algo);
            cb_kda.SelectedIndex = 0;

            cb_kda.SelectedIndexChanged += cb_kda_SelectedIndexChanged;

            foreach (Control c in Controls) {
                if (c != cb_sm && c != this && c != label5)
                    c.Enabled = false;
            }
        }

        private void MayRun() {
            switch (cb_sm.Items[cb_sm.SelectedIndex].ToString()) {
                case "LSB":
                    MayRunLSB();
                    return;
                case "Metadata":
                    MayRunMetadata();
                    return;
                case "JPEG LSB-DCT":
                    MayRunJpegLsbDct();
                    break;
            }
        }
        #region LSB Specific
        public void MayRunLSB() {
            b_start.Enabled = false;

            if (string.IsNullOrEmpty(tb_appOutputPath.Text))
                return;

            switch (CoverID.FileFormat) {
                case FileFormat.BMP:
                case FileFormat.PNG:
                case FileFormat.GIF:
                case FileFormat.TIFF:
                case FileFormat.WAV:
                    if (!CoverID.IsSupported())
                        return;
                    break;
                default:
                    return;
            }

            b_start.Enabled = !string.IsNullOrEmpty(tb_appCoverPath.Text) &&
                    !string.IsNullOrEmpty(tb_outputPath.Text) &&
                    !string.IsNullOrEmpty(tb_dataLength.Text);
        }

        private void b_setCover_Click_LSB(object sender, EventArgs e) {
            b_start.Enabled = false;
            FileStream fs;
            try { fs = new FileStream(tb_coverPath.Text, FileMode.Open, FileAccess.Read, FileShare.Read); }
            catch { return; }

            tb_appCoverPath.Text = tb_coverPath.Text;
            int starty = ExtraCrypto != null ? ExtraCrypto.Bottom : 0;

            CoverID = FileID.New(fs);
            tb_coverID.Text = CoverID.ToString().Replace("\n", "\r\n");
            fs.Close();
            fs.Dispose();

            if (CoverID.GetType().IsSubclassOf(typeof(ImageFileID))) {
                if (ExtraOptions?.GetType() != typeof(ExtraImage)) {
                    Controls.Remove(ExtraOptions);
                    ExtraOptions?.Dispose();
                    ExtraOptions = new ExtraImage() {
                        Location = new Point(FormerClientSize.Width, Math.Max(gb_cover.Top, starty))
                    };
                }
                ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width + 12, FormerClientSize.Height);
                Controls.Add(ExtraOptions);
                ExtraOptions.Parent = this;
                
            }
            else if (CoverID.GetType().IsSubclassOf(typeof(AudioFileID))) {
                Controls.Remove(ExtraOptions);
                ExtraOptions?.Dispose();
                ExtraOptions = new ExtraSound((AudioFileID)CoverID) {
                    Location = new Point(FormerClientSize.Width, Math.Max(gb_cover.Top, starty))
                };

                ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width + 12, FormerClientSize.Height);
                Controls.Add(ExtraOptions);
                ExtraOptions.Parent = this;
            }
            else {
                if (ExtraCrypto == null)
                    ClientSize = FormerClientSize;
                else if (ExtraCrypto.Location.Y != gb_cover.Top)
                    ExtraCrypto.Location = new Point(ExtraCrypto.Location.X, gb_cover.Top);

                Controls.Remove(ExtraOptions);
                ExtraOptions?.Dispose();
                ExtraOptions = null;
            }
            MayRunLSB();
        }

        private void b_start_Click_LSB(object sender, EventArgs e) {
            int i;
            if (!int.TryParse(tb_dataLength.Text, out i) || i < 0) {
                MessageBox.Show("Invalid data length", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LSBDecoderEngine engine = (LSBDecoderEngine)
                DecoderFactory.Create(Methods.LSB).
                OpenCover(tb_appCoverPath.Text).
                OpenOutput(tb_appOutputPath.Text).
                SetBackWork(bw_process).
                SetDataLength(i).
                SetCryptography((Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_crypto.Items[cb_crypto.SelectedIndex].ToString()])).
                SetCryptoKey(tb_cryptoKey.Text).
                Finish();

            switch (ExtraCrypto?.GetType().ToString()) {
                case "psteg.UI.AESExtra":
                    ((psteg.UI.AESExtra)ExtraCrypto).Apply((AES)engine.Encryption);
                    break;
            }

            if (CoverID.GetType().IsSubclassOf(typeof(ImageFileID))) {
                ExtraImage ei = (ExtraImage)ExtraOptions;

                engine.BitWidth = ei.BitDepth;
                engine.EngineMode = LSB.Mode.Image;
                engine.IV = ei.IV;
                engine.AdaptiveDistribution = ei.AdaptiveMode;
                engine.ReverseBitOrder = ei.ReverseBitOrder;
                engine.ImageSpecificOptions = new LSB.SpecificOptions.Img() {
                    ChannelString = ei.ChannelString,
                    RowReadMode = ei.RowReadMode
                };
            }
            else if (CoverID.GetType().IsSubclassOf(typeof(AudioFileID))) {
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
                    return;
                }

                try {
                    decoder = new File.Format.WavDecode((FileStream)engine.CoverStream);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    engine.Dispose();
                }

                engine.EngineMode = LSB.Mode.Audio;
                engine.IV = es.IV;
                engine.AdaptiveDistribution = es.AdaptiveMode;
                engine.ReverseBitOrder = es.ReverseBitOrder;
                engine.BitWidth = es.BitDepth;

                engine.AudioSpecificOptions = new LSB.SpecificOptions.Audio() {
                    Channels = es.ChannelAssignments,
                    ID = id,
                    Encoder = encoder,
                    Decoder = decoder
                };
            }

            bw_process.RunWorkerAsync(engine);
        }
        #endregion
        #region Metadata
        public void MayRunMetadata() {
            b_start.Enabled = false;

            if (string.IsNullOrEmpty(tb_appOutputPath.Text))
                return;

            switch (CoverID.FileFormat) {
                case FileFormat.JPEG:
                case FileFormat.MP4:
                    if (!CoverID.IsSupported())
                        return;
                    break;
                default:
                    return;
            }

            b_start.Enabled = !string.IsNullOrEmpty(tb_appCoverPath.Text) &&
                    !string.IsNullOrEmpty(tb_outputPath.Text);
        }
        private void b_setCover_Click_Metadata(object sender, EventArgs e) {
            b_start.Enabled = false;
            FileStream fs;
            try { fs = new FileStream(tb_coverPath.Text, FileMode.Open, FileAccess.Read, FileShare.Read); }
            catch { return; }

            tb_appCoverPath.Text = tb_coverPath.Text;
            int starty = ExtraCrypto != null ? ExtraCrypto.Bottom : 0;

            CoverID = FileID.New(fs);
            tb_coverID.Text = CoverID.ToString().Replace("\n", "\r\n");
            fs.Close();
            fs.Dispose();

            switch (CoverID.FileFormat) {
                case FileFormat.JPEG:
                    if (ExtraOptions?.GetType() != typeof(MetadataExtra.Jpeg)) {
                        Controls.Remove(ExtraOptions);
                        ExtraOptions?.Dispose();
                        ExtraOptions = new MetadataExtra.Jpeg() {
                            Location = new Point(FormerClientSize.Width, Math.Max(gb_cover.Top, starty))
                        };
                    }

                    ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width + 12, FormerClientSize.Height);
                    Controls.Add(ExtraOptions);
                    ExtraOptions.Parent = this;
                    break;
                case FileFormat.MP4:
                    if (ExtraOptions?.GetType() != typeof(MetadataExtra.MP4)) {
                        Controls.Remove(ExtraOptions);
                        ExtraOptions?.Dispose();
                        ExtraOptions = new MetadataExtra.MP4() {
                            Location = new Point(FormerClientSize.Width, Math.Max(gb_cover.Top, starty))
                        };
                    }

                    ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width + 12, FormerClientSize.Height);
                    Controls.Add(ExtraOptions);
                    ExtraOptions.Parent = this;
                    break;
                default:
                    if (ExtraCrypto == null)
                        ClientSize = FormerClientSize;
                    else if (ExtraCrypto.Location.Y != gb_cover.Top)
                        ExtraCrypto.Location = new Point(ExtraCrypto.Location.X, gb_cover.Top);

                    Controls.Remove(ExtraOptions);
                    ExtraOptions?.Dispose();
                    ExtraOptions = null;
                    break;
            }


            b_setOutput.Enabled = true;
            b_browseOutput.Enabled = true;

            MayRunMetadata();
        }

        private void b_start_Click_Metadata(object sender, EventArgs e) {
            MetadataDecoderEngine engine = (MetadataDecoderEngine)
                DecoderFactory.Create(Methods.Metadata).
                OpenOutput(tb_appOutputPath.Text).
                OpenCover(tb_appCoverPath.Text).
                SetBackWork(bw_process).
                SetCryptography((Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_crypto.Items[cb_crypto.SelectedIndex].ToString()])).
                SetCryptoKey(tb_cryptoKey.Text).
                Finish();

            switch (ExtraCrypto?.GetType().ToString()) {
                case "psteg.UI.AESExtra":
                    ((psteg.UI.AESExtra)ExtraCrypto).Apply((AES)engine.Encryption);
                    break;
            }

            switch (CoverID.FileFormat) {
                case FileFormat.JPEG:
                    MetadataExtra.Jpeg je = (MetadataExtra.Jpeg)ExtraOptions;
                    engine.JpegMarker = je.Marker;
                    break;
                case FileFormat.MP4:
                    MetadataExtra.MP4 me = (MetadataExtra.MP4)ExtraOptions;
                    engine.MP4BoxName = me.BoxName;
                    break;
                default:
                    throw new Exception("sex overload");
            }

            bw_process.RunWorkerAsync(engine);
        }
        #endregion
        #region JPEG LSB-DCT
        public void MayRunJpegLsbDct() {
            b_start.Enabled = false;

            if (string.IsNullOrEmpty(tb_appOutputPath.Text))
                return;

            switch (CoverID.FileFormat) {
                case FileFormat.JPEG:
                    if (!CoverID.IsSupported())
                        return;
                    break;
                default:
                    return;
            }

            b_start.Enabled = !string.IsNullOrEmpty(tb_appCoverPath.Text) &&
                    !string.IsNullOrEmpty(tb_outputPath.Text) &&
                    !string.IsNullOrEmpty(tb_dataLength.Text);
        }

        private void b_setCover_Click_JpegLsbDct(object sender, EventArgs e) {
            b_start.Enabled = false;
            FileStream fs;
            try { fs = new FileStream(tb_coverPath.Text, FileMode.Open, FileAccess.Read, FileShare.Read); }
            catch { return; }

            tb_appCoverPath.Text = tb_coverPath.Text;
            int starty = ExtraCrypto != null ? ExtraCrypto.Bottom : 0;

            CoverID = FileID.New(fs);
            tb_coverID.Text = CoverID.ToString().Replace("\n", "\r\n");
            fs.Close();
            fs.Dispose();

            switch (CoverID.FileFormat) {
                case FileFormat.JPEG:
                    if (ExtraOptions?.GetType() != typeof(JpegExtra.ExtraJpeg)) {
                        Controls.Remove(ExtraOptions);
                        ExtraOptions?.Dispose();
                        ExtraOptions = new JpegExtra.ExtraJpeg() {
                            Location = new Point(FormerClientSize.Width, Math.Max(gb_cover.Top, starty))
                        };
                    }

                    ClientSize = new Size(FormerClientSize.Width + ExtraOptions.Size.Width + 12, FormerClientSize.Height);
                    Controls.Add(ExtraOptions);
                    ExtraOptions.Parent = this;
                    break;
                default:
                    if (ExtraCrypto == null)
                        ClientSize = FormerClientSize;
                    else if (ExtraCrypto.Location.Y != gb_cover.Top)
                        ExtraCrypto.Location = new Point(ExtraCrypto.Location.X, gb_cover.Top);

                    Controls.Remove(ExtraOptions);
                    ExtraOptions?.Dispose();
                    ExtraOptions = null;
                    break;
            }


            b_setOutput.Enabled = true;
            b_browseOutput.Enabled = true;

            MayRunJpegLsbDct();
        }
        private void b_start_Click_JpegLsbDct(object sender, EventArgs e) {
            DecoderEngine engine = DecoderFactory.Create(Methods.DCT, ((JpegExtra.ExtraJpeg)ExtraOptions).GetOptions()).
                OpenOutput(tb_appOutputPath.Text).
                OpenCover(tb_appCoverPath.Text).
                SetBackWork(bw_process).
                SetCryptography((Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_crypto.Items[cb_crypto.SelectedIndex].ToString()])).
                SetCryptoKey(tb_cryptoKey.Text).
                SetDataLength(int.Parse(tb_dataLength.Text)).
                Finish();

            switch (ExtraCrypto?.GetType().ToString()) {
                case "psteg.UI.AESExtra":
                    ((psteg.UI.AESExtra)ExtraCrypto).Apply((AES)engine.Encryption);
                    break;
            }

            bw_process.RunWorkerAsync(engine);
        }
        #endregion

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

        private void b_browseCover_Click(object sender, EventArgs e) {
            if (ofd_cover.ShowDialog() == DialogResult.OK)
                tb_coverPath.Text = ofd_cover.FileName;
        }

        private IDisposable _ng;

        private void bw_process_DoWork(object sender, DoWorkEventArgs e) {
            DecoderEngine ng = (DecoderEngine)e.Argument;
            _ng = ng;
            ng.Go();
            bw_process.ReportProgress(99, new ProgressState(1, 2, "Finalizing", true));

        }

        private void bw_process_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.ProgressPercentage == 100) {
                pb_progress.Maximum = 1;
                pb_progress.Value = 1;
                pb_progress.Style = ProgressBarStyle.Blocks;
                l_status.Text = (string)e.UserState;
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

        private void tb_dataLength_KeyPress(object sender, KeyPressEventArgs e) => 
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        private void tb_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = DragDropEffects.Copy;

        private void tb_coverPath_DragDrop(object sender, DragEventArgs e) =>
            tb_coverPath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];

        private void cb_crypto_SelectedIndexChanged(object sender, EventArgs e) {
            Encryption tmp = (Encryption)Activator.CreateInstance(Encryption.AlgoList[cb_crypto.Items[cb_crypto.SelectedIndex].ToString()]);
            Controls.Remove(ExtraCrypto);
            ExtraCrypto?.Dispose();
            if (tmp.ExtraOptions == null) {
                if (ExtraOptions == null)
                    ClientSize = FormerClientSize;
                else
                    ExtraOptions.Location = new Point(ExtraOptions.Location.X, gb_cover.Top);
                tmp.Dispose();
                ExtraCrypto = null;
                return;
            }

            ExtraCrypto = (UserControl)Activator.CreateInstance(tmp.ExtraOptions, new object[] { tmp, true });

            ExtraCrypto.Location = new Point(FormerClientSize.Width, ExtraOptions != null ? ExtraOptions.Bottom : gb_cover.Top);
            ClientSize = new Size(FormerClientSize.Width + ExtraCrypto.Width + 12, FormerClientSize.Height);
            Controls.Add(ExtraCrypto);
            tmp.Dispose();
        }

        private void cb_sm_SelectedIndexChanged(object sender, EventArgs e) {
            if (cb_sm.SelectedIndex == -1)
                return;

            foreach (Control c in Controls)
                if (c != b_start)
                    c.Enabled = true;
            cb_sm.Enabled = false;

            switch (cb_sm.Items[cb_sm.SelectedIndex].ToString()) {
                case "LSB":
                    break;
                case "Metadata":
                    ofd_cover.Filter = "JPEG Files|*.jpg;*.jpeg;*.jfif|MP4 Files|*.mp4";
                    b_setCover.Click -= b_setCover_Click_LSB;
                    b_start.Click -= b_start_Click_LSB;
                    b_setCover.Click += b_setCover_Click_Metadata;
                    b_start.Click += b_start_Click_Metadata;
                    tb_dataLength.Enabled = false;
                    break;
                case "JPEG LSB-DCT":
                    ofd_cover.Filter = "JPEG Files|*.jpg;*.jpeg;*.jfif";
                    b_setCover.Click -= b_setCover_Click_LSB;
                    b_start.Click -= b_start_Click_LSB;
                    b_setCover.Click += b_setCover_Click_JpegLsbDct;
                    b_start.Click += b_start_Click_JpegLsbDct;
                    break;
            }
        }

        private void bw_process_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Exception err = e.Error;
            _ng.Dispose();
            Invoke(new Action(() => bw_process_ProgressChanged(null, new ProgressChangedEventArgs(100, err!=null ? "Error" : "Done"))));
            pb_progress.Invoke(new Action(delegate {
                pb_progress.Style = ProgressBarStyle.Continuous;
                pb_progress.Maximum = 1;
                pb_progress.Value = 1;
            }));
            if (err!=null)
                MessageBox.Show("Decoder error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tb_coverPath_TextChanged(object sender, EventArgs e) {
            try { ofd_cover.FileName = tb_coverPath.Text; }
            catch { }
        }

        private void tb_outputPath_TextChanged(object sender, EventArgs e) {
            try { sfd_destination.FileName = tb_outputPath.Text; }
            catch { }
        }
    }
}
