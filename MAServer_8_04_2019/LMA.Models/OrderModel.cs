using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels.Order {
    public class OrderModel {
        
        public Guid ID { get; set; }

        public Guid OrderID { get; set; }

        public Guid UserID { get; set; }

        public Guid AutoPartID { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
