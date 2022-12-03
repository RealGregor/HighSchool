using LeaveMeAlone._Groups;
using LMA.Data.UI.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LeaveMeAlone
{
    public partial class GroupsLayout : UserControl
    {
        private Color original;
        public int which = 1;

        private EmployeeProfileViewFormAdmin userProfileViewForm;
        
        public GroupsLayout()
        {
            InitializeComponent();
            original = myGroupsButton.FlatAppearance.BorderColor;

            panelButtons.SendToBack();

            myGroupsButton.FlatAppearance.BorderColor = Color.Purple;
            myGroupsButton.ForeColor = Color.Purple;
            
            //waiting screen?
        }
        //public void ResetVisibility() {
        //    if (which == 1)
        //    {
        //        myGroups.Visible = true;
        //    }
        //    else if (which == 2) {
        //        join_CreateGroups.Visible = true;
        //    }
        //    else {
        //        groupRequestsLayout.Visible = true;
        //    }
        //}
        
        //============= SHOWING SELECTED USER PROFILE =============//
        public void ShowThisUserProfile(EmployeeViewModel selectedEmployeeProfile)
        {
            if (userProfileViewForm != null)
            {
                userProfileViewForm.Close();
            }
            userProfileViewForm = new EmployeeProfileViewFormAdmin(selectedEmployeeProfile);// change if you want to send group requests here too
            userProfileViewForm.Show();
        }

        //============= MYGROUPS BUTTON =============//
        private void myGroupsButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            myGroupsButton.ForeColor = Color.Black;
        }

        private void myGroupsButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            myGroupsButton.ForeColor = Color.Gray;
        }

        private void myGroupsButton_Click(object sender, EventArgs e)
        {
            formMainAdmin.mainForm.FunctionSummoner(6);
            if (which == 1)
            {
                return;
            }
            formMainAdmin.mainForm.groupPanelVisible = 1;
            which = 1;
            /*set my friends list to visible again --> need to refresh it though -> microservice*/
            
            //myGroups.Visible = true;

            myGroupsButton.FlatAppearance.BorderColor = Color.Purple;
            myGroupsButton.ForeColor = Color.Purple;

            joinAndCreateAGroupButton.FlatAppearance.BorderColor = original;
            joinAndCreateAGroupButton.ForeColor = Color.Gray;

            groupRequestsButton.FlatAppearance.BorderColor = original;
            groupRequestsButton.ForeColor = Color.Gray;
        }

        //============= CREATE/JOIN GROUPS BUTTON =============//
        private void joinAndCreateAGroupButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            joinAndCreateAGroupButton.ForeColor = Color.Black;
        }

        private void joinAndCreateAGroupButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 2)
            {
                //refresh list -> list which indicates which people match the user's constraints
                return;
            }
            joinAndCreateAGroupButton.ForeColor = Color.Gray;
        }

        private void joinAndCreateAGroupButton_Click(object sender, EventArgs e)
        {
            if (which == 2)
            {
                //string[] info = join_CreateGroups.GetInformation();
                //formMain.mainForm.FunctionSummoner(8, "", "", info[1], info[0]);
                return;
            }
            formMainAdmin.mainForm.groupPanelVisible = 2;
            which = 2;
            
            joinAndCreateAGroupButton.FlatAppearance.BorderColor = Color.Purple;
            joinAndCreateAGroupButton.ForeColor = Color.Purple;

            myGroupsButton.FlatAppearance.BorderColor = original;
            myGroupsButton.ForeColor = Color.Gray;

            groupRequestsButton.FlatAppearance.BorderColor = original;
            groupRequestsButton.ForeColor = Color.Gray;
        }

        //============= GROUP REQUESTS & INVITES =============//
        private void friendRequestButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            groupRequestsButton.ForeColor = Color.Black;
        }

        private void friendRequestButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            groupRequestsButton.ForeColor = Color.Gray;

        }

        private void groupRequestButton_Click(object sender, EventArgs e)
        {
            //if (GroupRequestsLayout.which == 1) {
            //    formMainAdmin.mainForm.FunctionSummoner(16);//get all sent group requests
            //}
            //else if (GroupRequestsLayout.which == 3)
            //{
            //    formMainAdmin.mainForm.FunctionSummoner(24);//get sent group invites
            //}
            //else{
            //    formMainAdmin.mainForm.FunctionSummoner(25);//get received group invites
            //}
            if (which == 3)
            {
                return;
            }
            formMainAdmin.mainForm.groupPanelVisible = 3;
            which = 3;

            groupRequestsButton.FlatAppearance.BorderColor = Color.Purple;
            groupRequestsButton.ForeColor = Color.Purple;

            myGroupsButton.FlatAppearance.BorderColor = original;
            myGroupsButton.ForeColor = Color.Gray;

            joinAndCreateAGroupButton.FlatAppearance.BorderColor = original;
            joinAndCreateAGroupButton.ForeColor = Color.Gray;
        }
    }
}
