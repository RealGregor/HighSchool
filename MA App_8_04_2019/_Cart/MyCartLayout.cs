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
    public partial class MyCartLayout : UserControl
    {
        private BindingList<Group> listSuitableGroups = null;

        private bool first = true;

        private TireViewForm tireViewForm;
        private LightViewForm lightViewForm;
        private OilViewForm oilViewForm;
        private FilterViewForm filterViewForm;

        public MyCartLayout()
        {
            InitializeComponent();
            //txtCreateGroupPassword.Properties.PasswordChar = '*';
        }

        public void SetCartItemsDataControlSource(BindingList<CartItem> list) {
            if (!first) { return; }
            first = false;

            cartData.RowHeadersVisible = false;
            //employeesData.Enabled = false;
            cartData.DefaultCellStyle.SelectionBackColor = cartData.DefaultCellStyle.BackColor;
            cartData.DefaultCellStyle.SelectionForeColor = cartData.DefaultCellStyle.ForeColor;
            cartData.AllowUserToResizeRows = false;
            cartData.AllowUserToResizeColumns = false;

            cartData.RowTemplate.MinimumHeight = 90;
            cartData.RowTemplate.ReadOnly = true;

            cartData.DataSource = list;

            cartData.Columns[0].Visible = false;

            cartData.Columns[1].HeaderText = "Slika Avto dela";
            cartData.Columns[2].HeaderText = "Ime";
            cartData.Columns[3].HeaderText = "Proizvajalec";
            cartData.Columns[4].HeaderText = "Rok Dostave";
            cartData.Columns[5].HeaderText = "Količina";
            cartData.Columns[6].HeaderText = "Skupna Cena";

            foreach (DataGridViewColumn data in cartData.Columns) {
                data.DefaultCellStyle.Font = new Font("Microsoft YaHei", 16);
                if (data.Name.Equals("Name")) {
                    data.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    continue;
                }
                if (data.Name.Equals("Picture")) {
                    continue;
                }
                data.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void cartData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) { return; }
            CartItem cartItem = (CartItem)(cartData.Rows[e.RowIndex].DataBoundItem);

            switch (cartItem.cartItem.AutoPart.Category) {
                case "Tire":
                    if (tireViewForm != null) {
                        tireViewForm.Close();
                    }
                    tireViewForm = new TireViewForm(cartItem);
                    tireViewForm.Show();
                    break;
                case "Light":
                    if (lightViewForm != null) {
                        lightViewForm.Close();
                    }
                    lightViewForm = new LightViewForm(cartItem);
                    lightViewForm.Show();
                    break;
                case "Oil":
                    if (oilViewForm != null) {
                        oilViewForm.Close();
                    }
                    oilViewForm = new OilViewForm(cartItem);
                    oilViewForm.Show();
                    break;
                case "Filter":
                    if (filterViewForm != null) {
                        filterViewForm.Close();
                    }
                    filterViewForm = new FilterViewForm(cartItem);
                    filterViewForm.Show();
                    break;
            }

            
        }

        private void btnAddOrder_Click(object sender, EventArgs e) {
            formMain.mainForm.FunctionSummoner(43, password: txtUserPass.Text);
            txtUserPass.Text = "";
        }
    }
}
