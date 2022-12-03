using DevExpress.XtraGrid.Views.Tile;
using LeaveMeAlone._AutoParts.Tires;
using LeaveMeAlone._Cart;
using LeaveMeAlone._Groups;
using LeaveMeAlone._Information;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.AutoPart;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMeAlone
{
    public partial class TireViewForm : Form
    {
        private readonly AutoPart autoPart;
        private CartItem cartItem;

        public static bool shouldClose = true;

        private bool changing = true;

        private Color original;
        private ImageFormat format;

        public static TireViewForm tireViewFormAdmin;

        public TireViewForm(AutoPart autoPart) {
            InitializeComponent();

            tireViewFormAdmin = this;

            SetInformation(autoPart);
            this.autoPart = autoPart;
        }

        public TireViewForm(CartItem cartItem, bool order = false) {
            InitializeComponent();
            
            tireViewFormAdmin = this;

            if (!order) {
                btnRemoveAmountFromCart.Visible = true;
                btnRemoveAllFromCart.Visible = true;
                labelCurrentAmount.Visible = true; //CHANGE THAT LATER SO YOU CAN SEE THAT EVERYTIME
            } else {
                //dey alredi false
                //btnRemoveAmountFromCart.Visible = false;
                //btnRemoveAllFromCart.Visible = false;
                //labelCurrentAmount.Visible = false;
                labelAmount.Visible = false;
                labelCurrentAmount.Visible = false;
                btnAddToCart.Visible = false;
                txtAmount.Visible = false;
            }

            /*
             COULD MAKE IT THAT YOU CAN ALWAYS REMOVE PARTS FROM CART BUT --> WOULD ALWAYS NEED
             TO KNOW HOW MUCH OF THIS ITEM U HAVE --> WHEN  ADD CALL FUNCTION HERE
             */

            this.autoPart = new AutoPart(cartItem.cartItem.AutoPart);

            SetCartInformation(cartItem);

            this.cartItem = cartItem;
        }

        private void SetInformation(AutoPart autoPart) {

            if (!string.IsNullOrEmpty(autoPart.autoPart.Name)) {
                txtName.Text = autoPart.autoPart.Name;
            }
            if (!string.IsNullOrEmpty(autoPart.autoPart.ProducerName)) {
                txtProducer.Text = autoPart.autoPart.ProducerName;
            }
            if (!string.IsNullOrEmpty("" +autoPart.autoPart.DeliveryDeadline)) {
                txtDeliveryDeadline.Text = "" + autoPart.autoPart.DeliveryDeadline;
            }
            if (!string.IsNullOrEmpty(autoPart.autoPart.Price + "")) {
                txtPrice.Text = autoPart.autoPart.Price + "";
            }
            if (!string.IsNullOrEmpty(autoPart.autoPart.Description)) {
                txtDescription.Text = autoPart.autoPart.Description;
            }
            if (!string.IsNullOrEmpty(autoPart.autoPart.TechnicalDetails)) {
                string[] detailsData = autoPart.autoPart.TechnicalDetails.Split(',');
                Dictionary<string, string> technicalDetails = new Dictionary<string, string>();
                foreach (var v in detailsData) {
                    technicalDetails.Add(v.Substring(0, v.IndexOf(':')), v.Substring(v.IndexOf(':') + 1));  
                }
                foreach (TextBox t in panel1.Controls.OfType<TextBox>().ToList()) {
                    if (!string.IsNullOrEmpty(t.AccessibleName)) {
                        if (technicalDetails.ContainsKey(t.AccessibleName)) {
                            if (!string.IsNullOrEmpty(technicalDetails[t.AccessibleName])) {
                                t.Text = technicalDetails[t.AccessibleName];
                                //technicalDetails.TryGetValue(t.AccessibleName); maybe could do with this one
                            } else {
                                t.Text = "Ni podatka";
                            }
                        }
                    } else {
                        //if (string.IsNullOrEmpty(t.Text) && !t.Name.Equals(txtAdminPassword.Name)) {
                        //    t.Text = "Ni podatka";
                        //}
                    }
                }
                txtDescription.Text = autoPart.autoPart.Description;
            }

            //can never happen because the picture will always be added --> if it happens --> error on server
            if (!string.IsNullOrEmpty(autoPart.autoPart.Picture)) {
                autoPartPicture.BackgroundImage = autoPart.Picture;
            } else {
                autoPartPicture.BackgroundImage = Properties.Resources.noImage;
            }
            foreach (TextBox t in panel1.Controls.OfType<TextBox>().ToList()) {
                //if (string.IsNullOrEmpty(t.Text) && !t.Name.Equals(txtAdminPassword.Name)) {
                //    t.Text = "Ni podatka";
                //}
            }
        }

        private void SetCartInformation(CartItem cartItem) {
            AutoPartViewModel autoPart = cartItem.cartItem.AutoPart;

            if (!string.IsNullOrEmpty(autoPart.Name)) {
                txtName.Text = autoPart.Name;
            }
            if (!string.IsNullOrEmpty(autoPart.ProducerName)) {
                txtProducer.Text = autoPart.ProducerName;
            }
            if (!string.IsNullOrEmpty("" + autoPart.DeliveryDeadline)) {
                txtDeliveryDeadline.Text = "" + autoPart.DeliveryDeadline;
            }
            if (!string.IsNullOrEmpty(autoPart.Price + "")) {
                txtPrice.Text = autoPart.Price + "";
            }
            if (!string.IsNullOrEmpty(autoPart.Description)) {
                txtDescription.Text = autoPart.Description;
            }
            if (!string.IsNullOrEmpty(autoPart.TechnicalDetails)) {
                string[] detailsData = autoPart.TechnicalDetails.Split(',');
                Dictionary<string, string> technicalDetails = new Dictionary<string, string>();
                foreach (var v in detailsData) {
                    technicalDetails.Add(v.Substring(0, v.IndexOf(':')), v.Substring(v.IndexOf(':') + 1));
                }
                foreach (TextBox t in panel1.Controls.OfType<TextBox>().ToList()) {
                    if (!string.IsNullOrEmpty(t.AccessibleName)) {
                        if (technicalDetails.ContainsKey(t.AccessibleName)) {
                            if (!string.IsNullOrEmpty(technicalDetails[t.AccessibleName])) {
                                t.Text = technicalDetails[t.AccessibleName];
                                //technicalDetails.TryGetValue(t.AccessibleName); maybe could do with this one
                            } else {
                                t.Text = "Ni podatka";
                            }
                        }
                    } else {
                        //if (string.IsNullOrEmpty(t.Text) && !t.Name.Equals(txtAdminPassword.Name)) {
                        //    t.Text = "Ni podatka";
                        //}
                    }
                }
                txtDescription.Text = autoPart.Description;
                labelCurrentAmount.Text = "V košarici imate trenutno " + cartItem.Amount + " takšnih izdelkov.";
                this.cartItem = cartItem;
            }

            //can never happen because the picture will always be added --> if it happens --> error on server
            if (!string.IsNullOrEmpty(autoPart.Picture)) {
                autoPartPicture.BackgroundImage = cartItem.Picture;
            } else {
                autoPartPicture.BackgroundImage = Properties.Resources.noImage;
            }
            foreach (TextBox t in panel1.Controls.OfType<TextBox>().ToList()) {
                //if (string.IsNullOrEmpty(t.Text) && !t.Name.Equals(txtAdminPassword.Name)) {
                //    t.Text = "Ni podatka";
                //}
            }
        }

        public void SetCartSuccess(CartItem cartItem, int which) {
            string s = "";
            if (which == 1) {
                s = "Izbira je bila dodana v košarico.";
            } else if (which == 2) {
                s = "Število teh produktov je bilo odstranjenih iz košarice.";
            } else {
                s = "Produkt je bil v celoti odstranjen iz košarice.";
                shouldClose = false;
                MessageBox.Show(s);
                shouldClose = true;
                this.Close();
                return;
            }
            shouldClose = false;
            MessageBox.Show(s);
            SetCartInformation(cartItem);
            shouldClose = true;
        }

        //public void ChangeAmountText() {
        // TO DO - CALL AFTER YOU ADD/REMOVE CERTAIN AMOUNT OF THIS PROCUST FROM BAZA SO THIS SHIT SETT S NEW INFO FOR THE TESTOBX AND LBERL
        //}

        //============= TRANSFORM STRING INTO IMAGE ============//
        public Bitmap stringToImage(string inputString)
        {
            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            return new Bitmap(ms);
        }
        
        // ===== NEW ====== //
        private void UserProfileViewForm_Deactivate(object sender, EventArgs e) {
            if (!shouldClose) { return; }
            this.Close();
        }
        
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //moving form around
        private bool mouseDown;
        private Point lastLocation;

        private void formLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void formLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void formLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void addToCartButton_Click(object sender, EventArgs e) {
            int amount = 0;
            try {
                amount = Convert.ToInt16(txtAmount.Text.Trim());
                if (amount <= 0) { throw new Exception(); }
            } catch (Exception ex) {
                shouldClose = false;
                MessageBox.Show("Neveljavno število v polju 'Količina'.");
                txtAmount.Text = "";
                shouldClose = true;
                return;
            }
            formMain.mainForm.FunctionSummoner(39, autoPart: this.autoPart.autoPart, amount: amount);
            txtAmount.Text = "";
        }

        private void btnRemoveAmountFromCart_Click(object sender, EventArgs e) {
            int amount = 0;
            try {
                amount = Convert.ToInt16(txtAmount.Text.Trim());
                if (amount <= 0) { throw new Exception(); }
            } catch (Exception ex) {
                shouldClose = false;
                MessageBox.Show("Neveljavno število v polju 'Količina'.");
                txtAmount.Text = "";
                shouldClose = true;
                return;
            }
            if (amount < cartItem.Amount) {
                formMain.mainForm.FunctionSummoner(40, autoPart: this.cartItem.cartItem.AutoPart, amount: amount);
                txtAmount.Text = "";
                return;
            }
            formMain.mainForm.FunctionSummoner(41, autoPart: this.cartItem.cartItem.AutoPart);
            txtAmount.Text = "";
        }

        private void btnRemoveAllFromCart_Click(object sender, EventArgs e) {
            formMain.mainForm.FunctionSummoner(41, autoPart: this.cartItem.cartItem.AutoPart);
        }
    }
}
