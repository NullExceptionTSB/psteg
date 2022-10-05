using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Algorithm;

namespace psteg {
    public partial class CryptoOpts : Form {
        private PstegEngine engine;

        private Size tb_key_Size = new Size(174, 20);
        private Size tb_password_Size;
        private CryptoMethod newMethod;

        private string pass = null;
        private string key = null;

        private bool inhibitsave = false;
        private bool init = true;

        public CryptoOpts(PstegEngine engine) {
            this.engine = engine;
            InitializeComponent();
            
            tb_password_Size = b_advopts.Size;

            InitAlgoList();
            CryptoMethod? method = engine.CryptoAlgorithm?.MethodEnum;
            if (string.IsNullOrEmpty(l_method.Text)) l_method.Text = "N/A";

            ChangeMethod(method == null ? CryptoMethod.None : (CryptoMethod)method);


            rb_key.Checked = engine.KeyMode == KeyMode.Key;
            rb_password.Checked = !rb_key.Checked;

            pass = engine.CryptoAlgorithm?.CryptoPasswd;

            init = false;
        }

        public void InitAlgoList() {
            foreach (CryptoMethod key in PstegEngine.KnownCrypto.Keys)
                lv_methods.Items.Add(key.ToString());
        }

        private void UpdateMethodText(string text) {
            l_method.Text = text;
            Point oldLoc = l_method.Location;
            Point newLoc = new Point(lv_methods.Right - l_method.Width, oldLoc.Y);
            l_method.Location = newLoc;
        }

        private void ChangeMethod(CryptoMethod method) {
            newMethod = method;
            if (method != CryptoMethod.None)
                UpdateMethodText(method.ToString());
            else
                UpdateMethodText("N/A");

            bool validMethod = method != CryptoMethod.None;
            
            rb_key.Enabled = validMethod;
            rb_password.Enabled = validMethod;

            tb_pw_key.Enabled = validMethod;
            b_browse.Enabled = validMethod;
            b_ok.Enabled = validMethod;

            cb_showpw.Enabled = validMethod;

            engine.SetAlgorithms(newMethod);
        }

        #region WinForms Code
        private void b_advopts_Click(object sender, EventArgs e) {
            if (!engine.ShowCryptoSettings()) MessageBox.Show("Selected algorithm has no settings", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rb_CheckedChanged(object sender, EventArgs e) {
            inhibitsave = true;
            if (rb_key.Checked) {
                b_browse.Visible = true;
                tb_pw_key.Size = tb_key_Size;
                l_pw_key.Text = "Key path:";
                tb_pw_key.PasswordChar = '\0';
                cb_showpw.Visible = false;

                if (!init) tb_pw_key.Text = key;
            }
            else {
                b_browse.Visible = false;
                tb_pw_key.Size = tb_password_Size;
                l_pw_key.Text = "Password:";
                cb_showpw.Visible = true;
                tb_pw_key.PasswordChar = cb_showpw.Checked ? '\0' : '*';

                //key = tb_pw_key.Text;
                if (!init) tb_pw_key.Text = pass;
            }
            inhibitsave = false;
        }
        
        private void b_ok_Click(object sender, EventArgs e) {
            engine.KeyMode = rb_key.Checked ? KeyMode.Key : KeyMode.Password;
            Close();
        }

        private void lv_methods_ItemActivate(object sender, EventArgs e) {
            CryptoMethod newMethod;
            if (!Enum.TryParse(lv_methods.SelectedItems[0].Text, out newMethod))
                MessageBox.Show("Method error?");
            else
                ChangeMethod(newMethod);
        }

        private void b_cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void cb_showpw_CheckedChanged(object sender, EventArgs e) {
            tb_pw_key.PasswordChar = cb_showpw.Checked ? '\0' : '*';
        }
        #endregion

        private void tb_pw_key_TextChanged(object sender, EventArgs e) {
            if (inhibitsave) return;

            if (rb_password.Checked)
                pass = tb_pw_key.Text;
            else
                key = tb_pw_key.Text;
        }
    }
}
