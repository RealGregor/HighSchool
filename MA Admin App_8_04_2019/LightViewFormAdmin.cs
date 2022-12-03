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
    public partial class LightViewFormAdmin : Form
    {
        private readonly AutoPart autoPart;
        private CartItem cartItem;

        public static bool shouldClose = true;

        private bool changing = true;

        private Color original;
        private ImageFormat format;

        public static LightViewFormAdmin lightViewFormAdmin;

        public LightViewFormAdmin(AutoPart autoPart) {
            InitializeComponent();

            lightViewFormAdmin = this;

            original = changeInformationButton.FlatAppearance.BorderColor;

            changeInformationButton.FlatAppearance.BorderColor = Color.Orange;
            changeInformationButton.ForeColor = Color.RoyalBlue;

            SetInformation(autoPart);
            this.autoPart = autoPart;
        }

        public LightViewFormAdmin(CartItem cartItem, bool order = false) {
            InitializeComponent();

            lightViewFormAdmin = this;

            if (order) {
                panel2.Visible = false;
                txtAdminPassword.Visible = false;
                labelPass.Visible = false;
                changeEmployeeInformationButton.Visible = false;
                autoPartPicture.Enabled = false;
                autoPartPicture.Cursor = Cursors.Default;
                panel1.Controls.Add(buttonClose);
                buttonClose.Visible = true;
            }

            /*
             COULD MAKE IT THAT YOU CAN ALWAYS REMOVE PARTS FROM CART BUT --> WOULD ALWAYS NEED
             TO KNOW HOW MUCH OF THIS ITEM U HAVE --> WHEN  ADD CALL FUNCTION HERE
             */

            this.autoPart = new AutoPart(cartItem.cartItem.AutoPart);

            SetCartInformation(cartItem, order);

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
                        if (string.IsNullOrEmpty(t.Text) && !t.Name.Equals(txtAdminPassword.Name)) {
                            t.Text = "Ni podatka";
                       }
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
                if (string.IsNullOrEmpty(t.Text) && !t.Name.Equals(txtAdminPassword.Name)) {
                    t.Text = "Ni podatka";
                }
            }
        }

        private void SetCartInformation(CartItem cartItem, bool order) {
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
                    t.ReadOnly = order;
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
                txtDescription.ReadOnly = order;
                txtDescription.Text = autoPart.Description;
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

        private void changeAutoPartInformationButton_Click(object sender, EventArgs e) {
            string technicalDescription = "";
            foreach (TextBox textBox in panel1.Controls.OfType<TextBox>().ToList()) {

                string name = textBox.AccessibleName;
                string text = textBox.Text.Trim();
                if (string.IsNullOrEmpty(text)) {
                    text = "Ni podatka";
                    textBox.Text = text;
                }
                if (string.IsNullOrEmpty(name)) {
                    continue;
                }
                if (technicalDescription.Equals("")) {
                    technicalDescription += name + ":" + text;
                } else {
                    technicalDescription += "," + textBox.AccessibleName + ":" + textBox.Text;
                }
            }

            try {
                ChangeAutoPartViewModel changeAutoPart = new ChangeAutoPartViewModel {
                    ID = autoPart.autoPart.ID,
                    Name = txtName.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    ProducerName = txtProducer.Text,
                    TechnicalDetails = technicalDescription,
                    DeliveryDeadline = Convert.ToInt32(txtDeliveryDeadline.Text),
                    Description = txtDescription.Text.Trim(),
                    Picture = formMainAdmin.mainForm.ImageToByteArray(autoPartPicture.BackgroundImage),
                    Password = txtAdminPassword.Text.Trim()
                };
                shouldClose = false;
                formMainAdmin.mainForm.FunctionSummoner(42, changeAutoPart: changeAutoPart);
                //shouldClose = true;
            } catch (Exception ex) {
                shouldClose = false;
                MessageBox.Show("Napaka pri pretvarjanju besede v število.");
                shouldClose = true;
                //bla bla error neki povej kakec 223 neki juha je že treba je jest
            }
            txtAdminPassword.Text = "";//PASSWORD DOESN'T STAY WHEN YOU CHANGE INFO

            //shouldClose = false;

            /*
             set the new information for the given employee in the employee linked list
             */
        }

        private void deleteAutoPartInformationButton_Click(object sender, EventArgs e) {
            DeleteAutoPartViewModel deleteAutoPart = new DeleteAutoPartViewModel();

            deleteAutoPart.ID = autoPart.autoPart.ID;
            deleteAutoPart.Password = txtAdminPassword.Text.Trim();

            formMainAdmin.mainForm.FunctionSummoner(43, deleteAutoPart: deleteAutoPart);
            /*only close if the request went through ok -- IM LAZY DUNT WAN DUIT*/
            this.Close();
            /*
             delete the employee from the linked list
             */
        }
        
        //============= CHANGE PROFILE PICTURE CLICK ============//
        private void changePicture_Click(object sender, EventArgs e) {
            shouldClose = false;
            // Displays an OpenFileDialog so the user can select a Cursor.  
            openFileDialog1.Filter = "PNG images|*.png|JPG images|*.jpg|GIF images|*.gif";
            openFileDialog1.Title = "Izberite sliko";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Image image = autoPartPicture.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

                if (image.Height > 100 || image.Width > 80) {
                    format = image.RawFormat;
                    if (formMainAdmin.mainForm != null) { formMainAdmin.mainForm.SetImageFormat(format); }
                    image = ResizeImage(ref image, 100, 80);
                }
                autoPartPicture.BackgroundImage = image;
            }
            shouldClose = true;
        }
        //============= RESIZE IMAGE ============//
        public static Bitmap ResizeImage(ref Image image, int width, int height) {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //bttutosn
        private void changeInformationButton_MouseEnter(object sender, EventArgs e) {
            if (changing) {
                return;
            }
            changeInformationButton.ForeColor = Color.Black;
        }

        //asd
        private void changeInformationButton_MouseLeave(object sender, EventArgs e) {
            if (changing) {
                return;
            }
            changeInformationButton.ForeColor = Color.Gray;
        }
        //click
        private void changeInformationButton_Click(object sender, EventArgs e) {
            foreach (TextBox t in panel1.Controls.OfType<TextBox>().ToList()) {
                t.Enabled = true;
            }
            txtDescription.Enabled = true;

            deleteEmployeeInformationButton.Visible = false;
            changeEmployeeInformationButton.Visible = true;

            if (changing) {
                return;
            }
            changing = true;

            changeInformationButton.FlatAppearance.BorderColor = Color.Orange;
            changeInformationButton.ForeColor = Color.RoyalBlue;

            deleteEmployeeButton.FlatAppearance.BorderColor = original;
            deleteEmployeeButton.ForeColor = Color.Gray;

        }

        //paint
        private void changeInformationButton_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         changeInformationButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeInformationButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeInformationButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeInformationButton.FlatAppearance.BorderColor, 2, ButtonBorderStyle.Solid);
        }


        //receivedGroupRequests
        private void deleteAutoPartButton_MouseEnter(object sender, EventArgs e) {
            if (!changing) {
                return;
            }
            deleteEmployeeButton.ForeColor = Color.Black;
        }

        private void deleteAutoPartButton_MouseLeave(object sender, EventArgs e) {
            if (!changing) {
                return;
            }
            deleteEmployeeButton.ForeColor = Color.Gray;
        }
        //click
        private void deleteAutoPartButton_Click(object sender, EventArgs e) {
            foreach (TextBox t in panel1.Controls.OfType<TextBox>().ToList()) {
                t.Enabled = false;
            }
            txtDescription.Enabled = false;

            txtAdminPassword.Enabled = true;

            deleteEmployeeInformationButton.Visible = true;
            changeEmployeeInformationButton.Visible = false;

            SetInformation(this.autoPart);

            if (!changing) {
                return;
            }
            changing = false;
            deleteEmployeeButton.FlatAppearance.BorderColor = Color.Orange;
            deleteEmployeeButton.ForeColor = Color.RoyalBlue;

            changeInformationButton.FlatAppearance.BorderColor = original;
            changeInformationButton.ForeColor = Color.Gray;
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
    }
}
