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
    public partial class UserProfileViewForm : Form
    {
        private readonly EmployeeViewModel employee;

        private List<string> groupsIDs = new List<string>();

        private bool shouldClose = true;

        private bool changing = true;

        private Color original;

        public bool showingGroupInvite = false;

        public static UserProfileViewForm userProfileViewForm;

        public UserProfileViewForm(EmployeeViewModel employee)
        {
            InitializeComponent();

            userProfileViewForm = this;

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
