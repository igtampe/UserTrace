using System;
using System.Drawing;
using System.Windows.Forms;

namespace Igtampe.UserTracer {

    /// <summary>This is where everything happens</summary>
    public partial class MainForm:Form {

        //-[Properties]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Trace this form is editing</summary>
        public Trace MyTrace = new Trace();

        /// <summary>private holder for the save location</summary>
        private string savelocale = "";

        /// <summary>Location on disk the usertrace being edited will be saved to</summary>
        public string SaveLocaiton { 
            get { return savelocale; } 
            set { 
                savelocale = value;

                if(string.IsNullOrWhiteSpace(savelocale)) { Text = "UserTrace - " + "New Project"; } 
                else { Text = "UserTrace - " + value; }
            } 
        }

        /// <summary>Used to determine if the trace has been modified since it was loaded or last saved</summary>
        private bool Modified = false;

        /// <summary>Splash form to be shown</summary>
        private readonly SplashForm Splash = new SplashForm();

        //-[Constructor]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Default constructor for a MainForm creating a new Trace</summary>
        public MainForm() : this(new Trace()) { }
        
        /// <summary>Constructor for a mainform editing a pre-existing trace.</summary>
        /// <param name="T"></param>
        public MainForm(Trace T) {
            InitializeComponent();
            MyTrace = T;
            Splash.Show();
        }

        /// <summary>Loads the trace when the form loads</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Loading(object sender,EventArgs e) {LoadTrace(MyTrace);}

        /// <summary>Does nothing when the form is shown. Reserved for later.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender,EventArgs e) {}

        //-[Buttons]------------------------------------------------------------------------------------------------------------------------------------------

        //You know maybe all of this logic should've been put *in* the UserTrace object.... oh well. It works, so it works

        /// <summary>Handles the adding of a new user to the UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender,EventArgs e) {
            User NewUser = new User();
            
            if(MyTrace.AllUsers.Count == 0) {
                MessageBox.Show("Since this is the first user, this will be the root user.\n\nThis can be changed later, but you may lose users before the root user if you save","Root User Notice",MessageBoxButtons.OK,MessageBoxIcon.Information);
            } else {
                if("TRC".Equals(sender)|| AddUnder()) {
                    if(GetSelectedIndex() == -1) { return; }
                    NewUser.Parent = MyTrace.AllUsers[GetSelectedIndex()];

                } else {
                    UserLinkerForm Linker = new UserLinkerForm(NewUser,MyTrace.AllUsers);
                    if(Linker.ShowDialog() != DialogResult.OK) { return; }
                    NewUser.Parent = MyTrace.AllUsers[Linker.ListIndex];
                }
            }


            UserForm TheForm = new UserForm(NewUser);
            if(TheForm.ShowDialog() != DialogResult.OK) { return; }

            while(MyTrace.AllUsers.Contains(NewUser)) {
                MessageBox.Show("A user with the name " + NewUser.Name + " already exists! Please use a different name.","Two people?",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if(TheForm.ShowDialog() != DialogResult.OK) { return; }
            }


            NewUser = TheForm.MyUser;
            if(MyTrace.AllUsers.Count == 0) { MyTrace.RootUser = NewUser; }
            MyTrace.AllUsers.Add(NewUser);
            NewUser.Parent?.AddChild(NewUser);

            GeneratePreview();
            PopulateListview();


        }

        /// <summary>Handles the editing of an already existing User in the UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender,EventArgs e) {
            
            if(GetSelectedIndex() == -1) { return; }

            UserForm TheForm = new UserForm(MyTrace.AllUsers[GetSelectedIndex()]);
            if(TheForm.ShowDialog() != DialogResult.OK) { return; }

            MyTrace.AllUsers[GetSelectedIndex()] = TheForm.MyUser;
            GeneratePreview();
            PopulateListview();
            Modified = true;
        }

        /// <summary>Handles the process of re-linking an already existing User in this UserTrace to a new parent</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkButton_Click(object sender,EventArgs e) {
            if(GetSelectedIndex() == -1) { return; }

