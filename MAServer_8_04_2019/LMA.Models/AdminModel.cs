using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.Models
{
    public class AdminModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
