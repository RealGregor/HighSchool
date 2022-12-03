using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMA.Data.UI.ViewModels.ViewModels;

namespace LeaveMeAlone
{
    public partial class SettingsLayout : UserControl
    {
        private Color original;
        private int which = 1;

        public SettingsLayout()
        {
            InitializeComponent();
            original = myProfileButton.FlatAppearance.BorderColor;

            myProfileButton.FlatAppearance.BorderColor = Color.Purple;
            myProfileButton.ForeColor = Color.Purple;
        }
        public void SetMyProfileInformation(UserViewModel user, Image profilePicture) {
            myProfile.setInformation(user, profilePicture);
        }

        //============= SET AVAILABILITY CONSTRAINTS(for myProfile) ============//
        //public void SetAvailabilityConstraints(AllTimeSettingsViewModel tenantData) {
        //    //myNotificationSettings.SetAvailabilityConstraints(tenantData);
        //}


        public void ResetVisibility() { }


        private void myProfileButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 1) {
                return;
            }
            myProfileButton.ForeColor = Color.Black;
        }

        private void myProfileButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1) {
                return;
            }
            myProfileButton.ForeColor = Color.Gray;
        }
        //click
        private void myProfileButton_Click(object sender, EventArgs e)
        {
            if (which == 1) {
                return;
            }
            which = 1;
            myProfile.Visible = true;
            //myNotificationSettings.Visible = false;

            myProfileButton.FlatAppearance.BorderColor = Color.Purple;
            myProfileButton.ForeColor = Color.Purple;

            notifications_AvailabilityButton.FlatAppearance.BorderColor = original;
            notifications_AvailabilityButton.ForeColor = Color.Gray;
        }

        //notifications
        private void notificationsButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            notifications_AvailabilityButton.ForeColor = Color.Black;
        }

        private void notificationsButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            notifications_AvailabilityButton.ForeColor = Color.Gray;
        }
        //click
        private void notificationsButton_Click(object sender, EventArgs e)
        {
            if (which == 2) {
                return;
            }
            which = 2;

            //myNotificationSettings.Visible = true;
            myProfile.Visible = false;

            notifications_AvailabilityButton.FlatAppearance.BorderColor = Color.Purple;
            notifications_AvailabilityButton.ForeColor = Color.Purple;
            
            myProfileButton.FlatAppearance.BorderColor = original;
            myProfileButton.ForeColor = Color.Gray;
        }
    }
}