            if(MyTrace.AllUsers[GetSelectedIndex()].Equals(MyTrace.RootUser)) {
                MessageBox.Show("You cannot re-link the Root User.","no",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            UserLinkerForm Linker = new UserLinkerForm(MyTrace.AllUsers[GetSelectedIndex()],MyTrace.AllUsers);
            if(Linker.ShowDialog() != DialogResult.OK) { return; }


            //find the parent and link it.
            //Delink the user from the old parent
            MyTrace.AllUsers[GetSelectedIndex()].Parent?.RemoveChild(MyTrace.AllUsers[GetSelectedIndex()]);
            MyTrace.AllUsers[GetSelectedIndex()].Parent = null;

            //Link the new parent.
            MyTrace.AllUsers[GetSelectedIndex()].Parent = MyTrace.AllUsers[Linker.ListIndex];
            MyTrace.AllUsers[Linker.ListIndex].AddChild(MyTrace.AllUsers[GetSelectedIndex()]);
            GeneratePreview();
            PopulateListview();
            Modified = true;

        }

        /// <summary>Handles the process of removing a user from the UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender,EventArgs e) {
            if(GetSelectedIndex() == -1) { return; }

            if(MyTrace.AllUsers[GetSelectedIndex()].Equals(MyTrace.RootUser)) {
                MessageBox.Show("You cannot delete the Root User.","no",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            User D = MyTrace.AllUsers[GetSelectedIndex()];
            DialogResult T = MessageBox.Show("Are you sure you want to delete user " + D.Name + "?\n\n All of its children will be moved to " + D.Name +"'s Parent (" +D.Parent.Name +")","Sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(T != DialogResult.Yes) { return; }

            int ParentIndex = MyTrace.AllUsers.IndexOf(D.Parent);

            foreach(User orphan in D.Children) {
                int OrphanIndex = MyTrace.AllUsers.IndexOf(orphan);
                MyTrace.AllUsers[ParentIndex].AddChild(MyTrace.AllUsers[OrphanIndex]);
                MyTrace.AllUsers[OrphanIndex].Parent = MyTrace.AllUsers[ParentIndex];
            }

            MyTrace.AllUsers[ParentIndex].RemoveChild(D);
            MyTrace.AllUsers.Remove(D);

            GeneratePreview();
            PopulateListview();
            Modified = true;
        }

        /// <summary>Handles loading and changing the Server Icon</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PFPPictureBox_Click(object sender,EventArgs e) {
            if(ImagePicker.ShowDialog() == DialogResult.OK) {
                Image NewPFP = Trace.SafeLoadImage(ImagePicker.FileName);
                PFPPictureBox.Image = NewPFP;
                MyTrace.ServerLogo = NewPFP;
                GeneratePreview();
                Modified = true;
            }
        }

        /// <summary>Handles loading and changing the tiled background of the UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileBG_Click(object sender,EventArgs e) {
            BackgroundOptionsForm BGForm = new BackgroundOptionsForm(MyTrace.TileBackground);
            if(BGForm.ShowDialog() == DialogResult.OK) {
                Image NewPFP = BGForm.TileBackground;
                MyTrace.TileBackground = NewPFP;
                GeneratePreview();
                Modified = true;
            }
        }

        /// <summary>Handles creating a previewform for the UserTrace image and its big big subroutine</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewPictureBox_Click(object sender,MouseEventArgs e) {
            if(e.Button != MouseButtons.Right && e.Button!=MouseButtons.Left) { return; }

            fromPreviewPane = true;

            //If the usertrace is empty, just show it anyways.
            if(MyTrace.AllUsers.Count == 0 && e.Button==MouseButtons.Right) { UsersContextMenu.Show(PreviewPictureBox,e.Location); fromPreviewPane = false; return; }

            //Let's find the top right corner of the image. 
            Size ImageSize = PreviewPictureBox.Image.Size;
            Size BoxSize = PreviewPictureBox.Size;
            Size RealImageSize = PreviewPictureBox.Size;

            int PictureX = 0;
            int PictureY = 0;
            double scale = 1;

            //Get the aspect ratio of the picturebox and image.
            double BoxWidthToHeight = (BoxSize.Width +0.0) / (BoxSize.Height + 0.0);
            double ImageWidthToHeight = (ImageSize.Width + 0.0) / (ImageSize.Height + 0.0);

            if(ImageSize.Equals(BoxSize)) {
                //do nothing the thing is set.
            } else if(ImageWidthToHeight > BoxWidthToHeight) {
                //Find the correct Y
                //It's wider than it's tall
                
                //determine the scale
                scale = (ImageSize.Width+0.0) / (BoxSize.Width+0.0);

                //Determine the size of the image on screen
                RealImageSize = new Size(Convert.ToInt32(ImageSize.Width / scale),Convert.ToInt32(ImageSize.Height / scale));

                //Now determine the correct Y
                PictureY = (BoxSize.Height - RealImageSize.Height) / 2;
            } else {
                //It's taller than it's wide
                //find the correct X

                //Determine the scale
                scale = (ImageSize.Height + 0.0) / (BoxSize.Height + 0.0);

                //Determine the size of the image on screen
                RealImageSize = new Size(Convert.ToInt32(ImageSize.Width / scale),Convert.ToInt32(ImageSize.Height / scale));

                //Now determine the correct X
                PictureX = (BoxSize.Width - RealImageSize.Width) / 2;
            }

            //OK now that we know where the picture is and its size.
            //Now we have to translate the point that we clicked on to a point on the image.
            //first lets determine if we're in or out of the rectangle that contains the image.
            Rectangle ImageRectangle = new Rectangle(PictureX,PictureY,RealImageSize.Width,RealImageSize.Height);

            //If it isn't then oh my god we've literally done everything 
            if(!ImageRectangle.Contains(e.Location)) { fromPreviewPane = false; return; }

            //Convert
            //subtract PictureX and Picture Y from the click position.
            int ClickPointX=e.X-PictureX;
            int ClickPointY=e.Y-PictureY;

            //now scale it.
            ClickPointX = Convert.ToInt32(ClickPointX * scale);
            ClickPointY = Convert.ToInt32(ClickPointY * scale);

            User ColideUser=null;

            foreach(User U in MyTrace.AllUsers) {
                //Create a rectangle that's going to represent this user.
                if(new Rectangle(U.DrawnX,U.DrawnY,U.Width(),U.Height()).Contains(ClickPointX,ClickPointY)){
                    ColideUser = U;
                    break;
                }
            }

            if(!(ColideUser is null)) {
                UserListView.Items[MyTrace.AllUsers.IndexOf(ColideUser)].Selected = true;
                if(e.Button == MouseButtons.Left) { EditButton_Click(PreviewPictureBox,new EventArgs()); }
                if(e.Button == MouseButtons.Right) { UsersContextMenu.Show(PreviewPictureBox,e.Location); }
            } else {
                if(GetSelectedIndex(false) != -1) { UserListView.Items[GetSelectedIndex(false)].Selected = false; } //unselect the user if necessary
                if(e.Button == MouseButtons.Left) { new PreviewForm(MyTrace.TraceImage).ShowDialog(); }
                if(e.Button == MouseButtons.Right) {UsersContextMenu.Show(PreviewPictureBox,e.Location);}
            }
            fromPreviewPane = false;
        }

