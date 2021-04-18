using System.Drawing;
using System.Windows.Forms;

namespace Igtampe.UserTracer {

    /// <summary>Previews an image</summary>
    public partial class PreviewForm:Form {
        
        /// <summary>Creates a preview form to show an image (but without an image)</summary>
        public PreviewForm() {InitializeComponent();}

        /// <summary>Creates a preview form to show an image (with an image)</summary>
        /// <param name="I"></param>
        public PreviewForm(Image I) : this() {SetImage(I);}

        /// <summary>Sets the image in this previewform</summary>
        /// <param name="I"></param>
        public void SetImage(Image I) {
            ImageBox.Image = I;
            Size = new Size(I.Width,I.Height);
        }

        /// <summary>Saves the preview to the clipboard because why not</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewForm_Load(object sender,System.EventArgs e) {Clipboard.SetImage(ImageBox.Image);}
    }
}
