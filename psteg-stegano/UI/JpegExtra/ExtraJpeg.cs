using System;
using System.Windows.Forms;

using psteg.Stegano.Engine.Encode;

namespace psteg.Stegano.UI.JpegExtra {
    public partial class ExtraJpeg : UserControl {
        public ExtraJpeg() {
            InitializeComponent();

            tb_ins_depth.Enabled = JpegCoderOptions.ALLOW_INSERT;
            tb_ins_depth.Value = JpegCoderOptions.ALLOW_INSERT ? JpegCoderOptions.DEFAULT_INS_DEPTH : 1;
            tb_sub_depth.Value = JpegCoderOptions.DEFAULT_SUB_DEPTH;

            cb_dist_algo.SelectedIndex = 0;
        }

        public JpegCoderOptions GetOptions() {
            switch (cb_dist_algo.SelectedIndex) {
                case 0:
                    return new JstegCoderOptions() {
                        InsertInZRL = cb_zrlinsert.Checked,
                        MaxInsertDepth = tb_ins_depth.Value,
                        MaxSubstituteDepth = tb_sub_depth.Value
                    };
                default: return null;
            }
        }

        private void cb_zrlinsert_CheckedChanged(object sender, EventArgs e) =>
            tb_sub_depth.Enabled = cb_zrlinsert.Checked;
        private void tb_sub_depth_Scroll(object sender, EventArgs e) =>
            l_sub_depth.Text = tb_sub_depth.Value.ToString();
        private void tb_ins_depth_Scroll(object sender, EventArgs e) =>
            l_ins_depth.Text = tb_ins_depth.Value.ToString();
        
    }
}