        //-[Context Menu Items]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>I gave up and put a small variable to indicate if a rightclick was from the previewpane instead of the listview. </summary>
        private bool fromPreviewPane = false;

        /// <summary>Enables or disables the usercontextmenu when it's time to do so.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersContextMenu_Opening(object sender,System.ComponentModel.CancelEventArgs e) {

            newUnderThisUserToolStripMenuItem.Enabled = true;
            newUnderThisUserToolStripMenuItem.Text = "New User under selected user";
            editToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            reLinkToolStripMenuItem.Enabled = true;

            bGOptionsToolStripMenuItem.Visible = fromPreviewPane;
            BGOptionsToolStripSeparator.Visible = fromPreviewPane;
            changeServerIconToolStripMenuItem.Visible = fromPreviewPane;

            //Case to show new Root User and only allow the user to set that option
            if(MyTrace.AllUsers.Count == 0) { 
                newUnderThisUserToolStripMenuItem.Text = "New Root User";

                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                reLinkToolStripMenuItem.Enabled = false;

                return; 
            }

            //Case to cancel if right click on the listview with nothing selected
            if(GetSelectedIndex(false) == -1 && !fromPreviewPane) { e.Cancel = true; return; }

            //Case to 
            if(GetSelectedIndex(false) == -1 && fromPreviewPane) {

                newUnderThisUserToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                reLinkToolStripMenuItem.Enabled = false;
                return; 
            }

