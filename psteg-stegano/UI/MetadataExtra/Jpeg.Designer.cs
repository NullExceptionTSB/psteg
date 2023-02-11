namespace psteg.Stegano.UI.MetadataExtra {
    partial class Jpeg {
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
            this.cb_marker = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Controls.Add(this.cb_marker);
            this.gb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_main.Location = new System.Drawing.Point(0, 0);
            this.gb_main.Name = "gb_main";
            this.gb_main.Size = new System.Drawing.Size(343, 55);
            this.gb_main.TabIndex = 0;
            this.gb_main.TabStop = false;
            this.gb_main.Text = "Jpeg";
            // 
            // cb_marker
            // 
            this.cb_marker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_marker.FormattingEnabled = true;
            this.cb_marker.Location = new System.Drawing.Point(55, 19);
            this.cb_marker.Name = "cb_marker";
            this.cb_marker.Size = new System.Drawing.Size(282, 21);
            this.cb_marker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Marker:";
            // 
            // Jpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_main);
            this.Name = "Jpeg";
            this.Size = new System.Drawing.Size(343, 55);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_marker;
    }
}
