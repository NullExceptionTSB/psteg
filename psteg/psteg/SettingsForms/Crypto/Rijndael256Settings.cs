using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Algorithm.Crypto;

namespace psteg.SettingsForms.Crypto {
    public partial class RijndaelSettings : Form {
        private readonly CryptoRijndael owner;

        public RijndaelSettings(CryptoRijndael owner) {
            this.owner = owner;


            InitializeComponent();
        }
    }
}
