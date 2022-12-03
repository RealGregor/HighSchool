using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LMA.Data.UI.ViewModels.ViewModels;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace LeaveMeAlone
{
    public partial class MyProfile : UserControl
    {
        private DeleteUserAccountConfirmation_ deleteForm;
        public static MyProfile myProfile = null;

        private ImageFormat format = null;

        public MyProfile()
        {
            InitializeComponent();
            myProfile = this;

            txtPassword.Properties.PasswordChar = '*';
            txtConfirmPassword.Properties.PasswordChar = '*';
        }


        //=============  SET INFORMATION ============//
        public void setInformation(AdminViewModel admin, Image profilePic) {
            labelName.Text = admin.Name;
            labelSurname.Text = admin.Surname;
            //labelEmail.Text = admin.Email;
            if (profilePic != null) {
                profilePicture.BackgroundImage = profilePic;
                changeProfilePicture.BackgroundImage = profilePic;
            }
            labelSurname.Location = new Point(labelName.Location.X + labelName.Width + 10, labelName.Location.Y);
        }
        //=============  SET NEW INFORMATION ============//
        public void setNewInformation(AdminViewModel admin)
        {
            if (admin.Name != null) { labelName.Text = admin.Name; };
            if (admin.Surname != null) { labelSurname.Text = admin.Surname; }
            //if (admin.ProfilePicture != null && !admin.ProfilePicture.Equals(""))
            //{
            //    Image image = stringToImage(admin.ProfilePicture);
            //    profilePicture.BackgroundImage = image;
            //    changeProfilePicture.BackgroundImage = image;
            //}

            labelSurname.Location = new Point(labelName.Location.X + labelName.Width + 10, labelName.Location.Y);
        }

        //=============  STRING INTO IMAGE ============//
        public Bitmap stringToImage(string inputString)
        {
            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            return new Bitmap(ms);
        }
        //============= RESIZE IMAGE ============//
        public static Bitmap ResizeImage(ref Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        //============= CHANGE PROFILE PICTURE CLICK ============//
        private void changeProfilePicture_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            openFileDialog1.Filter = "PNG images|*.png|JPG images|*.jpg|GIF images|*.gif";
            openFileDialog1.Title = "Select an image";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image image = profilePicture.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

                if (image.Height > 80 || image.Width > 80)
                {
                    format = image.RawFormat;
                    if (formMainAdmin.mainForm != null) { formMainAdmin.mainForm.SetImageFormat(format); }
                    image = ResizeImage(ref image, 80, 80);
                }
                profilePicture.BackgroundImage = image;
                changeProfilePicture.BackgroundImage = image;
                if (formMainAdmin.mainForm != null)
                    formMainAdmin.mainForm.FunctionSummoner(26, image: image);

            }
        }


        // DELETE ACCOUNT 
        private void deleteMyAccountButton_Click(object sender, EventArgs e)
        {
            if (deleteForm != null) {
                deleteForm.Close();
            }
            deleteForm = new DeleteUserAccountConfirmation_();
            deleteForm.Show();
            deleteForm.Location = new Point(PointToScreen(Location).X +10, PointToScreen(Location).Y + Height-deleteForm.Height - 70);
        }
        // CHANGE INFORMATION
        private void changeInformationButton_Click(object sender, EventArgs e)
        {
            ChangeUserViewModel newInfo = new ChangeUserViewModel();
            newInfo.Name = txtName.Text.Trim();
            newInfo.Surname = txtSurname.Text.Trim();
            newInfo.PhoneNumber = txtPhoneNumber.Text.Trim();

            txtName.Text = newInfo.Name;
            txtSurname.Text = newInfo.Surname;
            txtPhoneNumber.Text = newInfo.PhoneNumber;


            if (InformationValid(newInfo.Name) && InformationValid(newInfo.Surname) && InformationValid(newInfo.PhoneNumber)) {
                if (formMainAdmin.mainForm == null) { return; }
                formMainAdmin.mainForm.FunctionSummoner(26, newInfo: newInfo);
                txtName.Text = null;
                txtSurname.Text = null;
                txtPhoneNumber.Text = null;
            }
        }
        // CHANGE PASSWORD
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();
            
            if (!PasswordValid(pass)) {
                invalidPasswordLabel.Text = "Invalid password";
            }
            formMainAdmin.mainForm.FunctionSummoner(27, password: confirmPass, newPassword: pass);
            txtPassword.Text = null;
            txtConfirmPassword.Text = null;
        }
       
        
        
        
        // CHANGE PASSWORD
        private bool InformationValid(string s) {
            for (int i = 0; i < s.Length; i++)
            {
                if ((!char.IsLetterOrDigit(s[i]) && s[i] != ' ' && s[i] != '\'' && s[i] != '.') || (i != 0 && !char.IsLetterOrDigit(s[i]) && s[i] == s[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }
        // CHANGE PASSWORD
        private bool PasswordValid(string s) {
            for (int i = 0; i < s.Length; i++) {
                if (!char.IsLetterOrDigit(s[i])) {
                    return false;
                }
            }
            return true;
        }
    }
}
