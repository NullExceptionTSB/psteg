namespace psteg.UI.Dialog {
    partial class KeygenDialog {
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
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_ok = new System.Windows.Forms.Button();
            this.tb_keysize = new System.Windows.Forms.TextBox();
            this.tb_ivsize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(133, 64);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(118, 23);
            this.b_cancel.TabIndex = 9;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(12, 64);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(118, 23);
            this.b_ok.TabIndex = 8;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // tb_keysize
            // 
            this.tb_keysize.Location = new System.Drawing.Point(69, 12);
            this.tb_keysize.Name = "tb_keysize";
            this.tb_keysize.Size = new System.Drawing.Size(182, 20);
            this.tb_keysize.TabIndex = 10;
            this.tb_keysize.Text = "256";
            this.tb_keysize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numsOnly);
            // 
            // tb_ivsize
            // 
            this.tb_ivsize.Location = new System.Drawing.Point(69, 38);
            this.tb_ivsize.Name = "tb_ivsize";
            this.tb_ivsize.Size = new System.Drawing.Size(182, 20);
            this.tb_ivsize.TabIndex = 11;
            this.tb_ivsize.Text = "128";
            this.tb_ivsize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numsOnly);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Key Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "IV Size:";
            // 
            // KeygenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 101);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ivsize);
            this.Controls.Add(this.tb_keysize);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeygenDialog";
            this.Text = "Key Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.TextBox tb_keysize;
        private System.Windows.Forms.TextBox tb_ivsize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}