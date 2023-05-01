namespace psteg.Chaffblob.UI {
    partial class Decode {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Decode));
            this.tb_idKey = new System.Windows.Forms.TextBox();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.tb_encKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.b_browseOutput = new System.Windows.Forms.Button();
            this.b_browseInput = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_input = new System.Windows.Forms.TextBox();
            this.l_state = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.b_start = new System.Windows.Forms.Button();
            this.cb_showIdKey = new System.Windows.Forms.CheckBox();
            this.cb_showCryptoKey = new System.Windows.Forms.CheckBox();
            this.bw_process = new System.ComponentModel.BackgroundWorker();
            this.ofd_input = new System.Windows.Forms.OpenFileDialog();
            this.sfd_output = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // tb_idKey
            // 
            this.tb_idKey.Location = new System.Drawing.Point(298, 39);
            this.tb_idKey.Name = "tb_idKey";
            this.tb_idKey.Size = new System.Drawing.Size(139, 20);
            this.tb_idKey.TabIndex = 3;
            this.tb_idKey.UseSystemPasswordChar = true;
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(69, 64);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(139, 20);
            this.tb_output.TabIndex = 2;
            this.tb_output.TextChanged += new System.EventHandler(this.tb_output_TextChanged);
            // 
            // tb_encKey
            // 
            this.tb_encKey.Location = new System.Drawing.Point(298, 65);
            this.tb_encKey.Name = "tb_encKey";
            this.tb_encKey.Size = new System.Drawing.Size(139, 20);
            this.tb_encKey.TabIndex = 4;
            this.tb_encKey.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encryption Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output File:";
            // 
            // b_browseOutput
            // 
            this.b_browseOutput.Location = new System.Drawing.Point(69, 90);
            this.b_browseOutput.Name = "b_browseOutput";
            this.b_browseOutput.Size = new System.Drawing.Size(139, 20);
            this.b_browseOutput.TabIndex = 6;
            this.b_browseOutput.Text = "Browse...";
            this.b_browseOutput.UseVisualStyleBackColor = true;
            this.b_browseOutput.Click += new System.EventHandler(this.b_browseOutput_Click);
            // 
            // b_browseInput
            // 
            this.b_browseInput.Location = new System.Drawing.Point(69, 38);
            this.b_browseInput.Name = "b_browseInput";
            this.b_browseInput.Size = new System.Drawing.Size(139, 20);
            this.b_browseInput.TabIndex = 9;
            this.b_browseInput.Text = "Browse...";
            this.b_browseInput.UseVisualStyleBackColor = true;
            this.b_browseInput.Click += new System.EventHandler(this.b_browseInput_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Input File:";
            // 
            // tb_input
            // 
            this.tb_input.AllowDrop = true;
            this.tb_input.Location = new System.Drawing.Point(69, 12);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(139, 20);
            this.tb_input.TabIndex = 1;
            this.tb_input.TextChanged += new System.EventHandler(this.tb_input_TextChanged);
            this.tb_input.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_input_DragDrop);
            this.tb_input.DragEnter += new System.Windows.Forms.DragEventHandler(this.dDragEnter);
            // 
            // l_state
            // 
            this.l_state.AutoSize = true;
            this.l_state.Location = new System.Drawing.Point(107, 148);
            this.l_state.Name = "l_state";
            this.l_state.Size = new System.Drawing.Size(24, 13);
            this.l_state.TabIndex = 27;
            this.l_state.Text = "Idle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(66, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "State:";
            // 
            // pb_progress
            // 
            this.pb_progress.Location = new System.Drawing.Point(69, 164);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(380, 23);
            this.pb_progress.TabIndex = 25;
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(69, 116);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(380, 20);
            this.b_start.TabIndex = 5;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // cb_showIdKey
            // 
            this.cb_showIdKey.AutoSize = true;
            this.cb_showIdKey.Location = new System.Drawing.Point(443, 41);
            this.cb_showIdKey.Name = "cb_showIdKey";
            this.cb_showIdKey.Size = new System.Drawing.Size(15, 14);
            this.cb_showIdKey.TabIndex = 29;
            this.cb_showIdKey.TabStop = false;
            this.cb_showIdKey.UseVisualStyleBackColor = true;
            this.cb_showIdKey.CheckedChanged += new System.EventHandler(this.cb_showIdKey_CheckedChanged);
            // 
            // cb_showCryptoKey
            // 
            this.cb_showCryptoKey.AutoSize = true;
            this.cb_showCryptoKey.Location = new System.Drawing.Point(443, 68);
            this.cb_showCryptoKey.Name = "cb_showCryptoKey";
            this.cb_showCryptoKey.Size = new System.Drawing.Size(15, 14);
            this.cb_showCryptoKey.TabIndex = 30;
            this.cb_showCryptoKey.TabStop = false;
            this.cb_showCryptoKey.UseVisualStyleBackColor = true;
            this.cb_showCryptoKey.CheckedChanged += new System.EventHandler(this.cb_showCryptoKey_CheckedChanged);
            // 
            // bw_process
            // 
            this.bw_process.WorkerReportsProgress = true;
            this.bw_process.WorkerSupportsCancellation = true;
            this.bw_process.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_process_DoWork);
            this.bw_process.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_process_ProgressChanged);
            this.bw_process.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_process_RunWorkerCompleted);
            // 
            // ofd_input
            // 
            this.ofd_input.Filter = "Chaffblock File|*.chablk|Encapsulated TAR File|*.tar";
            // 
            // sfd_output
            // 
            this.sfd_output.Filter = "All Files|*.*";
            // 
            // Decode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 204);
            this.Controls.Add(this.cb_showCryptoKey);
            this.Controls.Add(this.cb_showIdKey);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.l_state);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pb_progress);
            this.Controls.Add(this.b_browseInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_input);
            this.Controls.Add(this.b_browseOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_encKey);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.tb_idKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Decode";
            this.Text = "psteg ChaffBlob - Chaffing and Winnowing Tool - Decode Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_idKey;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.TextBox tb_encKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_browseOutput;
        private System.Windows.Forms.Button b_browseInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.Label l_state;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.CheckBox cb_showIdKey;
        private System.Windows.Forms.CheckBox cb_showCryptoKey;
        private System.ComponentModel.BackgroundWorker bw_process;
        private System.Windows.Forms.OpenFileDialog ofd_input;
        private System.Windows.Forms.SaveFileDialog sfd_output;
    }
}