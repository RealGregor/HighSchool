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
    public partial class TiresLayout : UserControl
    {
        private Color original;

        public int which = 0;

        public TiresLayout()
        {
            InitializeComponent();
            original = addingTiresButton.FlatAppearance.BorderColor;
            
            addingTiresButton.FlatAppearance.BorderColor = Color.Purple;
            addingTiresButton.ForeColor = Color.Purple;
            which = 1;

        }

        public void SetAutoPartsDataControlSource(BindingList<AutoPart> list)
        {
            searchTiresLayout.SetAutoPartsDataControlSource(list);
        }
        public void SetAutoPartData(AutoPartViewModel autoPart)
        {
            changeAndDeleteTiresLayout.SetAutoPartData(autoPart);
        }
        public Guid GetActiveAutoPartID() {
            return changeAndDeleteTiresLayout.GetActiveAutoPartID();
        }
        public void ClearAutoPartData() {
            changeAndDeleteTiresLayout.ClearAutoPartData();
        }
      

        private void addTiresButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            addingTiresButton.ForeColor = Color.Black;
        }

        private void addTiresButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            addingTiresButton.ForeColor = Color.Gray;
        }
        // About us button click
        private void addTiresButton_Click(object sender, EventArgs e)
        {
            formMainAdmin.mainForm.FunctionSummoner(31);//set my friends list to visible again --> need to refresh it though -> microservice
            if (which == 1)
            {
                return;
            }
            which = 1;

            addTiresLayout.Visible = true;
            searchTiresLayout.Visible = false;
            changeAndDeleteTiresLayout.Visible = false;            
           
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
            formMainAdmin.mainForm.friendPanelVisible = 2;

            which = 2;

            searchTiresLayout.Visible = true;
            addTiresLayout.Visible = false;
            changeAndDeleteTiresLayout.Visible = false;

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

            changeAndDeleteTiresLayout.Visible = true;
            addTiresLayout.Visible = false;
            searchTiresLayout.Visible = false;

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

        private void closeInviteToGroup_Click(object sender, EventArgs e)
        {
            //panelControl2.Visible = false;
            //employeesData.Visible = true;
            //
        }
    }
}
