using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psteg.UI.Dialog {
    public partial class KeygenDialog : Form {
        public KeygenDialog() {
            InitializeComponent();
        }

        public int KeySize { get; private set; }
        public int IVSize { get; private set; }

        private void numsOnly(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void b_cancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void b_ok_Click(object sender, EventArgs e) {
            KeySize = int.Parse(tb_keysize.Text) / 8;
            IVSize = int.Parse(tb_ivsize.Text) / 8;
            DialogResult = DialogResult.OK;
        }

        public KeygenDialog(int keysize, int ivsize) : this() {
            tb_ivsize.Text = ivsize.ToString();
            tb_keysize.Text = keysize.ToString();
        }

    }
}
