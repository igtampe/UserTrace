using System;
using System.Drawing;
using System.Collections.Generic;

namespace Igtampe.UserTracer {

    /// <summary>Holds a UserTrace User Object</summary>
    public class User : IComparable {

        //-[Properties]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Name of the user</summary>
        public string Name { get; set; } = "Name";

        /// <summary>The PFP image of this user</summary>
        public Image PFP { get; set; } = Properties.Resources.UnknownPerson;

        /// <summary>Date this user Joined</summary>
        public DateTime JoinDate { get; set; } = new DateTime(2017,3,31);

        /// <summary>Color of this user's header</summary>
        public Color HeaderColor { get; set; } = Color.Red;

        /// <summary>Description of this User</summary>
        public string Description { get; set; } = "";

        /// <summary>Parent of this user</summary>
        public User Parent { get; set; }

        /// <summary>List of users this user has invited</summary>
        public List<User> Children { get; } = new List<User>();

        /// <summary>Array of children that need to be loaded after instantiating the object</summary>
        public string[] LoadedChildrenArray { get; }

        /// <summary>Usercard holder</summary>
        private Image usercard;

        /// <summary>Gets the UserCard for a User. If it does not exist, it is generated.</summary>
        public Image UserCard { 
            get {
                if(usercard == null) { GenerateImage(); }
                return usercard;
            } 
            private set { usercard = value; } 
        }

        //-[Constructor]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Default user constructor</summary>
        public User() { }

        /// <summary>Creates a user from a saved UserString. DOES NOT LINK CHILDREN.</summary>
        /// <param name="UserStirng"></param>
        public User(string UserStirng, string ProjectDirectory) {
            string[] UserStringSplit = UserStirng.Split('~');
            Name = UserStringSplit[0];
            PFP = Trace.SafeLoadImage(ProjectDirectory + "\\images\\" + Name + ".png");
            string[] DateString = UserStringSplit[2].Split('-');
            JoinDate = new DateTime(int.Parse(DateString[0]),int.Parse(DateString[1]),int.Parse(DateString[2]));
            HeaderColor = Color.FromArgb(int.Parse(UserStringSplit[3]));
            Description = UserStringSplit[4];
            LoadedChildrenArray = UserStringSplit[5].Split('`');
        }

        //-[Methods]------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Adds the given user to this user's children</summary>
        /// <param name="U"></param>
        public void AddChild(User U) {Children.Add(U);}

        /// <summary>Removes the given user from this User's children</summary>
        /// <param name="U"></param>
        public void RemoveChild(User U) { Children.Remove(U); }

        /// <summary>Generates a UserString for the given user, for saving</summary>
        /// <returns></returns>
        public string GenerateUserString() {
            string DateString = string.Join("-",JoinDate.Year,JoinDate.Month,JoinDate.Day);
            string ChildrenString = "";
            foreach(User subu in Children) { ChildrenString += subu.Name+"`"; }
            return string.Join("~",Name,"pfp",DateString,HeaderColor.ToArgb(),Description,ChildrenString);
        }

        /// <summary>Gets the height of this user's individual usercard</summary>
        /// <returns>The user card's height plus 10 (5 pixels above, and 5 pixels below) for padding</returns>
        public int Height() {return UserCard.Height;}

        /// <summary>Gets the *total* height of this user's usercard and all of their cihldren</summary>
        /// <returns></returns>
        public int TotalHeight() {

            //If this user has no children then just return its own height
            if(Children.Count == 0) { return Height(); }

            int TotalHeight=0;

            //Now if this user *does* have children
            foreach(User Child in Children) {
                TotalHeight += Child.TotalHeight() + 10; //Child's total height plus 5 above, and 5 below for spacing.
            }

            return Math.Max(Height(),TotalHeight);

        }

        /// <summary>Gets the width of this user's individual usercard.</summary>
        /// <returns></returns>
        public int Width() { return UserCard.Width; }

