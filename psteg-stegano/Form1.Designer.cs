namespace psteg.Stegano {
    partial class Form1 {
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pb_sm_test = new System.Windows.Forms.ProgressBar();
            this.l_sm_test = new System.Windows.Forms.Label();
            this.b_smadd = new System.Windows.Forms.Button();
            this.b_smrm = new System.Windows.Forms.Button();
            this.b_indef = new System.Windows.Forms.Button();
            this.b_smadd5 = new System.Windows.Forms.Button();
            this.b_smrm5 = new System.Windows.Forms.Button();
            this.b_smdef = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "LSBEncode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "LSBDecode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(143, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(545, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "if you see this window, ignore it, as it is of no use to you";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "TestDCT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 116);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "TestBitC";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pb_sm_test
            // 
            this.pb_sm_test.Location = new System.Drawing.Point(384, 396);
            this.pb_sm_test.Maximum = 10;
            this.pb_sm_test.Name = "pb_sm_test";
            this.pb_sm_test.Size = new System.Drawing.Size(221, 23);
            this.pb_sm_test.TabIndex = 10;
            // 
            // l_sm_test
            // 
            this.l_sm_test.AutoSize = true;
            this.l_sm_test.Location = new System.Drawing.Point(381, 380);
            this.l_sm_test.Name = "l_sm_test";
            this.l_sm_test.Size = new System.Drawing.Size(35, 13);
            this.l_sm_test.TabIndex = 11;
            this.l_sm_test.Text = "label1";
            // 
            // b_smadd
            // 
            this.b_smadd.Location = new System.Drawing.Point(384, 322);
            this.b_smadd.Name = "b_smadd";
            this.b_smadd.Size = new System.Drawing.Size(75, 23);
            this.b_smadd.TabIndex = 12;
            this.b_smadd.Text = "sm_add";
            this.b_smadd.UseVisualStyleBackColor = true;
            this.b_smadd.Click += new System.EventHandler(this.b_smadd_Click);
            // 
            // b_smrm
            // 
            this.b_smrm.Location = new System.Drawing.Point(465, 322);
            this.b_smrm.Name = "b_smrm";
            this.b_smrm.Size = new System.Drawing.Size(75, 23);
            this.b_smrm.TabIndex = 13;
            this.b_smrm.Text = "sm_rm";
            this.b_smrm.UseVisualStyleBackColor = true;
            this.b_smrm.Click += new System.EventHandler(this.b_smrm_Click);
            // 
            // b_indef
            // 
            this.b_indef.Location = new System.Drawing.Point(546, 322);
            this.b_indef.Name = "b_indef";
            this.b_indef.Size = new System.Drawing.Size(75, 23);
            this.b_indef.TabIndex = 14;
            this.b_indef.Text = "indef";
            this.b_indef.UseVisualStyleBackColor = true;
            this.b_indef.Click += new System.EventHandler(this.b_indef_Click);
            // 
            // b_smadd5
            // 
            this.b_smadd5.Location = new System.Drawing.Point(384, 351);
            this.b_smadd5.Name = "b_smadd5";
            this.b_smadd5.Size = new System.Drawing.Size(75, 23);
            this.b_smadd5.TabIndex = 15;
            this.b_smadd5.Text = "sm_add5";
            this.b_smadd5.UseVisualStyleBackColor = true;
            this.b_smadd5.Click += new System.EventHandler(this.b_smadd5_Click);
            // 
            // b_smrm5
            // 
            this.b_smrm5.Location = new System.Drawing.Point(465, 351);
            this.b_smrm5.Name = "b_smrm5";
            this.b_smrm5.Size = new System.Drawing.Size(75, 23);
            this.b_smrm5.TabIndex = 16;
            this.b_smrm5.Text = "sm_rm5";
            this.b_smrm5.UseVisualStyleBackColor = true;
            this.b_smrm5.Click += new System.EventHandler(this.b_smrm5_Click);
            // 
            // b_smdef
            // 
            this.b_smdef.Location = new System.Drawing.Point(546, 351);
            this.b_smdef.Name = "b_smdef";
            this.b_smdef.Size = new System.Drawing.Size(75, 23);
            this.b_smdef.TabIndex = 17;
            this.b_smdef.Text = "def";
            this.b_smdef.UseVisualStyleBackColor = true;
            this.b_smdef.Click += new System.EventHandler(this.b_smdef_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b_smdef);
            this.Controls.Add(this.b_smrm5);
            this.Controls.Add(this.b_smadd5);
            this.Controls.Add(this.b_indef);
            this.Controls.Add(this.b_smrm);
            this.Controls.Add(this.b_smadd);
            this.Controls.Add(this.l_sm_test);
            this.Controls.Add(this.pb_sm_test);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Debug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar pb_sm_test;
        private System.Windows.Forms.Label l_sm_test;
        private System.Windows.Forms.Button b_smadd;
        private System.Windows.Forms.Button b_smrm;
        private System.Windows.Forms.Button b_indef;
        private System.Windows.Forms.Button b_smadd5;
        private System.Windows.Forms.Button b_smrm5;
        private System.Windows.Forms.Button b_smdef;
    }
}