            if(MyTrace.AllUsers[GetSelectedIndex()].Equals(MyTrace.RootUser)){
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                reLinkToolStripMenuItem.Enabled = false;
            }

            newUnderThisUserToolStripMenuItem.Text = "New user under " + MyTrace.AllUsers[GetSelectedIndex()].Name;
        }

        /// <summary>Creates a new user under the user that was right clicked</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewUnderThisUserToolStripMenuItem_Click(object sender,EventArgs e) { AddButton_Click("TRC",e); }

        //-[Toolstrip Menu Items]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Launches the About page</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender,EventArgs e) { new AboutForm().ShowDialog(); }

        /// <summary>Handles saving the UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender,EventArgs e) {
            if(string.IsNullOrWhiteSpace(SaveLocaiton)) { SaveAsToolStripMenuItem_Click(sender,e); return; }
            MyTrace.SaveTrace(SaveLocaiton);
            Modified = false;
        }

        /// <summary>Handles selecting where to save the UserTrace, then saves it</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender,EventArgs e) {
            ProjectDirPicker.Description = "Pick a folder to save this UserTrace to";
            if(ProjectDirPicker.ShowDialog() == DialogResult.OK) {
                SaveLocaiton = ProjectDirPicker.SelectedPath;
                SaveToolStripMenuItem_Click(sender,e);
            }
        }

        /// <summary>Handles exporting the UserTrace image</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintToolStripMenuItem_Click(object sender,EventArgs e) { if(ExportFileDialog.ShowDialog() == DialogResult.OK) { MyTrace.TraceImage.Save(ExportFileDialog.FileName,System.Drawing.Imaging.ImageFormat.Png); } }

        /// <summary>Handles Opening another existing UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender,EventArgs e) {

            if(!AreYouSure()) { return; }

            ProjectDirPicker.Description = "Pick a folder to Open a UserTrace from";
            if(ProjectDirPicker.ShowDialog() == DialogResult.OK) {

                Trace T;

                try {
                    T = new Trace(ProjectDirPicker.SelectedPath);
                } catch(ArgumentException E) {
                    MessageBox.Show(E.Message,"no",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                SaveLocaiton = ProjectDirPicker.SelectedPath;
                LoadTrace(T);
                PopulateListview();
                Modified = false;
            }
        }

        /// <summary>Handles switching to a new UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewToolStripMenuItem_Click(object sender,EventArgs e) {
            if(!AreYouSure()) { return; }

            SaveLocaiton = "";
            LoadTrace(new Trace());
            PopulateListview();
            Modified = false;
        }

        /// <summary>Closes UserTrace</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender,EventArgs e) { Close(); }

        //-[Change Handlers]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Handles changing the Server Name</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameBox_TextChanged(object sender,EventArgs e) {
            MyTrace.ServerName = NameBox.Text;
            GeneratePreview();
            Modified = true;
        }

        /// <summary>Handles changing the server creation date</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatedDateTimePicker_ValueChanged(object sender,EventArgs e) {
            MyTrace.ServerCreationDate = CreatedDateTimePicker.Value;
            GeneratePreview();
            Modified = true;
        }

        /// <summary>Handles changing the root user</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RootUserComboBox_SelectedIndexChanged(object sender,EventArgs e) {
            MyTrace.RootUser = MyTrace.AllUsers[RootUserComboBox.SelectedIndex];
            GeneratePreview();
            Modified = true;
        }

        /// <summary>Handles enabling modification buttons when an item is selected</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserListView_SelectedIndexChange(object sender,EventArgs e) { ModifyButtons(true); }

        //-[Methods]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Enables or disables buttons relating to modification of users in the UserTrace</summary>
        /// <param name="Enabled"></param>
        private void ModifyButtons(bool Enabled) {
            EditButton.Enabled = Enabled;
            LinkButton.Enabled = Enabled;
            DeleteButton.Enabled = Enabled;
        }

        /// <summary>Asks the UserTrace to regenerate the image, and to display it.</summary>
        private void GeneratePreview() {PreviewPictureBox.Image = MyTrace.GenerateTraceImage();}

        /// <summary>checks if a user is selected, and if it is desired to add a new user under the selected one</summary>
        /// <returns></returns>
        private bool AddUnder() {
            if(GetSelectedIndex(false) == -1) { return false; }
            if(MessageBox.Show("Add new user under " + MyTrace.AllUsers[GetSelectedIndex()].Name + "?","Do?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) { return true; }
            return false;
        }

        /// <summary>Gets selected index of the user Listview, showing an error if nothing is selected</summary>
        /// <returns></returns>
        private int GetSelectedIndex() { return GetSelectedIndex(true); }

        /// <summary>Gets the selected index of the user listview</summary>
        /// <returns></returns>
        private int GetSelectedIndex(bool showError) {
            if(UserListView.SelectedIndices.Count == 0) {
                if(showError) { MessageBox.Show("Please select an index before using this button","no",MessageBoxButtons.OK,MessageBoxIcon.Error); }
                return - 1; 
            }
            return UserListView.SelectedIndices[0]; 
        }

        /// <summary>Populates the listview and combobox with all users in the UserTrace</summary>
        private void PopulateListview() {

            UserListView.Items.Clear();
            RootUserComboBox.Items.Clear();

            MyTrace.RebuildList();

            if(MyTrace.RootUser != null) { RecursivePopulate(MyTrace.RootUser,""); }

            //foreach(User U in MyTrace.AllUsers) {
            //    ListViewItem L = new ListViewItem(U.Name);
            //    L.SubItems.Add(U.Children.Count.ToString());
            //    listView1.Items.Add(L);

            //    RootUserComboBox.Items.Add(U.Name);

            //}

            RootUserComboBox.Text = MyTrace.RootUser?.Name;

            ModifyButtons(false);
        }

        /// <summary>Recursively populates the list-view and combobox, adding indents to see the tree structure on the text</summary>
        /// <param name="U"></param>
        /// <param name="Prefix"></param>
        private void RecursivePopulate(User U, string Prefix) {

            ListViewItem L = new ListViewItem(Prefix+""+U.Name);
            L.SubItems.Add(U.Children.Count.ToString());
            UserListView.Items.Add(L);
            RootUserComboBox.Items.Add(Prefix + "-" + U.Name);
            foreach(User Child in U.Children) {RecursivePopulate(Child,Prefix+"|     ");}
        }

        /// <summary>Handles the closing of the form</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosingHandler(object sender,FormClosingEventArgs e) {e.Cancel = !AreYouSure();}

        /// <summary>Loads a Trace</summary>
        /// <param name="T"></param>
        private void LoadTrace(Trace T) {
            MyTrace = T;
            PFPPictureBox.Image = MyTrace.ServerLogo;
            NameBox.Text = MyTrace.ServerName;
            CreatedDateTimePicker.Value = MyTrace.ServerCreationDate;

            PopulateListview();
            GeneratePreview();
            Modified = false;

        }

        /// <summary>Asks a user if they're sure when Opening a new UserTrace, creating a new UserTrace, or closing UserTrace if the currently open UserTrace has unsaved changes</summary>
        /// <returns></returns>
        private bool AreYouSure() {
            if(Modified) {
                DialogResult D = MessageBox.Show("This project has not been saved! Save before proceeding?","Are you sure you want to do this?",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                switch(D) {
                    case DialogResult.None:
                    case DialogResult.OK:
                    case DialogResult.Abort:
                    case DialogResult.Retry:
                    case DialogResult.Ignore:
                    case DialogResult.Cancel:
                    default:
                        return false;
                    case DialogResult.Yes:
                        SaveToolStripMenuItem_Click("it's me",new EventArgs());
                        return true;
                    case DialogResult.No:
                        return true;
                }

            } else { return true; }
        }

    }
}
