using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Algorithm.Stegano;

namespace psteg.SettingsForms.Stegano {
    public partial class LSBSettings : Form {
        private readonly SteganoLSB _owner;

        public LSBSettings(SteganoLSB owner) {
            _owner = owner;
            InitializeComponent();
        }

        private void tb_bitWidth_Scroll(object sender, EventArgs e) {
            l_bitWidth.Text = tb_bitWidth.Value.ToString();
            _owner.BitWidth = tb_bitWidth.Value;
        }
    }
}
