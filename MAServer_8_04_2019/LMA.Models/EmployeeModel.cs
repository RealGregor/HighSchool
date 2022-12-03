using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.Models {
    public class EmployeeModel {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
