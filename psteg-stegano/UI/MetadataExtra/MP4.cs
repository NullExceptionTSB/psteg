using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psteg.Stegano.UI.MetadataExtra {
    public partial class MP4 : UserControl {
        public MP4() {
            InitializeComponent();
        }

        public string BoxName { get => tb_boxname.Text; }
    }
}
