
namespace psteg.Stegano.UI.LSBExtra
{
    partial class ExtraImage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_main = new System.Windows.Forms.GroupBox();
            this.tb_iv = new System.Windows.Forms.TextBox();
            this.cb_iv = new System.Windows.Forms.CheckBox();
            this.cb_adaptive = new System.Windows.Forms.CheckBox();
            this.cb_rbo = new System.Windows.Forms.CheckBox();
            this.cb_row_read_mode = new System.Windows.Forms.CheckBox();
            this.cb_a = new System.Windows.Forms.CheckBox();
            this.cb_b = new System.Windows.Forms.CheckBox();
            this.cb_g = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_r = new System.Windows.Forms.CheckBox();
            this.l_bitdepth = new System.Windows.Forms.Label();
            this.tb_bitdepth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitdepth)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.tb_iv);
            this.gb_main.Controls.Add(this.cb_iv);
            this.gb_main.Controls.Add(this.cb_adaptive);
            this.gb_main.Controls.Add(this.cb_rbo);
            this.gb_main.Controls.Add(this.cb_row_read_mode);
            this.gb_main.Controls.Add(this.cb_a);
            this.gb_main.Controls.Add(this.cb_b);
            this.gb_main.Controls.Add(this.cb_g);
            this.gb_main.Controls.Add(this.label2);
            this.gb_main.Controls.Add(this.cb_r);
            this.gb_main.Controls.Add(this.l_bitdepth);
            this.gb_main.Controls.Add(this.tb_bitdepth);
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_main.Location = new System.Drawing.Point(0, 0);
            this.gb_main.Name = "gb_main";
            this.gb_main.Size = new System.Drawing.Size(343, 251);
            this.gb_main.TabIndex = 0;
            this.gb_main.TabStop = false;
            this.gb_main.Text = "Image";
            // 
            // tb_iv
            // 
            this.tb_iv.Enabled = false;
            this.tb_iv.Location = new System.Drawing.Point(129, 210);
            this.tb_iv.Name = "tb_iv";
            this.tb_iv.Size = new System.Drawing.Size(183, 20);
            this.tb_iv.TabIndex = 25;
            // 
            // cb_iv
            // 
            this.cb_iv.AutoSize = true;
            this.cb_iv.Location = new System.Drawing.Point(9, 210);
            this.cb_iv.Name = "cb_iv";
            this.cb_iv.Size = new System.Drawing.Size(114, 17);
            this.cb_iv.TabIndex = 24;
            this.cb_iv.Text = "Initialization Vector";
            this.cb_iv.UseVisualStyleBackColor = true;
            this.cb_iv.CheckedChanged += new System.EventHandler(this.cb_iv_CheckedChanged);
            // 
            // cb_adaptive
            // 
            this.cb_adaptive.AutoSize = true;
            this.cb_adaptive.Enabled = false;
            this.cb_adaptive.Location = new System.Drawing.Point(9, 187);
            this.cb_adaptive.Name = "cb_adaptive";
            this.cb_adaptive.Size = new System.Drawing.Size(192, 17);
            this.cb_adaptive.TabIndex = 23;
            this.cb_adaptive.Text = "Adaptive Distribution [Experimental]";
            this.cb_adaptive.UseVisualStyleBackColor = true;
            // 
            // cb_rbo
            // 
            this.cb_rbo.AutoSize = true;
            this.cb_rbo.Location = new System.Drawing.Point(9, 164);
            this.cb_rbo.Name = "cb_rbo";
            this.cb_rbo.Size = new System.Drawing.Size(110, 17);
            this.cb_rbo.TabIndex = 22;
            this.cb_rbo.Text = "Reverse Bit Order";
            this.cb_rbo.UseVisualStyleBackColor = true;
            // 
            // cb_row_read_mode
            // 
            this.cb_row_read_mode.AutoSize = true;
            this.cb_row_read_mode.Checked = true;
            this.cb_row_read_mode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_row_read_mode.Location = new System.Drawing.Point(9, 141);
            this.cb_row_read_mode.Name = "cb_row_read_mode";
            this.cb_row_read_mode.Size = new System.Drawing.Size(129, 17);
            this.cb_row_read_mode.TabIndex = 21;
            this.cb_row_read_mode.Text = "Row-First Read Mode";
            this.cb_row_read_mode.UseVisualStyleBackColor = true;
            // 
            // cb_a
            // 
            this.cb_a.AutoSize = true;
            this.cb_a.Location = new System.Drawing.Point(245, 93);
            this.cb_a.Name = "cb_a";
            this.cb_a.Size = new System.Drawing.Size(33, 17);
            this.cb_a.TabIndex = 20;
            this.cb_a.Text = "A";
            this.cb_a.UseVisualStyleBackColor = true;
            // 
            // cb_b
            // 
            this.cb_b.AutoSize = true;
            this.cb_b.Checked = true;
            this.cb_b.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_b.Location = new System.Drawing.Point(167, 93);
            this.cb_b.Name = "cb_b";
            this.cb_b.Size = new System.Drawing.Size(33, 17);
            this.cb_b.TabIndex = 19;
            this.cb_b.Text = "B";
            this.cb_b.UseVisualStyleBackColor = true;
            // 
            // cb_g
            // 
            this.cb_g.AutoSize = true;
            this.cb_g.Checked = true;
            this.cb_g.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_g.Location = new System.Drawing.Point(88, 93);
            this.cb_g.Name = "cb_g";
            this.cb_g.Size = new System.Drawing.Size(34, 17);
            this.cb_g.TabIndex = 18;
            this.cb_g.Text = "G";
            this.cb_g.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Channels:";
            // 
            // cb_r
            // 
            this.cb_r.AutoSize = true;
            this.cb_r.Checked = true;
            this.cb_r.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_r.Location = new System.Drawing.Point(9, 93);
            this.cb_r.Name = "cb_r";
            this.cb_r.Size = new System.Drawing.Size(34, 17);
            this.cb_r.TabIndex = 16;
            this.cb_r.Text = "R";
            this.cb_r.UseVisualStyleBackColor = true;
            // 
            // l_bitdepth
            // 
            this.l_bitdepth.AutoSize = true;
            this.l_bitdepth.Location = new System.Drawing.Point(299, 16);
            this.l_bitdepth.Name = "l_bitdepth";
            this.l_bitdepth.Size = new System.Drawing.Size(13, 13);
            this.l_bitdepth.TabIndex = 15;
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
            this.tb_bitdepth.TabIndex = 14;
            this.tb_bitdepth.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Bit Depth:";
            // 
            // ExtraImage
            // 
            this.Controls.Add(this.gb_main);
            this.Name = "ExtraImage";
            this.Size = new System.Drawing.Size(343, 251);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitdepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_main;
        private System.Windows.Forms.TextBox tb_iv;
        private System.Windows.Forms.CheckBox cb_iv;
        private System.Windows.Forms.CheckBox cb_adaptive;
        private System.Windows.Forms.CheckBox cb_rbo;
        private System.Windows.Forms.CheckBox cb_row_read_mode;
        private System.Windows.Forms.CheckBox cb_a;
        private System.Windows.Forms.CheckBox cb_b;
        private System.Windows.Forms.CheckBox cb_g;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_r;
        private System.Windows.Forms.Label l_bitdepth;
        private System.Windows.Forms.TrackBar tb_bitdepth;
        private System.Windows.Forms.Label label1;
    }
}
