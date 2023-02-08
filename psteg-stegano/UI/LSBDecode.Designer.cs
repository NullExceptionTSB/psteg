namespace psteg.Stegano.UI {
    partial class LSBDecode {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LSBDecode));
            this.gb_cover = new System.Windows.Forms.GroupBox();
            this.tb_coverID = new System.Windows.Forms.TextBox();
            this.tb_appCoverPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_coverPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_setCover = new System.Windows.Forms.Button();
            this.b_browseCover = new System.Windows.Forms.Button();
            this.gb_output = new System.Windows.Forms.GroupBox();
            this.tb_dataLength = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_shpwd = new System.Windows.Forms.CheckBox();
            this.tb_appOutputPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_outputPath = new System.Windows.Forms.TextBox();
            this.cb_kda = new System.Windows.Forms.ComboBox();
            this.b_browseOutput = new System.Windows.Forms.Button();
            this.tb_cryptoKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.b_setOutput = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_crypto = new System.Windows.Forms.ComboBox();
            this.b_start = new System.Windows.Forms.Button();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.l_status = new System.Windows.Forms.Label();
            this.sfd_destination = new System.Windows.Forms.SaveFileDialog();
            this.ofd_cover = new System.Windows.Forms.OpenFileDialog();
            this.bw_process = new System.ComponentModel.BackgroundWorker();
            this.gb_cover.SuspendLayout();
            this.gb_output.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_cover
            // 
            this.gb_cover.AllowDrop = true;
            this.gb_cover.Controls.Add(this.tb_coverID);
            this.gb_cover.Controls.Add(this.tb_appCoverPath);
            this.gb_cover.Controls.Add(this.label4);
            this.gb_cover.Controls.Add(this.tb_coverPath);
            this.gb_cover.Controls.Add(this.label2);
            this.gb_cover.Controls.Add(this.b_setCover);
            this.gb_cover.Controls.Add(this.b_browseCover);
            this.gb_cover.Location = new System.Drawing.Point(12, 12);
            this.gb_cover.Name = "gb_cover";
            this.gb_cover.Size = new System.Drawing.Size(402, 283);
            this.gb_cover.TabIndex = 6;
            this.gb_cover.TabStop = false;
            this.gb_cover.Text = "Cover File";
            // 
            // tb_coverID
            // 
            this.tb_coverID.Location = new System.Drawing.Point(9, 119);
            this.tb_coverID.Multiline = true;
            this.tb_coverID.Name = "tb_coverID";
            this.tb_coverID.ReadOnly = true;
            this.tb_coverID.Size = new System.Drawing.Size(387, 158);
            this.tb_coverID.TabIndex = 9;
            // 
            // tb_appCoverPath
            // 
            this.tb_appCoverPath.Location = new System.Drawing.Point(9, 81);
            this.tb_appCoverPath.Name = "tb_appCoverPath";
            this.tb_appCoverPath.ReadOnly = true;
            this.tb_appCoverPath.Size = new System.Drawing.Size(387, 20);
            this.tb_appCoverPath.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "File ID:";
            // 
            // tb_coverPath
            // 
            this.tb_coverPath.AllowDrop = true;
            this.tb_coverPath.Location = new System.Drawing.Point(9, 13);
            this.tb_coverPath.Name = "tb_coverPath";
            this.tb_coverPath.Size = new System.Drawing.Size(387, 20);
            this.tb_coverPath.TabIndex = 0;
            this.tb_coverPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_coverPath_DragDrop);
            this.tb_coverPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Path:";
            // 
            // b_setCover
            // 
            this.b_setCover.Location = new System.Drawing.Point(208, 39);
            this.b_setCover.Name = "b_setCover";
            this.b_setCover.Size = new System.Drawing.Size(188, 23);
            this.b_setCover.TabIndex = 3;
            this.b_setCover.Text = "Set";
            this.b_setCover.UseVisualStyleBackColor = true;
            this.b_setCover.Click += new System.EventHandler(this.b_setCover_Click);
            // 
            // b_browseCover
            // 
            this.b_browseCover.Location = new System.Drawing.Point(9, 39);
            this.b_browseCover.Name = "b_browseCover";
            this.b_browseCover.Size = new System.Drawing.Size(188, 23);
            this.b_browseCover.TabIndex = 2;
            this.b_browseCover.Text = "Browse";
            this.b_browseCover.UseVisualStyleBackColor = true;
            this.b_browseCover.Click += new System.EventHandler(this.b_browseCover_Click);
            // 
            // gb_output
            // 
            this.gb_output.Controls.Add(this.tb_dataLength);
            this.gb_output.Controls.Add(this.label9);
            this.gb_output.Controls.Add(this.cb_shpwd);
            this.gb_output.Controls.Add(this.tb_appOutputPath);
            this.gb_output.Controls.Add(this.label8);
            this.gb_output.Controls.Add(this.tb_outputPath);
            this.gb_output.Controls.Add(this.cb_kda);
            this.gb_output.Controls.Add(this.b_browseOutput);
            this.gb_output.Controls.Add(this.tb_cryptoKey);
            this.gb_output.Controls.Add(this.label1);
            this.gb_output.Controls.Add(this.label7);
            this.gb_output.Controls.Add(this.b_setOutput);
            this.gb_output.Controls.Add(this.label6);
            this.gb_output.Controls.Add(this.cb_crypto);
            this.gb_output.Location = new System.Drawing.Point(12, 296);
            this.gb_output.Name = "gb_output";
            this.gb_output.Size = new System.Drawing.Size(402, 220);
            this.gb_output.TabIndex = 7;
            this.gb_output.TabStop = false;
            this.gb_output.Text = "Output";
            // 
            // tb_dataLength
            // 
            this.tb_dataLength.Location = new System.Drawing.Point(117, 192);
            this.tb_dataLength.Name = "tb_dataLength";
            this.tb_dataLength.Size = new System.Drawing.Size(279, 20);
            this.tb_dataLength.TabIndex = 34;
            this.tb_dataLength.TextChanged += new System.EventHandler(this.tb_dataLength_TextChanged);
            this.tb_dataLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_dataLength_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Data Length:";
            // 
            // cb_shpwd
            // 
            this.cb_shpwd.AutoSize = true;
            this.cb_shpwd.Location = new System.Drawing.Point(381, 142);
            this.cb_shpwd.Name = "cb_shpwd";
            this.cb_shpwd.Size = new System.Drawing.Size(15, 14);
            this.cb_shpwd.TabIndex = 32;
            this.cb_shpwd.UseVisualStyleBackColor = true;
            this.cb_shpwd.CheckedChanged += new System.EventHandler(this.cb_shpwd_CheckedChanged);
            // 
            // tb_appOutputPath
            // 
            this.tb_appOutputPath.Location = new System.Drawing.Point(9, 87);
            this.tb_appOutputPath.Name = "tb_appOutputPath";
            this.tb_appOutputPath.ReadOnly = true;
            this.tb_appOutputPath.Size = new System.Drawing.Size(387, 20);
            this.tb_appOutputPath.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Key Derivation:";
            // 
            // tb_outputPath
            // 
            this.tb_outputPath.Location = new System.Drawing.Point(9, 19);
            this.tb_outputPath.Name = "tb_outputPath";
            this.tb_outputPath.Size = new System.Drawing.Size(387, 20);
            this.tb_outputPath.TabIndex = 9;
            // 
            // cb_kda
            // 
            this.cb_kda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kda.FormattingEnabled = true;
            this.cb_kda.Location = new System.Drawing.Point(117, 166);
            this.cb_kda.Name = "cb_kda";
            this.cb_kda.Size = new System.Drawing.Size(279, 21);
            this.cb_kda.TabIndex = 30;
            this.cb_kda.SelectedIndexChanged += new System.EventHandler(this.cb_kda_SelectedIndexChanged);
            // 
            // b_browseOutput
            // 
            this.b_browseOutput.Location = new System.Drawing.Point(9, 45);
            this.b_browseOutput.Name = "b_browseOutput";
            this.b_browseOutput.Size = new System.Drawing.Size(188, 23);
            this.b_browseOutput.TabIndex = 10;
            this.b_browseOutput.Text = "Browse";
            this.b_browseOutput.UseVisualStyleBackColor = true;
            this.b_browseOutput.Click += new System.EventHandler(this.b_browseOutput_Click);
            // 
            // tb_cryptoKey
            // 
            this.tb_cryptoKey.Location = new System.Drawing.Point(117, 140);
            this.tb_cryptoKey.Name = "tb_cryptoKey";
            this.tb_cryptoKey.Size = new System.Drawing.Size(258, 20);
            this.tb_cryptoKey.TabIndex = 29;
            this.tb_cryptoKey.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Current Path:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Password:";
            // 
            // b_setOutput
            // 
            this.b_setOutput.Location = new System.Drawing.Point(208, 45);
            this.b_setOutput.Name = "b_setOutput";
            this.b_setOutput.Size = new System.Drawing.Size(188, 23);
            this.b_setOutput.TabIndex = 11;
            this.b_setOutput.Text = "Set";
            this.b_setOutput.UseVisualStyleBackColor = true;
            this.b_setOutput.Click += new System.EventHandler(this.b_setOutput_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Encryption Algorithm:";
            // 
            // cb_crypto
            // 
            this.cb_crypto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_crypto.FormattingEnabled = true;
            this.cb_crypto.Location = new System.Drawing.Point(117, 113);
            this.cb_crypto.Name = "cb_crypto";
            this.cb_crypto.Size = new System.Drawing.Size(279, 21);
            this.cb_crypto.TabIndex = 26;
            // 
            // b_start
            // 
            this.b_start.Enabled = false;
            this.b_start.Location = new System.Drawing.Point(12, 522);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(402, 23);
            this.b_start.TabIndex = 18;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // pb_progress
            // 
            this.pb_progress.Location = new System.Drawing.Point(12, 568);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(402, 23);
            this.pb_progress.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Status:";
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Location = new System.Drawing.Point(52, 552);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(27, 13);
            this.l_status.TabIndex = 17;
            this.l_status.Text = "N/A";
            // 
            // ofd_cover
            // 
            this.ofd_cover.Filter = "All Supported Cover Formats|*.bmp;*.dib;*.gif;*.png;*.wav;*.wave|Images|*.bmp;*.d" +
    "ib;*.gif;*.png|Audio|*.wav;*.wave";
            // 
            // bw_process
            // 
            this.bw_process.WorkerReportsProgress = true;
            this.bw_process.WorkerSupportsCancellation = true;
            this.bw_process.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_process_DoWork);
            this.bw_process.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_process_ProgressChanged);
            // 
            // LSBDecode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 603);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.gb_output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gb_cover);
            this.Controls.Add(this.pb_progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LSBDecode";
            this.Text = "psteg-stegano: LSB Steganography Decoder";
            this.gb_cover.ResumeLayout(false);
            this.gb_cover.PerformLayout();
            this.gb_output.ResumeLayout(false);
            this.gb_output.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_cover;
        private System.Windows.Forms.TextBox tb_coverID;
        private System.Windows.Forms.TextBox tb_appCoverPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_coverPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_setCover;
        private System.Windows.Forms.Button b_browseCover;
        private System.Windows.Forms.GroupBox gb_output;
        private System.Windows.Forms.TextBox tb_appOutputPath;
        private System.Windows.Forms.TextBox tb_outputPath;
        private System.Windows.Forms.Button b_browseOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_setOutput;
        private System.Windows.Forms.CheckBox cb_shpwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_kda;
        private System.Windows.Forms.TextBox tb_cryptoKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_crypto;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.SaveFileDialog sfd_destination;
        private System.Windows.Forms.OpenFileDialog ofd_cover;
        private System.ComponentModel.BackgroundWorker bw_process;
        private System.Windows.Forms.TextBox tb_dataLength;
        private System.Windows.Forms.Label label9;
    }
}