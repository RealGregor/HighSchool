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
    public partial class EmployeeProfileViewFormAdmin : Form
    {
        private readonly EmployeeViewModel employee;
        private string userNameAndSurname = null;

        private List<string> groupsIDs = new List<string>();

        private bool shouldClose = true;

        private bool changing = true;

        private Color original;
        private ImageFormat format;

        public bool showingGroupInvite = false;

        public static EmployeeProfileViewFormAdmin userProfileViewForm;

        public EmployeeProfileViewFormAdmin(EmployeeViewModel employee)
        {
            InitializeComponent();

            userProfileViewForm = this;

            original = changeInformationButton.FlatAppearance.BorderColor;

            changeInformationButton.FlatAppearance.BorderColor = Color.Orange;
            changeInformationButton.ForeColor = Color.RoyalBlue;

            //if (status == 2)
            //{
            //    availableIndicatorLabel.Size = new Size(60, 60);
            //    availableIndicatorLabel.Image = Properties.Resources.Available;
            //}
            txtName.Text = employee.Name;
            txtSurname.Text = employee.Surname;
            txtEmail.Text = employee.Email;
            txtPhoneNumber.Text = employee.PhoneNumber;

            //can never happen because the picture will always be added --> if it happens --> error on server
            if (employee.ProfilePicture == null || employee.ProfilePicture.Equals("")) {
                //profilePicture.BackgroundImage = Properties.Resources.icons8_account_80;
            }
            else {
                changeEmployeePicture.BackgroundImage = stringToImage(employee.ProfilePicture);
            }
            this.employee = employee;

            //btnSendGroupInvite.Visible = true;
        }
        //============= TRANSFORM STRING INTO IMAGE ============//
        public Bitmap stringToImage(string inputString)
        {
           
            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            return new Bitmap(ms);
        }




        public string GetEmail() {
            return employee.Email;
        }

        // ===== NEW ====== //
        private void UserProfileViewForm_Deactivate(object sender, EventArgs e) {
            if (!shouldClose) { return; }
            this.Close();
        }
        // ======= SEND FRIEND REQUEST ======= //
        private void btnSendFriendRequest_Click(object sender, EventArgs e)
        {
            if (formMainAdmin.mainForm == null) { return; }
            formMainAdmin.mainForm.FunctionSummoner(10, email: employee.Email);
        }
        // ======= DELETE FRIEND ======= //
        private void btnDeleteFriend_Click(object sender, EventArgs e)
        {
            if (formMainAdmin.mainForm == null) { return; }
            formMainAdmin.mainForm.FunctionSummoner(14, email: employee.Email);
            this.Close();
        }

        private void changeEmployeeInformationButton_Click(object sender, EventArgs e) {
            ChangeEmployeeViewModel changeEmployee = new ChangeEmployeeViewModel();
            if (string.IsNullOrEmpty(txtName.Text)) { changeEmployee.Name = employee.Name;} else { changeEmployee.Name = txtName.Text;}
            if (string.IsNullOrEmpty(txtSurname.Text)) { changeEmployee.Surname = employee.Surname; } else { changeEmployee.Surname = txtSurname.Text;}
            if (string.IsNullOrEmpty(txtEmail.Text)) { changeEmployee.Email = employee.Email; } else { changeEmployee.Email = txtEmail.Text; }
            if (string.IsNullOrEmpty(txtPhoneNumber.Text)) { changeEmployee.PhoneNumber = employee.PhoneNumber; } else { changeEmployee.PhoneNumber = txtPhoneNumber.Text; }

            changeEmployee.ProfilePicture = formMainAdmin.mainForm.ImageToByteArray(changeEmployeePicture.BackgroundImage);
            changeEmployee.Password = txtAdminPassword.Text.Trim();
            changeEmployee.OldEmail = employee.Email;

            txtAdminPassword.Text = "";//PASSWORD DOESN'T STAY WHEN YOU CHANGE INFO

            //shouldClose = false;

            formMainAdmin.mainForm.FunctionSummoner(39, changeEmployee: changeEmployee);
            
            /*
             set the new information for the given employee in the employee linked list
             */
        }

        private void deleteEmployeeInformationButton_Click(object sender, EventArgs e) {
            DeleteEmployeeViewModel deleteEmployee = new DeleteEmployeeViewModel();

            deleteEmployee.Email = employee.Email;
            deleteEmployee.Password = txtAdminPassword.Text.Trim();

            formMainAdmin.mainForm.FunctionSummoner(40, deleteEmployee: deleteEmployee);
            this.Close();
            /*
             delete the employee from the linked list
             */
        }

        //add user to given groups -> if its empty, then do nothing // IMPLEMENT
        private void sendGroupInvitesButton_Click(object sender, EventArgs e)
        {
            if (formMainAdmin.mainForm != null && groupsIDs.Count > 0)
            {
                formMainAdmin.mainForm.FunctionSummoner(34, email: employee.Email, groupsIDs: groupsIDs);
            }
        }
        //============= CHANGE PROFILE PICTURE CLICK ============//
        private void changeProfilePicture_Click(object sender, EventArgs e) {
            shouldClose = false;
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
            }
            shouldClose = true;
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

        //bttutosn
        private void changeInformationButton_MouseEnter(object sender, EventArgs e) {
            if (changing) {
                return;
            }
            changeInformationButton.ForeColor = Color.Black;
        }

        //asd
        private void changeInformationButton_MouseLeave(object sender, EventArgs e) {
            if (changing) {
                return;
            }
            changeInformationButton.ForeColor = Color.Gray;
        }
        //click
        private void changeInformationButton_Click(object sender, EventArgs e) {
            txtName.Enabled = true;
            txtSurname.Enabled = true;
            txtEmail.Enabled = true;
            txtPhoneNumber.Enabled = true;
            changeEmployeePicture.Enabled = true;

            deleteEmployeeInformationButton.Visible = false;
            changeEmployeeInformationButton.Visible = true;

            if (changing) {
                return;
            }
            changing = true;

            changeInformationButton.FlatAppearance.BorderColor = Color.Orange;
            changeInformationButton.ForeColor = Color.RoyalBlue;

            deleteEmployeeButton.FlatAppearance.BorderColor = original;
            deleteEmployeeButton.ForeColor = Color.Gray;

        }

        //paint
        private void changeInformationButton_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         changeInformationButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeInformationButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeInformationButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeInformationButton.FlatAppearance.BorderColor, 2, ButtonBorderStyle.Solid);
        }


        //receivedGroupRequests
        private void deleteEmployeeButton_MouseEnter(object sender, EventArgs e) {
            if (!changing) {
                return;
            }
            deleteEmployeeButton.ForeColor = Color.Black;
        }

        private void deleteEmployeeButton_MouseLeave(object sender, EventArgs e) {
            if (!changing) {
                return;
            }
            deleteEmployeeButton.ForeColor = Color.Gray;
        }
        //click
        private void deleteEmployeeButton_Click(object sender, EventArgs e) {
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtEmail.Enabled = false;
            txtPhoneNumber.Enabled = false;
            changeEmployeePicture.Enabled = false;

            deleteEmployeeInformationButton.Visible = true;
            changeEmployeeInformationButton.Visible = false;

            txtName.Text = employee.Name;
            txtSurname.Text = employee.Surname;
            txtEmail.Text = employee.Email;
            txtPhoneNumber.Text = employee.PhoneNumber;

            if (!changing) {
                return;
            }
            changing = false;
            deleteEmployeeButton.FlatAppearance.BorderColor = Color.Orange;
            deleteEmployeeButton.ForeColor = Color.RoyalBlue;

            changeInformationButton.FlatAppearance.BorderColor = original;
            changeInformationButton.ForeColor = Color.Gray;
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
