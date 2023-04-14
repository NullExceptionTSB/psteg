using System;
using System.Windows.Forms;
using psteg.Chaffblob.UI;

namespace psteg.Chaffblob {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0) return;

            switch (args[0]) {
                case "--encode":
                    Application.Run(new Encode());
                    break;
                case "--decode":
                    Application.Run(new Decode());
                    break;
                default: return;
            }
        }
    }
}
