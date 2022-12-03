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

namespace LeaveMeAlone._Groups
{
    public partial class MyOrdersLayout : UserControl
    {
        public static bool showingOneOrder = false;

        private bool first = true;

        public MyOrdersLayout()
        {
            InitializeComponent();
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
            ordersData.Columns[0].HeaderText = "Imena naročenih izdelkov";
            ordersData.Columns[1].HeaderText = "Rok dostave";
            ordersData.Columns[2].HeaderText = "Količina izdelkov v naročilu";
            ordersData.Columns[3].HeaderText = "Skupna cena";
            ordersData.Columns[4].HeaderText = "Datum naročila";

            foreach (DataGridViewColumn data in ordersData.Columns) {
                data.DefaultCellStyle.Font = new Font("Microsoft YaHei", 16);
                if (data.Name.Equals("Name")) {
                    data.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    continue;
                }
                data.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void cartData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) { return; }
            Order order = (Order)(ordersData.Rows[e.RowIndex].DataBoundItem);

            cartItems.SetCartItemsDataControlSource(new BindingList<CartItem>(order.CartItems));

            cartItems.Visible = true;
            ordersData.Visible = false;
            btnClose.Visible = true;

            showingOneOrder = true;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            ordersData.Visible = true;
            cartItems.Visible = false;
            btnClose.Visible = false;

            showingOneOrder = false;
        }
    }
}
