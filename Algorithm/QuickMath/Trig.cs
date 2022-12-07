using System;

namespace psteg.Algorithm.QuickMath {
    public static class Trig {
        private const double pihalf = Math.PI / 2;
        private static double pmul;
        private static int precision;
        private static int costl;
        private static double[] cos_table;

        public static double PrecisionMultiplier { get => pmul; }

        public static void Init(int decimalPrecision = 2) {
            precision = decimalPrecision;

            pmul = Math.Pow(10.0, precision);
            cos_table = new double[(int)(Math.PI * 2 * pmul)];
            costl = cos_table.Length;
            for (int i = 0; i < cos_table.Length; i++) { 
                cos_table[i] = Math.Cos(i / pmul);
            }
        }

        public static double Sin(double n) => cos_table[((int)((Math.Abs(n-pihalf)) * pmul)) % costl];
        public static double Cos(double n) => cos_table[((int)((Math.Abs(n)) * pmul))%costl];
        public static double Tan(double n) => cos_table[((int)((Math.Abs(n - pihalf)) * pmul)) % costl] / cos_table[((int)((Math.Abs(n)) * pmul)) % costl];
        public static double Ctg(double n) => cos_table[((int)((Math.Abs(n)) * pmul)) % costl] / cos_table[((int)((Math.Abs(n)) * pmul)) % costl];
        public static double Sec(double n) => 1 / cos_table[((int)((Math.Abs(n - pihalf)) * pmul)) % costl];
        public static double Csc(double n) => 1 / cos_table[((int)((Math.Abs(n)) * pmul)) % costl];

        public static void BatchSin(double[] input, double[] output) {
            for (int i = 0; i < input.Length; i++)
                output[i] = cos_table[((int)((Math.Abs(input[i]-pihalf)) * pmul)) % costl];
        }

        public static void BatchCos(double[] input, double[] output) {
            for (int i = 0; i < input.Length; i++)
                output[i] = cos_table[((int)((Math.Abs(input[i])) * pmul)) % costl];
        }

        public static void BatchTan(double[] input, double[] output) {
            for (int i = 0; i < input.Length; i++)
                output[i] = cos_table[((int)((Math.Abs(input[i] - pihalf)) * pmul)) % costl] / cos_table[((int)((Math.Abs(input[i])) * pmul)) % costl];
        }

        public static void BatchCtg(double[] input, double[] output) {
            for (int i = 0; i < input.Length; i++)
                output[i] = cos_table[((int)((Math.Abs(input[i])) * pmul)) % costl] /  cos_table[((int)((Math.Abs(input[i] - pihalf)) * pmul)) % costl];
        }

        public static void BatchSec(double[] input, double[] output) {
            for (int i = 0; i < input.Length; i++)
                output[i] = 1/cos_table[((int)((Math.Abs(input[i] - pihalf)) * pmul)) % costl];
        }

        public static void BatchCsc(double[] input, double[] output) {
            for (int i = 0; i < input.Length; i++)
                output[i] = 1/cos_table[((int)((Math.Abs(input[i])) * pmul)) % costl];
        }
    }
}
