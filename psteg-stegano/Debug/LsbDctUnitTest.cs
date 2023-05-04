using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using psteg.Stegano.Engine.Encode;
using psteg.Stegano.Engine.Decode;
using psteg.Stegano.Engine.Util;

namespace psteg.Stegano.Debug {
    public sealed class LsbDctUnitTest : UnitTest {
        private const int DEPTH = 8;
        private enum FailReason {
            None,
            TooMuchData,
            EncoderError,
            DataOutputMismatch,
            CodeMismatch
        }

        public override string TestName => "LSB-DCT Data Validity";

        private FailReason FailureReason = FailReason.None;
        private int FailExtra = 0;

        private bool TestFile(string cover, byte[] data) {
            JpegDecoderEngine<JstegCoderOptions> decoder = new JpegDecoderEngine<JstegCoderOptions>(new JstegCoderOptions { MaxSubstituteDepth = DEPTH });
            JpegEncoderEngine<JstegCoderOptions> encoder = new JpegEncoderEngine<JstegCoderOptions>(new JstegCoderOptions { MaxSubstituteDepth = DEPTH });
            string intermediary = Path.GetTempFileName();

            byte[] passed_data = new byte[data.Length];

            encoder.Encryption = decoder.Encryption = new Crypto.NullEncrypt();
            try { 
                using (FileStream int_str = new FileStream(intermediary, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) { 
                    using (FileStream cov_str = new FileStream(cover, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                        using (MemoryStream dat_str = new MemoryStream(data)) { 
                            encoder.CoverStream = cov_str;
                            encoder.DataStream = dat_str;
                            encoder.OutputStream = int_str;
                            encoder.Go();
                        }
                    }
                    using (MemoryStream comp_ds = new MemoryStream(passed_data)) {
                        decoder.CoverStream = int_str;
                        decoder.OutputStream = comp_ds;
                        decoder.DataSize = data.Length;
                        decoder.Go();
                    }
                }
            } catch {
                FailureReason = FailReason.EncoderError;
                return false;
            } finally {
                System.IO.File.Delete(intermediary);
            }

            for (int i = 0; i < data.Length; i++)
                if (data[i] != passed_data[i]) {
                    FailureReason = FailReason.DataOutputMismatch;
                    FailExtra = i;
                    return false;
                }
            
            return true;
        }

        public override bool Run() {
            if (Inputs == null) return false;

            Random rng = new Random();
            int fileid = 1;
            foreach (string cover in Inputs) {
                byte[] data = new byte[rng.Next() % 1000];
                rng.NextBytes(data);
                Delimit();
                Info($"Running test on file {fileid++}, encoding {data.Length} bytes");
                try { 
                    bool success = TestFile(cover, data);
                    if (!success) {
                        switch (FailureReason) {
                            case FailReason.None:
                                Error("Coding failed for unknown reason.");
                                break;
                            case FailReason.TooMuchData:
                                Warning("Too much data encoded or encoder error.");
                                break;
                            case FailReason.EncoderError:
                                FailTest("Encoding error.");
                                return false;
                            case FailReason.DataOutputMismatch:
                                FailTest($"Data input and output don't match (index {FailExtra}).");
                                return false;
                            case FailReason.CodeMismatch:
                                FailTest("Input and output code mismatch.");
                                return false;
                        }
                    }
                    else Info("File encoded OK");
                } catch (Exception ex) {
                    FailTest("Test threw: " + ex.InnerException + " " + ex.StackTrace);
                    return false;
                }
                Delimit();
            }
            return true;
        }

        public LsbDctUnitTest(string source, bool cli_out = true) : base(source, cli_out) { }
    }
}
