using DevExpress.XtraGrid.Views.Tile;
using LeaveMeAlone._Groups;
using LeaveMeAlone._Information;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMeAlone
{
    public partial class UserProfileViewFormAdmin : Form
    {
        private readonly UserViewModel user;
        private string userNameAndSurname = null;

        private List<string> groupsIDs = new List<string>();

        private bool shouldClose = true;

        private bool changing = true;

        private Color original;
        private ImageFormat format;

        public bool showingGroupInvite = false;

        public static UserProfileViewFormAdmin userProfileViewForm;

        public UserProfileViewFormAdmin(UserViewModel user)
        {
            InitializeComponent();

            userProfileViewForm = this;

            txtName.Text = user.Name;
            txtSurname.Text = user.Surname;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;

            //can never happen because the picture will always be added --> if it happens --> error on server
            if (user.ProfilePicture == null || user.ProfilePicture.Equals("")) {
                //profilePicture.BackgroundImage = Properties.Resources.icons8_account_80;
            }
            else {
                userPicture.BackgroundImage = stringToImage(user.ProfilePicture);
            }
            this.user = user;
        }


        //============= TRANSFORM STRING INTO IMAGE ============//
        public Bitmap stringToImage(string inputString)
        {
           
            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            return new Bitmap(ms);
        }
        
        // ===== NEW ====== //
        private void UserProfileViewForm_Deactivate(object sender, EventArgs e) {
            if (!shouldClose) { return; }
            this.Close();
        }
        
        //============= RESIZE IMAGE ============//
        public static Bitmap ResizeImage(ref Image image, int width, int height) {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //moving form around
        private bool mouseDown;
        private Point lastLocation;

        private void formLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void formLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void formLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
