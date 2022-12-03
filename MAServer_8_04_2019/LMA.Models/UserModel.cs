using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LMA.Data.Models
{
    public class UserModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool EmailConfirmed { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string AddressNumber { get; set; }

        public string Country { get; set; }

        public string Password { get; set; }

        public DateTime TimeCreated { get; set; }

        public Guid TenantId { get; set; }

        public string Role { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
