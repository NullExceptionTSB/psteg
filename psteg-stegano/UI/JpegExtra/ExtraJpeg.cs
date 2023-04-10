using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psteg.Stegano.UI.JpegExtra {
    public partial class ExtraJpeg : UserControl {
        public ExtraJpeg() {
            InitializeComponent();
            cb_dist_algo.SelectedIndex = 0;
        }

        public Engine.Encode.JpegCoderOptions GetOptions() {
            switch (cb_dist_algo.SelectedIndex) {
                case 0:
                    return new Engine.Encode.JstegDecoderOptions() {
                        InsertInZRL = cb_zrlinsert.Checked,
                        MaxInsertDepth = tb_ins_depth.Value,
                        MaxSubstituteDepth = tb_sub_depth.Value
                    };
                default: return null;
            }
        }

        private void cb_zrlinsert_CheckedChanged(object sender, EventArgs e) =>
            tb_sub_depth.Enabled = cb_zrlinsert.Checked;
        
    }
}
