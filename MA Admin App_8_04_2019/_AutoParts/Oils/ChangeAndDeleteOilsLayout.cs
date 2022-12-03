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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using LMA.Data.UI.ViewModels.ViewModels;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using LMA.Data.UI.ViewModels.ViewModels.AutoPart;

namespace LeaveMeAlone
{
    public partial class ChangeAndDeleteOilsLayout : UserControl
    {
        private ImageFormat format = null;

        private Color original;

        private bool changing = true;

        private string originalAutoPartID;

        private AutoPartViewModel autoPart;

        public ChangeAndDeleteOilsLayout()
        {
            InitializeComponent();

            original = changeAutoPartButton.FlatAppearance.BorderColor;

            changeAutoPartButton.FlatAppearance.BorderColor = Color.Orange;
            changeAutoPartButton.ForeColor = Color.RoyalBlue;
        }

        //============= SET AUTO PART INFORMATION ============//
        public void SetAutoPartData(AutoPartViewModel autoPart) {

            this.autoPart = autoPart;
            if (autoPart == null) { return; }
            originalAutoPartID = autoPart.ID.ToString();

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
                foreach (TextBox t in this.Controls.OfType<TextBox>().ToList()) {
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
                txtDescription.Text = autoPart.Description;
            }

            //can never happen because the picture will always be added --> if it happens --> error on server
            if (!string.IsNullOrEmpty(autoPart.Picture)) {
                autoPartPicture.BackgroundImage = formMainAdmin.mainForm.stringToImage(autoPart.Picture);
            } else {
                autoPartPicture.BackgroundImage = Properties.Resources.noImage;
            }
            foreach (TextBox t in this.Controls.OfType<TextBox>().ToList()) {
                if (string.IsNullOrEmpty(t.Text) && !t.Name.Equals(txtAdminPassword.Name)) {
                    t.Text = "Ni podatka";
                }
            }
        }

        public Guid GetActiveAutoPartID() {
            if (this.autoPart == null) { return Guid.Empty; }
            return this.autoPart.ID;
        }

        public void ClearAutoPartData() {
            /*
             IF THE REQUEST WENT THROUGH OK, THEN DELETE
             */
            foreach (TextBox textBox in this.Controls.OfType<TextBox>().ToList()) {
                textBox.Text = "";
            }
            txtDescription.Text = "";
            autoPartPicture.BackgroundImage = Properties.Resources.noImage;
        }

        //============= CHANGE PICTURE CLICK ============//
        private void changePicture_Click(object sender, EventArgs e) {
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
                    image = ResizeImage(ref image, 110, 80);//not sure
                }
                autoPartPicture.BackgroundImage = image;
                autoPartPicture.BackgroundImage = image;
                //if (formMainAdmin.mainForm != null)
                //    formMainAdmin.mainForm.FunctionSummoner(26, image: image);
            }
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

        //============= GET AUTO PART BY ID ============//
        private void getTireButton_Click(object sender, EventArgs e) {
            string ID = txtTireID.Text.Trim();

            formMainAdmin.mainForm.FunctionSummoner(44, autoPartID: ID);
        }
        //============= CHANGE AUTO PART BY ID ============//
        private void changeTireInformationButton_Click(object sender, EventArgs e) {
            if (!txtTireID.Text.Trim().Equals(originalAutoPartID)) {
                MessageBox.Show("Neujemanje šifre izdelka z izdelkom.");
                return;
            }
            string technicalDescription = "";
            foreach (TextBox textBox in this.Controls.OfType<TextBox>().ToList()) {

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
                    ID = autoPart.ID,
                    Name = txtName.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    ProducerName = txtProducer.Text,
                    TechnicalDetails = technicalDescription,
                    DeliveryDeadline = Convert.ToInt32(txtDeliveryDeadline.Text),
                    Description = txtDescription.Text.Trim(),
                    Picture = formMainAdmin.mainForm.ImageToByteArray(autoPartPicture.BackgroundImage),
                    Password = txtAdminPassword.Text.Trim()
                };

                formMainAdmin.mainForm.FunctionSummoner(42, changeAutoPart: changeAutoPart);

            } catch (Exception ex) {
                MessageBox.Show("Napaka pri pretvarjanju besede v število.");
                //bla bla error neki povej kakec 223 neki juha je že treba je jest
            }
            txtAdminPassword.Text = "";//PASSWORD DOESN'T STAY WHEN YOU CHANGE INFO

