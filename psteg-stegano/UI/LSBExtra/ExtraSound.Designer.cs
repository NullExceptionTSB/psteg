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
            this.cb_adaptive = new System.Windows.Forms.CheckBox();
            this.l_bitdepth = new System.Windows.Forms.Label();
            this.tb_bitdepth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_r = new System.Windows.Forms.CheckBox();
            this.cb_l = new System.Windows.Forms.CheckBox();
            this.gb_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitdepth)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.cb_rbo);
            this.gb_main.Controls.Add(this.tb_iv);
            this.gb_main.Controls.Add(this.cb_iv);
            this.gb_main.Controls.Add(this.cb_adaptive);
            this.gb_main.Controls.Add(this.l_bitdepth);
            this.gb_main.Controls.Add(this.tb_bitdepth);
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Controls.Add(this.label2);
            this.gb_main.Controls.Add(this.cb_r);
            this.gb_main.Controls.Add(this.cb_l);
            this.gb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_main.Location = new System.Drawing.Point(0, 0);
            this.gb_main.Name = "gb_main";
            this.gb_main.Size = new System.Drawing.Size(343, 227);
            this.gb_main.TabIndex = 19;
            this.gb_main.TabStop = false;
            this.gb_main.Text = "Audio";
            // 
            // cb_rbo
            // 
            this.cb_rbo.AutoSize = true;
            this.cb_rbo.Location = new System.Drawing.Point(9, 162);
            this.cb_rbo.Name = "cb_rbo";
            this.cb_rbo.Size = new System.Drawing.Size(110, 17);
            this.cb_rbo.TabIndex = 28;
            this.cb_rbo.Text = "Reverse Bit Order";
            this.cb_rbo.UseVisualStyleBackColor = true;
            // 
            // tb_iv
            // 
            this.tb_iv.Enabled = false;
            this.tb_iv.Location = new System.Drawing.Point(129, 185);
            this.tb_iv.Name = "tb_iv";
            this.tb_iv.Size = new System.Drawing.Size(183, 20);
            this.tb_iv.TabIndex = 27;
            // 
            // cb_iv
            // 
            this.cb_iv.AutoSize = true;
            this.cb_iv.Enabled = false;
            this.cb_iv.Location = new System.Drawing.Point(9, 188);
            this.cb_iv.Name = "cb_iv";
            this.cb_iv.Size = new System.Drawing.Size(114, 17);
            this.cb_iv.TabIndex = 26;
            this.cb_iv.Text = "Initialization Vector";
            this.cb_iv.UseVisualStyleBackColor = true;
            // 
            // cb_adaptive
            // 
            this.cb_adaptive.AutoSize = true;
            this.cb_adaptive.Enabled = false;
            this.cb_adaptive.Location = new System.Drawing.Point(9, 141);
            this.cb_adaptive.Name = "cb_adaptive";
            this.cb_adaptive.Size = new System.Drawing.Size(192, 17);
            this.cb_adaptive.TabIndex = 25;
            this.cb_adaptive.Text = "Adaptive Distribution [Experimental]";
            this.cb_adaptive.UseVisualStyleBackColor = true;
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
            this.label2.Location = new System.Drawing.Point(4, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Channels:";
            // 
            // cb_r
            // 
            this.cb_r.AutoSize = true;
            this.cb_r.Location = new System.Drawing.Point(178, 93);
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
            this.cb_l.Location = new System.Drawing.Point(9, 93);
            this.cb_l.Name = "cb_l";
            this.cb_l.Size = new System.Drawing.Size(32, 17);
            this.cb_l.TabIndex = 19;
            this.cb_l.Text = "L";
            this.cb_l.UseVisualStyleBackColor = true;
            // 
            // ExtraSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_main);
            this.Name = "ExtraSound";
            this.Size = new System.Drawing.Size(343, 227);
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
        private System.Windows.Forms.CheckBox cb_adaptive;
        private System.Windows.Forms.TextBox tb_iv;
        private System.Windows.Forms.CheckBox cb_iv;
        private System.Windows.Forms.CheckBox cb_rbo;
    }
}
