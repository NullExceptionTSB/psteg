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
    public partial class ADSSettings : Form {
        private readonly SteganoADS _owner = null;
        private const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public ADSSettings(SteganoADS owner) {
            _owner = owner;
            InitializeComponent();

            tb_streamname.Text = _owner.StreamName;
        }

        private void b_randomize_Click(object sender, EventArgs e) {
            Random random = new Random();
            tb_streamname.Text = "";
            for (int i = 0; i < 32; i++)
                tb_streamname.Text += allowedChars[random.Next(allowedChars.Length-1)];
        }

        private void button1_Click(object sender, EventArgs e) {
            _owner.StreamName = tb_streamname.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
