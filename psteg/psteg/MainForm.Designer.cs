namespace psteg
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lv_containers = new System.Windows.Forms.ListView();
            this.lv_methods = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_datapath = new System.Windows.Forms.TextBox();
            this.b_dataBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_encode = new System.Windows.Forms.RadioButton();
            this.rb_decode = new System.Windows.Forms.RadioButton();
            this.cb_encrypt = new System.Windows.Forms.CheckBox();
            this.b_start = new System.Windows.Forms.Button();
            this.b_stegOptions = new System.Windows.Forms.Button();
            this.b_cryptoOptions = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.l_status = new System.Windows.Forms.Label();
            this.pb_status = new System.Windows.Forms.ProgressBar();
            this.bw_process = new System.ComponentModel.BackgroundWorker();
            this.tb_container = new System.Windows.Forms.TextBox();
            this.b_containerBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.b_add_set = new System.Windows.Forms.Button();
            this.cb_multicontainer = new System.Windows.Forms.CheckBox();
            this.sfd_data = new System.Windows.Forms.SaveFileDialog();
            this.ofd_data = new System.Windows.Forms.OpenFileDialog();
            this.ofd_container = new System.Windows.Forms.OpenFileDialog();
            this.l_selectedMethod = new System.Windows.Forms.Label();
            this.sfd_encoded = new System.Windows.Forms.SaveFileDialog();
            this.ofd_encoded = new System.Windows.Forms.OpenFileDialog();
            this.l_underConstruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lv_containers
            // 
            this.lv_containers.AllowDrop = true;
            this.lv_containers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_containers.HideSelection = false;
            this.lv_containers.Location = new System.Drawing.Point(12, 23);
            this.lv_containers.MultiSelect = false;
            this.lv_containers.Name = "lv_containers";
            this.lv_containers.Size = new System.Drawing.Size(200, 200);
            this.lv_containers.TabIndex = 0;
            this.lv_containers.UseCompatibleStateImageBehavior = false;
            this.lv_containers.View = System.Windows.Forms.View.List;
            this.lv_containers.ItemActivate += new System.EventHandler(this.lv_containers_ItemActivate);
            // 
            // lv_methods
            // 
            this.lv_methods.HideSelection = false;
            this.lv_methods.Location = new System.Drawing.Point(515, 23);
            this.lv_methods.MultiSelect = false;
            this.lv_methods.Name = "lv_methods";
            this.lv_methods.Size = new System.Drawing.Size(200, 200);
            this.lv_methods.TabIndex = 1;
            this.lv_methods.UseCompatibleStateImageBehavior = false;
            this.lv_methods.View = System.Windows.Forms.View.List;
            this.lv_methods.ItemActivate += new System.EventHandler(this.lv_methods_ItemActivate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Container file(s)";
            // 
            // tb_datapath
            // 
            this.tb_datapath.Location = new System.Drawing.Point(218, 39);
            this.tb_datapath.Name = "tb_datapath";
            this.tb_datapath.Size = new System.Drawing.Size(189, 20);
            this.tb_datapath.TabIndex = 4;
            this.tb_datapath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // b_dataBrowse
            // 
            this.b_dataBrowse.Location = new System.Drawing.Point(412, 38);
            this.b_dataBrowse.Name = "b_dataBrowse";
            this.b_dataBrowse.Size = new System.Drawing.Size(98, 21);
            this.b_dataBrowse.TabIndex = 5;
            this.b_dataBrowse.Text = "Browse";
            this.b_dataBrowse.UseVisualStyleBackColor = true;
            this.b_dataBrowse.Click += new System.EventHandler(this.b_dataBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data file:";
            // 
            // rb_encode
            // 
            this.rb_encode.AutoSize = true;
            this.rb_encode.Checked = true;
            this.rb_encode.Location = new System.Drawing.Point(218, 71);
            this.rb_encode.Name = "rb_encode";
            this.rb_encode.Size = new System.Drawing.Size(62, 17);
            this.rb_encode.TabIndex = 10;
            this.rb_encode.TabStop = true;
            this.rb_encode.Text = "Encode";
            this.rb_encode.UseVisualStyleBackColor = true;
            this.rb_encode.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_decode
            // 
            this.rb_decode.AutoSize = true;
            this.rb_decode.Location = new System.Drawing.Point(218, 94);
            this.rb_decode.Name = "rb_decode";
            this.rb_decode.Size = new System.Drawing.Size(63, 17);
            this.rb_decode.TabIndex = 11;
            this.rb_decode.Text = "Decode";
            this.rb_decode.UseVisualStyleBackColor = true;
            this.rb_decode.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // cb_encrypt
            // 
            this.cb_encrypt.AutoSize = true;
            this.cb_encrypt.Location = new System.Drawing.Point(218, 117);
            this.cb_encrypt.Name = "cb_encrypt";
            this.cb_encrypt.Size = new System.Drawing.Size(62, 17);
            this.cb_encrypt.TabIndex = 12;
            this.cb_encrypt.Text = "Encrypt";
            this.cb_encrypt.UseVisualStyleBackColor = true;
            this.cb_encrypt.CheckedChanged += new System.EventHandler(this.cb_encrypt_CheckedChanged);
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(310, 71);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(199, 23);
            this.b_start.TabIndex = 13;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // b_stegOptions
            // 
            this.b_stegOptions.Location = new System.Drawing.Point(310, 94);
            this.b_stegOptions.Name = "b_stegOptions";
            this.b_stegOptions.Size = new System.Drawing.Size(199, 23);
            this.b_stegOptions.TabIndex = 14;
            this.b_stegOptions.Text = "Steganographic Options";
            this.b_stegOptions.UseVisualStyleBackColor = true;
            this.b_stegOptions.Click += new System.EventHandler(this.b_stegOptions_Click);
            // 
            // b_cryptoOptions
            // 
            this.b_cryptoOptions.Enabled = false;
            this.b_cryptoOptions.Location = new System.Drawing.Point(310, 117);
            this.b_cryptoOptions.Name = "b_cryptoOptions";
            this.b_cryptoOptions.Size = new System.Drawing.Size(199, 23);
            this.b_cryptoOptions.TabIndex = 16;
            this.b_cryptoOptions.Text = "Cryptographic Options";
            this.b_cryptoOptions.UseVisualStyleBackColor = true;
            this.b_cryptoOptions.Click += new System.EventHandler(this.b_cryptoOptions_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Status:";
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Location = new System.Drawing.Point(257, 210);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(24, 13);
            this.l_status.TabIndex = 21;
            this.l_status.Text = "Idle";
            // 
            // pb_status
            // 
            this.pb_status.Location = new System.Drawing.Point(310, 207);
            this.pb_status.Name = "pb_status";
            this.pb_status.Size = new System.Drawing.Size(200, 16);
            this.pb_status.TabIndex = 22;
            // 
            // bw_process
            // 
            this.bw_process.WorkerReportsProgress = true;
            this.bw_process.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_process_ProgressChanged);
            this.bw_process.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_process_RunWorkerCompleted);
            // 
            // tb_container
            // 
            this.tb_container.Location = new System.Drawing.Point(219, 181);
            this.tb_container.Name = "tb_container";
            this.tb_container.Size = new System.Drawing.Size(188, 20);
            this.tb_container.TabIndex = 23;
            this.tb_container.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // b_containerBrowse
            // 
            this.b_containerBrowse.Location = new System.Drawing.Point(412, 180);
            this.b_containerBrowse.Name = "b_containerBrowse";
            this.b_containerBrowse.Size = new System.Drawing.Size(98, 21);
            this.b_containerBrowse.TabIndex = 24;
            this.b_containerBrowse.Text = "Browse";
            this.b_containerBrowse.UseVisualStyleBackColor = true;
            this.b_containerBrowse.Click += new System.EventHandler(this.b_containerBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Container file:";
            // 
            // b_add_set
            // 
            this.b_add_set.Location = new System.Drawing.Point(412, 158);
            this.b_add_set.Name = "b_add_set";
            this.b_add_set.Size = new System.Drawing.Size(98, 20);
            this.b_add_set.TabIndex = 26;
            this.b_add_set.Text = "Set";
            this.b_add_set.UseVisualStyleBackColor = true;
            this.b_add_set.Click += new System.EventHandler(this.b_add_set_Click);
            // 
            // cb_multicontainer
            // 
            this.cb_multicontainer.AutoSize = true;
            this.cb_multicontainer.Enabled = false;
            this.cb_multicontainer.Location = new System.Drawing.Point(218, 138);
            this.cb_multicontainer.Name = "cb_multicontainer";
            this.cb_multicontainer.Size = new System.Drawing.Size(96, 17);
            this.cb_multicontainer.TabIndex = 27;
            this.cb_multicontainer.Text = "Multi-Container";
            this.cb_multicontainer.UseVisualStyleBackColor = true;
            this.cb_multicontainer.CheckedChanged += new System.EventHandler(this.cb_multicontainer_CheckedChanged);
            // 
            // sfd_data
            // 
            this.sfd_data.AddExtension = false;
            this.sfd_data.DefaultExt = "bin";
            this.sfd_data.Filter = "Text File (*.txt)|*.txt|Binary File (*.bin)|*.bin|All Files|*.*";
            // 
            // ofd_container
            // 
            this.ofd_container.Filter = resources.GetString("ofd_container.Filter");
            // 
            // l_selectedMethod
            // 
            this.l_selectedMethod.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.l_selectedMethod.AutoSize = true;
            this.l_selectedMethod.Location = new System.Drawing.Point(688, 9);
            this.l_selectedMethod.Name = "l_selectedMethod";
            this.l_selectedMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.l_selectedMethod.Size = new System.Drawing.Size(27, 13);
            this.l_selectedMethod.TabIndex = 28;
            this.l_selectedMethod.Text = "N/A";
            this.l_selectedMethod.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.l_selectedMethod.TextChanged += new System.EventHandler(this.l_selectedMethod_TextChanged);
            // 
            // sfd_encoded
            // 
            this.sfd_encoded.AddExtension = false;
            this.sfd_encoded.Filter = resources.GetString("sfd_encoded.Filter");
            // 
            // ofd_encoded
            // 
            this.ofd_encoded.AddExtension = false;
            this.ofd_encoded.FileName = "openFileDialog1";
            this.ofd_encoded.Filter = resources.GetString("ofd_encoded.Filter");
            // 
            // l_underConstruction
            // 
            this.l_underConstruction.AutoSize = true;
            this.l_underConstruction.BackColor = System.Drawing.Color.Red;
            this.l_underConstruction.ForeColor = System.Drawing.Color.Yellow;
            this.l_underConstruction.Location = new System.Drawing.Point(253, 9);
            this.l_underConstruction.Name = "l_underConstruction";
            this.l_underConstruction.Size = new System.Drawing.Size(227, 13);
            this.l_underConstruction.TabIndex = 29;
            this.l_underConstruction.Text = "== ALPHA 2 == UNDER CONSTRUCTION ==";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 235);
            this.Controls.Add(this.l_underConstruction);
            this.Controls.Add(this.l_selectedMethod);
            this.Controls.Add(this.cb_multicontainer);
            this.Controls.Add(this.b_add_set);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.b_containerBrowse);
            this.Controls.Add(this.tb_container);
            this.Controls.Add(this.pb_status);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.b_cryptoOptions);
            this.Controls.Add(this.b_stegOptions);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.cb_encrypt);
            this.Controls.Add(this.rb_decode);
            this.Controls.Add(this.rb_encode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_dataBrowse);
            this.Controls.Add(this.tb_datapath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_methods);
            this.Controls.Add(this.lv_containers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "psteg - Steganographic encoder/decoder - Alpha 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_containers;
        private System.Windows.Forms.ListView lv_methods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_datapath;
        private System.Windows.Forms.Button b_dataBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_encode;
        private System.Windows.Forms.RadioButton rb_decode;
        private System.Windows.Forms.CheckBox cb_encrypt;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Button b_stegOptions;
        private System.Windows.Forms.Button b_cryptoOptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.ProgressBar pb_status;
        private System.ComponentModel.BackgroundWorker bw_process;
        private System.Windows.Forms.TextBox tb_container;
        private System.Windows.Forms.Button b_containerBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_add_set;
        private System.Windows.Forms.CheckBox cb_multicontainer;
        private System.Windows.Forms.SaveFileDialog sfd_data;
        private System.Windows.Forms.OpenFileDialog ofd_data;
        private System.Windows.Forms.OpenFileDialog ofd_container;
        private System.Windows.Forms.Label l_selectedMethod;
        private System.Windows.Forms.SaveFileDialog sfd_encoded;
        private System.Windows.Forms.OpenFileDialog ofd_encoded;
        private System.Windows.Forms.Label l_underConstruction;
    }
}

