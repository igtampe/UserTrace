using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Igtampe.UserTracer {
    public partial class AllUsersForm:Form {

        public User myUser = new User();
        private readonly List<User> allUsers = new List<User>();
        public AllUsersForm() {InitializeComponent();}
        public int ListIndex { get { return comboBox1.SelectedIndex; } }

        public AllUsersForm(User U, List<User> AllUsers):this() { 
            myUser = U; 
            allUsers = AllUsers;

            foreach(User N in allUsers) {comboBox1.Items.Add(N.Name);}
        }


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

        private void OKButton_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
