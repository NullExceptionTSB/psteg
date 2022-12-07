using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Container;
using psteg.Container.Audio;
using psteg.File;
using psteg.File.Audio;

using psteg.Algorithm.QuickMath;

namespace psteg {
    public partial class Testmode : Form {
        public Testmode() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            using (FileStream fs = new FileStream("H:\\test\\test.wav", FileMode.Open)) {
                StegFile sf = new LosslessAudioFile(fs);
                byte[] b = sf.GetRawData(1024);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            const int n = int.MaxValue/64;
            MessageBox.Show($"Computing {n} tangens values");

            Random random = new Random();
            double[] vals = new double[n];
            double[] outs = new double[n];
            for (int i = 0; i < n; i++)
                vals[i] = random.NextDouble() * 8.0 * Math.PI- 4.0 * Math.PI;

            long mathtime, quicktime, batchtime;

            Stopwatch a = new Stopwatch();
            a.Start();
            for (int i = 0; i < n; i++)
                outs[i] = Math.Sin(vals[i]);
            a.Stop();
            mathtime = a.ElapsedMilliseconds;

            a.Reset();

            a.Start();
            for (int i = 0; i < n; i++)
                outs[i] = Trig.Sin(vals[i]);
            a.Stop();
            /*
            for (int i = 0; i < n; i++)
                if (Trig.Cos(vals[i]) != Math.Cos(vals[i]))
                    MessageBox.Show($"MATH DIFFERENCE! System.Math:{Math.Cos(vals[i])}, QuickMath.Trig: {Trig.Cos(vals[i])}");
            */

            quicktime = a.ElapsedMilliseconds;

            a.Reset();

            a.Start();
            Trig.BatchSin(vals, outs);
            a.Stop();

            batchtime = a.ElapsedMilliseconds;

            MessageBox.Show($"System.Math.Sin: {mathtime}ms, psteg.Algorithm.QuickMath.Trig.Sin: {quicktime}ms, psteg.Algorithm.QuickMath.Trig.BatchSin(double[],double[]): {batchtime}ms");
        }

        private double abs(double n) => n > 0 ? n : -1;

        private void button3_Click(object sender, EventArgs e) {
            const int n = int.MaxValue / 64;
            Stopwatch a = new Stopwatch();

            Random random = new Random();
            double[] vals = new double[n];
            for (int i = 0; i < n; i++)
                vals[i] = random.NextDouble() * 8.0 * Math.PI - 4.0 * Math.PI;
            double r;
            a.Start();
            for (int i = 0; i < n; i++)
                r = Math.Abs(vals[i]);
            a.Stop();
            MessageBox.Show($"System.Math.Abs: {a.ElapsedMilliseconds}ms");

            a.Reset();

            a.Start();
            for (int i = 0; i < n; i++)
                r = i > 0 ? i : -i;
            a.Stop();
            MessageBox.Show($"ternary: {a.ElapsedMilliseconds}ms");

            a.Reset();

            a.Start();
            for (int i = 0; i < n; i++)
                r = abs(i);
            a.Stop();
            MessageBox.Show($"called ternary: {a.ElapsedMilliseconds}ms");
        }
    }
}
