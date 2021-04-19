using System;
using System.Threading;
using System.Windows.Forms;

namespace Igtampe.UserTracer {
    public partial class SplashForm:Form {
        public SplashForm() {InitializeComponent();}
        public bool open = true;

        private void SplashForm_Shown(object sender,EventArgs e) { Waiter.RunWorkerAsync(); }

        private void Waiter_DoWork(object sender,System.ComponentModel.DoWorkEventArgs e) {Thread.Sleep(1500);}
        private void Waiter_Complete(object sender,System.ComponentModel.RunWorkerCompletedEventArgs e) { open = false;  Close(); }

    }
}
