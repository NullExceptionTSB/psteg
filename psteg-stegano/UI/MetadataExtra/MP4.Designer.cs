namespace psteg.Stegano.UI.MetadataExtra {
    partial class MP4 {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gb_main = new System.Windows.Forms.GroupBox();
            this.tb_boxname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.tb_boxname);
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_main.Location = new System.Drawing.Point(0, 0);
            this.gb_main.Name = "gb_main";
            this.gb_main.Size = new System.Drawing.Size(343, 55);
            this.gb_main.TabIndex = 1;
            this.gb_main.TabStop = false;
            this.gb_main.Text = "MP4";
            // 
            // tb_boxname
            // 
            this.tb_boxname.Location = new System.Drawing.Point(69, 19);
            this.tb_boxname.MaxLength = 4;
            this.tb_boxname.Name = "tb_boxname";
            this.tb_boxname.Size = new System.Drawing.Size(268, 20);
            this.tb_boxname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Box name:";
            // 
            // MP4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_main);
            this.Name = "MP4";
            this.Size = new System.Drawing.Size(343, 55);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_main;
        private System.Windows.Forms.TextBox tb_boxname;
        private System.Windows.Forms.Label label1;
    }
}
