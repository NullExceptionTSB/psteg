namespace psteg.Chaffblob {
    partial class Encode {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encode));
            this.lv_files = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDkey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CryptoKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_filename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_browseInput = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_idKey = new System.Windows.Forms.TextBox();
            this.cb_showIdKey = new System.Windows.Forms.CheckBox();
            this.cb_showCryptoKey = new System.Windows.Forms.CheckBox();
            this.tb_cryptoKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_showKeys = new System.Windows.Forms.CheckBox();
            this.cb_prng = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.b_addfile = new System.Windows.Forms.Button();
            this.b_remove = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_cryptoalgo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_chaffCount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_randomizeChaffCount = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_hmac = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_container = new System.Windows.Forms.ComboBox();
            this.tb_outputFile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.b_browseOutput = new System.Windows.Forms.Button();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.l_state = new System.Windows.Forms.Label();
            this.b_start_cancel = new System.Windows.Forms.Button();
            this.b_reset = new System.Windows.Forms.Button();
            this.ofd_blobfile = new System.Windows.Forms.OpenFileDialog();
            this.bw_go = new System.ComponentModel.BackgroundWorker();
            this.sfd_output = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_files
            // 
            this.lv_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File,
            this.IDkey,
            this.CryptoKey});
            this.lv_files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_files.HideSelection = false;
            this.lv_files.LabelWrap = false;
            this.lv_files.Location = new System.Drawing.Point(12, 25);
            this.lv_files.MultiSelect = false;
            this.lv_files.Name = "lv_files";
            this.lv_files.Size = new System.Drawing.Size(304, 236);
            this.lv_files.TabIndex = 0;
            this.lv_files.TabStop = false;
            this.lv_files.UseCompatibleStateImageBehavior = false;
            this.lv_files.View = System.Windows.Forms.View.Details;
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 90;
            // 
            // IDkey
            // 
            this.IDkey.Text = "ID Key";
            this.IDkey.Width = 76;
            // 
            // CryptoKey
            // 
            this.CryptoKey.Text = "Crypto Key";
            this.CryptoKey.Width = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Blob State:";
            // 
            // tb_filename
            // 
            this.tb_filename.Location = new System.Drawing.Point(67, 13);
            this.tb_filename.Name = "tb_filename";
            this.tb_filename.Size = new System.Drawing.Size(168, 20);
            this.tb_filename.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Name:";
            // 
            // b_browseInput
            // 
            this.b_browseInput.Location = new System.Drawing.Point(67, 39);
            this.b_browseInput.Name = "b_browseInput";
            this.b_browseInput.Size = new System.Drawing.Size(168, 20);
            this.b_browseInput.TabIndex = 3;
            this.b_browseInput.Text = "Browse...";
            this.b_browseInput.UseVisualStyleBackColor = true;
            this.b_browseInput.Click += new System.EventHandler(this.b_browseInput_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID Key:";
            // 
            // tb_idKey
            // 
            this.tb_idKey.Location = new System.Drawing.Point(67, 65);
            this.tb_idKey.Name = "tb_idKey";
            this.tb_idKey.Size = new System.Drawing.Size(168, 20);
            this.tb_idKey.TabIndex = 4;
            this.tb_idKey.UseSystemPasswordChar = true;
            // 
            // cb_showIdKey
            // 
            this.cb_showIdKey.AutoSize = true;
            this.cb_showIdKey.Location = new System.Drawing.Point(241, 68);
            this.cb_showIdKey.Name = "cb_showIdKey";
            this.cb_showIdKey.Size = new System.Drawing.Size(15, 14);
            this.cb_showIdKey.TabIndex = 99;
            this.cb_showIdKey.TabStop = false;
            this.cb_showIdKey.UseVisualStyleBackColor = true;
            this.cb_showIdKey.CheckedChanged += new System.EventHandler(this.cb_showIdKey_CheckedChanged);
            // 
            // cb_showCryptoKey
            // 
            this.cb_showCryptoKey.AutoSize = true;
            this.cb_showCryptoKey.Location = new System.Drawing.Point(241, 95);
            this.cb_showCryptoKey.Name = "cb_showCryptoKey";
            this.cb_showCryptoKey.Size = new System.Drawing.Size(15, 14);
            this.cb_showCryptoKey.TabIndex = 100;
            this.cb_showCryptoKey.TabStop = false;
            this.cb_showCryptoKey.UseVisualStyleBackColor = true;
            this.cb_showCryptoKey.CheckedChanged += new System.EventHandler(this.cb_showCryptoKey_CheckedChanged);
            // 
            // tb_cryptoKey
            // 
            this.tb_cryptoKey.Location = new System.Drawing.Point(67, 91);
            this.tb_cryptoKey.Name = "tb_cryptoKey";
            this.tb_cryptoKey.Size = new System.Drawing.Size(168, 20);
            this.tb_cryptoKey.TabIndex = 5;
            this.tb_cryptoKey.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Crypto Key:";
            // 
            // cb_showKeys
            // 
            this.cb_showKeys.AutoSize = true;
            this.cb_showKeys.Location = new System.Drawing.Point(245, 8);
            this.cb_showKeys.Name = "cb_showKeys";
            this.cb_showKeys.Size = new System.Drawing.Size(79, 17);
            this.cb_showKeys.TabIndex = 11;
            this.cb_showKeys.TabStop = false;
            this.cb_showKeys.Text = "Show Keys";
            this.cb_showKeys.UseVisualStyleBackColor = true;
            this.cb_showKeys.CheckedChanged += new System.EventHandler(this.cb_showKeys_CheckedChanged);
            // 
            // cb_prng
            // 
            this.cb_prng.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prng.FormattingEnabled = true;
            this.cb_prng.Location = new System.Drawing.Point(71, 39);
            this.cb_prng.Name = "cb_prng";
            this.cb_prng.Size = new System.Drawing.Size(174, 21);
            this.cb_prng.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "PRNG:";
            // 
            // b_addfile
            // 
            this.b_addfile.Location = new System.Drawing.Point(67, 117);
            this.b_addfile.Name = "b_addfile";
            this.b_addfile.Size = new System.Drawing.Size(81, 23);
            this.b_addfile.TabIndex = 6;
            this.b_addfile.Text = "Add";
            this.b_addfile.UseVisualStyleBackColor = true;
            this.b_addfile.Click += new System.EventHandler(this.b_addfile_Click);
            // 
            // b_remove
            // 
            this.b_remove.Location = new System.Drawing.Point(154, 117);
            this.b_remove.Name = "b_remove";
            this.b_remove.Size = new System.Drawing.Size(81, 23);
            this.b_remove.TabIndex = 7;
            this.b_remove.Text = "Remove";
            this.b_remove.UseVisualStyleBackColor = true;
            this.b_remove.Click += new System.EventHandler(this.b_remove_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Encryption:";
            // 
            // cb_cryptoalgo
            // 
            this.cb_cryptoalgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cryptoalgo.FormattingEnabled = true;
            this.cb_cryptoalgo.Location = new System.Drawing.Point(71, 66);
            this.cb_cryptoalgo.Name = "cb_cryptoalgo";
            this.cb_cryptoalgo.Size = new System.Drawing.Size(174, 21);
            this.cb_cryptoalgo.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Chaffs:";
            // 
            // tb_chaffCount
            // 
            this.tb_chaffCount.Location = new System.Drawing.Point(71, 13);
            this.tb_chaffCount.Name = "tb_chaffCount";
            this.tb_chaffCount.Size = new System.Drawing.Size(134, 20);
            this.tb_chaffCount.TabIndex = 8;
            this.tb_chaffCount.Text = "256";
            this.tb_chaffCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_chaffCount_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_filename);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.b_browseInput);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_idKey);
            this.groupBox1.Controls.Add(this.b_remove);
            this.groupBox1.Controls.Add(this.cb_showIdKey);
            this.groupBox1.Controls.Add(this.b_addfile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_cryptoKey);
            this.groupBox1.Controls.Add(this.cb_showCryptoKey);
            this.groupBox1.Location = new System.Drawing.Point(322, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_randomizeChaffCount);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cb_hmac);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cb_container);
            this.groupBox2.Controls.Add(this.tb_outputFile);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tb_chaffCount);
            this.groupBox2.Controls.Add(this.cb_prng);
            this.groupBox2.Controls.Add(this.b_browseOutput);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_cryptoalgo);
            this.groupBox2.Location = new System.Drawing.Point(590, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 207);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // b_randomizeChaffCount
            // 
            this.b_randomizeChaffCount.Location = new System.Drawing.Point(211, 11);
            this.b_randomizeChaffCount.Name = "b_randomizeChaffCount";
            this.b_randomizeChaffCount.Size = new System.Drawing.Size(34, 23);
            this.b_randomizeChaffCount.TabIndex = 24;
            this.b_randomizeChaffCount.Text = "R";
            this.b_randomizeChaffCount.UseVisualStyleBackColor = true;
            this.b_randomizeChaffCount.Click += new System.EventHandler(this.b_randomizeChaffCount_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "MAC:";
            // 
            // cb_hmac
            // 
            this.cb_hmac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_hmac.FormattingEnabled = true;
            this.cb_hmac.Location = new System.Drawing.Point(71, 93);
            this.cb_hmac.Name = "cb_hmac";
            this.cb_hmac.Size = new System.Drawing.Size(174, 21);
            this.cb_hmac.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Container:";
            // 
            // cb_container
            // 
            this.cb_container.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_container.FormattingEnabled = true;
            this.cb_container.Items.AddRange(new object[] {
            "ChaffBlob"});
            this.cb_container.Location = new System.Drawing.Point(71, 120);
            this.cb_container.Name = "cb_container";
            this.cb_container.Size = new System.Drawing.Size(174, 21);
            this.cb_container.TabIndex = 12;
            // 
            // tb_outputFile
            // 
            this.tb_outputFile.Location = new System.Drawing.Point(71, 147);
            this.tb_outputFile.Name = "tb_outputFile";
            this.tb_outputFile.Size = new System.Drawing.Size(174, 20);
            this.tb_outputFile.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Output File:";
            // 
            // b_browseOutput
            // 
            this.b_browseOutput.Location = new System.Drawing.Point(71, 173);
            this.b_browseOutput.Name = "b_browseOutput";
            this.b_browseOutput.Size = new System.Drawing.Size(174, 20);
            this.b_browseOutput.TabIndex = 14;
            this.b_browseOutput.Text = "Browse...";
            this.b_browseOutput.UseVisualStyleBackColor = true;
            this.b_browseOutput.Click += new System.EventHandler(this.b_browseOutput_Click);
            // 
            // pb_progress
            // 
            this.pb_progress.Location = new System.Drawing.Point(324, 238);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(519, 23);
            this.pb_progress.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(321, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "State:";
            // 
            // l_state
            // 
            this.l_state.AutoSize = true;
            this.l_state.Location = new System.Drawing.Point(362, 222);
            this.l_state.Name = "l_state";
            this.l_state.Size = new System.Drawing.Size(24, 13);
            this.l_state.TabIndex = 24;
            this.l_state.Text = "Idle";
            // 
            // b_start_cancel
            // 
            this.b_start_cancel.Location = new System.Drawing.Point(322, 184);
            this.b_start_cancel.Name = "b_start_cancel";
            this.b_start_cancel.Size = new System.Drawing.Size(128, 23);
            this.b_start_cancel.TabIndex = 3;
            this.b_start_cancel.Text = "Start";
            this.b_start_cancel.UseVisualStyleBackColor = true;
            this.b_start_cancel.Click += new System.EventHandler(this.b_start_cancel_Click);
            // 
            // b_reset
            // 
            this.b_reset.Location = new System.Drawing.Point(456, 184);
            this.b_reset.Name = "b_reset";
            this.b_reset.Size = new System.Drawing.Size(128, 23);
            this.b_reset.TabIndex = 4;
            this.b_reset.Text = "Clear";
            this.b_reset.UseVisualStyleBackColor = true;
            this.b_reset.Click += new System.EventHandler(this.b_reset_Click);
            // 
            // bw_go
            // 
            this.bw_go.WorkerReportsProgress = true;
            this.bw_go.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_go_DoWork);
            this.bw_go.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_go_ProgressChanged);
            this.bw_go.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_go_RunWorkerCompleted);
            // 
            // sfd_output
            // 
            this.sfd_output.Filter = "Chaffblock File|*.chablk";
            // 
            // Encode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 269);
            this.Controls.Add(this.b_reset);
            this.Controls.Add(this.b_start_cancel);
            this.Controls.Add(this.l_state);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pb_progress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cb_showKeys);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Encode";
            this.Text = "psteg ChaffBlob - Chaffing and Winnowing Tool - Encode Mode";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_files;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader IDkey;
        private System.Windows.Forms.ColumnHeader CryptoKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_filename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_browseInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_idKey;
        private System.Windows.Forms.CheckBox cb_showIdKey;
        private System.Windows.Forms.CheckBox cb_showCryptoKey;
        private System.Windows.Forms.TextBox tb_cryptoKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_showKeys;
        private System.Windows.Forms.ComboBox cb_prng;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b_addfile;
        private System.Windows.Forms.Button b_remove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_cryptoalgo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_chaffCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_outputFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button b_browseOutput;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_container;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label l_state;
        private System.Windows.Forms.Button b_start_cancel;
        private System.Windows.Forms.Button b_reset;
        private System.Windows.Forms.OpenFileDialog ofd_blobfile;
        private System.ComponentModel.BackgroundWorker bw_go;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_hmac;
        private System.Windows.Forms.SaveFileDialog sfd_output;
        private System.Windows.Forms.Button b_randomizeChaffCount;
    }
}

