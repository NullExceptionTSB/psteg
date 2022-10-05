namespace psteg.SettingsForms.Stegano {
    partial class LSBSettings {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_bitWidth = new System.Windows.Forms.TrackBar();
            this.l_bitWidth = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l_bitWidth);
            this.groupBox1.Controls.Add(this.tb_bitWidth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bit Width [Reccomended: 2]\r\n";
            // 
            // tb_bitWidth
            // 
            this.tb_bitWidth.Location = new System.Drawing.Point(6, 32);
            this.tb_bitWidth.Maximum = 8;
            this.tb_bitWidth.Minimum = 1;
            this.tb_bitWidth.Name = "tb_bitWidth";
            this.tb_bitWidth.Size = new System.Drawing.Size(216, 45);
            this.tb_bitWidth.TabIndex = 1;
            this.tb_bitWidth.Value = 2;
            this.tb_bitWidth.Scroll += new System.EventHandler(this.tb_bitWidth_Scroll);
            // 
            // l_bitWidth
            // 
            this.l_bitWidth.AutoSize = true;
            this.l_bitWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_bitWidth.Location = new System.Drawing.Point(228, 42);
            this.l_bitWidth.Name = "l_bitWidth";
            this.l_bitWidth.Size = new System.Drawing.Size(24, 25);
            this.l_bitWidth.TabIndex = 2;
            this.l_bitWidth.Text = "2";
            // 
            // LSBSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 351);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LSBSettings";
            this.Text = "LSBSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_bitWidth;
        private System.Windows.Forms.TrackBar tb_bitWidth;
        private System.Windows.Forms.Label label1;
    }
}