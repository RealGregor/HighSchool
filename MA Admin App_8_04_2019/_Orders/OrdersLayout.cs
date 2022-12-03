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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.Utils;
using LeaveMeAlone._Cart;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Data.UI.ViewModels.ViewModels;

namespace LeaveMeAlone {
    public partial class OrdersLayout : UserControl {
        public static bool showingOneOrder = false;

        private UserProfileViewFormAdmin userProfileViewForm;

        private Color original;
        private int which = 0;

        private bool first = true;

        public OrdersLayout() {
            InitializeComponent();
            original = coWorkersButton.FlatAppearance.BorderColor;

            coWorkersButton.FlatAppearance.BorderColor = Color.Purple;
            coWorkersButton.ForeColor = Color.Purple;
            which = 1;
        }

        public void SetOrdersDataControlSource(BindingList<Order> list) {
            if (!first) { return; }
            first = false;

            ordersData.RowHeadersVisible = false;
            ordersData.DefaultCellStyle.SelectionBackColor = ordersData.DefaultCellStyle.BackColor;
            ordersData.DefaultCellStyle.SelectionForeColor = ordersData.DefaultCellStyle.ForeColor;
            ordersData.AllowUserToResizeRows = false;
            ordersData.AllowUserToResizeColumns = false;

            ordersData.RowTemplate.MinimumHeight = 90;
            ordersData.RowTemplate.ReadOnly = true;

            ordersData.DataSource = list;

            //ordersData.Columns[0].Visible = false;

            //not 0 -> but 1
            ordersData.Columns[0].HeaderText = "Ime uporabnika";
            ordersData.Columns[1].HeaderText = "Količina izdelkov v naročilu";
            ordersData.Columns[2].HeaderText = "Skupna cena";
            ordersData.Columns[3].HeaderText = "Datum naročila";

            foreach (DataGridViewColumn data in ordersData.Columns) {
                data.DefaultCellStyle.Font = new Font("Microsoft YaHei", 16);
                if (data.Name.Equals("Name")) {
                    data.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    continue;
                }
                data.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            ordersData.Visible = true;
            cartItems.Visible = false;
            btnClose.Visible = false;

            showingOneOrder = false;
        }

        private void btnApplyFilters_Click(object sender, EventArgs e) {
            DateTime date = dateTimePicker1.Value.Date;

            ordersData.Visible = true;
            cartItems.Visible = false;
            btnClose.Visible = false;

            showingOneOrder = false;

            formMainAdmin.mainForm.FunctionSummoner(45, date: date.ToString());
        }

        private void ordersData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) { return; }

            if (e.ColumnIndex == 0) {
                Order selectedOrder = (Order)(ordersData.Rows[e.RowIndex].DataBoundItem);


                UserViewModel userData = selectedOrder.CartItems[0].cartItem.User;

                if (userProfileViewForm != null) {
                    userProfileViewForm.Close();
                }
                userProfileViewForm = new UserProfileViewFormAdmin(userData);
                userProfileViewForm.Show();
                return;
            }

            Order order = (Order)(ordersData.Rows[e.RowIndex].DataBoundItem);

            cartItems.SetCartItemsDataControlSource(new BindingList<CartItem>(order.CartItems));

            cartItems.Visible = true;
            ordersData.Visible = false;
            btnClose.Visible = true;

            showingOneOrder = true;
        }
    }
}
