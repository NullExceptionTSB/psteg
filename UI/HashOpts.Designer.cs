namespace psteg.UI {
    partial class HashOpts {
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
            this.l_method = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_algos = new System.Windows.Forms.ListView();
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_method
            // 
            this.l_method.AutoSize = true;
            this.l_method.Location = new System.Drawing.Point(185, 9);
            this.l_method.Name = "l_method";
            this.l_method.Size = new System.Drawing.Size(27, 13);
            this.l_method.TabIndex = 5;
            this.l_method.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Algorithm";
            // 
            // lv_algos
            // 
            this.lv_algos.HideSelection = false;
            this.lv_algos.Location = new System.Drawing.Point(12, 25);
            this.lv_algos.MultiSelect = false;
            this.lv_algos.Name = "lv_algos";
            this.lv_algos.Size = new System.Drawing.Size(200, 200);
            this.lv_algos.TabIndex = 3;
            this.lv_algos.UseCompatibleStateImageBehavior = false;
            this.lv_algos.View = System.Windows.Forms.View.List;
            this.lv_algos.ItemActivate += new System.EventHandler(this.lv_algos_ItemActivate);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(113, 231);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(99, 23);
            this.b_cancel.TabIndex = 9;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(12, 231);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(99, 23);
            this.b_ok.TabIndex = 8;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // HashOpts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 263);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.l_method);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_algos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HashOpts";
            this.Text = "Hashing Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_method;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_algos;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_ok;
    }
}