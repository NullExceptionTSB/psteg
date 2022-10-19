namespace psteg.UI.Info {
    partial class ContainerInfo {
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
            this.l_path = new System.Windows.Forms.Label();
            this.l_fileType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.l_fileSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_currentCapacity = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_path
            // 
            this.l_path.AutoSize = true;
            this.l_path.Location = new System.Drawing.Point(100, 16);
            this.l_path.Name = "l_path";
            this.l_path.Size = new System.Drawing.Size(36, 13);
            this.l_path.TabIndex = 0;
            this.l_path.Text = "l_path";
            // 
            // l_fileType
            // 
            this.l_fileType.AutoSize = true;
            this.l_fileType.Location = new System.Drawing.Point(100, 29);
            this.l_fileType.Name = "l_fileType";
            this.l_fileType.Size = new System.Drawing.Size(52, 13);
            this.l_fileType.TabIndex = 1;
            this.l_fileType.Text = "l_fileType";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.l_currentCapacity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.l_fileSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.l_path);
            this.groupBox1.Controls.Add(this.l_fileType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "File Size:";
            // 
            // l_fileSize
            // 
            this.l_fileSize.AutoSize = true;
            this.l_fileSize.Location = new System.Drawing.Point(101, 42);
            this.l_fileSize.Name = "l_fileSize";
            this.l_fileSize.Size = new System.Drawing.Size(48, 13);
            this.l_fileSize.TabIndex = 5;
            this.l_fileSize.Text = "l_fileSize";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Current Capacity:";
            // 
            // l_currentCapacity
            // 
            this.l_currentCapacity.AutoSize = true;
            this.l_currentCapacity.Location = new System.Drawing.Point(100, 55);
            this.l_currentCapacity.Name = "l_currentCapacity";
            this.l_currentCapacity.Size = new System.Drawing.Size(89, 13);
            this.l_currentCapacity.TabIndex = 7;
            this.l_currentCapacity.Text = "l_currentCapacity";
            // 
            // ContainerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 113);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContainerInfo";
            this.Text = "Container Information";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l_path;
        private System.Windows.Forms.Label l_fileType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_currentCapacity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_fileSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}