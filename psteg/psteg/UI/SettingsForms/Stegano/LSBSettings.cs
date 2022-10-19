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

namespace psteg.UI.SettingsForms.Stegano {
    public partial class LSBSettings : Form {
        private readonly SteganoLSB _owner;
        private bool initialized = false;

        public LSBSettings(SteganoLSB owner) {
            _owner = owner;
            InitializeComponent();

            tb_bitWidth.Value = _owner.BitWidth;

            tb_datasize.Text = _owner.DecodedDataLength.ToString();

            cb_rowfirst.Checked = File.Image.LosslessImg.RowFirst;

            cb_imgcA.Checked = _owner.ImageChannels.HasFlag(LSBImageChannels.Alpha);
            cb_imgcR.Checked = _owner.ImageChannels.HasFlag(LSBImageChannels.Red);
            cb_imgcG.Checked = _owner.ImageChannels.HasFlag(LSBImageChannels.Green);
            cb_imgcB.Checked = _owner.ImageChannels.HasFlag(LSBImageChannels.Blue);
            initialized = true;
        }

        private void tb_bitWidth_Scroll(object sender, EventArgs e) {
            l_bitWidth.Text = tb_bitWidth.Value.ToString();
            _owner.BitWidth = tb_bitWidth.Value;
        }

        private void cb_imgc_CheckedChanged(object sender, EventArgs e) {
            if (!initialized) return;
            _owner.ImageChannels = 0;

            _owner.ImageChannels |= cb_imgcA.Checked ? LSBImageChannels.Alpha : 0;
            _owner.ImageChannels |= cb_imgcR.Checked ? LSBImageChannels.Red : 0;
            _owner.ImageChannels |= cb_imgcG.Checked ? LSBImageChannels.Green : 0;
            _owner.ImageChannels |= cb_imgcB.Checked ? LSBImageChannels.Blue : 0;
        }

        private void cb_rowfirst_CheckedChanged(object sender, EventArgs e) {
            File.Image.LosslessImg.RowFirst = cb_rowfirst.Checked;
        }

        private void tb_datasize_TextChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tb_datasize.Text))
                _owner.DecodedDataLength = null;
            else {
                long datalen;
                bool isnum = long.TryParse(tb_datasize.Text, out datalen);
                if (isnum) _owner.DecodedDataLength = datalen;
            }
        }

        private void tb_datasize_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
