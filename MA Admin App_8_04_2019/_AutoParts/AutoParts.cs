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
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LeaveMeAlone._AutoParts.Tires;

namespace LeaveMeAlone
{
    public partial class AutoParts : UserControl
    {
        private EmployeeProfileViewFormAdmin employeeProfileViewForm;

        private Color original;

        private int which = 0;

        public AutoParts()
        {
            InitializeComponent();
            panelButtons.SendToBack();

            original = tiresButton.FlatAppearance.BorderColor;
            
            tiresButton.FlatAppearance.BorderColor = Color.Purple;
            tiresButton.ForeColor = Color.Purple;
        }

        public void SetAutoPartsDataControlSource(BindingList<AutoPart> list, string category)
        {
            switch (category) {
                case "Tire": tiresLayout.SetAutoPartsDataControlSource(list); break;
                case "Light": lightsLayout.SetAutoPartsDataControlSource(list); break;
                case "Oil": oilsLayout.SetAutoPartsDataControlSource(list); break;
                case "Filter": filtersLayout.SetAutoPartsDataControlSource(list); break;
                    //add default if somehow value wouldn't be as intended
            }

            
        }

        public void SetAutoPartData(AutoPartViewModel autoPart) {
            switch (autoPart.Category) {
                case "Tire": tiresLayout.SetAutoPartData(autoPart); break;
                case "Light": lightsLayout.SetAutoPartData(autoPart); break;
                case "Oil": oilsLayout.SetAutoPartData(autoPart); break;
                case "Filter": filtersLayout.SetAutoPartData(autoPart); break;
                default: MessageBox.Show("ID entered wasn't found in the database");break;
                    //add default if somehow value wouldn't be as intended
            }
        }
        public Guid GetActiveAutoPartID() {
            return tiresLayout.GetActiveAutoPartID();
        }
        public void ClearAutoPartData() {
            tiresLayout.ClearAutoPartData();
        }
        
        //
        //set data source for new people grid control source
        //
        public void ShowThisEmployeeProfile(EmployeeViewModel selectedEmployee) {
            
            //adding a windows form
            if (employeeProfileViewForm != null) {
                employeeProfileViewForm.Close();
            }
            employeeProfileViewForm = new EmployeeProfileViewFormAdmin(selectedEmployee);
            employeeProfileViewForm.Show();
        }

        //
        //ESTHETICS
        //

        private void tiresButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            tiresButton.ForeColor = Color.Black;
        }

        private void tiresButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            tiresButton.ForeColor = Color.Gray;
        }
        // myFriends button click
        private void tiresButton_Click(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            which = 1;

            tiresLayout.Visible = true;
            lightsLayout.Visible = false;
            oilsLayout.Visible = false;
            filtersLayout.Visible = true;

            tiresButton.FlatAppearance.BorderColor = Color.Purple;
            tiresButton.ForeColor = Color.Purple;

            lightsButton.FlatAppearance.BorderColor = original;
            lightsButton.ForeColor = Color.Gray;

            oilsButton.FlatAppearance.BorderColor = original;
            oilsButton.ForeColor = Color.Gray;

            filtersButton.FlatAppearance.BorderColor = original;
            filtersButton.ForeColor = Color.Gray;
        }

        //notifications
        private void lightsButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            lightsButton.ForeColor = Color.Black;
        }

        private void lightsButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 2)
            {
                //refresh list -> list which indicates which people match the user's constraints
                return;
            }
            lightsButton.ForeColor = Color.Gray;
        }
        //click
        private void lightsButton_Click(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            which = 2;

            lightsLayout.Visible = true;
            tiresLayout.Visible = false;
            oilsLayout.Visible = false;
            filtersLayout.Visible = false;

            lightsButton.FlatAppearance.BorderColor = Color.Purple;
            lightsButton.ForeColor = Color.Purple;

            tiresButton.FlatAppearance.BorderColor = original;
            tiresButton.ForeColor = Color.Gray;

            oilsButton.FlatAppearance.BorderColor = original;
            oilsButton.ForeColor = Color.Gray;

            filtersButton.FlatAppearance.BorderColor = original;
            filtersButton.ForeColor = Color.Gray;
        }

        //friend request button
        private void oilsButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            oilsButton.ForeColor = Color.Black;
        }

        private void oilsButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            oilsButton.ForeColor = Color.Gray;
        }

        private void oilsButton_Click(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            which = 3;

            oilsLayout.Visible = true;
            tiresLayout.Visible = false;
            lightsLayout.Visible = false;
            filtersLayout.Visible = false;

            oilsButton.FlatAppearance.BorderColor = Color.Purple;
            oilsButton.ForeColor = Color.Purple;

            tiresButton.FlatAppearance.BorderColor = original;
            tiresButton.ForeColor = Color.Gray;

            lightsButton.FlatAppearance.BorderColor = original;
            lightsButton.ForeColor = Color.Gray;

            filtersButton.FlatAppearance.BorderColor = original;
            filtersButton.ForeColor = Color.Gray;
        }
        
        private void filtersButton_MouseEnter(object sender, EventArgs e) {
            if (which == 4) {
                return;
            }
            filtersButton.ForeColor = Color.Black;
        }

        private void filtersButton_MouseLeave(object sender, EventArgs e) {
            if (which == 4) {
                return;
            }
            filtersButton.ForeColor = Color.Gray;
        }

        private void filtersButton_Click(object sender, EventArgs e) {
            if (which == 4) {
                return;
            }
            which = 4;

            filtersLayout.Visible = true;
            tiresLayout.Visible = false;
            lightsLayout.Visible = false;
            oilsLayout.Visible = false;

            filtersButton.FlatAppearance.BorderColor = Color.Purple;
            filtersButton.ForeColor = Color.Purple;

            oilsButton.FlatAppearance.BorderColor = original;
            oilsButton.ForeColor = Color.Gray;

            tiresButton.FlatAppearance.BorderColor = original;
            tiresButton.ForeColor = Color.Gray;

            lightsButton.FlatAppearance.BorderColor = original;
            lightsButton.ForeColor = Color.Gray;
        }
    }
}
