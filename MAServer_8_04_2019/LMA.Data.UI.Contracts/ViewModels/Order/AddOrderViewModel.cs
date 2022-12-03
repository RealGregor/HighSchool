using LMA.Data.UI.ViewModels.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels.Order {
    public class AddOrderViewModel {

        public List<CartItemViewModel> CartItems { get; set; }

        public string Password { get; set; }

    }
}