        /// <summary>Gets the total width of this User's userscard and all of their children</summary>
        /// <returns></returns>
        public int TotalWidth() {
            if(Children.Count == 0) { return Width(); }

            int LongestWidth=0;

            foreach(User Child in Children) {LongestWidth = Math.Max(LongestWidth,Child.TotalWidth());}

            return Width()+100+ LongestWidth; //Width of this card, plus 50 for spacing of the arrows, plus the longest width from there
        }

        /// <summary>Returns a list of all the child users of this user</summary>
        /// <returns></returns>
        public List<User> GetAllSubUsers() {

            List<User> returnList = new List<User> {
                this //add ourselves to the list.
            };

            foreach(User Child in Children) {returnList.AddRange(Child.GetAllSubUsers());} //Add all the users under each of our children
            return returnList;
        }

        /// <summary>Generates a bitmap to represent this user</summary>
        /// <param name="U"></param>
        /// <returns></returns>
        public Image GenerateImage() {

            //First we have to find the dimensions of this usercard
            //The base dimension is the dimension of the image which is 64 + 15 + Math.Max(Width of date text, width of Name Text, width of the description (if any)) x (64 or 64 + 23 + height of the description)

            //We create a temporary handler and image so we can measure text
            Image Temp = new Bitmap(1,1);
            Graphics Handler = Graphics.FromImage(Temp);

            string JoinDateString = "Joined: " + JoinDate.Month + "/" + JoinDate.Day + "/" + JoinDate.Year;

            FontFamily Arial = new FontFamily("Arial");

            Font BigText = new Font(Arial,20,FontStyle.Bold,GraphicsUnit.Point);
            Font SmallText = new Font(Arial,8,FontStyle.Regular,GraphicsUnit.Point);

            SizeF NameSize = Handler.MeasureString(Name,BigText);
            SizeF JoinDateSize = Handler.MeasureString(JoinDateString,SmallText); ;
            SizeF DescriptionSize;

            if(string.IsNullOrWhiteSpace(Description)) { DescriptionSize = new Size(0,0); } else { DescriptionSize = Handler.MeasureString(Description,SmallText); }

            //Now that we have the sizes, its time to determine the base.

            //Here we can calculate this directly since if there is no description, its width is 0.
            int BaseWidth = 64 + Math.Max(Convert.ToInt32(DescriptionSize.Width),15+Math.Max(Convert.ToInt32(NameSize.Width),Convert.ToInt32(JoinDateSize.Width)));
            //We add 15 since there's going to be some padding between the 64 pixel wide pfp, and the name/joindate text.

            //Here we do have to calculate separately, since if there is or isn't a description determines whether there's an extra height or not.
            int BaseHeight = 64;
            if(!string.IsNullOrWhiteSpace(Description)) {BaseHeight = 64 + 23 + Convert.ToInt32(DescriptionSize.Height);}
            //We add 23 since that's padding between the description, the pfp (10 pixels above and below), and a 3 pixel wide line that will go between them.            

            //We now have the base width and base height of the card, we can add some more nice padding.
            //Above and below the base height, we're going to add 10 pixels of the background color, and 10 more in outline.. This means that we're going to add 40 pixels in total.
            int ImageHeight = BaseHeight + 40;

            //Now on each side, we're going to add about 20 pixels in color, and 10 more in outline, meaning we're going to add 60 pixels in total.
            int ImageWidth = BaseWidth + 60;

            //Now that we have our image height and width, we can go ahead and start creating the real bitmap.
            UserCard = new Bitmap(ImageWidth,ImageHeight);

            //Now let's create a graphics thing so we can actually draw onto this image
            Handler = Graphics.FromImage(UserCard);

            //Now let's create a reusable brush
            Brush TheBrush = new SolidBrush(Color.Black);

            //Now time to draw the big rectangle.
            Handler.FillRectangle(TheBrush,0,0,ImageWidth,ImageHeight);

            //Now make the brush the color of the user's header color
            TheBrush.Dispose();
            TheBrush = new SolidBrush(HeaderColor);

            //Now fill the subrectangle.
            Handler.FillRectangle(TheBrush,10,10,ImageWidth - 20,ImageHeight - 20);

            //Since we don't want to store the image resized, we must resize the PFP.
            Image SmolPFP = new Bitmap(PFP,new Size(64,64));

            //Now let's draw the PFP. It should be 10+20 from the left, and 10+10 from the top
            Handler.DrawImage(SmolPFP,30,20);

            //Now let's draw some text.

            //First things first, we have to decide if we're going to use white or black.
            TheBrush.Dispose();

            double DistanceToBlack = ColourDistance(Color.Black,HeaderColor);
            double DistanceToWhite = ColourDistance(Color.White,HeaderColor);

            if(DistanceToBlack>DistanceToWhite) { TheBrush = new SolidBrush(Color.Black); } else { TheBrush = new SolidBrush(Color.White); }

            //Now let's draw. The name should be approximately 30 +64 (the rightmost point of the image) + 15 (padding), 20 (upper point of the image) + 6 (padding)
            Handler.DrawString(Name,BigText,TheBrush,30 + 64 + 15-6,6+20);

            //Now onto the date!
            Handler.DrawString(JoinDateString,SmallText,TheBrush,30 + 64 + 15-2,6 + NameSize.Height + 6 +20 -6);

            //Now the rest only applies if there's a description
            if(!string.IsNullOrWhiteSpace(Description)) {

                //Nice line between the top and the description which will be 3 long, and run the length of the PFP to the edge of the name text or joinedate text (whichever is longer)
                //To keep it centered, it must be at the same x position as the PFP
                //And to keep it centered between the two, it must be at the height of The PFP, plus the padding of the PFP, plus an additional 10 pixels
                Handler.FillRectangle(TheBrush,30,20 + 64 + 10,64 + Math.Max(DescriptionSize.Width,15 + Math.Max(NameSize.Width,JoinDateSize.Width)),3);

                //Lastly draw the description. It's 13 pixels below the position of the line (3 for the line's height, and 10 for padding).
                Handler.DrawString(Description,SmallText,TheBrush,30,20 + 64 + 10 + 13);
            
            }
            //And we're done! Let's see if this works
            return UserCard;
        }

