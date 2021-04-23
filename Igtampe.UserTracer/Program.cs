using System;
using System.Windows.Forms;

namespace Igtampe.UserTracer {
    
    /// <summary>Main program class</summary>
    static class Program {
        
        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Trace LoadTrace = new Trace();
            
            if(args.Length != 0) {
                args[0] = args[0].ToUpper().Replace("PROJECT.UTRACE","");
                try {LoadTrace = new Trace(args[0]);} catch(Exception E) {
                    MessageBox.Show(E.Message,"no",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            MainForm theForm = new MainForm(LoadTrace);
            if(args.Length != 0) {theForm.SaveLocaiton = args[0];}
            Application.Run(theForm);
        }
    }
}
