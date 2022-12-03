using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using LMA.Data.UI.ViewModels.ViewModels;

namespace LeaveMeAlone._Information
{
    public class Employee
    {
        public Image ProfilePicture { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }//KategorijaHitros: /
        public string StringProfilePicture { get; set; }

        public Employee(UserViewModel user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            if (PhoneNumber == null) {
                PhoneNumber = "";
            }
            if (!string.IsNullOrEmpty(user.ProfilePicture))
            {
                Image i = StringToImage(user.ProfilePicture);
                ProfilePicture = OvalImage(i);
                StringProfilePicture = user.ProfilePicture;
            }
            else {
                ProfilePicture = OvalImage(Properties.Resources.icons8_account_80);
                StringProfilePicture = null;
            }
        }
        //============= TRANSFORM STRING INTO IMAGE ============//
        public Bitmap StringToImage(string inputString)
        {

            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            return new Bitmap(ms);
        }
        //============= CREATE IMAGE WITH ROUNDED EDGES ============//
        private Bitmap RoundCorners(Image StartImage, int CornerRadius)
        {
            CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
            using (Graphics g = Graphics.FromImage(RoundedImage))
            {
                //g.Clear(BackgroundColor);
                g.SmoothingMode = SmoothingMode.HighQuality;//anti alias
                Brush brush = new TextureBrush(StartImage);
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                g.FillPath(brush, gp);
                return RoundedImage;
            }
        }
        //============= CREATE ROUND IMAGE ============//
        private Bitmap OvalImage(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, img.Width, img.Height);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.SetClip(gp);
                    gr.DrawImage(img, Point.Empty);
                }
            }
            return bmp;
        }
    }
}
