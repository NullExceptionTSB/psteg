using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace psteg.Stegano.UI.LSBExtra {
    public partial class ExtraImage : UserControl {
        public Dictionary<char, bool> ChannelAssignments {
            get => new Dictionary<char, bool>() {
                { 'R', cb_r.Checked },
                { 'G', cb_g.Checked },
                { 'B', cb_b.Checked },
                { 'A', cb_a.Checked }
            };
        }

        public bool AdaptiveMode { get => false; }
        public int BitDepth { get => tb_bitdepth.Value; }
        public bool RowReadMode { get => cb_row_read_mode.Checked; }
        public bool ReverseBitOrder { get => cb_rbo.Checked; }
        public string ChannelString { get => tb_co.Text; }

        public int? IV {
            get {
                if (cb_iv.Checked) return int.Parse(tb_iv.Text);
                return null;
            }
        }

        public ExtraImage() { 
            InitializeComponent();
            cb_dist_algo.SelectedIndex = 0;
        }

        private void tb_bitdepth_Scroll(object sender, EventArgs e) => l_bitdepth.Text = tb_bitdepth.Value.ToString();

        private void cb_iv_CheckedChanged(object sender, EventArgs e) => tb_iv.Enabled = cb_iv.Checked;
        //mess, rewrite later
        private void cb_chan_chc(object sender, EventArgs e) {
            if (cb_co.Checked) {
                bool b = false, g = false, r = false, a = false;
                foreach (char c in tb_co.Text) {
                    switch (c) {
                        case 'B':
                            b=cb_b.Checked;
                            if (!cb_b.Checked)
                                tb_co.Text = tb_co.Text.Replace("B", "");
                            break;
                        case 'G':
                            g=cb_g.Checked;
                            if (!cb_g.Checked)
                                tb_co.Text = tb_co.Text.Replace("G", "");
                            break;
                        case 'R':
                            r=cb_r.Checked;
                            if (!cb_r.Checked)
                                tb_co.Text = tb_co.Text.Replace("R", "");
                            break;
                        case 'A':
                            a=cb_a.Checked;
                            if (!cb_a.Checked)
                                tb_co.Text = tb_co.Text.Replace("A", "");
                            break;
                    }
                }

                if (!b && cb_b.Checked)
                    tb_co.Text += "B";
                if (!g && cb_g.Checked)
                    tb_co.Text += "G";
                if (!r && cb_r.Checked)
                    tb_co.Text += "R";
                if (!a && cb_a.Checked)
                    tb_co.Text += "A";
            } else {
                tb_co.Text = "";
                tb_co.Text += cb_b.Checked ? "B" : "";
                tb_co.Text += cb_g.Checked ? "G" : "";
                tb_co.Text += cb_r.Checked ? "R" : "";
                tb_co.Text += cb_a.Checked ? "A" : "";
            }
        }

        private void cb_co_CheckedChanged(object sender, EventArgs e) {
            tb_co.Enabled = cb_co.Checked;
            cb_chan_chc(null, null);
        }

        private void tb_co_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
            switch (e.KeyChar) {
                case 'r':
                case 'R':
                    if (cb_r.Checked && !tb_co.Text.Contains("R"))
                        tb_co.Text += "R";
                    break;
                case 'g':
                case 'G':
                    if (cb_g.Checked && !tb_co.Text.Contains("G"))
                        tb_co.Text += "G";
                    break;
                case 'b':
                case 'B':
                    if (cb_b.Checked && !tb_co.Text.Contains("B"))
                        tb_co.Text += "B";
                    break;
                case 'a':
                case 'A':
                    if (cb_a.Checked && !tb_co.Text.Contains("A"))
                        tb_co.Text += "A";
                    break;
                case '\b':
                    e.Handled = false;
                    break;
            }
        }
    }
}
