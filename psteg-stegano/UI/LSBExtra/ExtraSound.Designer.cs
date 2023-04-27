namespace psteg.Stegano.UI.LSBExtra {
    partial class ExtraSound {
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
            this.gb_main = new System.Windows.Forms.GroupBox();
            this.cb_rbo = new System.Windows.Forms.CheckBox();
            this.tb_iv = new System.Windows.Forms.TextBox();
            this.cb_iv = new System.Windows.Forms.CheckBox();
            this.l_bitdepth = new System.Windows.Forms.Label();
            this.tb_bitdepth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_r = new System.Windows.Forms.CheckBox();
            this.cb_l = new System.Windows.Forms.CheckBox();
            this.cb_da_algo = new System.Windows.Forms.ComboBox();
            this.l_da_algo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_da_param = new System.Windows.Forms.Label();
            this.tb_distalg_data = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_dist_algo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitdepth)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.label5);
            this.gb_main.Controls.Add(this.cb_da_algo);
            this.gb_main.Controls.Add(this.l_da_algo);
            this.gb_main.Controls.Add(this.label4);
            this.gb_main.Controls.Add(this.l_da_param);
            this.gb_main.Controls.Add(this.tb_distalg_data);
            this.gb_main.Controls.Add(this.label3);
            this.gb_main.Controls.Add(this.cb_dist_algo);
            this.gb_main.Controls.Add(this.cb_rbo);
            this.gb_main.Controls.Add(this.tb_iv);
            this.gb_main.Controls.Add(this.cb_iv);
            this.gb_main.Controls.Add(this.l_bitdepth);
            this.gb_main.Controls.Add(this.tb_bitdepth);
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Controls.Add(this.label2);
            this.gb_main.Controls.Add(this.cb_r);
            this.gb_main.Controls.Add(this.cb_l);
            this.gb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_main.Location = new System.Drawing.Point(0, 0);
            this.gb_main.Name = "gb_main";
            this.gb_main.Size = new System.Drawing.Size(343, 296);
            this.gb_main.TabIndex = 19;
            this.gb_main.TabStop = false;
            this.gb_main.Text = "Audio";
            // 
            // cb_rbo
            // 
            this.cb_rbo.AutoSize = true;
            this.cb_rbo.Location = new System.Drawing.Point(8, 246);
            this.cb_rbo.Name = "cb_rbo";
            this.cb_rbo.Size = new System.Drawing.Size(110, 17);
            this.cb_rbo.TabIndex = 28;
            this.cb_rbo.Text = "Reverse Bit Order";
            this.cb_rbo.UseVisualStyleBackColor = true;
            // 
            // tb_iv
            // 
            this.tb_iv.Enabled = false;
            this.tb_iv.Location = new System.Drawing.Point(130, 266);
            this.tb_iv.Name = "tb_iv";
            this.tb_iv.Size = new System.Drawing.Size(207, 20);
            this.tb_iv.TabIndex = 27;
            // 
            // cb_iv
            // 
            this.cb_iv.AutoSize = true;
            this.cb_iv.Enabled = false;
            this.cb_iv.Location = new System.Drawing.Point(8, 269);
            this.cb_iv.Name = "cb_iv";
            this.cb_iv.Size = new System.Drawing.Size(114, 17);
            this.cb_iv.TabIndex = 26;
            this.cb_iv.Text = "Initialization Vector";
            this.cb_iv.UseVisualStyleBackColor = true;
            // 
            // l_bitdepth
            // 
            this.l_bitdepth.AutoSize = true;
            this.l_bitdepth.Location = new System.Drawing.Point(299, 16);
            this.l_bitdepth.Name = "l_bitdepth";
            this.l_bitdepth.Size = new System.Drawing.Size(13, 13);
            this.l_bitdepth.TabIndex = 24;
            this.l_bitdepth.Text = "1";
            // 
            // tb_bitdepth
            // 
            this.tb_bitdepth.LargeChange = 2;
            this.tb_bitdepth.Location = new System.Drawing.Point(66, 12);
            this.tb_bitdepth.Maximum = 8;
            this.tb_bitdepth.Minimum = 1;
            this.tb_bitdepth.Name = "tb_bitdepth";
            this.tb_bitdepth.Size = new System.Drawing.Size(227, 45);
            this.tb_bitdepth.TabIndex = 23;
            this.tb_bitdepth.Value = 1;
            this.tb_bitdepth.Scroll += new System.EventHandler(this.tb_bitdepth_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Bit Depth:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Channels:";
            // 
            // cb_r
            // 
            this.cb_r.AutoSize = true;
            this.cb_r.Location = new System.Drawing.Point(180, 80);
            this.cb_r.Name = "cb_r";
            this.cb_r.Size = new System.Drawing.Size(34, 17);
            this.cb_r.TabIndex = 20;
            this.cb_r.Text = "R";
            this.cb_r.UseVisualStyleBackColor = true;
            // 
            // cb_l
            // 
            this.cb_l.AutoSize = true;
            this.cb_l.Checked = true;
            this.cb_l.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_l.Location = new System.Drawing.Point(11, 80);
            this.cb_l.Name = "cb_l";
            this.cb_l.Size = new System.Drawing.Size(32, 17);
            this.cb_l.TabIndex = 19;
            this.cb_l.Text = "L";
            this.cb_l.UseVisualStyleBackColor = true;
            // 
            // cb_da_algo
            // 
            this.cb_da_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_da_algo.Enabled = false;
            this.cb_da_algo.FormattingEnabled = true;
            this.cb_da_algo.Location = new System.Drawing.Point(130, 185);
            this.cb_da_algo.Name = "cb_da_algo";
            this.cb_da_algo.Size = new System.Drawing.Size(208, 21);
            this.cb_da_algo.TabIndex = 42;
            // 
            // l_da_algo
            // 
            this.l_da_algo.AutoSize = true;
            this.l_da_algo.Enabled = false;
            this.l_da_algo.Location = new System.Drawing.Point(7, 188);
            this.l_da_algo.Name = "l_da_algo";
            this.l_da_algo.Size = new System.Drawing.Size(30, 13);
            this.l_da_algo.TabIndex = 41;
            this.l_da_algo.Text = "N/A:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Distribution:";
            // 
            // l_da_param
            // 
            this.l_da_param.AutoSize = true;
            this.l_da_param.Enabled = false;
            this.l_da_param.Location = new System.Drawing.Point(7, 163);
            this.l_da_param.Name = "l_da_param";
            this.l_da_param.Size = new System.Drawing.Size(30, 13);
            this.l_da_param.TabIndex = 39;
            this.l_da_param.Text = "N/A:";
            // 
            // tb_distalg_data
            // 
            this.tb_distalg_data.Enabled = false;
            this.tb_distalg_data.Location = new System.Drawing.Point(130, 160);
            this.tb_distalg_data.Name = "tb_distalg_data";
            this.tb_distalg_data.Size = new System.Drawing.Size(208, 20);
            this.tb_distalg_data.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 136);
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
            "Linear"});
            this.cb_dist_algo.Location = new System.Drawing.Point(130, 133);
            this.cb_dist_algo.Name = "cb_dist_algo";
            this.cb_dist_algo.Size = new System.Drawing.Size(208, 21);
            this.cb_dist_algo.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Hidden data storage:";
            // 
            // ExtraSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_main);
            this.Name = "ExtraSound";
            this.Size = new System.Drawing.Size(343, 296);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitdepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gb_main;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_r;
        private System.Windows.Forms.CheckBox cb_l;
        private System.Windows.Forms.Label l_bitdepth;
        private System.Windows.Forms.TrackBar tb_bitdepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_iv;
        private System.Windows.Forms.CheckBox cb_iv;
        private System.Windows.Forms.CheckBox cb_rbo;
        private System.Windows.Forms.ComboBox cb_da_algo;
        private System.Windows.Forms.Label l_da_algo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_da_param;
        private System.Windows.Forms.TextBox tb_distalg_data;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_dist_algo;
        private System.Windows.Forms.Label label5;
    }
}
