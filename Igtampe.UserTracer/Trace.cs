using System;
using System.IO;
using System.Drawing;
using Igtampe.DictionaryOnDisk;
using System.Collections.Generic;

namespace Igtampe.UserTracer {

    /// <summary>Holds one UserTrace file and can generate the Trace Image</summary>
    public class Trace {

        //-[Properties]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Holder for root user</summary>
        private User rootuser;

        /// <summary>Root user of this UserTrace</summary>
        public User RootUser { get { return rootuser; } set { rootuser = value; } }

        /// <summary>All users in this UserTrace</summary>
        public List<User> AllUsers { get; set; } = new List<User>();

        /// <summary>Tile Background of this user trace</summary>
        public Image TileBackground { get; set; } = Properties.Resources.Sandstone;

        /// <summary>Server Logo of this UserTrace</summary>
        public Image ServerLogo { get; set; } = Properties.Resources.UnknownPerson;

        /// <summary>Name of the server presented in this UserTrace </summary>
        public string ServerName { get; set; } = "Server";

        /// <summary>Date the server presented in this UserTrace was created</summary>
        public DateTime ServerCreationDate { get; set; } = new DateTime(2017,3,31);

        /// <summary>private holder for the trace image</summary>
        private Image traceImage;

        /// <summary>Gets this trace's rendered image. If it is not created, it will be generated</summary>
        public Image TraceImage {
            get { if(traceImage == null) { return GenerateTraceImage(); } else { return traceImage; } } 
            private set { traceImage = value; } 
        }

        //-[Constructor]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Creates a default new UserTrace</summary>
        public Trace() { }

        /// <summary>Loads a UserTrace from a directory.</summary>
        /// <param name="ProjectDir"></param>
        public Trace(string ProjectDir) {

            if(!Directory.Exists(ProjectDir) ||
               !File.Exists(ProjectDir+"/"+"Project.UTrace") ||
               !File.Exists(ProjectDir+"/"+"Users.DOD") ||
               !Directory.Exists(ProjectDir+"/"+"Images")
                ) { throw new ArgumentException("Project Dir does not contain a project"); }

            //Load the Project DOD
            Dictionary<string,string> ProjectDOD = DOD.Load(ProjectDir + "/" + "Project.UTrace");

            //Load the Tile IMG and the Server Logo
            if(File.Exists(ProjectDir + "/TileBG.png")) { TileBackground = SafeLoadImage(ProjectDir + "/TileBG.png"); }
            if(File.Exists(ProjectDir + "/Logo.png")) { ServerLogo = SafeLoadImage(ProjectDir + "/Logo.png"); }

            //Load the server name and  server start date
            ServerName = ProjectDOD["name"];
            string[] DateTemp = ProjectDOD["date"].Split('-');
            ServerCreationDate = new DateTime(int.Parse(DateTemp[0]),int.Parse(DateTemp[1]),int.Parse(DateTemp[2]));

            //Now load the users!!!
            Dictionary<string,string> UsersDOD = DOD.Load(ProjectDir + "/" + "Users.DOD");

            //now we're going to load the root user
            RootUser = new User(UsersDOD[ProjectDOD["root"]],ProjectDir);

            //Now time to link the users
            LinkUsers(ref rootuser,ref UsersDOD,ProjectDir);

            //now let's add all the users 
            AllUsers = rootuser.GetAllSubUsers();

            //and that's it.
        }

        //-[Methods]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>saves the UserTrace to a directory</summary>
        /// <param name="ProjectDir"></param>
        public void SaveTrace(string ProjectDir) {
            if(!Directory.Exists(ProjectDir)) { Directory.CreateDirectory(ProjectDir); }
            if(!Directory.Exists(ProjectDir + "/images")) { Directory.CreateDirectory(ProjectDir + "/images"); }
            Dictionary<string,string> ProjectDOD = new Dictionary<string,string> {
                { "name",ServerName },
                { "date",string.Join("-",ServerCreationDate.Year,ServerCreationDate.Month,ServerCreationDate.Day) },
                { "root",RootUser.Name }
            };

            DOD.Save(ProjectDOD,ProjectDir + "/" + "Project.UTrace");
            if(File.Exists(ProjectDir + "/" + "Logo.png")) { File.Delete(ProjectDir + "/" + "Logo.png"); }
            ServerLogo.Save(ProjectDir + "/" + "Logo.png",System.Drawing.Imaging.ImageFormat.Png);
            if(File.Exists(ProjectDir + "/" + "TileBG.png")) { File.Delete(ProjectDir + "/" + "TileBG.png"); }
            TileBackground.Save(ProjectDir + "/" + "TileBG.png",System.Drawing.Imaging.ImageFormat.Png);

            //now to save the users:
            Dictionary<string,string> UsersDOD = new Dictionary<string,string>();

            foreach(User user in AllUsers) {

                //Add the user to the DOD
                UsersDOD.Add(user.Name,user.GenerateUserString());

                //Save their image
                if(File.Exists(ProjectDir + "/images/" + user.Name + ".png")) { File.Delete(ProjectDir + "/images/" + user.Name + ".png"); }
                user.PFP.Save(ProjectDir +"/images/"+user.Name + ".png",System.Drawing.Imaging.ImageFormat.Png);

            }

            //Save the DOD
            DOD.Save(UsersDOD,ProjectDir + "/" + "Users.DOD");
        }

