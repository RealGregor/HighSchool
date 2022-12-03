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
        }

        //=============  SET INFORMATION ============//
        public void setInformation(UserViewModel user, Image profilePic = null)
        {
            if (user.Name != null && user.Surname != null) { labelNameAndSurname.Text = "Ime in priimek: " + user.Name + " " + user.Surname; };
            if (user.Email != null) { labelEmail.Text = "Poštni naslov: " + user.Email; }
            if (user.PhoneNumber != null) { labelPhoneNumber.Text = "Telefonska številka: " + user.PhoneNumber; }
            if (user.Address != null) { labelAddress.Text = "Poštni naslov: " + user.Address; }
            if (user.AddressNumber != null) { labelAddressNumber.Text = "Poštna številka: " + user.AddressNumber; }
            if (user.Country != null) { labelCountry.Text = "Kraj: " + user.Country; }

            if (profilePic != null) {
                profilePicture.BackgroundImage = profilePic;
                changeProfilePicture.BackgroundImage = profilePic;
                return;
            }

            if (!string.IsNullOrEmpty(user.ProfilePicture))
            {
                Image image = stringToImage(user.ProfilePicture);
                profilePicture.BackgroundImage = image;
                changeProfilePicture.BackgroundImage = image;
            }
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
                    if (formMain.mainForm != null) { formMain.mainForm.SetImageFormat(format); }
                    image = ResizeImage(ref image, 80, 80);
                }
                profilePicture.BackgroundImage = image;
                changeProfilePicture.BackgroundImage = image;
                //formMain.mainForm.FunctionSummoner(26, image: image);

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
            //deleteForm.Location = new Point(PointToScreen(Location).X +10, PointToScreen(Location).Y + Height-deleteForm.Height - 70);
        }
        // CHANGE INFORMATION
        private void changeInformationButton_Click(object sender, EventArgs e) {
            foreach (var v in this.Controls.OfType<TextBox>().ToList()) {
                if (string.IsNullOrEmpty(v.Text.Trim())) {
                    return;
                }
            }

            ChangeUserViewModel newInfo = new ChangeUserViewModel();
            newInfo.Name = txtName.Text.Trim();
            newInfo.Surname = txtSurname.Text.Trim();
            newInfo.Address = txtPhoneNumber.Text.Trim();
            newInfo.AddressNumber = txtPhoneNumber.Text.Trim();
            newInfo.Country = txtPhoneNumber.Text.Trim();
            newInfo.ProfilePicture = formMain.mainForm.ImageToByteArray(changeProfilePicture.BackgroundImage);
            
            formMain.mainForm.FunctionSummoner(26, newInfo: newInfo);
            txtName.Text = "";
            txtSurname.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtAddressNumber.Text = "";
            txtCountry.Text = "";

        }
        // CHANGE PASSWORD
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (!txtConfirmPassword.Text.Trim().Equals(txtNewPassword.Text.Trim())) {
                MessageBox.Show("Novo geslo in potrditev gesla se ne ujemata.");
                txtConfirmPassword.Text = null;
                return;
            }

            string pass = txtNewPassword.Text.Trim();
            string confirmPass = txtOldPassword.Text.Trim();
            
            //if (!PasswordValid(pass)) {
            //    invalidPasswordLabel.Text = "Invalid password";
            //}

            formMain.mainForm.FunctionSummoner(27, password: confirmPass, newPassword: pass);
            //txtPassword.Text = null;
            txtConfirmPassword.Text = null;
            txtOldPassword.Text = null;
            txtNewPassword.Text = null;
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
