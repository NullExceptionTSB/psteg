using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psteg_fstools {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Application.Run(new ADS());
            else
                MessageBox.Show("psteg-fstools relies on Windows API calls and is only available on Microsoft Windows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
