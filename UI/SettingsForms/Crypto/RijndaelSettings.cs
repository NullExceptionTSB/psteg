using System;
using System.Security.Cryptography;
using System.Windows.Forms;

using psteg.Algorithm.Crypto;

namespace psteg.UI.SettingsForms.Crypto {
    public partial class RijndaelSettings : Form {
        private readonly CryptoRijndael _owner;

        public RijndaelSettings(CryptoRijndael owner) {
            _owner = owner;
            InitializeComponent();

            foreach (KeySizes ks in _owner.ValidKeySizes) 
                for (int size = ks.MinSize; size <= ks.MaxSize; size += ks.SkipSize) { 
                    cb_keysize.Items.Add(size.ToString());
                    if (_owner.KeySize == size)
                        cb_keysize.SelectedIndex = cb_keysize.Items.Count - 1;
                }

            foreach (KeySizes ks in _owner.ValidBlockSizes)
                for (int size = ks.MinSize; size <= ks.MaxSize; size += ks.SkipSize) {
                    cb_blocksize.Items.Add(size.ToString());
                    if (_owner.BlockSize*8 == size)
                        cb_blocksize.SelectedIndex = cb_blocksize.Items.Count - 1;
                    if (ks.SkipSize == 0)
                        break;
                }

            foreach (CipherMode mode in _owner.ValidCipherModes) {
                cb_cipherMode.Items.Add(mode.ToString());
                if (_owner.CipherMode == mode)
                    cb_cipherMode.SelectedIndex = cb_cipherMode.Items.Count - 1;
            }

            foreach (PaddingMode mode in _owner.ValidPaddingModes) {
                cb_paddingMode.Items.Add(mode.ToString());
                if (_owner.PaddingMode == mode)
                    cb_paddingMode.SelectedIndex = cb_paddingMode.Items.Count - 1;
            }

        }

        private void b_cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void b_ok_Click(object sender, EventArgs e) {
            _owner.KeySize = int.Parse((string)cb_keysize.SelectedItem);
            _owner.SetBlockSize(int.Parse((string)cb_blocksize.SelectedItem));
            _owner.PaddingMode = (PaddingMode)Enum.Parse(typeof(PaddingMode), (string)cb_paddingMode.SelectedItem);
            _owner.CipherMode = (CipherMode)Enum.Parse(typeof(CipherMode), (string)cb_cipherMode.SelectedItem);
            Close();
        }
    }
}
