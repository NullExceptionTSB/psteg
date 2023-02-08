using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psteg.Stegano {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0) { 
                Application.Run(new Form1());
                return;
            }

            switch (args[0]) {
                case "--lsbencode":
                    Application.Run(new UI.LSBEncode());
                    break;
                case "--lsbdecode":
                    Application.Run(new UI.LSBDecode());
                    break;
            }
        }
    }
}
