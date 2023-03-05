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
    }
}
