using FluentValidation.Attributes;
using LMA.Data.UI.ViewModels.ViewModelValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels.Employee {
    [Validator(typeof(UserViewModelValidator))]
    public class EmployeeViewModel {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePicture { get; set; }
    }
}
