namespace psteg_launcher {
    partial class f_Launcher {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            this.b_chaffing = new System.Windows.Forms.Button();
            this.b_winnowing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.b_lsbencode = new System.Windows.Forms.Button();
            this.b_lsbdecode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_chaffing
            // 
            this.b_chaffing.Location = new System.Drawing.Point(12, 41);
            this.b_chaffing.Name = "b_chaffing";
            this.b_chaffing.Size = new System.Drawing.Size(138, 23);
            this.b_chaffing.TabIndex = 1;
            this.b_chaffing.Text = "Chaffing";
            this.b_chaffing.UseVisualStyleBackColor = true;
            this.b_chaffing.Click += new System.EventHandler(this.b_chaffing_Click);
            // 
            // b_winnowing
            // 
            this.b_winnowing.Location = new System.Drawing.Point(156, 41);
            this.b_winnowing.Name = "b_winnowing";
            this.b_winnowing.Size = new System.Drawing.Size(138, 23);
            this.b_winnowing.TabIndex = 2;
            this.b_winnowing.Text = "Winnowing";
            this.b_winnowing.UseVisualStyleBackColor = true;
            this.b_winnowing.Click += new System.EventHandler(this.b_winnowing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(53, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "psteg Beta 1 - not intended for production";
            // 
            // b_lsbencode
            // 
            this.b_lsbencode.Location = new System.Drawing.Point(12, 12);
            this.b_lsbencode.Name = "b_lsbencode";
            this.b_lsbencode.Size = new System.Drawing.Size(138, 23);
            this.b_lsbencode.TabIndex = 4;
            this.b_lsbencode.Text = "LSB Encode";
            this.b_lsbencode.UseVisualStyleBackColor = true;
            this.b_lsbencode.Click += new System.EventHandler(this.b_lsbencode_Click);
            // 
            // b_lsbdecode
            // 
            this.b_lsbdecode.Location = new System.Drawing.Point(156, 12);
            this.b_lsbdecode.Name = "b_lsbdecode";
            this.b_lsbdecode.Size = new System.Drawing.Size(138, 23);
            this.b_lsbdecode.TabIndex = 5;
            this.b_lsbdecode.Text = "LSB Decode";
            this.b_lsbdecode.UseVisualStyleBackColor = true;
            this.b_lsbdecode.Click += new System.EventHandler(this.b_lsbdecode_Click);
            // 
            // f_Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 87);
            this.Controls.Add(this.b_lsbdecode);
            this.Controls.Add(this.b_lsbencode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_winnowing);
            this.Controls.Add(this.b_chaffing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "f_Launcher";
            this.Text = "psteg - Steganographic Suite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_chaffing;
        private System.Windows.Forms.Button b_winnowing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_lsbencode;
        private System.Windows.Forms.Button b_lsbdecode;
    }
}

