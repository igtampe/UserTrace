using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Igtampe.UserTracer {

    /// <summary>
    /// Holds a UserLinkerForm. Used to link a User to a different Parent.
    /// </summary>
    public partial class UserLinkerForm:Form {

        //-[Properties]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>User to link</summary>
        public User myUser = new User();

        /// <summary>All users (including those this user shouldn't link to but shh)</summary>
        private readonly List<User> allUsers = new List<User>();

        /// <summary>Gets the selected list index.</summary>
        public int ListIndex { get { return comboBox1.SelectedIndex; } }

        //-[Constructor]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Crates a default UserLinkerForm. This one is basically useless pero shh.</summary>
        public UserLinkerForm() {InitializeComponent();}

        /// <summary>Creates a UserLinkerForm to link User U to a different Parent.</summary>
        /// <param name="U"></param>
        /// <param name="AllUsers"></param>
        public UserLinkerForm(User U, List<User> AllUsers):this() { 
            myUser = U; 
            allUsers = AllUsers;

            if(myUser.Name.ToUpper() != "NAME") { label1.Text = "Who invited " + myUser.Name + "?"; }

            RecursivePopulate(AllUsers[0],"");
        }

        /// <summary>Recursively populates the list-view and combobox, adding indents to see the tree structure on the text</summary>
        /// <param name="U"></param>
        /// <param name="Prefix"></param>
        private void RecursivePopulate(User U,string Prefix) {

            comboBox1.Items.Add(Prefix + "-" + U.Name);
            foreach(User Child in U.Children) { RecursivePopulate(Child,Prefix + "|     "); }
        }


        //-[Buttons]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Checks if the selected potential parent can be a parent. It reverts to the root user if the potential parent is a child of the user.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParentComboBox_SelectedIndexChanged(object sender,EventArgs e) {

            //get the new parent
            User PotentialNewParrent = allUsers[ListIndex];

            //Make sure that the new parent user is *not* a child
            if(myUser.GetAllSubUsers().Contains(PotentialNewParrent)) {
                MessageBox.Show("The selected user is a child (or sub-child) of the user you want to link. Please choose another one","Sorry, no",MessageBoxButtons.OK,MessageBoxIcon.Error);
                comboBox1.SelectedIndex = 0;
                return;
            }

        }

        /// <summary>Closes the form and returns OK</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>Closes the form and returns Cancel</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
