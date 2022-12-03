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
using LeaveMeAlone._AutoParts.Tires;

namespace LeaveMeAlone
{
    public partial class FiltersLayout : UserControl
    {
        private EmployeeProfileViewFormAdmin userProfileViewForm;

        private bool favorite = false;

        public int which = 0;

        bool ok = false;
        bool inviteOk = false;

        public FiltersLayout()
        {
            InitializeComponent();
            original = addingTiresButton.FlatAppearance.BorderColor;
            
            addingTiresButton.FlatAppearance.BorderColor = Color.Purple;
            addingTiresButton.ForeColor = Color.Purple;
            which = 1;

        }

        public void SetAutoPartsDataControlSource(BindingList<AutoPart> list)
        {
            searchFiltersLayout.SetAutoPartsDataControlSource(list);
        }
        public void SetAutoPartData(AutoPartViewModel autoPart)
        {
            changeAndDeleteFiltersLayout.SetAutoPartData(autoPart);
        }
        public Guid GetActiveAutoPartID() {
            return changeAndDeleteFiltersLayout.GetActiveAutoPartID();
        }
        public void ClearAutoPartData() {
            changeAndDeleteFiltersLayout.ClearAutoPartData();
        }
        //============= ADD/REMOVE USER FROM FAVOURITES CLICK =============//
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        
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
            addingTiresButton.ForeColor = Color.Black;
        }

        private void aboutUsButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            addingTiresButton.ForeColor = Color.Gray;
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

            addFiltersLayout.Visible = true;
            searchFiltersLayout.Visible = false;
            changeAndDeleteFiltersLayout.Visible = false;

            addingTiresButton.FlatAppearance.BorderColor = Color.Purple;
            addingTiresButton.ForeColor = Color.Purple;

            searchingTiresButton.FlatAppearance.BorderColor = original;
            searchingTiresButton.ForeColor = Color.Gray;

            changingAndDeletingTiresButton.FlatAppearance.BorderColor = original;
            changingAndDeletingTiresButton.ForeColor = Color.Gray;
        }

        //notifications
        private void searchingTiresButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            searchingTiresButton.ForeColor = Color.Black;
        }

        private void searchingTiresButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 2)
            {
                //refresh list -> list which indicates which people match the user's constraints
                return;
            }
            searchingTiresButton.ForeColor = Color.Gray;
        }
        //click
        private void searchingTiresButton_Click(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }

            which = 2;

            searchFiltersLayout.Visible = true;
            addFiltersLayout.Visible = false;
            changeAndDeleteFiltersLayout.Visible = false;

            searchingTiresButton.FlatAppearance.BorderColor = Color.Purple;
            searchingTiresButton.ForeColor = Color.Purple;

            addingTiresButton.FlatAppearance.BorderColor = original;
            addingTiresButton.ForeColor = Color.Gray;

            changingAndDeletingTiresButton.FlatAppearance.BorderColor = original;
            changingAndDeletingTiresButton.ForeColor = Color.Gray;
        }

        //friend request button
        private void changingAndDeletingTiresButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            changingAndDeletingTiresButton.ForeColor = Color.Black;
        }

        private void changingAndDeletingTiresButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            changingAndDeletingTiresButton.ForeColor = Color.Gray;

        }

        private void changingAndDeletingTiresButton_Click(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            formMainAdmin.mainForm.friendPanelVisible = 3;
            which = 3;

            changeAndDeleteFiltersLayout.Visible = true;
            addFiltersLayout.Visible = false;
            searchFiltersLayout.Visible = false;

            changingAndDeletingTiresButton.FlatAppearance.BorderColor = Color.Purple;
            changingAndDeletingTiresButton.ForeColor = Color.Purple;

            addingTiresButton.FlatAppearance.BorderColor = original;
            addingTiresButton.ForeColor = Color.Gray;

            searchingTiresButton.FlatAppearance.BorderColor = original;
            searchingTiresButton.ForeColor = Color.Gray;
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
    }
}
