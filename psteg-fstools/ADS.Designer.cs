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
            this.gb_creator = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_c_kda = new System.Windows.Forms.ComboBox();
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
            this.gb_reader = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_r_kda = new System.Windows.Forms.ComboBox();
            this.b_extract = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_r_key = new System.Windows.Forms.TextBox();
            this.tb_r_streamName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_r_encryption = new System.Windows.Forms.ComboBox();
            this.gb_info = new System.Windows.Forms.GroupBox();
            this.lv_streams = new System.Windows.Forms.ListView();
            this.Stream = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_appFile = new System.Windows.Forms.TextBox();
            this.b_fileSet = new System.Windows.Forms.Button();
            this.b_fileBrowse = new System.Windows.Forms.Button();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.ofd_stream = new System.Windows.Forms.OpenFileDialog();
            this.ofd_data_source = new System.Windows.Forms.OpenFileDialog();
            this.sfd_extract = new System.Windows.Forms.SaveFileDialog();
            this.b_r_delete = new System.Windows.Forms.Button();
            this.cb_c_showkey = new System.Windows.Forms.CheckBox();
            this.cb_r_showkey = new System.Windows.Forms.CheckBox();
            this.b_randsname = new System.Windows.Forms.Button();
            this.gb_creator.SuspendLayout();
            this.gb_reader.SuspendLayout();
            this.gb_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_creator
            // 
            this.gb_creator.Controls.Add(this.b_randsname);
            this.gb_creator.Controls.Add(this.cb_c_showkey);
            this.gb_creator.Controls.Add(this.label10);
            this.gb_creator.Controls.Add(this.cb_c_kda);
            this.gb_creator.Controls.Add(this.b_c_clear);
            this.gb_creator.Controls.Add(this.b_add);
            this.gb_creator.Controls.Add(this.label5);
            this.gb_creator.Controls.Add(this.tb_c_key);
            this.gb_creator.Controls.Add(this.label4);
            this.gb_creator.Controls.Add(this.cb_c_encryption);
            this.gb_creator.Controls.Add(this.label3);
            this.gb_creator.Controls.Add(this.label2);
            this.gb_creator.Controls.Add(this.b_c_browse);
            this.gb_creator.Controls.Add(this.tb_c_streamName);
            this.gb_creator.Controls.Add(this.tb_c_dataSource);
            this.gb_creator.Location = new System.Drawing.Point(380, 12);
            this.gb_creator.Name = "gb_creator";
            this.gb_creator.Size = new System.Drawing.Size(408, 219);
            this.gb_creator.TabIndex = 6;
            this.gb_creator.TabStop = false;
            this.gb_creator.Text = "Stream Creator";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Key Derivation:";
            // 
            // cb_c_kda
            // 
            this.cb_c_kda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_c_kda.FormattingEnabled = true;
            this.cb_c_kda.Location = new System.Drawing.Point(86, 127);
            this.cb_c_kda.Name = "cb_c_kda";
            this.cb_c_kda.Size = new System.Drawing.Size(316, 21);
            this.cb_c_kda.TabIndex = 17;
            // 
            // b_c_clear
            // 
            this.b_c_clear.Location = new System.Drawing.Point(245, 180);
            this.b_c_clear.Name = "b_c_clear";
            this.b_c_clear.Size = new System.Drawing.Size(157, 23);
            this.b_c_clear.TabIndex = 16;
            this.b_c_clear.Text = "Clear";
            this.b_c_clear.UseVisualStyleBackColor = true;
            // 
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(86, 180);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(157, 23);
            this.b_add.TabIndex = 15;
            this.b_add.Text = "Add";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Key:";
            // 
            // tb_c_key
            // 
            this.tb_c_key.Location = new System.Drawing.Point(86, 154);
            this.tb_c_key.Name = "tb_c_key";
            this.tb_c_key.Size = new System.Drawing.Size(295, 20);
            this.tb_c_key.TabIndex = 13;
            this.tb_c_key.UseSystemPasswordChar = true;
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
            this.cb_c_encryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.b_c_browse.Click += new System.EventHandler(this.b_c_browse_Click);
            // 
            // tb_c_streamName
            // 
            this.tb_c_streamName.Location = new System.Drawing.Point(86, 19);
            this.tb_c_streamName.Name = "tb_c_streamName";
            this.tb_c_streamName.Size = new System.Drawing.Size(235, 20);
            this.tb_c_streamName.TabIndex = 0;
            // 
            // tb_c_dataSource
            // 
            this.tb_c_dataSource.Location = new System.Drawing.Point(86, 45);
            this.tb_c_dataSource.Name = "tb_c_dataSource";
            this.tb_c_dataSource.Size = new System.Drawing.Size(316, 20);
            this.tb_c_dataSource.TabIndex = 8;
            this.tb_c_dataSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_c_dataSource_DragDrop);
            this.tb_c_dataSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // gb_reader
            // 
            this.gb_reader.Controls.Add(this.cb_r_showkey);
            this.gb_reader.Controls.Add(this.b_r_delete);
            this.gb_reader.Controls.Add(this.label9);
            this.gb_reader.Controls.Add(this.cb_r_kda);
            this.gb_reader.Controls.Add(this.b_extract);
            this.gb_reader.Controls.Add(this.label7);
            this.gb_reader.Controls.Add(this.label6);
            this.gb_reader.Controls.Add(this.tb_r_key);
            this.gb_reader.Controls.Add(this.tb_r_streamName);
            this.gb_reader.Controls.Add(this.label8);
            this.gb_reader.Controls.Add(this.cb_r_encryption);
            this.gb_reader.Location = new System.Drawing.Point(380, 237);
            this.gb_reader.Name = "gb_reader";
            this.gb_reader.Size = new System.Drawing.Size(408, 154);
            this.gb_reader.TabIndex = 7;
            this.gb_reader.TabStop = false;
            this.gb_reader.Text = "Stream Reader";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Key Derivation:";
            // 
            // cb_r_kda
            // 
            this.cb_r_kda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_r_kda.FormattingEnabled = true;
            this.cb_r_kda.Location = new System.Drawing.Point(86, 72);
            this.cb_r_kda.Name = "cb_r_kda";
            this.cb_r_kda.Size = new System.Drawing.Size(316, 21);
            this.cb_r_kda.TabIndex = 21;
            // 
            // b_extract
            // 
            this.b_extract.Enabled = false;
            this.b_extract.Location = new System.Drawing.Point(86, 125);
            this.b_extract.Name = "b_extract";
            this.b_extract.Size = new System.Drawing.Size(157, 23);
            this.b_extract.TabIndex = 17;
            this.b_extract.Text = "Extract";
            this.b_extract.UseVisualStyleBackColor = true;
            this.b_extract.Click += new System.EventHandler(this.b_extract_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 102);
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
            this.tb_r_key.Location = new System.Drawing.Point(86, 99);
            this.tb_r_key.Name = "tb_r_key";
            this.tb_r_key.Size = new System.Drawing.Size(295, 20);
            this.tb_r_key.TabIndex = 19;
            this.tb_r_key.UseSystemPasswordChar = true;
            // 
            // tb_r_streamName
            // 
            this.tb_r_streamName.Location = new System.Drawing.Point(86, 19);
            this.tb_r_streamName.Name = "tb_r_streamName";
            this.tb_r_streamName.Size = new System.Drawing.Size(316, 20);
            this.tb_r_streamName.TabIndex = 17;
            this.tb_r_streamName.TextChanged += new System.EventHandler(this.tb_r_streamName_TextChanged);
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
            this.cb_r_encryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_r_encryption.FormattingEnabled = true;
            this.cb_r_encryption.Location = new System.Drawing.Point(86, 45);
            this.cb_r_encryption.Name = "cb_r_encryption";
            this.cb_r_encryption.Size = new System.Drawing.Size(316, 21);
            this.cb_r_encryption.TabIndex = 17;
            // 
            // gb_info
            // 
            this.gb_info.Controls.Add(this.lv_streams);
            this.gb_info.Controls.Add(this.label1);
            this.gb_info.Controls.Add(this.tb_appFile);
            this.gb_info.Controls.Add(this.b_fileSet);
            this.gb_info.Controls.Add(this.b_fileBrowse);
            this.gb_info.Controls.Add(this.tb_file);
            this.gb_info.Location = new System.Drawing.Point(12, 12);
            this.gb_info.Name = "gb_info";
            this.gb_info.Size = new System.Drawing.Size(362, 379);
            this.gb_info.TabIndex = 17;
            this.gb_info.TabStop = false;
            this.gb_info.Text = "Stream Information";
            // 
            // lv_streams
            // 
            this.lv_streams.AllowDrop = true;
            this.lv_streams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Stream,
            this.DataSize});
            this.lv_streams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_streams.HideSelection = false;
            this.lv_streams.Location = new System.Drawing.Point(6, 113);
            this.lv_streams.MultiSelect = false;
            this.lv_streams.Name = "lv_streams";
            this.lv_streams.Size = new System.Drawing.Size(350, 260);
            this.lv_streams.TabIndex = 14;
            this.lv_streams.UseCompatibleStateImageBehavior = false;
            this.lv_streams.View = System.Windows.Forms.View.Details;
            this.lv_streams.SelectedIndexChanged += new System.EventHandler(this.lv_streams_SelectedIndexChanged);
            this.lv_streams.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_appFile_DragDrop);
            this.lv_streams.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // Stream
            // 
            this.Stream.Text = "Stream Name";
            this.Stream.Width = 213;
            // 
            // DataSize
            // 
            this.DataSize.Text = "Data Size";
            this.DataSize.Width = 132;
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
            this.tb_appFile.AllowDrop = true;
            this.tb_appFile.Location = new System.Drawing.Point(6, 87);
            this.tb_appFile.Name = "tb_appFile";
            this.tb_appFile.ReadOnly = true;
            this.tb_appFile.Size = new System.Drawing.Size(350, 20);
            this.tb_appFile.TabIndex = 12;
            this.tb_appFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_appFile_DragDrop);
            this.tb_appFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // b_fileSet
            // 
            this.b_fileSet.Location = new System.Drawing.Point(182, 45);
            this.b_fileSet.Name = "b_fileSet";
            this.b_fileSet.Size = new System.Drawing.Size(174, 23);
            this.b_fileSet.TabIndex = 11;
            this.b_fileSet.Text = "Set";
            this.b_fileSet.UseVisualStyleBackColor = true;
            this.b_fileSet.Click += new System.EventHandler(this.b_fileSet_Click);
            // 
            // b_fileBrowse
            // 
            this.b_fileBrowse.Location = new System.Drawing.Point(6, 45);
            this.b_fileBrowse.Name = "b_fileBrowse";
            this.b_fileBrowse.Size = new System.Drawing.Size(174, 23);
            this.b_fileBrowse.TabIndex = 10;
            this.b_fileBrowse.Text = "Browse";
            this.b_fileBrowse.UseVisualStyleBackColor = true;
            this.b_fileBrowse.Click += new System.EventHandler(this.b_fileBrowse_Click);
            // 
            // tb_file
            // 
            this.tb_file.AllowDrop = true;
            this.tb_file.Location = new System.Drawing.Point(9, 19);
            this.tb_file.Name = "tb_file";
            this.tb_file.Size = new System.Drawing.Size(347, 20);
            this.tb_file.TabIndex = 9;
            this.tb_file.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_file_DragDrop);
            this.tb_file.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // b_r_delete
            // 
            this.b_r_delete.Enabled = false;
            this.b_r_delete.Location = new System.Drawing.Point(245, 125);
            this.b_r_delete.Name = "b_r_delete";
            this.b_r_delete.Size = new System.Drawing.Size(157, 23);
            this.b_r_delete.TabIndex = 23;
            this.b_r_delete.Text = "Delete";
            this.b_r_delete.UseVisualStyleBackColor = true;
            this.b_r_delete.Click += new System.EventHandler(this.b_r_delete_Click);
            // 
            // cb_c_showkey
            // 
            this.cb_c_showkey.AutoSize = true;
            this.cb_c_showkey.Location = new System.Drawing.Point(387, 157);
            this.cb_c_showkey.Name = "cb_c_showkey";
            this.cb_c_showkey.Size = new System.Drawing.Size(15, 14);
            this.cb_c_showkey.TabIndex = 19;
            this.cb_c_showkey.UseVisualStyleBackColor = true;
            this.cb_c_showkey.CheckedChanged += new System.EventHandler(this.cb_c_showkey_CheckedChanged);
            // 
            // cb_r_showkey
            // 
            this.cb_r_showkey.AutoSize = true;
            this.cb_r_showkey.Location = new System.Drawing.Point(387, 102);
            this.cb_r_showkey.Name = "cb_r_showkey";
            this.cb_r_showkey.Size = new System.Drawing.Size(15, 14);
            this.cb_r_showkey.TabIndex = 20;
            this.cb_r_showkey.UseVisualStyleBackColor = true;
            this.cb_r_showkey.CheckedChanged += new System.EventHandler(this.cb_r_showkey_CheckedChanged);
            // 
            // b_randsname
            // 
            this.b_randsname.Location = new System.Drawing.Point(327, 17);
            this.b_randsname.Name = "b_randsname";
            this.b_randsname.Size = new System.Drawing.Size(75, 23);
            this.b_randsname.TabIndex = 20;
            this.b_randsname.Text = "Random";
            this.b_randsname.UseVisualStyleBackColor = true;
            this.b_randsname.Click += new System.EventHandler(this.b_randsname_Click);
            // 
            // ADS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 397);
            this.Controls.Add(this.gb_info);
            this.Controls.Add(this.gb_reader);
            this.Controls.Add(this.gb_creator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ADS";
            this.Text = "psteg-fstools: NTFS Alternate Data Streams";
            this.gb_creator.ResumeLayout(false);
            this.gb_creator.PerformLayout();
            this.gb_reader.ResumeLayout(false);
            this.gb_reader.PerformLayout();
            this.gb_info.ResumeLayout(false);
            this.gb_info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gb_creator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_c_streamName;
        private System.Windows.Forms.GroupBox gb_reader;
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
        private System.Windows.Forms.GroupBox gb_info;
        private System.Windows.Forms.ListView lv_streams;
        private System.Windows.Forms.ColumnHeader Stream;
        private System.Windows.Forms.ColumnHeader DataSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_appFile;
        private System.Windows.Forms.Button b_fileSet;
        private System.Windows.Forms.Button b_fileBrowse;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.OpenFileDialog ofd_stream;
        private System.Windows.Forms.OpenFileDialog ofd_data_source;
        private System.Windows.Forms.SaveFileDialog sfd_extract;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_r_kda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_c_kda;
        private System.Windows.Forms.CheckBox cb_c_showkey;
        private System.Windows.Forms.CheckBox cb_r_showkey;
        private System.Windows.Forms.Button b_r_delete;
        private System.Windows.Forms.Button b_randsname;
    }
}

