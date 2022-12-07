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

namespace psteg.UI {
    public partial class HashOpts : Form {
        private CryptoAlgorithm _owner;

        private void UpdateMethodText(string text) {
            l_method.Text = text;
            Point oldLoc = l_method.Location;
            Point newLoc = new Point(lv_algos.Right - l_method.Width, oldLoc.Y);
            l_method.Location = newLoc;
        }

        public HashOpts(CryptoAlgorithm owner) {
            _owner = owner;
            InitializeComponent();

            foreach (HashAlgo algo in CryptoAlgorithm.HashingAlgorithms) 
                lv_algos.Items.Add(algo.ToString());

            UpdateMethodText(_owner.HashingAlgorithm.ToString());
        }

        private void lv_algos_ItemActivate(object sender, EventArgs e) {
            UpdateMethodText(lv_algos.SelectedItems[0].Text);
        }

        private void b_ok_Click(object sender, EventArgs e) {
            HashAlgo hashAlgo;
            if (Enum.TryParse(l_method.Text, out hashAlgo))
                _owner.HashingAlgorithm = hashAlgo;
            Close();
        }

        private void b_cancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
