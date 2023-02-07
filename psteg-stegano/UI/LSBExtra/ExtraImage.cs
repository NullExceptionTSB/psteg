using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool AdaptiveMode { get => cb_adaptive.Checked; }
        public int BitDepth { get => tb_bitdepth.Value; }
        public bool RowReadMode { get => cb_row_read_mode.Checked; }
        public bool ReverseBitOrder { get => cb_rbo.Checked; }
        public int? IV { 
            get {
                if (cb_iv.Checked) return int.Parse(tb_iv.Text);
                return null;
            } 
        }

        public ExtraImage() =>
            InitializeComponent();

        private void tb_bitdepth_Scroll(object sender, EventArgs e) => l_bitdepth.Text = tb_bitdepth.Value.ToString();

        private void cb_iv_CheckedChanged(object sender, EventArgs e) => tb_iv.Enabled = cb_iv.Checked;
    }
}
