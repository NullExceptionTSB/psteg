using System;
using System.Collections.Generic;
using System.Windows.Forms;

using psteg.Stegano.File;

namespace psteg.Stegano.UI.LSBExtra {
    public partial class ExtraSound : UserControl {
        public Dictionary<char, bool> ChannelAssignments {
            get => new Dictionary<char, bool>() {
                { 'L', cb_l.Checked },
                { 'R', cb_r.Checked }
            };
        }

        private bool Mono {
            set {
                if (value) {
                    cb_l.Text = "Mono";
                    cb_r.Visible = false;
                    cb_l.Checked = true;
                    cb_l.Enabled = false;
                }
            }
        }

        public int? IV {
            get {
                if (cb_iv.Checked)
                    return int.Parse(tb_iv.Text);
                return null;
            }
        }

        private void tb_bitdepth_Scroll(object sender, EventArgs e) => l_bitdepth.Text = tb_bitdepth.Value.ToString();

        public bool AdaptiveMode { get => cb_dist_algo.Items[cb_dist_algo.SelectedIndex].ToString() != "Linear"; }
        public int BitDepth { get => tb_bitdepth.Value; }
        public bool ReverseBitOrder { get => cb_rbo.Checked; }

        public ExtraSound(AudioFileID id) {
            InitializeComponent();
            if (!id.Valid)
                throw new Exception("you forgor 💀 to error handle");

            Mono = id.Channels == 1;

            tb_bitdepth.Maximum = id.SampleSize;

            cb_dist_algo.SelectedIndex = 0;
        }
    }
}
