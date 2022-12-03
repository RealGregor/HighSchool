using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.Models {

    public class CartItemModel : IModel {

        public Guid Id { get; set; }

        public Guid UserID { get; set; }

        public Guid AutoPartID { get; set; }

        public int Amount { get; set; }

    }
}
