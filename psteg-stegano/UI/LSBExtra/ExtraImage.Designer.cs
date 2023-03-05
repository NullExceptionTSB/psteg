
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
            this.cb_co = new System.Windows.Forms.CheckBox();
            this.tb_co = new System.Windows.Forms.TextBox();
            this.cb_dist_algo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.l_da_param = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.l_da_algo = new System.Windows.Forms.Label();
            this.cb_da_algo = new System.Windows.Forms.ComboBox();
            this.gb_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitdepth)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.cb_da_algo);
            this.gb_main.Controls.Add(this.l_da_algo);
            this.gb_main.Controls.Add(this.label5);
            this.gb_main.Controls.Add(this.label4);
            this.gb_main.Controls.Add(this.l_da_param);
            this.gb_main.Controls.Add(this.textBox1);
            this.gb_main.Controls.Add(this.label3);
            this.gb_main.Controls.Add(this.cb_dist_algo);
            this.gb_main.Controls.Add(this.tb_co);
            this.gb_main.Controls.Add(this.cb_co);
            this.gb_main.Controls.Add(this.tb_iv);
            this.gb_main.Controls.Add(this.cb_iv);
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
            this.gb_main.Size = new System.Drawing.Size(343, 310);
            this.gb_main.TabIndex = 0;
            this.gb_main.TabStop = false;
            this.gb_main.Text = "Image";
            // 
            // tb_iv
            // 
            this.tb_iv.Enabled = false;
            this.tb_iv.Location = new System.Drawing.Point(129, 284);
            this.tb_iv.Name = "tb_iv";
            this.tb_iv.Size = new System.Drawing.Size(183, 20);
            this.tb_iv.TabIndex = 25;
            // 
            // cb_iv
            // 
            this.cb_iv.AutoSize = true;
            this.cb_iv.Location = new System.Drawing.Point(9, 287);
            this.cb_iv.Name = "cb_iv";
            this.cb_iv.Size = new System.Drawing.Size(114, 17);
            this.cb_iv.TabIndex = 24;
            this.cb_iv.Text = "Initialization Vector";
            this.cb_iv.UseVisualStyleBackColor = true;
            this.cb_iv.CheckedChanged += new System.EventHandler(this.cb_iv_CheckedChanged);
            // 
            // cb_rbo
            // 
            this.cb_rbo.AutoSize = true;
            this.cb_rbo.Location = new System.Drawing.Point(9, 264);
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
            this.cb_row_read_mode.Location = new System.Drawing.Point(9, 241);
            this.cb_row_read_mode.Name = "cb_row_read_mode";
            this.cb_row_read_mode.Size = new System.Drawing.Size(129, 17);
            this.cb_row_read_mode.TabIndex = 21;
            this.cb_row_read_mode.Text = "Row-First Read Mode";
            this.cb_row_read_mode.UseVisualStyleBackColor = true;
            // 
            // cb_a
            // 
            this.cb_a.AutoSize = true;
            this.cb_a.Location = new System.Drawing.Point(245, 68);
            this.cb_a.Name = "cb_a";
            this.cb_a.Size = new System.Drawing.Size(33, 17);
            this.cb_a.TabIndex = 20;
            this.cb_a.Text = "A";
            this.cb_a.UseVisualStyleBackColor = true;
            this.cb_a.CheckedChanged += new System.EventHandler(this.cb_chan_chc);
            // 
            // cb_b
            // 
            this.cb_b.AutoSize = true;
            this.cb_b.Checked = true;
            this.cb_b.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_b.Location = new System.Drawing.Point(167, 68);
            this.cb_b.Name = "cb_b";
            this.cb_b.Size = new System.Drawing.Size(33, 17);
            this.cb_b.TabIndex = 19;
            this.cb_b.Text = "B";
            this.cb_b.UseVisualStyleBackColor = true;
            this.cb_b.CheckedChanged += new System.EventHandler(this.cb_chan_chc);
            // 
            // cb_g
            // 
            this.cb_g.AutoSize = true;
            this.cb_g.Checked = true;
            this.cb_g.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_g.Location = new System.Drawing.Point(88, 68);
            this.cb_g.Name = "cb_g";
            this.cb_g.Size = new System.Drawing.Size(34, 17);
            this.cb_g.TabIndex = 18;
            this.cb_g.Text = "G";
            this.cb_g.UseVisualStyleBackColor = true;
            this.cb_g.CheckedChanged += new System.EventHandler(this.cb_chan_chc);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
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
            this.cb_r.Location = new System.Drawing.Point(9, 68);
            this.cb_r.Name = "cb_r";
            this.cb_r.Size = new System.Drawing.Size(34, 17);
            this.cb_r.TabIndex = 16;
            this.cb_r.Text = "R";
            this.cb_r.UseVisualStyleBackColor = true;
            this.cb_r.CheckedChanged += new System.EventHandler(this.cb_chan_chc);
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
            this.tb_bitdepth.Scroll += new System.EventHandler(this.tb_bitdepth_Scroll);
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
            // cb_co
            // 
            this.cb_co.AutoSize = true;
            this.cb_co.Location = new System.Drawing.Point(9, 91);
            this.cb_co.Name = "cb_co";
            this.cb_co.Size = new System.Drawing.Size(90, 17);
            this.cb_co.TabIndex = 26;
            this.cb_co.Text = "Custom Order";
            this.cb_co.UseVisualStyleBackColor = true;
            this.cb_co.CheckedChanged += new System.EventHandler(this.cb_co_CheckedChanged);
            // 
            // tb_co
            // 
            this.tb_co.Enabled = false;
            this.tb_co.Location = new System.Drawing.Point(129, 88);
            this.tb_co.Name = "tb_co";
            this.tb_co.Size = new System.Drawing.Size(183, 20);
            this.tb_co.TabIndex = 27;
            this.tb_co.Text = "BGR";
            this.tb_co.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_co_KeyPress);
            // 
            // cb_dist_algo
            // 
            this.cb_dist_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dist_algo.FormattingEnabled = true;
            this.cb_dist_algo.Items.AddRange(new object[] {
            "Linear"});
            this.cb_dist_algo.Location = new System.Drawing.Point(129, 143);
            this.cb_dist_algo.Name = "cb_dist_algo";
            this.cb_dist_algo.Size = new System.Drawing.Size(183, 21);
            this.cb_dist_algo.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Distribution Algorithm:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(129, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 30;
            // 
            // l_da_param
            // 
            this.l_da_param.AutoSize = true;
            this.l_da_param.Enabled = false;
            this.l_da_param.Location = new System.Drawing.Point(6, 173);
            this.l_da_param.Name = "l_da_param";
            this.l_da_param.Size = new System.Drawing.Size(30, 13);
            this.l_da_param.TabIndex = 31;
            this.l_da_param.Text = "N/A:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Distribution:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Hidden data storage:";
            // 
            // l_da_algo
            // 
            this.l_da_algo.AutoSize = true;
            this.l_da_algo.Enabled = false;
            this.l_da_algo.Location = new System.Drawing.Point(6, 198);
            this.l_da_algo.Name = "l_da_algo";
            this.l_da_algo.Size = new System.Drawing.Size(30, 13);
            this.l_da_algo.TabIndex = 34;
            this.l_da_algo.Text = "N/A:";
            // 
            // cb_da_algo
            // 
            this.cb_da_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_da_algo.Enabled = false;
            this.cb_da_algo.FormattingEnabled = true;
            this.cb_da_algo.Location = new System.Drawing.Point(129, 195);
            this.cb_da_algo.Name = "cb_da_algo";
            this.cb_da_algo.Size = new System.Drawing.Size(183, 21);
            this.cb_da_algo.TabIndex = 35;
            // 
            // ExtraImage
            // 
            this.Controls.Add(this.gb_main);
            this.Name = "ExtraImage";
            this.Size = new System.Drawing.Size(343, 310);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bitdepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_main;
        private System.Windows.Forms.TextBox tb_iv;
        private System.Windows.Forms.CheckBox cb_iv;
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
        private System.Windows.Forms.TextBox tb_co;
        private System.Windows.Forms.CheckBox cb_co;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_dist_algo;
        private System.Windows.Forms.Label l_da_param;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_da_algo;
        private System.Windows.Forms.Label l_da_algo;
    }
}