        //-[Overrides]------------------------------------------------------------------------------------------------------------------------------------------

        public override bool Equals(object obj) {
            try {
                User OtherUser = (User)obj;
                return OtherUser.Name == Name;
            } catch(Exception) {return base.Equals(obj);}
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public int CompareTo(object obj) {return GetAllSubUsers().Count.CompareTo(obj);}

        //-[Static Methods]------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Color Distance Calculator provided by FUBO on Stack Overflow<br></br><br></br>
        /// 
        /// See: https://stackoverflow.com/questions/3968179/compare-rgb-colors-in-c-sharp
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static double ColourDistance(Color e1,Color e2) {
            long rmean = ((long)e1.R + (long)e2.R) / 2;
            long r = (long)e1.R - (long)e2.R;
            long g = (long)e1.G - (long)e2.G;
            long b = (long)e1.B - (long)e2.B;
            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }


        //-[Operators]------------------------------------------------------------------------------------------------------------------------------------------

        public static bool operator ==(User left,User right) { if(left is null) { return right is null; } else { return left.Equals(right); } }
        public static bool operator !=(User left,User right) {return !(left == right);}
        public static bool operator <(User left,User right) {return left is null ? right is object : left.CompareTo(right) < 0;}
        public static bool operator <=(User left,User right) {return left is null || left.CompareTo(right) <= 0;}
        public static bool operator >(User left,User right) {return left is object && left.CompareTo(right) > 0;}
        public static bool operator >=(User left,User right) {return left is null ? right is null : left.CompareTo(right) >= 0;}
    }
}
