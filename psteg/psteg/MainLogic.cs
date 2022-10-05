using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using psteg.File;
using psteg.Algorithm;
namespace psteg {
    public partial class MainForm : Form {
        Dictionary<string, StegFile> containerDict;
        FileType outputContainerType;

        void FileChanged() {
            //BLOCKED
            return;
            /*
            try {
                if (rb_encode.Checked)
                    engine.RawFile = OpenFileRead(tb_datapath.Text);
                else
                    throw new NotImplementedException();

                
                    FileInfo fi = new FileInfo(tb_datapath.Text);
                if (!fi.Exists && rb_encode.Checked) {
                    MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearDataPath();
                    return;
                }
                if (rb_encode.Checked) {
                    engine.RawData = StegFile.Open(tb_datapath.Text);
                }
                else {
                    throw new NotImplementedException();
                }
                

            } 
            catch (Exception ex) {
                MessageBox.Show($"File error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearDataPath();
                return;
            }
           */
        }

        StegFile OpenFileRead(string path) {
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists) 
                return null;
            return StegFile.Open(path);
        }

        StegFile OpenFileWrite(string path) {
            return StegFile.Create(path, outputContainerType);
        }

        void SetContainer() {
            try {
                if (engine.Containers.Count > 0)
                    foreach (StegFile sf in engine.Containers)
                        sf.Dispose();

                StegFile cont = StegFile.Open(tb_container.Text);

                if (cont == null)
                    return;

                engine.Containers.Clear();
                engine.Containers.Add(cont);

                lv_containers.Clear();
                lv_containers.Items.Add(tb_container.Text);

                containerDict.Clear();
                containerDict.Add(tb_container.Text, cont);

                SetAvailableMethods(SteganoAlgorithm.AvailableMethods(new FileType[] { cont.FileType }));
                outputContainerType = cont.FileType;
            } 
            catch (Exception ex) {
                MessageBox.Show($"File error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lv_containers.Clear();
            }
            
        }

        void SetAvailableMethods(StegMethod[] methods) {
            StegMethod[] methds = methods.Distinct().ToArray();
            lv_methods.Clear();
            foreach (StegMethod method in methds) {
                ListViewItem lvi = lv_methods.Items.Add(SteganoAlgorithm.GetDisplayName(method));
                lvi.Name = method.ToString();
            }
        }

        void SetMethod() {
            StegMethod method;
            bool parsed = Enum.TryParse(l_selectedMethod.Text, out method);
            if (!parsed) {
                MessageBox.Show("Method error", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            engine.SetAlgorithms(method);
        }

        void ShowContainerInfo(string file) {
            StegFile cont = null;
            try {
                cont = containerDict[file];
            }
            catch {
                MessageBox.Show("Container error?", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cont == null)
                return;

            new ContainerInfo(cont).Show();
        }

        void ClearDataPath() {
            tb_datapath.Text = string.Empty;
        }
    }
}
