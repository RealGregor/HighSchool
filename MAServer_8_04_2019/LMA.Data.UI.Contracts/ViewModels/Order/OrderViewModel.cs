using LMA.Data.UI.ViewModels.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels.Order {
    public class OrderViewModel {

        public Guid OrderID { get; set; }

        public CartItemViewModel OrderItem { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

    }
}
