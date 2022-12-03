using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels.Employee {
    public class CartItemViewModel {

        public Guid AutoPartID { get; set; }

        public Guid UserID { get; set; }

        public AutoPartViewModel AutoPart { get; set; }

        public UserViewModel User { get; set; }

        public int Amount { get; set; }

    }
}
