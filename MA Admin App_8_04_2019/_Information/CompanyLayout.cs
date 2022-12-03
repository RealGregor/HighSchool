using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using LMA.Data.UI.ViewModels.ViewModels;
using RestSharp;
using LeaveMeAlone._Groups;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.Utils;
using LeaveMeAlone._Information;
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LeaveMeAlone
{
    public partial class CompanyLayout : UserControl
    {
        private EmployeeProfileViewFormAdmin userProfileViewForm;

        private List<string> favouritesEmails = null;

        //INVITING USER TO GROUPS
        private string userNameAndSurname = null;
        private List<string> groupsIDs = new List<string>();
        private string focusedEmail = null;

        private bool favorite = false;

        public int which = 0;

        bool ok = false;
        bool inviteOk = false;

        public CompanyLayout()
        {
            InitializeComponent();
            original = aboutUsButton.FlatAppearance.BorderColor;
            
            aboutUsButton.FlatAppearance.BorderColor = Color.Purple;
            aboutUsButton.ForeColor = Color.Purple;
            which = 1;

        }

        public void SetEmployeesDataControlSource(BindingList<Employee> list)
        {
            employees.SetEmployeesDataControlSource(list);
            //panelControl2.Visible = false;
            //if (formMainAdmin.mainForm != null && favouritesEmails == null)
            //{
            //    favouritesEmails = formMainAdmin.mainForm.GetFavouritesEmails();//has the actual reference to the main form's list of favourites' emails
            //}
            if (ok) {
                //tileView1.AnimateArrival = true;
                //tileView1.FindFilterText = "Jana";
                //tileView1.OptionsFind.HighlightFindResults = false;
                //clear search after that
                return;
            }
            ok = true;
            
            

            //tileView1.AnimateArrival = true;
            //tileView1.ItemCustomize += TileView1_ItemCustomize;
            //employeesData.DataSource = list;
            //tileView1.ItemClick += TileView1_ItemClick;
            //tileView1.ItemRightClick += TileView1_ItemRightClick;
            //tileView1.Focus();

        }
        
        public void ResetVisibility() { }


        public void ShowThisUserProfile(EmployeeViewModel selectedEmployeeProfile) {
            
            //adding a windows form
            if (userProfileViewForm != null) {
                userProfileViewForm.Close();
            }
            userProfileViewForm = new EmployeeProfileViewFormAdmin(selectedEmployeeProfile);
            userProfileViewForm.Show();
        }

       
        //
        //ESTHETICS
        //
        private Color original;
      
        private void aboutUsButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            aboutUsButton.ForeColor = Color.Black;
        }

        private void aboutUsButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            aboutUsButton.ForeColor = Color.Gray;
        }
        // About us button click
        private void aboutUsButton_Click(object sender, EventArgs e)
        {
            formMainAdmin.mainForm.FunctionSummoner(31);//set my friends list to visible again --> need to refresh it though -> microservice
            if (which == 1)
            {
                return;
            }
            which = 1;

            employees.Visible = false;
            //friendRequests.Visible = false;
            addEmployee.Visible = true;
           
            aboutUsButton.FlatAppearance.BorderColor = Color.Purple;
            aboutUsButton.ForeColor = Color.Purple;

            employeesButton.FlatAppearance.BorderColor = original;
            employeesButton.ForeColor = Color.Gray;

            friendRequestsButton.FlatAppearance.BorderColor = original;
            friendRequestsButton.ForeColor = Color.Gray;
        }

        //notifications
        private void employeesButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            employeesButton.ForeColor = Color.Black;
        }

        private void employeesButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 2)
            {
                //refresh list -> list which indicates which people match the user's constraints
                return;
            }
            employeesButton.ForeColor = Color.Gray;
        }
        //click
        private void employeesButton_Click(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            formMainAdmin.mainForm.friendPanelVisible = 2;
            formMainAdmin.mainForm.FunctionSummoner(31);//maybe do it ath the start of the app
                                                   //so you don't need to do it every time 
                                                   //you click the button 
            which = 2;

            addEmployee.Visible = false;
            //friendRequests.Visible = false;
            employees.Visible = true;

            employeesButton.FlatAppearance.BorderColor = Color.Purple;
            employeesButton.ForeColor = Color.Purple;

            aboutUsButton.FlatAppearance.BorderColor = original;
            aboutUsButton.ForeColor = Color.Gray;

            friendRequestsButton.FlatAppearance.BorderColor = original;
            friendRequestsButton.ForeColor = Color.Gray;
        }

        //friend request button
        private void friendRequestButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            employeesButton.ForeColor = Color.Black;
        }

        private void friendRequestButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            employeesButton.ForeColor = Color.Gray;

        }

        private void friendRequestButton_Click(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            formMainAdmin.mainForm.friendPanelVisible = 3;
            which = 3;

            addEmployee.Visible = false;
            employees.Visible = false;
            //friendRequests.Visible = true;

            friendRequestsButton.FlatAppearance.BorderColor = Color.Purple;
            friendRequestsButton.ForeColor = Color.Purple;

            aboutUsButton.FlatAppearance.BorderColor = original;
            aboutUsButton.ForeColor = Color.Gray;

            employeesButton.FlatAppearance.BorderColor = original;
            employeesButton.ForeColor = Color.Gray;
        }


        //IMPLEMENT THIS === TO DO === REFRESH BUTTON
        private void refreshButton_MouseEnter(object sender, EventArgs e)
        {
            //refreshButton.BackgroundImage = Properties.Resources.RefreshHover1;
        }

        private void refreshButton_MouseLeave(object sender, EventArgs e)
        {
            //refreshButton.BackgroundImage = Properties.Resources.RefreshNormal2;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (formMainAdmin.mainForm != null) {
                formMainAdmin.mainForm.FunctionSummoner(31);
            }
        }

        private void closeInviteToGroup_Click(object sender, EventArgs e)
        {
            //panelControl2.Visible = false;
            //employeesData.Visible = true;
            //
        }
        

        //bar button
        private void inviteToGroups_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //userNameAndSurname = "Invite '" + tileView1.GetFocusedRowCellValue("Name") + " " + tileView1.GetFocusedRowCellValue("Surname") + "' to:";
            //inviteNameAndSurnameLabel.Text = userNameAndSurname;
            //string email = (string)tileView1.GetFocusedRowCellValue("Email");
            //focusedEmail = email;
            //if (formMain.mainForm == null) { return; }
            //formMain.mainForm.FunctionSummoner(28, email: email);//get all groups without the given user in them
        }

        //add user to given groups -> if its empty, then do nothing
        private void sendGroupInvitesButton_Click(object sender, EventArgs e)
        {
            if (formMainAdmin.mainForm != null && groupsIDs.Count > 0) {
                formMainAdmin.mainForm.FunctionSummoner(34, email: focusedEmail, groupsIDs: groupsIDs);
            }
        }
        
    }
}
