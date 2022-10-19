namespace psteg.UI.SettingsForms.Stegano {
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
            this.tb_datasize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.l_bitWidth = new System.Windows.Forms.Label();
            this.tb_bitWidth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_rowfirst = new System.Windows.Forms.CheckBox();
            this.cb_imgcA = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_imgcB = new System.Windows.Forms.CheckBox();
            this.cb_imgcR = new System.Windows.Forms.CheckBox();
            this.cb_imgcG = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitWidth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_datasize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.l_bitWidth);
            this.groupBox1.Controls.Add(this.tb_bitWidth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // tb_datasize
            // 
            this.tb_datasize.Location = new System.Drawing.Point(9, 96);
            this.tb_datasize.Name = "tb_datasize";
            this.tb_datasize.Size = new System.Drawing.Size(242, 20);
            this.tb_datasize.TabIndex = 4;
            this.tb_datasize.TextChanged += new System.EventHandler(this.tb_datasize_TextChanged);
            this.tb_datasize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_datasize_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data size (0 for unknown) [Decode only]:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bit Width [Reccomended: 2]\r\n";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_rowfirst);
            this.groupBox2.Controls.Add(this.cb_imgcA);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cb_imgcB);
            this.groupBox2.Controls.Add(this.cb_imgcR);
            this.groupBox2.Controls.Add(this.cb_imgcG);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // cb_rowfirst
            // 
            this.cb_rowfirst.AutoSize = true;
            this.cb_rowfirst.Location = new System.Drawing.Point(9, 19);
            this.cb_rowfirst.Name = "cb_rowfirst";
            this.cb_rowfirst.Size = new System.Drawing.Size(157, 17);
            this.cb_rowfirst.TabIndex = 5;
            this.cb_rowfirst.Text = "Row First Read-Write Mode";
            this.cb_rowfirst.UseVisualStyleBackColor = true;
            this.cb_rowfirst.CheckedChanged += new System.EventHandler(this.cb_rowfirst_CheckedChanged);
            // 
            // cb_imgcA
            // 
            this.cb_imgcA.AutoSize = true;
            this.cb_imgcA.Location = new System.Drawing.Point(9, 57);
            this.cb_imgcA.Name = "cb_imgcA";
            this.cb_imgcA.Size = new System.Drawing.Size(33, 17);
            this.cb_imgcA.TabIndex = 5;
            this.cb_imgcA.Text = "A";
            this.cb_imgcA.UseVisualStyleBackColor = true;
            this.cb_imgcA.CheckedChanged += new System.EventHandler(this.cb_imgc_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Channels";
            // 
            // cb_imgcB
            // 
            this.cb_imgcB.AutoSize = true;
            this.cb_imgcB.Location = new System.Drawing.Point(218, 57);
            this.cb_imgcB.Name = "cb_imgcB";
            this.cb_imgcB.Size = new System.Drawing.Size(33, 17);
            this.cb_imgcB.TabIndex = 4;
            this.cb_imgcB.Text = "B";
            this.cb_imgcB.UseVisualStyleBackColor = true;
            this.cb_imgcB.CheckedChanged += new System.EventHandler(this.cb_imgc_CheckedChanged);
            // 
            // cb_imgcR
            // 
            this.cb_imgcR.AutoSize = true;
            this.cb_imgcR.Location = new System.Drawing.Point(78, 57);
            this.cb_imgcR.Name = "cb_imgcR";
            this.cb_imgcR.Size = new System.Drawing.Size(34, 17);
            this.cb_imgcR.TabIndex = 2;
            this.cb_imgcR.Text = "R";
            this.cb_imgcR.UseVisualStyleBackColor = true;
            this.cb_imgcR.CheckedChanged += new System.EventHandler(this.cb_imgc_CheckedChanged);
            // 
            // cb_imgcG
            // 
            this.cb_imgcG.AutoSize = true;
            this.cb_imgcG.Location = new System.Drawing.Point(148, 57);
            this.cb_imgcG.Name = "cb_imgcG";
            this.cb_imgcG.Size = new System.Drawing.Size(34, 17);
            this.cb_imgcG.TabIndex = 3;
            this.cb_imgcG.Text = "G";
            this.cb_imgcG.UseVisualStyleBackColor = true;
            this.cb_imgcG.CheckedChanged += new System.EventHandler(this.cb_imgc_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 233);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 63);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(32, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "L";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Channels";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(78, 32);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(34, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "R";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // LSBSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 311);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LSBSettings";
            this.Text = "Least-Significant Bit Steganography Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitWidth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_bitWidth;
        private System.Windows.Forms.TrackBar tb_bitWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_imgcA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_imgcB;
        private System.Windows.Forms.CheckBox cb_imgcR;
        private System.Windows.Forms.CheckBox cb_imgcG;
        private System.Windows.Forms.TextBox tb_datasize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox cb_rowfirst;
    }
}