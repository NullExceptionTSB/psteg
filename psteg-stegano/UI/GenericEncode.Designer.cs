﻿namespace psteg.Stegano.UI {
    partial class GenericEncode {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericEncode));
            this.tb_coverPath = new System.Windows.Forms.TextBox();
            this.b_browseCover = new System.Windows.Forms.Button();
            this.b_setCover = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_cover = new System.Windows.Forms.GroupBox();
            this.tb_coverID = new System.Windows.Forms.TextBox();
            this.tb_appCoverPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_output = new System.Windows.Forms.GroupBox();
            this.tb_appOutputPath = new System.Windows.Forms.TextBox();
            this.tb_outputPath = new System.Windows.Forms.TextBox();
            this.b_browseOutput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.b_setOutput = new System.Windows.Forms.Button();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.ofd_cover = new System.Windows.Forms.OpenFileDialog();
            this.l_status = new System.Windows.Forms.Label();
            this.b_start = new System.Windows.Forms.Button();
            this.sfd_destination = new System.Windows.Forms.SaveFileDialog();
            this.bw_process = new System.ComponentModel.BackgroundWorker();
            this.gb_data = new System.Windows.Forms.GroupBox();
            this.cb_shpwd = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_kda = new System.Windows.Forms.ComboBox();
            this.tb_cryptoKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_crypto = new System.Windows.Forms.ComboBox();
            this.tb_appDataPath = new System.Windows.Forms.TextBox();
            this.tb_dataPath = new System.Windows.Forms.TextBox();
            this.b_browseData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.b_setData = new System.Windows.Forms.Button();
            this.ofd_data = new System.Windows.Forms.OpenFileDialog();
            this.cb_sm = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gb_cover.SuspendLayout();
            this.gb_output.SuspendLayout();
            this.gb_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_coverPath
            // 
            this.tb_coverPath.AllowDrop = true;
            this.tb_coverPath.Location = new System.Drawing.Point(9, 13);
            this.tb_coverPath.Name = "tb_coverPath";
            this.tb_coverPath.Size = new System.Drawing.Size(387, 20);
            this.tb_coverPath.TabIndex = 0;
            this.tb_coverPath.TextChanged += new System.EventHandler(this.tb_coverPath_TextChanged);
            this.tb_coverPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_coverPath_DragDrop);
            this.tb_coverPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
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
            // b_setCover
            // 
            this.b_setCover.Location = new System.Drawing.Point(208, 39);
            this.b_setCover.Name = "b_setCover";
            this.b_setCover.Size = new System.Drawing.Size(188, 23);
            this.b_setCover.TabIndex = 3;
            this.b_setCover.Text = "Set";
            this.b_setCover.UseVisualStyleBackColor = true;
            this.b_setCover.Click += new System.EventHandler(this.b_setCover_Click_LSB);
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
            this.gb_cover.Location = new System.Drawing.Point(12, 39);
            this.gb_cover.Name = "gb_cover";
            this.gb_cover.Size = new System.Drawing.Size(402, 283);
            this.gb_cover.TabIndex = 5;
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
            // gb_output
            // 
            this.gb_output.Controls.Add(this.tb_appOutputPath);
            this.gb_output.Controls.Add(this.tb_outputPath);
            this.gb_output.Controls.Add(this.b_browseOutput);
            this.gb_output.Controls.Add(this.label1);
            this.gb_output.Controls.Add(this.b_setOutput);
            this.gb_output.Location = new System.Drawing.Point(12, 536);
            this.gb_output.Name = "gb_output";
            this.gb_output.Size = new System.Drawing.Size(402, 123);
            this.gb_output.TabIndex = 6;
            this.gb_output.TabStop = false;
            this.gb_output.Text = "Output";
            // 
            // tb_appOutputPath
            // 
            this.tb_appOutputPath.Location = new System.Drawing.Point(9, 87);
            this.tb_appOutputPath.Name = "tb_appOutputPath";
            this.tb_appOutputPath.ReadOnly = true;
            this.tb_appOutputPath.Size = new System.Drawing.Size(387, 20);
            this.tb_appOutputPath.TabIndex = 13;
            // 
            // tb_outputPath
            // 
            this.tb_outputPath.Location = new System.Drawing.Point(9, 19);
            this.tb_outputPath.Name = "tb_outputPath";
            this.tb_outputPath.Size = new System.Drawing.Size(387, 20);
            this.tb_outputPath.TabIndex = 9;
            this.tb_outputPath.TextChanged += new System.EventHandler(this.tb_outputPath_TextChanged);
            // 
            // b_browseOutput
            // 
            this.b_browseOutput.Enabled = false;
            this.b_browseOutput.Location = new System.Drawing.Point(9, 45);
            this.b_browseOutput.Name = "b_browseOutput";
            this.b_browseOutput.Size = new System.Drawing.Size(188, 23);
            this.b_browseOutput.TabIndex = 10;
            this.b_browseOutput.Text = "Browse";
            this.b_browseOutput.UseVisualStyleBackColor = true;
            this.b_browseOutput.Click += new System.EventHandler(this.b_browseOutput_Click);
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
            // b_setOutput
            // 
            this.b_setOutput.Enabled = false;
            this.b_setOutput.Location = new System.Drawing.Point(208, 45);
            this.b_setOutput.Name = "b_setOutput";
            this.b_setOutput.Size = new System.Drawing.Size(188, 23);
            this.b_setOutput.TabIndex = 11;
            this.b_setOutput.Text = "Set";
            this.b_setOutput.UseVisualStyleBackColor = true;
            this.b_setOutput.Click += new System.EventHandler(this.b_setOutput_Click);
            // 
            // pb_progress
            // 
            this.pb_progress.Location = new System.Drawing.Point(12, 711);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(402, 23);
            this.pb_progress.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 695);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status:";
            // 
            // ofd_cover
            // 
            this.ofd_cover.Filter = "All Supported Cover Formats|*.bmp;*.dib;*.gif;*.png;*.wav;*.wave|Images|*.bmp;*.d" +
    "ib;*.gif;*.png|Audio|*.wav;*.wave";
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Location = new System.Drawing.Point(52, 695);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(27, 13);
            this.l_status.TabIndex = 9;
            this.l_status.Text = "N/A";
            // 
            // b_start
            // 
            this.b_start.Enabled = false;
            this.b_start.Location = new System.Drawing.Point(12, 665);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(402, 23);
            this.b_start.TabIndex = 12;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click_LSB);
            // 
            // bw_process
            // 
            this.bw_process.WorkerReportsProgress = true;
            this.bw_process.WorkerSupportsCancellation = true;
            this.bw_process.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_process_DoWork);
            this.bw_process.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_process_ProgressChanged);
            this.bw_process.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_process_RunWorkerCompleted);
            // 
            // gb_data
            // 
            this.gb_data.Controls.Add(this.cb_shpwd);
            this.gb_data.Controls.Add(this.label8);
            this.gb_data.Controls.Add(this.cb_kda);
            this.gb_data.Controls.Add(this.tb_cryptoKey);
            this.gb_data.Controls.Add(this.label7);
            this.gb_data.Controls.Add(this.label6);
            this.gb_data.Controls.Add(this.cb_crypto);
            this.gb_data.Controls.Add(this.tb_appDataPath);
            this.gb_data.Controls.Add(this.tb_dataPath);
            this.gb_data.Controls.Add(this.b_browseData);
            this.gb_data.Controls.Add(this.label3);
            this.gb_data.Controls.Add(this.b_setData);
            this.gb_data.Location = new System.Drawing.Point(12, 328);
            this.gb_data.Name = "gb_data";
            this.gb_data.Size = new System.Drawing.Size(402, 202);
            this.gb_data.TabIndex = 14;
            this.gb_data.TabStop = false;
            this.gb_data.Text = "Data";
            // 
            // cb_shpwd
            // 
            this.cb_shpwd.AutoSize = true;
            this.cb_shpwd.Location = new System.Drawing.Point(381, 142);
            this.cb_shpwd.Name = "cb_shpwd";
            this.cb_shpwd.Size = new System.Drawing.Size(15, 14);
            this.cb_shpwd.TabIndex = 25;
            this.cb_shpwd.UseVisualStyleBackColor = true;
            this.cb_shpwd.CheckedChanged += new System.EventHandler(this.cb_shpwd_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Key Derivation:";
            // 
            // cb_kda
            // 
            this.cb_kda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kda.FormattingEnabled = true;
            this.cb_kda.Location = new System.Drawing.Point(117, 166);
            this.cb_kda.Name = "cb_kda";
            this.cb_kda.Size = new System.Drawing.Size(279, 21);
            this.cb_kda.TabIndex = 23;
            // 
            // tb_cryptoKey
            // 
            this.tb_cryptoKey.Location = new System.Drawing.Point(117, 140);
            this.tb_cryptoKey.Name = "tb_cryptoKey";
            this.tb_cryptoKey.Size = new System.Drawing.Size(258, 20);
            this.tb_cryptoKey.TabIndex = 22;
            this.tb_cryptoKey.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Encryption Algorithm:";
            // 
            // cb_crypto
            // 
            this.cb_crypto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_crypto.FormattingEnabled = true;
            this.cb_crypto.Location = new System.Drawing.Point(117, 113);
            this.cb_crypto.Name = "cb_crypto";
            this.cb_crypto.Size = new System.Drawing.Size(279, 21);
            this.cb_crypto.TabIndex = 19;
            this.cb_crypto.SelectedIndexChanged += new System.EventHandler(this.cb_crypto_SelectedIndexChanged);
            // 
            // tb_appDataPath
            // 
            this.tb_appDataPath.Location = new System.Drawing.Point(9, 87);
            this.tb_appDataPath.Name = "tb_appDataPath";
            this.tb_appDataPath.ReadOnly = true;
            this.tb_appDataPath.Size = new System.Drawing.Size(387, 20);
            this.tb_appDataPath.TabIndex = 18;
            // 
            // tb_dataPath
            // 
            this.tb_dataPath.AllowDrop = true;
            this.tb_dataPath.Location = new System.Drawing.Point(9, 19);
            this.tb_dataPath.Name = "tb_dataPath";
            this.tb_dataPath.Size = new System.Drawing.Size(387, 20);
            this.tb_dataPath.TabIndex = 14;
            this.tb_dataPath.TextChanged += new System.EventHandler(this.tb_dataPath_TextChanged);
            this.tb_dataPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_dataPath_DragDrop);
            this.tb_dataPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // b_browseData
            // 
            this.b_browseData.Location = new System.Drawing.Point(9, 45);
            this.b_browseData.Name = "b_browseData";
            this.b_browseData.Size = new System.Drawing.Size(188, 23);
            this.b_browseData.TabIndex = 15;
            this.b_browseData.Text = "Browse";
            this.b_browseData.UseVisualStyleBackColor = true;
            this.b_browseData.Click += new System.EventHandler(this.b_browseData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Current Path:";
            // 
            // b_setData
            // 
            this.b_setData.Location = new System.Drawing.Point(208, 45);
            this.b_setData.Name = "b_setData";
            this.b_setData.Size = new System.Drawing.Size(188, 23);
            this.b_setData.TabIndex = 16;
            this.b_setData.Text = "Set";
            this.b_setData.UseVisualStyleBackColor = true;
            this.b_setData.Click += new System.EventHandler(this.b_setData_Click);
            // 
            // cb_sm
            // 
            this.cb_sm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sm.FormattingEnabled = true;
            this.cb_sm.Items.AddRange(new object[] {
            "LSB",
            "Metadata",
            "JPEG LSB-DCT"});
            this.cb_sm.Location = new System.Drawing.Point(147, 12);
            this.cb_sm.Name = "cb_sm";
            this.cb_sm.Size = new System.Drawing.Size(267, 21);
            this.cb_sm.TabIndex = 15;
            this.cb_sm.SelectedIndexChanged += new System.EventHandler(this.cb_sm_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Steganographic Method:";
            // 
            // GenericEncode
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 746);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_sm);
            this.Controls.Add(this.gb_data);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pb_progress);
            this.Controls.Add(this.gb_output);
            this.Controls.Add(this.gb_cover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GenericEncode";
            this.Text = "psteg-stegano: Steganography Encoder";
            this.gb_cover.ResumeLayout(false);
            this.gb_cover.PerformLayout();
            this.gb_output.ResumeLayout(false);
            this.gb_output.PerformLayout();
            this.gb_data.ResumeLayout(false);
            this.gb_data.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_coverPath;
        private System.Windows.Forms.Button b_browseCover;
        private System.Windows.Forms.Button b_setCover;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_cover;
        private System.Windows.Forms.TextBox tb_appCoverPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_output;
        private System.Windows.Forms.TextBox tb_appOutputPath;
        private System.Windows.Forms.TextBox tb_outputPath;
        private System.Windows.Forms.Button b_browseOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_setOutput;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog ofd_cover;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.TextBox tb_coverID;
        private System.Windows.Forms.SaveFileDialog sfd_destination;
        private System.ComponentModel.BackgroundWorker bw_process;
        private System.Windows.Forms.GroupBox gb_data;
        private System.Windows.Forms.TextBox tb_appDataPath;
        private System.Windows.Forms.TextBox tb_dataPath;
        private System.Windows.Forms.Button b_browseData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_setData;
        private System.Windows.Forms.OpenFileDialog ofd_data;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_crypto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_kda;
        private System.Windows.Forms.TextBox tb_cryptoKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_shpwd;
        private System.Windows.Forms.ComboBox cb_sm;
        private System.Windows.Forms.Label label9;
    }
}