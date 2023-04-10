namespace psteg.Stegano.UI.JpegExtra {
    partial class ExtraJpeg {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_da_algo = new System.Windows.Forms.ComboBox();
            this.l_da_algo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_da_param = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_dist_algo = new System.Windows.Forms.ComboBox();
            this.l_bitdepth = new System.Windows.Forms.Label();
            this.tb_sub_depth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ins_depth = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_zrlinsert = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sub_depth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ins_depth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cb_zrlinsert);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_ins_depth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.l_bitdepth);
            this.groupBox1.Controls.Add(this.tb_sub_depth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_da_algo);
            this.groupBox1.Controls.Add(this.l_da_algo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.l_da_param);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_dist_algo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 323);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JPEG LSB-DCT";
            // 
            // cb_da_algo
            // 
            this.cb_da_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_da_algo.Enabled = false;
            this.cb_da_algo.FormattingEnabled = true;
            this.cb_da_algo.Location = new System.Drawing.Point(132, 91);
            this.cb_da_algo.Name = "cb_da_algo";
            this.cb_da_algo.Size = new System.Drawing.Size(208, 21);
            this.cb_da_algo.TabIndex = 42;
            // 
            // l_da_algo
            // 
            this.l_da_algo.AutoSize = true;
            this.l_da_algo.Enabled = false;
            this.l_da_algo.Location = new System.Drawing.Point(9, 94);
            this.l_da_algo.Name = "l_da_algo";
            this.l_da_algo.Size = new System.Drawing.Size(30, 13);
            this.l_da_algo.TabIndex = 41;
            this.l_da_algo.Text = "N/A:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Distribution:";
            // 
            // l_da_param
            // 
            this.l_da_param.AutoSize = true;
            this.l_da_param.Enabled = false;
            this.l_da_param.Location = new System.Drawing.Point(9, 69);
            this.l_da_param.Name = "l_da_param";
            this.l_da_param.Size = new System.Drawing.Size(30, 13);
            this.l_da_param.TabIndex = 39;
            this.l_da_param.Text = "N/A:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(132, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Distribution Algorithm:";
            // 
            // cb_dist_algo
            // 
            this.cb_dist_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dist_algo.FormattingEnabled = true;
            this.cb_dist_algo.Items.AddRange(new object[] {
            "Linear (JSteg)"});
            this.cb_dist_algo.Location = new System.Drawing.Point(132, 39);
            this.cb_dist_algo.Name = "cb_dist_algo";
            this.cb_dist_algo.Size = new System.Drawing.Size(208, 21);
            this.cb_dist_algo.TabIndex = 36;
            // 
            // l_bitdepth
            // 
            this.l_bitdepth.AutoSize = true;
            this.l_bitdepth.Location = new System.Drawing.Point(324, 167);
            this.l_bitdepth.Name = "l_bitdepth";
            this.l_bitdepth.Size = new System.Drawing.Size(13, 13);
            this.l_bitdepth.TabIndex = 45;
            this.l_bitdepth.Text = "1";
            // 
            // tb_sub_depth
            // 
            this.tb_sub_depth.LargeChange = 2;
            this.tb_sub_depth.Location = new System.Drawing.Point(9, 163);
            this.tb_sub_depth.Minimum = 1;
            this.tb_sub_depth.Name = "tb_sub_depth";
            this.tb_sub_depth.Size = new System.Drawing.Size(309, 45);
            this.tb_sub_depth.TabIndex = 44;
            this.tb_sub_depth.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Maximum Substitution Depth:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "1";
            // 
            // tb_ins_depth
            // 
            this.tb_ins_depth.Enabled = false;
            this.tb_ins_depth.LargeChange = 2;
            this.tb_ins_depth.Location = new System.Drawing.Point(6, 251);
            this.tb_ins_depth.Minimum = 1;
            this.tb_ins_depth.Name = "tb_ins_depth";
            this.tb_ins_depth.Size = new System.Drawing.Size(309, 45);
            this.tb_ins_depth.TabIndex = 47;
            this.tb_ins_depth.Value = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Insertion Depth:";
            // 
            // cb_zrlinsert
            // 
            this.cb_zrlinsert.AutoSize = true;
            this.cb_zrlinsert.Location = new System.Drawing.Point(12, 214);
            this.cb_zrlinsert.Name = "cb_zrlinsert";
            this.cb_zrlinsert.Size = new System.Drawing.Size(129, 17);
            this.cb_zrlinsert.TabIndex = 49;
            this.cb_zrlinsert.Text = "Insert in ZRL sections";
            this.cb_zrlinsert.UseVisualStyleBackColor = true;
            this.cb_zrlinsert.CheckedChanged += new System.EventHandler(this.cb_zrlinsert_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Encoding:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(56, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 26);
            this.label7.TabIndex = 51;
            this.label7.Text = "!WARNING! LSB-DCT support is experimental. \r\nData loss is possible. Use at your o" +
    "wn risk.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExtraJpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ExtraJpeg";
            this.Size = new System.Drawing.Size(343, 323);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sub_depth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ins_depth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_da_algo;
        private System.Windows.Forms.Label l_da_algo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_da_param;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_dist_algo;
        private System.Windows.Forms.Label l_bitdepth;
        private System.Windows.Forms.TrackBar tb_sub_depth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cb_zrlinsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tb_ins_depth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}
