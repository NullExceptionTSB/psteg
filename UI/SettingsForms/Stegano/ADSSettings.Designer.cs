namespace psteg.UI.SettingsForms.Stegano {
    partial class ADSSettings {
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
            this.tb_streamname = new System.Windows.Forms.TextBox();
            this.b_randomize = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stream Name:";
            // 
            // tb_streamname
            // 
            this.tb_streamname.Location = new System.Drawing.Point(92, 12);
            this.tb_streamname.Name = "tb_streamname";
            this.tb_streamname.Size = new System.Drawing.Size(258, 20);
            this.tb_streamname.TabIndex = 1;
            // 
            // b_randomize
            // 
            this.b_randomize.Location = new System.Drawing.Point(356, 10);
            this.b_randomize.Name = "b_randomize";
            this.b_randomize.Size = new System.Drawing.Size(75, 23);
            this.b_randomize.TabIndex = 2;
            this.b_randomize.Text = "Randomize";
            this.b_randomize.UseVisualStyleBackColor = true;
            this.b_randomize.Click += new System.EventHandler(this.b_randomize_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ADSSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 69);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_randomize);
            this.Controls.Add(this.tb_streamname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ADSSettings";
            this.Text = "Alternate Data Stream Steganography Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_streamname;
        private System.Windows.Forms.Button b_randomize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}