using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Stegano.Debug {
    public abstract class UnitTest {
        public bool CliOut { get; private set; } = true;
        public abstract string TestName { get; }
        public bool Verbose { get; set; } = false;

        public string[] Inputs { get; private set; }

        #region Test Result Output
        protected void DebugPrint(string data) {
            if (CliOut) Console.WriteLine(data);
        }

        protected void FailTest(string reason) {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Delimit(Console.ForegroundColor);
            DebugPrint($"UNIT TEST FAILED [{TestName}]\nREASON: {reason}");
            Delimit(Console.ForegroundColor);
            Console.ForegroundColor = col;
        }
            
        protected void PassTest() {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            DebugPrint(new string('=', 30));
            DebugPrint($"UNIT TEST PASSED [{TestName}]");
            DebugPrint(new string('=', 30) + "\n");
            Console.ForegroundColor = col;
        }
        #endregion
        #region Error Reporting
        protected void Delimit(ConsoleColor color = ConsoleColor.White) => 
            ConsoleLog.Delimit(color);
        protected void Error(string error) =>
            ConsoleLog.Error(error);
        protected void Warning(string warning) =>
            ConsoleLog.Warning(warning);
        protected void Info(string info) =>
            ConsoleLog.Info(info);
        protected void VerbosePrint(string info) { if (Verbose) ConsoleLog.Verbose(info); }
        #endregion
        public abstract bool Run();

        protected UnitTest(string source, bool cli_out = true) {
            CliOut = cli_out;

            try {
                Inputs = Directory.GetFiles(source);
            }
            catch (Exception ex) {
                FailTest($"Failed to open data ({ex.Message})");
            }


        }
    }
}
