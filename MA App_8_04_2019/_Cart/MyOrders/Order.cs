using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMeAlone._Cart {
    public class Order {
        public List<CartItem> CartItems { get; set; }
        public string Name { get; set; }
        public int DeliveryDeadline { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public DateTime Date { get; set; }

        //public string StringProfilePicture { get; set; }

        public Order(List<OrderViewModel> _orders) {
            CartItems = new List<CartItem>();

            int amount = 0;
            decimal price = 0;

            foreach (var v in _orders) {
                if (string.IsNullOrEmpty(Name)) {//BAD IDEA, GET RID OF IT SOON
                    Name += "" + v.OrderItem.AutoPart.Name;
                } else {
                    Name += Name + ", " + v.OrderItem.AutoPart.Name;
                }
                DeliveryDeadline = 0;
                DeliveryDeadline = Math.Max(DeliveryDeadline, v.OrderItem.AutoPart.DeliveryDeadline);
                amount += v.Amount;
                price += v.Price;

                Date = v.Date;

                CartItems.Add(new CartItem(v.OrderItem));
            }
            
            Price = price + "€";
            Amount = amount + " Izdelkov";
        }
    }
}
