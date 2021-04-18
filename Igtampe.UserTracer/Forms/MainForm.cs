using System;
using System.Drawing;
using System.Windows.Forms;

namespace Igtampe.UserTracer {
    public partial class MainForm:Form {

        public Trace MyTrace = new Trace();
        private string savelocale = "";
        public string SaveLocaiton { get { return savelocale; } set { savelocale = value; Text = "UserTrace - " + value; } }
        private bool Modified = false;

        public MainForm() : this(new Trace()) { }
        
        public MainForm(Trace T) { 
            InitializeComponent();
            LoadTrace(T);
        }


        private void AboutToolStripMenuItem_Click(object sender,EventArgs e) {new AboutForm().ShowDialog();}

        private void AddButton_Click(object sender,EventArgs e) {
            User NewUser = new User();
            if(MyTrace.AllUsers.Count == 0) {
                MessageBox.Show("Since this is the first user, this will be the root user.\n\nThis can be changed later, but you may lose users before the root user if you save","Root User Notice",MessageBoxButtons.OK,MessageBoxIcon.Information);
            } else { 
                AllUsersForm Linker = new AllUsersForm(NewUser,MyTrace.AllUsers);
                if(Linker.ShowDialog() != DialogResult.OK) {return;}

                User Parent = MyTrace.AllUsers[Linker.ListIndex];

                //find the parent and link it.
                //Delink the user from the old parent
                NewUser.Parent?.RemoveChild(NewUser);
                NewUser.Parent = null;

                //Link the new parent.
                NewUser.Parent = Parent;
            }

            UserForm TheForm = new UserForm(NewUser);
            if(TheForm.ShowDialog() != DialogResult.OK) { return; }
            
            NewUser = TheForm.MyUser;
            MyTrace.AllUsers.Add(NewUser);
            NewUser.Parent?.AddChild(NewUser);

            GeneratePreview();
            PopulateListview();


        }

        private void EditButton_Click(object sender,EventArgs e) {

            if(GetSelectedIndex() == -1) { return; }

            UserForm TheForm = new UserForm(MyTrace.AllUsers[GetSelectedIndex()]);
            if(TheForm.ShowDialog() != DialogResult.OK) { return; }

            MyTrace.AllUsers[GetSelectedIndex()] = TheForm.MyUser;
            GeneratePreview();
            PopulateListview();
            Modified = true;
        }

        private void LinkButton_Click(object sender,EventArgs e) {
            if(GetSelectedIndex() == -1) { return; }

            if(MyTrace.AllUsers[GetSelectedIndex()].Equals(MyTrace.RootUser)) {
                MessageBox.Show("You cannot re-link the Root User.","no",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            AllUsersForm Linker = new AllUsersForm(MyTrace.AllUsers[GetSelectedIndex()],MyTrace.AllUsers);
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

        private void UserListView_SelectedIndexChange(object sender,EventArgs e) {ModifyButtons(true);}

        private void ModifyButtons(bool Enabled) {
            EditButton.Enabled = Enabled;
            LinkButton.Enabled = Enabled;
            DeleteButton.Enabled = Enabled;
        }

        private void PFPPictureBox_Click(object sender,EventArgs e) {
            if(ProfilePicturePicker.ShowDialog() == DialogResult.OK) {
                Image NewPFP = new Bitmap(ProfilePicturePicker.FileName);
                PFPPictureBox.Image = NewPFP;
                MyTrace.ServerLogo = NewPFP;
                GeneratePreview();
                Modified = true;
            }
        }

        private void TileBG_Click(object sender,EventArgs e) {
            if(ProfilePicturePicker.ShowDialog() == DialogResult.OK) {
                Image NewPFP = new Bitmap(ProfilePicturePicker.FileName);
                MyTrace.TileBackground = NewPFP;
                GeneratePreview();
                Modified = true;
            }
        }

        private void NameBox_TextChanged(object sender,EventArgs e) {
            MyTrace.ServerName = NameBox.Text;
            GeneratePreview();
            Modified = true;
        }

        private void CreatedDateTimePicker_ValueChanged(object sender,EventArgs e) {
            MyTrace.ServerStartDate = CreatedDateTimePicker.Value;
            GeneratePreview();
            Modified = true;
        }

        private void RootUserComboBox_SelectedIndexChanged(object sender,EventArgs e) {
            MyTrace.RootUser = MyTrace.AllUsers[RootUserComboBox.SelectedIndex];
            GeneratePreview();
            Modified = true;
        }

        private void GeneratePreview() {PreviewPictureBox.Image = MyTrace.GenerateTraceImage();}

        private int GetSelectedIndex() {
            if(listView1.SelectedIndices.Count == 0) {
                MessageBox.Show("Please select an index before using this button","no",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return - 1; 
            }
            return listView1.SelectedIndices[0]; 
        }

        private void PopulateListview() {

            listView1.Items.Clear();
            RootUserComboBox.Items.Clear();

            foreach(User U in MyTrace.AllUsers) {
                ListViewItem L = new ListViewItem(U.Name);
                L.SubItems.Add(U.Children.Count.ToString());
                listView1.Items.Add(L);

                RootUserComboBox.Items.Add(U.Name);

            }

            RootUserComboBox.Text = MyTrace.RootUser?.Name;

            ModifyButtons(false);
        }

        private void PreviewPictureBox_Click(object sender,EventArgs e) {new PreviewForm(MyTrace.TraceImage).ShowDialog() ;}

        private void SaveToolStripMenuItem_Click(object sender,EventArgs e) {
            if(string.IsNullOrWhiteSpace(SaveLocaiton)) { SaveAsToolStripMenuItem_Click(sender,e); return; }
            MyTrace.SaveTrace(SaveLocaiton);
            Modified = false;
        }

        private void SaveAsToolStripMenuItem_Click(object sender,EventArgs e) {
            ProjectDirPicker.Description = "Pick a folder to save this UserTrace to";
            if(ProjectDirPicker.ShowDialog() == DialogResult.OK) {
                SaveLocaiton = ProjectDirPicker.SelectedPath;
                SaveToolStripMenuItem_Click(sender,e);
            }
        }

        private void PrintToolStripMenuItem_Click(object sender,EventArgs e) {if(ExportFileDialog.ShowDialog() == DialogResult.OK) { MyTrace.TraceImage.Save(ExportFileDialog.FileName,System.Drawing.Imaging.ImageFormat.Png); }}

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

        private void NewToolStripMenuItem_Click(object sender,EventArgs e) {
            if(!AreYouSure()) { return; }

            LoadTrace(new Trace());
            PopulateListview();
            Modified = false;
        }

        private void ExitToolStripMenuItem_Click(object sender,EventArgs e) {Close();}

        private void ClosingHandler(object sender,FormClosingEventArgs e) {e.Cancel = !AreYouSure();}

        private void LoadTrace(Trace T) {
            MyTrace = T;
            PFPPictureBox.Image = MyTrace.ServerLogo;
            NameBox.Text = MyTrace.ServerName;
            CreatedDateTimePicker.Value = MyTrace.ServerStartDate;

            PopulateListview();
            GeneratePreview();
            Modified = false;

        }

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
