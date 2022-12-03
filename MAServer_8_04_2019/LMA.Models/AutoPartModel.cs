using System;
using System.Collections.Generic;
using System.Text;


namespace LMA.Data.Models
{
    public class AutoPartModel : IModel
    {        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }

        public string Description { get; set; }

        public string TechnicalDetails { get; set; }

        public string ProducerName { get; set; }

        public int DeliveryDeadline { get; set; }

        public decimal Price { get; set; }

        public byte[] Picture { get; set; }
    }
}