        /// <summary>Generates the trace image. Caches it to TraceImage property before returning it</summary>
        /// <returns></returns>
        public Image GenerateTraceImage() {

            int BaseWidth;
            int BaseHeight;

            if(RootUser != null) {
                BaseWidth = RootUser.TotalWidth();
                BaseHeight = RootUser.TotalHeight();
            } else {
                BaseWidth = 0;
                BaseHeight =0;
            }

            //now we're going to add like 100 to the left side, and 100 to the right, meaning the real width will be 200+BaseWidth
            //And we're going to add like 128 +10 + 10 to the top, not to the bottom, meaning the real height will be 148+BaseHeight
            //you know what +10 to the bottom because why not.

            traceImage = new Bitmap(Math.Max(200 + BaseWidth,640),Math.Max(148 + BaseHeight+10,480));

            //Now let's throw in the tile background.
            int x;
            int y = 0;
            Graphics GRD = Graphics.FromImage(traceImage);
            while(y < traceImage.Size.Height) {
                x = 0;
                while(x < traceImage.Size.Width) {
                    GRD.DrawImage(TileBackground,x,y);
                    x += TileBackground.Width;
                }
                y += TileBackground.Height;
            }

            //ok now let's add the server info
            Image SmolServerLogo = new Bitmap(ServerLogo,128,128);
            GRD.DrawImage(SmolServerLogo,10,10);

            Brush TheBrush = new SolidBrush(Color.White);

            FontFamily Arial = new FontFamily("Arial");

            Font BigText = new Font(Arial,48,FontStyle.Bold,GraphicsUnit.Point);
            Font SmallText = new Font(Arial,16,FontStyle.Regular,GraphicsUnit.Point);

            string CreateDateString = "Created: " + ServerCreationDate.Month + "/" + ServerCreationDate.Day + "/" + ServerCreationDate.Year;

            SizeF ServerNameSize = GRD.MeasureString(ServerName,BigText);

            GRD.DrawString(ServerName,BigText,TheBrush,128 + 10 + 10,10+15);
            GRD.DrawString(CreateDateString,SmallText,TheBrush,128 + 10 + 18,10 + 15 + ServerNameSize.Height);

            //now we can kick off the drawing process.
            if(rootuser == null) { return TraceImage; }
            DrawTrace(RootUser,100,148,GRD);


            return traceImage;
        }

        public void RebuildList() {
            if(rootuser is null) { AllUsers = new List<User>(); } 
            else { AllUsers = RootUser?.GetAllSubUsers(); }
        }

        //-[Private Methods]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Draws a trace with top left coordinates X and Y from the provided root user, to each of its sub-users</summary>
        /// <param name="U"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="GRD"></param>
        private void DrawTrace(User U,int X,int Y,Graphics GRD) {
            if(U.Children.Count == 0) { 
                GRD.DrawImage(U.UserCard,X,Y+5);
                U.DrawnX = X;
                U.DrawnY = Y+5;
                return; 
            }

            //OK now comes the complicated part.

            //Let's centralize the first card which will be our root
            //lets take the totalheight, subtract the individual user's card height out, then divide it by 2.
            int DrawY =(U.TotalHeight() - U.Height()) / 2;
            int DrawX = 0; //DrawX is 0 for now.

            GRD.DrawImage(U.UserCard,X+DrawX,Y+DrawY);
            U.DrawnX = X+DrawX;
            U.DrawnY = Y + DrawY;

            //Let's take a moment to calculate where each line will originate, and to set up the pen.
            Pen ArrowPen = new Pen(new SolidBrush(Color.Black),10);
            int ArrowX = X+U.UserCard.Width-4;
            int ArrowY = Y+U.TotalHeight()/2;

            //Now let's move X forward by the image's width, and the padding between columns which was 100.
            DrawX = U.UserCard.Width + 100; //This is now the X at which we will draw the next card.
            DrawY = 0; //we set Y to 5 since we have 5 pixesl of padding up above every child user card.

            //Draw the stub for the arrow:
            GRD.DrawLine(ArrowPen,ArrowX - 4,ArrowY,ArrowX + 50,ArrowY);

            //Now let's draw each child
            foreach(User child in U.Children) {

                //Foreach child we're going to draw it.
                DrawTrace(child,X+DrawX,Y+DrawY,GRD);

                //Then we're going to draw a line from the middle of the whole root user's middle (plus the width of the original card) to the middle of the total height of the child)
                GRD.DrawLine(ArrowPen,ArrowX+50,ArrowY,ArrowX+50,Y + DrawY + (child.TotalHeight() / 2)+5);
                GRD.DrawLine(ArrowPen,ArrowX + 45,Y + DrawY + (child.TotalHeight() / 2)+5,X + DrawX + 4,Y + DrawY + (child.TotalHeight() / 2)+5);

                //Then we're going to increment Y by that child's totalheight, plus 10 pixels in padding
                DrawY += child.TotalHeight() +10;


            }

        }

        /// <summary>Links Users during instantiation.</summary>
        /// <param name="root"></param>
        /// <param name="UsersDOD"></param>
        /// <param name="ProjectDirectory"></param>
        private void LinkUsers(ref User root,ref Dictionary<string,string> UsersDOD, string ProjectDirectory) {
            foreach(string Child in root.LoadedChildrenArray) {

                if(string.IsNullOrWhiteSpace(Child)) { continue; }

                //Load the child
                User childUser = new User(UsersDOD[Child],ProjectDirectory);
                //Load all of its children
                LinkUsers(ref childUser,ref UsersDOD,ProjectDirectory);

                //Link it to the root
                root.AddChild(childUser);

                //Link the child to the root
                childUser.Parent = root;
            }
        }

        //-[Static Methods]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Safely loads an image from the given path</summary>
        /// <returns></returns>
        public static Image SafeLoadImage(string Path) {
            Image R;
            using(var bmpTemp = new Bitmap(Path)) {R = new Bitmap(bmpTemp);}
            return R;
        }

    }
}
