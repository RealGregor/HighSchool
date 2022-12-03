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

namespace LeaveMeAlone
{
    public partial class AddLightsLayout : UserControl
    {
        private ImageFormat format = null;

        public AddLightsLayout()
        {
            InitializeComponent();
            
        }

        //Seems like it would be more efficient to use checkedListBox1.IndexFromPoint(e.x, e.y) 
        //in the MouseDown handler,instead of looping through the GetItemRectangle results.
        private void dataList_Click(object sender, EventArgs e) {
            var list = ((CheckedListBox)sender);
            for (int i = 0; i < list.Items.Count; i++) {


                if (list.GetItemRectangle(i).Contains(list.PointToClient(MousePosition))) {
                    switch (list.GetItemCheckState(i)) {
                        case CheckState.Checked:
                            list.SetItemCheckState(i, CheckState.Unchecked);
                            break;
                        case CheckState.Indeterminate:
                        case CheckState.Unchecked:
                            list.SetItemCheckState(i, CheckState.Checked);
                            break;
                    }

                }

            }
        }

        private void btnAddLight_Click(object sender, EventArgs e) {
            List< TextBox > textBoxes = Controls.OfType<TextBox>().ToList();
            string technicalDescription = "";
            foreach (var textBox in textBoxes) {
                string name = textBox.AccessibleName;
                string text = textBox.Text.Trim();
                if (text == null || text.Equals("")) {
                    text = "Ni podatka";
                    textBox.Text = text;
                }
                if (name == null || name.Equals("")) {
                    continue;
                }
                if (technicalDescription.Equals("")) {
                    technicalDescription +=  name+ ":" + text;
                } else {
                    technicalDescription += "," + textBox.AccessibleName + ":" + textBox.Text;
                }
            }
            try {
                AutoPartViewModel autoPart = new AutoPartViewModel {
                    Name = textName.Text.Trim(),
                    Category = "Light",
                    Price = Convert.ToDecimal(textPrice.Text.Trim()),
                    ProducerName = textProducer.Text.Trim(),
                    TechnicalDetails = technicalDescription,
                    DeliveryDeadline = Convert.ToInt32( textDeliveryDeadline.Text.Trim()),
                    Description = textDescription.Text.Trim() + "",
                    Picture = formMainAdmin.mainForm.ImageToByteArray(pictureBox1.BackgroundImage)
                };
                
                formMainAdmin.mainForm.FunctionSummoner(38, autoPart: autoPart);

            } catch (Exception ex) {
                MessageBox.Show("Tipi podatkov se ne ujemajo");
            }
        }
        //============= CHANGE PICTURE CLICK ============//
        private void changePicture_Click(object sender, EventArgs e) {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            openFileDialog1.Filter = "PNG images|*.png|JPG images|*.jpg|GIF images|*.gif";
            openFileDialog1.Title = "Izberite sliko";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Image image = pictureBox1.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

                if (image.Height > 100 || image.Width > 80) {
                    format = image.RawFormat;
                    if (formMainAdmin.mainForm != null) { formMainAdmin.mainForm.SetImageFormat(format); }
                    image = ResizeImage(ref image, 110, 80);//not sure
                }
                pictureBox1.BackgroundImage = image;
                pictureBox1.BackgroundImage = image;
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
    }
}
