using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg.Stegano.Debug {
    public static class ConsoleLog {
        public const bool VERBOSE = true;
        public const bool LOGGING = true;
        public const int SPLIT_SIZE = 80;

        private static void DebugPrint(string data) {
            if (LOGGING) Console.WriteLine(data);
        }

        public static void Delimit(ConsoleColor color = ConsoleColor.White) {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = color;
            DebugPrint(new string('=', SPLIT_SIZE));
            Console.ForegroundColor = col;
        }
        public static void Error(string error) {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            DebugPrint($"[ERR ] {error}");
            Console.ForegroundColor = col;
        }

        public static void Warning(string warning) {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            DebugPrint($"[WARN] {warning}");
            Console.ForegroundColor = col;
        }

        public static void Info(string info) {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            DebugPrint($"[INFO] {info}");
            Console.ForegroundColor = col;
        }

        public static void Verbose(string info) {
            if (!VERBOSE) return;
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            DebugPrint($"[VERB] {info}");
            Console.ForegroundColor = col;
        }
    }
}
