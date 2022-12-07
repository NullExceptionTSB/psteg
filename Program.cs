using System;
using System.Windows.Forms;

namespace psteg {
    static class Program {
        [STAThread]
        static void Main() {
            EngineInitializer.Initialize();
            Algorithm.QuickMath.Trig.Init(4);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
