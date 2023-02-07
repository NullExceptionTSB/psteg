﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace psteg_launcher {
    public partial class f_Launcher : Form {
        public f_Launcher() => InitializeComponent();
        public void Run(string process, string args) {
            Process p;
            try { 
                p = Process.Start(process, args);
            } catch (Exception e) {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hide();
            p.WaitForExit();
            Show();
            p?.Dispose();
        }

        private void b_chaffing_Click(object sender, EventArgs e) => Run(".\\chaffblob.exe", "--encode");
        private void b_winnowing_Click(object sender, EventArgs e) => Run(".\\chaffblob.exe", "--decode");

        private void b_lsbencode_Click(object sender, EventArgs e) => Run(".\\stegano.exe", "--lsbencode");
        private void b_lsbdecode_Click(object sender, EventArgs e) => Run(".\\stegano.exe", "--lsbdecode");
    }
}