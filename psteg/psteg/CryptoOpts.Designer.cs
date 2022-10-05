namespace psteg {
    partial class CryptoOpts {
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
            this.lv_methods = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.l_method = new System.Windows.Forms.Label();
            this.b_advopts = new System.Windows.Forms.Button();
            this.rb_password = new System.Windows.Forms.RadioButton();
            this.rb_key = new System.Windows.Forms.RadioButton();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.tb_pw_key = new System.Windows.Forms.TextBox();
            this.b_browse = new System.Windows.Forms.Button();
            this.sfd_key = new System.Windows.Forms.SaveFileDialog();
            this.ofd_key = new System.Windows.Forms.OpenFileDialog();
            this.l_pw_key = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_showpw = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lv_methods
            // 
            this.lv_methods.HideSelection = false;
            this.lv_methods.Location = new System.Drawing.Point(12, 25);
            this.lv_methods.MultiSelect = false;
            this.lv_methods.Name = "lv_methods";
            this.lv_methods.Size = new System.Drawing.Size(200, 200);
            this.lv_methods.TabIndex = 0;
            this.lv_methods.UseCompatibleStateImageBehavior = false;
            this.lv_methods.View = System.Windows.Forms.View.List;
            this.lv_methods.ItemActivate += new System.EventHandler(this.lv_methods_ItemActivate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Method";
            // 
            // l_method
            // 
            this.l_method.AutoSize = true;
            this.l_method.Location = new System.Drawing.Point(185, 9);
            this.l_method.Name = "l_method";
            this.l_method.Size = new System.Drawing.Size(27, 13);
            this.l_method.TabIndex = 2;
            this.l_method.Text = "N/A";
            // 
            // b_advopts
            // 
            this.b_advopts.Location = new System.Drawing.Point(218, 174);
            this.b_advopts.Name = "b_advopts";
            this.b_advopts.Size = new System.Drawing.Size(239, 23);
            this.b_advopts.TabIndex = 3;
            this.b_advopts.Text = "Advanced Options";
            this.b_advopts.UseVisualStyleBackColor = true;
            this.b_advopts.Click += new System.EventHandler(this.b_advopts_Click);
            // 
            // rb_password
            // 
            this.rb_password.AutoSize = true;
            this.rb_password.Location = new System.Drawing.Point(218, 41);
            this.rb_password.Name = "rb_password";
            this.rb_password.Size = new System.Drawing.Size(71, 17);
            this.rb_password.TabIndex = 4;
            this.rb_password.Text = "Password";
            this.rb_password.UseVisualStyleBackColor = true;
            this.rb_password.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_key
            // 
            this.rb_key.AutoSize = true;
            this.rb_key.Location = new System.Drawing.Point(218, 64);
            this.rb_key.Name = "rb_key";
            this.rb_key.Size = new System.Drawing.Size(43, 17);
            this.rb_key.TabIndex = 5;
            this.rb_key.Text = "Key";
            this.rb_key.UseVisualStyleBackColor = true;
            this.rb_key.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(218, 200);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(118, 23);
            this.b_ok.TabIndex = 6;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(339, 200);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(118, 23);
            this.b_cancel.TabIndex = 7;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // tb_pw_key
            // 
            this.tb_pw_key.Location = new System.Drawing.Point(218, 148);
            this.tb_pw_key.Name = "tb_pw_key";
            this.tb_pw_key.Size = new System.Drawing.Size(174, 20);
            this.tb_pw_key.TabIndex = 8;
            this.tb_pw_key.TextChanged += new System.EventHandler(this.tb_pw_key_TextChanged);
            // 
            // b_browse
            // 
            this.b_browse.Location = new System.Drawing.Point(398, 146);
            this.b_browse.Name = "b_browse";
            this.b_browse.Size = new System.Drawing.Size(59, 23);
            this.b_browse.TabIndex = 9;
            this.b_browse.Text = "Browse";
            this.b_browse.UseVisualStyleBackColor = true;
            // 
            // ofd_key
            // 
            this.ofd_key.FileName = "openFileDialog1";
            // 
            // l_pw_key
            // 
            this.l_pw_key.AutoSize = true;
            this.l_pw_key.Location = new System.Drawing.Point(215, 132);
            this.l_pw_key.Name = "l_pw_key";
            this.l_pw_key.Size = new System.Drawing.Size(53, 13);
            this.l_pw_key.TabIndex = 10;
            this.l_pw_key.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Crypto key mode:";
            // 
            // cb_showpw
            // 
            this.cb_showpw.AutoSize = true;
            this.cb_showpw.Location = new System.Drawing.Point(274, 131);
            this.cb_showpw.Name = "cb_showpw";
            this.cb_showpw.Size = new System.Drawing.Size(53, 17);
            this.cb_showpw.TabIndex = 12;
            this.cb_showpw.Text = "Show";
            this.cb_showpw.UseVisualStyleBackColor = true;
            this.cb_showpw.CheckedChanged += new System.EventHandler(this.cb_showpw_CheckedChanged);
            // 
            // CryptoOpts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 235);
            this.Controls.Add(this.cb_showpw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_pw_key);
            this.Controls.Add(this.b_browse);
            this.Controls.Add(this.tb_pw_key);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.rb_key);
            this.Controls.Add(this.rb_password);
            this.Controls.Add(this.b_advopts);
            this.Controls.Add(this.l_method);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_methods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoOpts";
            this.Text = "CryptoOpts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_methods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_method;
        private System.Windows.Forms.Button b_advopts;
        private System.Windows.Forms.RadioButton rb_password;
        private System.Windows.Forms.RadioButton rb_key;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.TextBox tb_pw_key;
        private System.Windows.Forms.Button b_browse;
        private System.Windows.Forms.SaveFileDialog sfd_key;
        private System.Windows.Forms.OpenFileDialog ofd_key;
        private System.Windows.Forms.Label l_pw_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_showpw;
    }
}