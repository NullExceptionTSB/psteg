using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using psteg.Crypto;

namespace psteg.UI {
    public partial class AESExtra : UserControl {
        public PaddingMode PaddingMode { get; set; }

        public AESExtra(AES e, bool allowPadding = true) {
            InitializeComponent();

            cb_padmode.Enabled = allowPadding;

            foreach (PaddingMode pm in Enum.GetValues(typeof(PaddingMode))) {
                if (allowPadding && pm.ToString() == "None")
                    continue;

                cb_padmode.Items.Add(pm.ToString());  

                if (!allowPadding && pm.ToString() == "None")
                    cb_padmode.SelectedIndex = cb_padmode.Items.Count-1;
                else if (pm.ToString() == e.PaddingMode.ToString())
                    cb_padmode.SelectedIndex = cb_padmode.Items.Count-1;
            }

            foreach (int ks in e.ValidKeySizes) {
                cb_keysize.Items.Add(ks.ToString());
                if (ks == e.KeySize)
                    cb_keysize.SelectedIndex = cb_keysize.Items.Count-1;
            }

            foreach (CipherMode pm in Enum.GetValues(typeof(CipherMode))) {
                cb_blockmode.Items.Add(pm.ToString());
                if (pm.ToString() == e.BlockMode.ToString())
                    cb_blockmode.SelectedIndex = cb_blockmode.Items.Count-1;
            }
        }

        public void Apply(AES e) {
            e.PaddingMode = (PaddingMode)Enum.Parse(typeof(PaddingMode), cb_padmode.Items[cb_padmode.SelectedIndex].ToString());
            e.KeySize = int.Parse(cb_keysize.Items[cb_keysize.SelectedIndex].ToString());
            e.BlockMode = (CipherMode)Enum.Parse(typeof(CipherMode), cb_blockmode.Items[cb_blockmode.SelectedIndex].ToString());
        }
    }
}
