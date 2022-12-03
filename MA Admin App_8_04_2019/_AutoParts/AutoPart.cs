using LMA.Data.UI.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMeAlone._AutoParts.Tires {
    public class AutoPart {
        public AutoPartViewModel autoPart { get; set; }
        public Image Picture { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int DeliveryDeadline { get; set; }
        public string Price { get; set; }

       //public string StringProfilePicture { get; set; }

        public AutoPart(AutoPartViewModel _autoPart) {
            this.autoPart = _autoPart;
            Name = _autoPart.Name;
            Producer = _autoPart.ProducerName;
            DeliveryDeadline = _autoPart.DeliveryDeadline;
            Price = _autoPart.Price + "€";
            Image i = StringToImage(_autoPart.Picture);

            Picture = i;
            //StringProfilePicture = autoPart.Picture;
        }
        //============= TRANSFORM STRING INTO IMAGE ============//
        public Bitmap StringToImage(string inputString) {

            byte[] imageBytes = Convert.FromBase64String(inputString);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            return new Bitmap(ms);
        }
        //============= CREATE IMAGE WITH ROUNDED EDGES ============//
        private Bitmap RoundCorners(Image StartImage, int CornerRadius) {
            CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
            using (Graphics g = Graphics.FromImage(RoundedImage)) {
                //g.Clear(BackgroundColor);
                g.SmoothingMode = SmoothingMode.HighQuality;//anti alias
                Brush brush = new TextureBrush(StartImage);
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                g.FillPath(brush, gp);
                return RoundedImage;
            }
        }
        //============= CREATE ROUND IMAGE ============//
        private Bitmap OvalImage(Image img) {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (GraphicsPath gp = new GraphicsPath()) {
                gp.AddEllipse(0, 0, img.Width, img.Height);
                using (Graphics gr = Graphics.FromImage(bmp)) {
                    gr.SetClip(gp);
                    gr.DrawImage(img, Point.Empty);
                }
            }
            return bmp;
        }
    }
}
