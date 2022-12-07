using System;
using System.Windows.Forms;

namespace psteg {
    static class DebugMode {
        [STAThread]
        static void Main() {
            EngineInitializer.Initialize();
            Algorithm.QuickMath.Trig.Init(4);
            Application.Run(new Testmode());
        }
    }
}
