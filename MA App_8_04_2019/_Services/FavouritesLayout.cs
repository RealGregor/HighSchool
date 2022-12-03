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
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Tile;
using LeaveMeAlone._Groups;
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LeaveMeAlone
{
    public partial class FavouritesLayout : UserControl
    {
        private UserProfileViewForm userProfileViewForm;

        private List<string> groupsIDs = new List<string>();
        private string focusedEmail = null;

        public int which = 1;
        private bool ok = false;
        private bool inviteOk = false;

        private string userNameAndSurname = null;

        public FavouritesLayout()
        {
            InitializeComponent();
            original = coWorkersButton.FlatAppearance.BorderColor;
            
            coWorkersButton.FlatAppearance.BorderColor = Color.Purple;
            coWorkersButton.ForeColor = Color.Purple;

            

        }
        //============= RIGHT CLICK ON AN ITEM -> REMOVE USER AS PROFILE =============//
        private void TileView1_ItemRightClick(object sender, TileViewItemClickEventArgs e)
        {
            AddToFavouritesButton.ImageOptions.Image = Properties.Resources.icons8_christmas_star_20;
            AddToFavouritesButton.Caption = "Remove from favourites";
            popupMenu1.ShowPopup(MousePosition);
        }
        public void ShowThisUserProfile(EmployeeViewModel selectedUserProfile) {
            //adding a windows form
            if (userProfileViewForm != null) {
                userProfileViewForm.Close();
            }
            userProfileViewForm = new UserProfileViewForm(selectedUserProfile);
            userProfileViewForm.Show();
        }



        public void ResetVisibility() { }




        //
        //ESTHETICS
        //
        private Color original;
      
        private void coWorkersButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            coWorkersButton.ForeColor = Color.Black;
        }

        private void coWorkersButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            coWorkersButton.ForeColor = Color.Gray;
        }
        // myFriends button click
        private void coWorkersButton_Click(object sender, EventArgs e)
        {
            formMain.mainForm.FunctionSummoner(31);//set my friends list to visible again --> need to refresh it though -> microservice
            if (which == 1)
            {
                return;
            }
            which = 1;

            //employeesData.Visible = true;
           
            coWorkersButton.FlatAppearance.BorderColor = Color.Purple;
            coWorkersButton.ForeColor = Color.Purple;
        }
        //============= REMOVING USER AS FAVOURITE =============//
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //string name = (string)tileView1.GetFocusedRowCellValue("Name");
            //string surname = (string)tileView1.GetFocusedRowCellValue("Surname");
            //string email = (string)tileView1.GetFocusedRowCellValue("Email");
            //string ProfilePicture = (string)tileView1.GetFocusedRowCellValue("StringProfilePicture");
            //string PhoneNumber = (string)tileView1.GetFocusedRowCellValue("PhoneNumber");

            //UserViewModel user = new UserViewModel();
            //user.Name = name;
            //user.Surname = surname;
            //user.Email = email;
            //user.PhoneNumber = PhoneNumber;
            //user.ProfilePicture = ProfilePicture;

            //if (formMain.mainForm != null) {
            //    formMain.mainForm.FunctionSummoner(33, user: user, favourite: false);
            //}
        }

        //============= SHOW GROUPS WHERE SELECTED USER CAN BE INVITED TO =============//
        private void inviteToGroupsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //userNameAndSurname = "Invite '" + tileView1.GetFocusedRowCellValue("Name") + " " + tileView1.GetFocusedRowCellValue("Surname") + "' to:";
            //inviteNameAndSurnameLabel.Text = userNameAndSurname;
            //string email = (string)tileView1.GetFocusedRowCellValue("Email");
            //focusedEmail = email;
            //if (formMain.mainForm == null) { return; }
            //formMain.mainForm.FunctionSummoner(28, email: email);//get all groups without the given user in them
        }
        //============= CLOSE INVITE TO GROUP =============//
        private void closeInviteToGroup_Click(object sender, EventArgs e)
        {
            //panelControl2.Visible = false;
            ////employeesData.Visible = true;
            //
        }
       
        //add user to given groups -> if its empty, then do nothing
        private void sendGroupInvitesButton_Click(object sender, EventArgs e)
        {
            if (formMain.mainForm != null && groupsIDs.Count > 0)
            {
                formMain.mainForm.FunctionSummoner(34, email: focusedEmail, groupsIDs: groupsIDs);
            }
        }
    }
}
