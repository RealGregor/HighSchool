using FluentValidation.Attributes;
using LMA.Data.UI.ViewModels.ViewModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels
{
    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }

        public string Address { get; set; }

        public string AddressNumber { get; set; }

        public string Country { get; set; }

        public DateTime TimeCreated { get; set; }

        public string Role { get; set; }

        public string PhoneNumber { get; set; }    

        public string ProfilePicture { get; set; }
    }
}
