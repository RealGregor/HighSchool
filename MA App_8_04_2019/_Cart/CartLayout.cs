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
using LeaveMeAlone._AutoParts.Tires;
using LeaveMeAlone._Cart;

namespace LeaveMeAlone
{
    public partial class CartLayout : UserControl
    {
        private Color original;
        public int which = 1;

        private bool first = true;

        public CartLayout()
        {
            InitializeComponent();
            original = myCart.FlatAppearance.BorderColor;

            panelButtons.SendToBack();

            myCart.FlatAppearance.BorderColor = Color.Purple;
            myCart.ForeColor = Color.Purple;
            
            //waiting screen?
        }
        //============= DATA CONTROL SOURCE FOR CART ITEMS =============//
        public void SetCartItemsDataControlSource(BindingList<CartItem> list) {
            myCartLayout.SetCartItemsDataControlSource(list);
        }

        //============= DATA CONTROL SOURCE FOR ORDERS =============//
        public void SetOrdersDataControlSource(BindingList<Order> list) {
            myOrdersLayout.SetOrdersDataControlSource(list);
        }

        public void ResetVisibility() {
            //join_CreateGroups.Visible = false;
            //groupRequestsLayout.Visible = false;
            //myGroups.Visible = false;
            //myGroups.ResetVisibility();
            //if (which == 1)
            //{
            //    myGroups.Visible = true;
            //}
            //else if (which == 2) {
            //    join_CreateGroups.Visible = true;
            //}
            //else {
            //    groupRequestsLayout.Visible = true;
            //}
        }
        //============= MY CART BUTTON =============//
        private void myCartButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            myCart.ForeColor = Color.Black;
        }

        private void myCartButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            myCart.ForeColor = Color.Gray;
        }

        private void myCartButton_Click(object sender, EventArgs e)
        {
            if (which == 1)
            {
                return;
            }
            which = 1;

            formMain.mainForm.FunctionSummoner(42);

            myCartLayout.Visible = true;
            myOrdersLayout.Visible = false;
            //groupRequestsLayout.Visible = false;


            myCart.FlatAppearance.BorderColor = Color.Purple;
            myCart.ForeColor = Color.Purple;

            myOrders.FlatAppearance.BorderColor = original;
            myOrders.ForeColor = Color.Gray;

            groupRequestsButton.FlatAppearance.BorderColor = original;
            groupRequestsButton.ForeColor = Color.Gray;
        }

        //============= MY ORDERS BUTTON =============//
        private void myOrdersButton_MouseEnter(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            myOrders.ForeColor = Color.Black;
        }

        private void myOrdersButton_MouseLeave(object sender, EventArgs e)
        {
            if (which == 2) {
                return;
            }
            myOrders.ForeColor = Color.Gray;
        }

        private void myOrdersButton_Click(object sender, EventArgs e)
        {
            if (which == 2)
            {
                return;
            }
            which = 2;

            formMain.mainForm.FunctionSummoner(44);

            myOrdersLayout.Visible = true;
            myCartLayout.Visible = false;
            //groupRequestsLayout.Visible = false;

            myOrders.FlatAppearance.BorderColor = Color.Purple;
            myOrders.ForeColor = Color.Purple;

            myCart.FlatAppearance.BorderColor = original;
            myCart.ForeColor = Color.Gray;

            groupRequestsButton.FlatAppearance.BorderColor = original;
            groupRequestsButton.ForeColor = Color.Gray;
        }

        //============= GROUP REQUESTS & INVITES =============//
        private void friendRequestButton_MouseEnter(object sender, EventArgs e)
        {
            //TO DO
        }

        private void friendRequestButton_MouseLeave(object sender, EventArgs e)
        {
            //TO DO
        }

        private void groupRequestButton_Click(object sender, EventArgs e)
        {
            if (which == 3)
            {
                return;
            }
            formMain.mainForm.groupPanelVisible = 3;
            which = 3;

            //myGroups.Visible = false;
            //join_CreateGroups.Visible = false;
            //groupRequestsLayout.Visible = true;

            groupRequestsButton.FlatAppearance.BorderColor = Color.Purple;
            groupRequestsButton.ForeColor = Color.Purple;

            myCart.FlatAppearance.BorderColor = original;
            myCart.ForeColor = Color.Gray;

            myOrders.FlatAppearance.BorderColor = original;
            myOrders.ForeColor = Color.Gray;
        }
    }
}
