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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(343, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JPEG";
            // 
            // cb_da_algo
            // 
            this.cb_da_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_da_algo.Enabled = false;
            this.cb_da_algo.FormattingEnabled = true;
            this.cb_da_algo.Location = new System.Drawing.Point(132, 87);
            this.cb_da_algo.Name = "cb_da_algo";
            this.cb_da_algo.Size = new System.Drawing.Size(208, 21);
            this.cb_da_algo.TabIndex = 42;
            // 
            // l_da_algo
            // 
            this.l_da_algo.AutoSize = true;
            this.l_da_algo.Enabled = false;
            this.l_da_algo.Location = new System.Drawing.Point(9, 90);
            this.l_da_algo.Name = "l_da_algo";
            this.l_da_algo.Size = new System.Drawing.Size(30, 13);
            this.l_da_algo.TabIndex = 41;
            this.l_da_algo.Text = "N/A:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Distribution:";
            // 
            // l_da_param
            // 
            this.l_da_param.AutoSize = true;
            this.l_da_param.Enabled = false;
            this.l_da_param.Location = new System.Drawing.Point(9, 65);
            this.l_da_param.Name = "l_da_param";
            this.l_da_param.Size = new System.Drawing.Size(30, 13);
            this.l_da_param.TabIndex = 39;
            this.l_da_param.Text = "N/A:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(132, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 38);
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
            "Naive"});
            this.cb_dist_algo.Location = new System.Drawing.Point(132, 35);
            this.cb_dist_algo.Name = "cb_dist_algo";
            this.cb_dist_algo.Size = new System.Drawing.Size(208, 21);
            this.cb_dist_algo.TabIndex = 36;
            // 
            // ExtraJpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ExtraJpeg";
            this.Size = new System.Drawing.Size(343, 129);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}
