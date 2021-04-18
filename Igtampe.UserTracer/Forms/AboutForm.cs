using System;
using System.Windows.Forms;

namespace Igtampe.UserTracer {
    /// <summary>About form to display about which basically is nada pero zop</summary>
    public partial class AboutForm:Form {

        /// <summary>Creates the About Form</summary>
        public AboutForm() {InitializeComponent();}

        /// <summary>It closes the About Form</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender,EventArgs e) { Close(); }

    }
}
