namespace psteg_fstools {
    partial class ADS {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_c_clear = new System.Windows.Forms.Button();
            this.b_add = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_c_key = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_c_encryption = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_c_browse = new System.Windows.Forms.Button();
            this.tb_c_streamName = new System.Windows.Forms.TextBox();
            this.tb_c_dataSource = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_extract = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_r_key = new System.Windows.Forms.TextBox();
            this.tb_r_streamName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_r_encryption = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lv_streams = new System.Windows.Forms.ListView();
            this.Stream = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_appFile = new System.Windows.Forms.TextBox();
            this.b_fileSet = new System.Windows.Forms.Button();
            this.b_fileBrowse = new System.Windows.Forms.Button();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.ofd_stream = new System.Windows.Forms.OpenFileDialog();
            this.ofd_data_soruce = new System.Windows.Forms.OpenFileDialog();
            this.sfd_extract = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_c_clear);
            this.groupBox1.Controls.Add(this.b_add);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_c_key);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_c_encryption);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.b_c_browse);
            this.groupBox1.Controls.Add(this.tb_c_streamName);
            this.groupBox1.Controls.Add(this.tb_c_dataSource);
            this.groupBox1.Location = new System.Drawing.Point(380, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 198);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stream Creator";
            // 
            // b_c_clear
            // 
            this.b_c_clear.Location = new System.Drawing.Point(245, 153);
            this.b_c_clear.Name = "b_c_clear";
            this.b_c_clear.Size = new System.Drawing.Size(157, 23);
            this.b_c_clear.TabIndex = 16;
            this.b_c_clear.Text = "Clear";
            this.b_c_clear.UseVisualStyleBackColor = true;
            // 
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(86, 153);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(157, 23);
            this.b_add.TabIndex = 15;
            this.b_add.Text = "Add";
            this.b_add.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Key:";
            // 
            // tb_c_key
            // 
            this.tb_c_key.Location = new System.Drawing.Point(86, 127);
            this.tb_c_key.Name = "tb_c_key";
            this.tb_c_key.Size = new System.Drawing.Size(316, 20);
            this.tb_c_key.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Encryption:";
            // 
            // cb_c_encryption
            // 
            this.cb_c_encryption.FormattingEnabled = true;
            this.cb_c_encryption.Location = new System.Drawing.Point(86, 100);
            this.cb_c_encryption.Name = "cb_c_encryption";
            this.cb_c_encryption.Size = new System.Drawing.Size(316, 21);
            this.cb_c_encryption.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stream Name:";
            // 
            // b_c_browse
            // 
            this.b_c_browse.Location = new System.Drawing.Point(86, 71);
            this.b_c_browse.Name = "b_c_browse";
            this.b_c_browse.Size = new System.Drawing.Size(316, 23);
            this.b_c_browse.TabIndex = 9;
            this.b_c_browse.Text = "Browse";
            this.b_c_browse.UseVisualStyleBackColor = true;
            // 
            // tb_c_streamName
            // 
            this.tb_c_streamName.Location = new System.Drawing.Point(86, 19);
            this.tb_c_streamName.Name = "tb_c_streamName";
            this.tb_c_streamName.Size = new System.Drawing.Size(316, 20);
            this.tb_c_streamName.TabIndex = 0;
            // 
            // tb_c_dataSource
            // 
            this.tb_c_dataSource.Location = new System.Drawing.Point(86, 45);
            this.tb_c_dataSource.Name = "tb_c_dataSource";
            this.tb_c_dataSource.Size = new System.Drawing.Size(316, 20);
            this.tb_c_dataSource.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_extract);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_r_key);
            this.groupBox2.Controls.Add(this.tb_r_streamName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cb_r_encryption);
            this.groupBox2.Location = new System.Drawing.Point(380, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 142);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stream Reader";
            // 
            // b_extract
            // 
            this.b_extract.Location = new System.Drawing.Point(86, 98);
            this.b_extract.Name = "b_extract";
            this.b_extract.Size = new System.Drawing.Size(316, 23);
            this.b_extract.TabIndex = 17;
            this.b_extract.Text = "Extract";
            this.b_extract.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Key:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Stream Name:";
            // 
            // tb_r_key
            // 
            this.tb_r_key.Location = new System.Drawing.Point(86, 72);
            this.tb_r_key.Name = "tb_r_key";
            this.tb_r_key.Size = new System.Drawing.Size(316, 20);
            this.tb_r_key.TabIndex = 19;
            // 
            // tb_r_streamName
            // 
            this.tb_r_streamName.Location = new System.Drawing.Point(86, 19);
            this.tb_r_streamName.Name = "tb_r_streamName";
            this.tb_r_streamName.Size = new System.Drawing.Size(316, 20);
            this.tb_r_streamName.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Encryption:";
            // 
            // cb_r_encryption
            // 
            this.cb_r_encryption.FormattingEnabled = true;
            this.cb_r_encryption.Location = new System.Drawing.Point(86, 45);
            this.cb_r_encryption.Name = "cb_r_encryption";
            this.cb_r_encryption.Size = new System.Drawing.Size(316, 21);
            this.cb_r_encryption.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lv_streams);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_appFile);
            this.groupBox3.Controls.Add(this.b_fileSet);
            this.groupBox3.Controls.Add(this.b_fileBrowse);
            this.groupBox3.Controls.Add(this.tb_file);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 346);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stream Information";
            // 
            // lv_streams
            // 
            this.lv_streams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Stream,
            this.DataSize});
            this.lv_streams.HideSelection = false;
            this.lv_streams.Location = new System.Drawing.Point(6, 113);
            this.lv_streams.Name = "lv_streams";
            this.lv_streams.Size = new System.Drawing.Size(350, 227);
            this.lv_streams.TabIndex = 14;
            this.lv_streams.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Current File:";
            // 
            // tb_appFile
            // 
            this.tb_appFile.Location = new System.Drawing.Point(6, 87);
            this.tb_appFile.Name = "tb_appFile";
            this.tb_appFile.ReadOnly = true;
            this.tb_appFile.Size = new System.Drawing.Size(350, 20);
            this.tb_appFile.TabIndex = 12;
            // 
            // b_fileSet
            // 
            this.b_fileSet.Location = new System.Drawing.Point(182, 45);
            this.b_fileSet.Name = "b_fileSet";
            this.b_fileSet.Size = new System.Drawing.Size(174, 23);
            this.b_fileSet.TabIndex = 11;
            this.b_fileSet.Text = "Set";
            this.b_fileSet.UseVisualStyleBackColor = true;
            // 
            // b_fileBrowse
            // 
            this.b_fileBrowse.Location = new System.Drawing.Point(6, 45);
            this.b_fileBrowse.Name = "b_fileBrowse";
            this.b_fileBrowse.Size = new System.Drawing.Size(174, 23);
            this.b_fileBrowse.TabIndex = 10;
            this.b_fileBrowse.Text = "Browse";
            this.b_fileBrowse.UseVisualStyleBackColor = true;
            // 
            // tb_file
            // 
            this.tb_file.Location = new System.Drawing.Point(9, 19);
            this.tb_file.Name = "tb_file";
            this.tb_file.Size = new System.Drawing.Size(347, 20);
            this.tb_file.TabIndex = 9;
            // 
            // ADS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ADS";
            this.Text = "psteg-fstools: NTFS Alternate Data Streams";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_c_streamName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button b_c_clear;
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_c_key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_c_encryption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_c_browse;
        private System.Windows.Forms.TextBox tb_c_dataSource;
        private System.Windows.Forms.Button b_extract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_r_key;
        private System.Windows.Forms.TextBox tb_r_streamName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_r_encryption;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lv_streams;
        private System.Windows.Forms.ColumnHeader Stream;
        private System.Windows.Forms.ColumnHeader DataSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_appFile;
        private System.Windows.Forms.Button b_fileSet;
        private System.Windows.Forms.Button b_fileBrowse;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.OpenFileDialog ofd_stream;
        private System.Windows.Forms.OpenFileDialog ofd_data_soruce;
        private System.Windows.Forms.SaveFileDialog sfd_extract;
    }
}

