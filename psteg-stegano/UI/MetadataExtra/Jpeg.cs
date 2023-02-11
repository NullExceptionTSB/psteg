using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using psteg.Stegano.Engine.Encode;

namespace psteg.Stegano.UI.MetadataExtra {
    public partial class Jpeg : UserControl {
        public File.Format.Jpeg.Marker Marker { get => (File.Format.Jpeg.Marker)Enum.Parse(typeof(File.Format.Jpeg.Marker), cb_marker.Items[cb_marker.SelectedIndex].ToString()); }

        public Jpeg() {
            InitializeComponent();

            foreach (Enum e in MetadataEncoderEngine.SupportedJpegMarkers)
                cb_marker.Items.Add(e.ToString());
            cb_marker.SelectedIndex = 0;
        }
    }
}
