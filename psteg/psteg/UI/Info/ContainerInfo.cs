using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg;
using psteg.File;
namespace psteg.UI.Info {
    public partial class ContainerInfo : Form {
        StegFile _c;
        PstegEngine _e;
        public ContainerInfo(PstegEngine engine, StegFile container) {
            _c = container;
            _e = engine;
            InitializeComponent();

            l_path.Text = _c.Path;
            l_fileType.Text = _c.FileType.ToString();
            l_fileSize.Text = _c.Stream?.Length.ToString();
            l_currentCapacity.Text = !string.IsNullOrEmpty(l_fileSize.Text) ? _e.SteganoAlgorithm?.CalculateCapacity(_c.Stream.Length).ToString() : null;

            if (string.IsNullOrEmpty(l_fileSize.Text)) l_fileSize.Text = "N/A";
            else l_fileSize.Text += " bytes";
            if (string.IsNullOrEmpty(l_currentCapacity.Text)) l_currentCapacity.Text = "N/A";
            else l_currentCapacity.Text += " bytes";

            Width += l_path.Width - l_path.Location.X;
        }
    }
}
