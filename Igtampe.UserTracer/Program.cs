using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Igtampe.UserTracer {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //            User Chopo = new User {
            //                Name = "Railroad Chopo",
            //                Description = "",
            //                HeaderColor = Color.DarkBlue,
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\Two.png")
            //            };

            //            User Hepe = new User {
            //                Name = "Doughnut Hepe",
            //                Description = "",
            //                HeaderColor = Color.DarkBlue,
            //                JoinDate = new DateTime(2017,4,1),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\hepe.png")
            //            };

            //            User Salb = new User {
            //                Name = "Rotated Salba",
            //                Description = "She/Her",
            //                HeaderColor = Color.Blue,
            //                JoinDate=new DateTime(2019,3,29),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\salb.png")
            //            };

            //            User Mopo = new User {
            //                Name = "Hat Mopo",
            //                Description = "",
            //                HeaderColor = Color.DarkBlue,
            //                JoinDate=new DateTime(2017,4,1),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\Mopo.png")
            //            };

            //            User Ajoke = new User {
            //                Name = "Concentrated Ajoke",
            //                Description = "",
            //                HeaderColor = Color.DarkBlue,
            //                JoinDate = new DateTime(2017,4,1),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\ajoke.png")
            //            };

            //            User Ocko = new User {
            //                Name = "Chef Ocko",
            //                Description = "",
            //                HeaderColor = Color.DarkBlue,
            //                JoinDate = new DateTime(2017,9,12),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\ocko.png")
            //            };

            //            User Eggdog = new User {
            //                Name = "Computer Eggdog",
            //                HeaderColor = Color.Blue,
            //                JoinDate = new DateTime(2019,1,25),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\Eggdog.png")
            //            };

            //            User Jenny = new User {
            //                Name = "Jenny",
            //                Description="Nobody knows who she really is.\n\nOnly maru does and by this point she doesn't even exist.",
            //                HeaderColor = Color.LightBlue,
            //                JoinDate = new DateTime(2020,8,4),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\Jenny.png")
            //            };

            //            User AB = new User {
            //                Name = "A🅱️",
            //                Description = "Has this man ever actually said anything on the server???\n\nmight be time to start auditing again.",
            //                HeaderColor = Color.LightBlue,
            //                JoinDate = new DateTime(2021,2,6)
            //                //PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\Jenny.png")
            //            };

            //            User Leve = new User {
            //                Name = "Daddy Leve",
            //                HeaderColor = Color.Blue,
            //                JoinDate = new DateTime(2018,7,29),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\Leve.png")
            //            };

            //            User tso = new User {
            //                Name = "General Tso",
            //                HeaderColor = Color.Blue,
            //                JoinDate = new DateTime(2021,2,5),
            //                PFP = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\tso.png")
            //            };

            //            //Link:
            //            Chopo.AddChild(Hepe);
            //            Chopo.AddChild(Mopo);
            //            Chopo.AddChild(Ajoke);
            //            Chopo.AddChild(Ocko);
            //            Mopo.AddChild(Jenny);
            //            Ocko.AddChild(AB)
            //;            Hepe.AddChild(Salb);
            //            Hepe.AddChild(Leve);
            //            Hepe.AddChild(tso);
            //            Salb.AddChild(Eggdog);

            //Now let's create a trace
            //Trace TheTrace = new Trace() {
            //    RootUser = Chopo,
            //    ServerLogo = new Bitmap("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\allPFPs\\Nexus.png"),
            //    ServerName = "Nexus",
            //};

            //            Trace TheTrace = new Trace("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\NexusCensus");

            //TheTrace.SaveTrace("A:\\Downloads\\Pictures\\Bad Drawings\\22nd Gen\\NexusCensus");

            //Now cross your fingers
            //            Clipboard.SetImage(TheTrace.TraceImage);
            //            Application.Run(new PreviewForm(TheTrace.TraceImage));


            Trace LoadTrace = new Trace();

            

            if(args.Length != 0) {
                args[0] = args[0].ToUpper().Replace("PROJECT.UTRACE","");
                LoadTrace = new Trace(args[0]); 
            }

            MainForm theForm = new MainForm(LoadTrace);

            if(args.Length != 0) {theForm.SaveLocaiton = args[0];}

            Application.Run(theForm);
        }
    }
}
