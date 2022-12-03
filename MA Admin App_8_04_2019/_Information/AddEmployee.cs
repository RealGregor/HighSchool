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
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LeaveMeAlone
{
    public partial class AddEmployee : UserControl
    {
        private DeleteUserAccountConfirmation_ deleteForm;
        public static AddEmployee addEmployee = null;

        private ImageFormat format = null;

        public AddEmployee()
        {
            InitializeComponent();
            addEmployee = this;
        }

        //============= CHANGE PROFILE PICTURE CLICK ============//
        private void changeProfilePicture_Click(object sender, EventArgs e) {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            openFileDialog1.Filter = "PNG images|*.png|JPG images|*.jpg|GIF images|*.gif";
            openFileDialog1.Title = "Izberite sliko";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Image image = changeEmployeePicture.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

                if (image.Height > 80 || image.Width > 80) {
                    format = image.RawFormat;
                    if (formMainAdmin.mainForm != null) { formMainAdmin.mainForm.SetImageFormat(format); }
                    image = ResizeImage(ref image, 80, 80);
                }
                changeEmployeePicture.BackgroundImage = image;
                //if (formMainAdmin.mainForm != null)
                //    formMainAdmin.mainForm.FunctionSummoner(26, image: image);
            }
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

        //ADD EMPLOYEE
        private void btnAddEmployee_Click(object sender, EventArgs e) {
            EmployeeViewModel employee = new EmployeeViewModel();
            employee.ProfilePicture = formMainAdmin.mainForm.ImageToByteArray(changeEmployeePicture.BackgroundImage);
            employee.Name = txtName.Text.Trim();
            employee.Surname = txtSurname.Text.Trim();
            employee.Email = txtEmail.Text.Trim();
            employee.PhoneNumber = txtPhoneNumber.Text.Trim();

            formMainAdmin.mainForm.FunctionSummoner(37, employee: employee);
        }
    }
}