            //shouldClose = false;

            /*
             set the new information for the given employee in the employee linked list
             */
        }
        //============= DELETE AUTO PART BY ID ============//
        private void deleteTireInformationButton_Click(object sender, EventArgs e) {
            DeleteAutoPartViewModel deleteAutoPart = new DeleteAutoPartViewModel();

            if (string.IsNullOrEmpty(txtTireID.Text.Trim())) {
                deleteAutoPart.ID = autoPart.ID;
            } else {
                deleteAutoPart.ID = new Guid(txtTireID.Text);
            }
            
            deleteAutoPart.Password = txtAdminPassword.Text.Trim();

            formMainAdmin.mainForm.FunctionSummoner(43, deleteAutoPart: deleteAutoPart);
        }
        

        //bttutosn
        private void changeAutoPartButton_MouseEnter(object sender, EventArgs e) {
            if (changing) {
                return;
            }
            changeAutoPartButton.ForeColor = Color.Black;
        }
        //asd
        private void changeAutoPart_MouseLeave(object sender, EventArgs e) {
            if (changing) {
                return;
            }
            changeAutoPartButton.ForeColor = Color.Gray;
        }
        //click
        private void changeAutoPart_Click(object sender, EventArgs e) {
            foreach (TextBox t in this.Controls.OfType<TextBox>().ToList()) {
                t.Enabled = true;
            }
            txtDescription.Enabled = true;

            deleteOilButton.Visible = false;
            changeTireButton.Visible = true;

            if (changing) {
                return;
            }
            changing = true;

            changeAutoPartButton.FlatAppearance.BorderColor = Color.Orange;
            changeAutoPartButton.ForeColor = Color.RoyalBlue;

            deleteAutoPartButton.FlatAppearance.BorderColor = original;
            deleteAutoPartButton.ForeColor = Color.Gray;

        }
        //paint
        private void changeAutoPart_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         changeAutoPartButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeAutoPartButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeAutoPartButton.FlatAppearance.BorderColor, 0, ButtonBorderStyle.None,
                                         changeAutoPartButton.FlatAppearance.BorderColor, 2, ButtonBorderStyle.Solid);
        }


        //receivedGroupRequests
        private void deleteAutoPartButton_MouseEnter(object sender, EventArgs e) {
            if (!changing) {
                return;
            }
            deleteAutoPartButton.ForeColor = Color.Black;
        }
        //SDF
        private void deleteAutoPartButton_MouseLeave(object sender, EventArgs e) {
            if (!changing) {
                return;
            }
            deleteAutoPartButton.ForeColor = Color.Gray;
        }
        //click
        private void deleteAutoPartButton_Click(object sender, EventArgs e) {
            foreach (TextBox t in this.Controls.OfType<TextBox>().ToList()) {
                t.Enabled = false;
            }
            txtDescription.Enabled = false;

            txtAdminPassword.Enabled = true;
            txtTireID.Enabled = true;

            deleteOilButton.Visible = true;
            changeTireButton.Visible = false;

            SetAutoPartData(this.autoPart);

            if (!changing) {
                return;
            }
            changing = false;
            deleteAutoPartButton.FlatAppearance.BorderColor = Color.Orange;
            deleteAutoPartButton.ForeColor = Color.RoyalBlue;

            changeAutoPartButton.FlatAppearance.BorderColor = original;
            changeAutoPartButton.ForeColor = Color.Gray;
        }
    }
}
