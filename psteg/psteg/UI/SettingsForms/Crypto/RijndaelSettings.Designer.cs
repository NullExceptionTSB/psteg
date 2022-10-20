namespace psteg.UI.SettingsForms.Crypto {
    partial class RijndaelSettings {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.cb_keysize = new System.Windows.Forms.ComboBox();
            this.cb_blocksize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_paddingMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_cipherMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key Size:";
            // 
            // cb_keysize
            // 
            this.cb_keysize.FormattingEnabled = true;
            this.cb_keysize.Location = new System.Drawing.Point(97, 6);
            this.cb_keysize.Name = "cb_keysize";
            this.cb_keysize.Size = new System.Drawing.Size(153, 21);
            this.cb_keysize.TabIndex = 2;
            // 
            // cb_blocksize
            // 
            this.cb_blocksize.FormattingEnabled = true;
            this.cb_blocksize.Location = new System.Drawing.Point(97, 33);
            this.cb_blocksize.Name = "cb_blocksize";
            this.cb_blocksize.Size = new System.Drawing.Size(153, 21);
            this.cb_blocksize.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Block Size:";
            // 
            // cb_paddingMode
            // 
            this.cb_paddingMode.FormattingEnabled = true;
            this.cb_paddingMode.Location = new System.Drawing.Point(97, 60);
            this.cb_paddingMode.Name = "cb_paddingMode";
            this.cb_paddingMode.Size = new System.Drawing.Size(153, 21);
            this.cb_paddingMode.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Padding Mode:";
            // 
            // cb_cipherMode
            // 
            this.cb_cipherMode.FormattingEnabled = true;
            this.cb_cipherMode.Location = new System.Drawing.Point(97, 87);
            this.cb_cipherMode.Name = "cb_cipherMode";
            this.cb_cipherMode.Size = new System.Drawing.Size(153, 21);
            this.cb_cipherMode.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cipher Mode:";
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(134, 114);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(116, 23);
            this.b_cancel.TabIndex = 9;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(12, 114);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(116, 23);
            this.b_ok.TabIndex = 10;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // RijndaelSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 144);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.cb_cipherMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_paddingMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_blocksize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_keysize);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RijndaelSettings";
            this.Text = "Rijndael Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_keysize;
        private System.Windows.Forms.ComboBox cb_blocksize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_paddingMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_cipherMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_ok;
    }
}