using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Igtampe.UserTracer {
    /// <summary>Shows one User, and allows someone to edit it</summary>
    public partial class UserForm:Form {

        //-[Properties]---------------------------------------------------------------------------------------------------------

        /// <summary>The user this form represents</summary>
        public User MyUser { get; private set; } = new User();

        //-[Constructors]---------------------------------------------------------------------------------------------------------

        /// <summary>Default constructor to create a new userform for a new user</summary>
        public UserForm() : this(new User()) {}

        /// <summary>Constructor to create a new userform to edit the given User U</summary>
        /// <param name="U">User to Edit</param>
        public UserForm(User U) {
            InitializeComponent();
            MyUser = U;
            NameBox.Text = U.Name;
            PFPPictureBox.Image = U.PFP;
            JoinDateTimePicker.Value = U.JoinDate;
            ColorBox.BackColor = U.HeaderColor;
            CardColorPicker.Color = U.HeaderColor;
            DescriptionBox.Text = U.Description;
        }

        //-[Buttons]---------------------------------------------------------------------------------------------------------

        /// <summary>It's the OK button</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>It's the cancel button. Guess what happens.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>Creates a preview form to see this</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBox_Click(object sender,EventArgs e) {new PreviewForm(MyUser.UserCard).ShowDialog();}

        //-[Change Handlers]---------------------------------------------------------------------------------------------------------

        /// <summary>Picks and sets a color for the usercard</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorBox_Click(object sender,EventArgs e) {

            //Load custom colors
            LoadColors();

            if(CardColorPicker.ShowDialog() == DialogResult.OK) {

                ColorBox.BackColor = CardColorPicker.Color;
                MyUser.HeaderColor = CardColorPicker.Color;
                GeneratePreview();

                //save custom colors
                SaveColors();

            }
        }

        /// <summary>Picks and sets a profile picture for this user</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PFPPictureBox_Click(object sender,EventArgs e) {
            if(ProfilePicturePicker.ShowDialog() == DialogResult.OK) {
                Image NewPFP = new Bitmap(ProfilePicturePicker.FileName);
                PFPPictureBox.Image = NewPFP;
                MyUser.PFP = NewPFP;
                GeneratePreview();
            }
        }

        /// <summary>Sets the name of this user</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameBox_TextChanged(object sender,EventArgs e) { MyUser.Name = NameBox.Text; GeneratePreview(); }

        /// <summary>Sets the join date of this user</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JoinDateTimePicker_ValueChanged(object sender,EventArgs e) { MyUser.JoinDate = JoinDateTimePicker.Value; GeneratePreview(); }

        /// <summary>Sets the description of this user</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescriptionBox_TextChanged(object sender,EventArgs e) { MyUser.Description = DescriptionBox.Text; GeneratePreview(); }

        //-[Method]---------------------------------------------------------------------------------------------------------

        /// <summary>Generates the preview for the previewform</summary>
        private void GeneratePreview() {PreviewPictureBox.Image = MyUser.GenerateImage();}

        //-[Static Methods]---------------------------------------------------------------------------------------------------------

        private static readonly string ColorsLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"UserTracerColors.csv");
            
        public static void LoadColors() {
            if(!File.Exists(ColorsLocation)) { return; }

            List<int> Colors = new List<int>();
            string[] ColorsArray = File.ReadAllText(ColorsLocation).Split(',');

            foreach(string C in ColorsArray) {Colors.Add(int.Parse(C));}
            CardColorPicker.CustomColors = Colors.ToArray();
        
        }
        public static void SaveColors() {File.WriteAllText(ColorsLocation,string.Join(",",CardColorPicker.CustomColors));}

    }
}
