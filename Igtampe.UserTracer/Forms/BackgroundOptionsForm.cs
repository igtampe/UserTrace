using System;
using System.Drawing;
using System.Windows.Forms;

namespace Igtampe.UserTracer {

    /// <summary>Holds a Background Options Window. Used to set options for the UserTrace.</summary>
    public partial class BackgroundOptionsForm:Form {

        public Image TileBackground { get; set; }

        public BackgroundOptionsForm() {InitializeComponent();}
        public BackgroundOptionsForm(Image I):this() { TileBackground = I; pictureBox1.Image = I; }

        private void BackgroundTypeComboBox_SelectedIndexChanged(object sender,EventArgs e) {

            switch(BackgroundTypeComboBox.SelectedIndex) {
                case 0:

                    //Launch an OpenFileDialog to pick a tile
                    if(ImagePicker.ShowDialog() == DialogResult.OK) { TileBackground = Trace.SafeLoadImage(ImagePicker.FileName); } 
                    else { BackgroundTypeComboBox.SelectedIndex = -1; }

                    break;
                case 1:

                    //Launch the Color Picker from UserForm to pick a color
                    UserForm.LoadColors();

                    if(UserForm.CardColorPicker.ShowDialog() == DialogResult.OK) {
                        TileBackground = new Bitmap(256,256);
                        using(Graphics GRD = Graphics.FromImage(TileBackground))
                        using(Brush T = new SolidBrush(UserForm.CardColorPicker.Color)) { GRD.FillRectangle(T,0,0,256,256); }
                    } else { BackgroundTypeComboBox.SelectedIndex = -1; }

                    UserForm.SaveColors();

                    break;
                default:
                    break;
            }

            pictureBox1.Image = TileBackground;

        }

        private void OKBTN_Click(object sender,EventArgs e) {
            //ensure there's an image selected
            if(TileBackground == null) { MessageBox.Show("Must have something set for the background!"); return; }
            DialogResult= DialogResult.OK;
            Close();

        }

        private void CancelBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
