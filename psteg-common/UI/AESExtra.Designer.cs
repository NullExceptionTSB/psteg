namespace psteg.UI {
    partial class AESExtra {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.g_main = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_blockmode = new System.Windows.Forms.ComboBox();
            this.cb_keysize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_padmode = new System.Windows.Forms.ComboBox();
            this.g_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // g_main
            // 
            this.g_main.Controls.Add(this.cb_padmode);
            this.g_main.Controls.Add(this.label3);
            this.g_main.Controls.Add(this.label2);
            this.g_main.Controls.Add(this.label1);
            this.g_main.Controls.Add(this.cb_blockmode);
            this.g_main.Controls.Add(this.cb_keysize);
            this.g_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_main.Location = new System.Drawing.Point(0, 0);
            this.g_main.Name = "g_main";
            this.g_main.Size = new System.Drawing.Size(346, 108);
            this.g_main.TabIndex = 0;
            this.g_main.TabStop = false;
            this.g_main.Text = "AES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Block Mode:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key Size:";
            // 
            // cb_blockmode
            // 
            this.cb_blockmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_blockmode.FormattingEnabled = true;
            this.cb_blockmode.Location = new System.Drawing.Point(129, 46);
            this.cb_blockmode.Name = "cb_blockmode";
            this.cb_blockmode.Size = new System.Drawing.Size(211, 21);
            this.cb_blockmode.TabIndex = 1;
            // 
            // cb_keysize
            // 
            this.cb_keysize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_keysize.FormattingEnabled = true;
            this.cb_keysize.Location = new System.Drawing.Point(129, 19);
            this.cb_keysize.Name = "cb_keysize";
            this.cb_keysize.Size = new System.Drawing.Size(211, 21);
            this.cb_keysize.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Padding Mode:";
            // 
            // cb_padmode
            // 
            this.cb_padmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_padmode.FormattingEnabled = true;
            this.cb_padmode.Location = new System.Drawing.Point(129, 73);
            this.cb_padmode.Name = "cb_padmode";
            this.cb_padmode.Size = new System.Drawing.Size(211, 21);
            this.cb_padmode.TabIndex = 5;
            // 
            // AESExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.g_main);
            this.Name = "AESExtra";
            this.Size = new System.Drawing.Size(346, 108);
            this.g_main.ResumeLayout(false);
            this.g_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox g_main;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_blockmode;
        private System.Windows.Forms.ComboBox cb_keysize;
        private System.Windows.Forms.ComboBox cb_padmode;
        private System.Windows.Forms.Label label3;
    }
}
