using FluentValidation.Attributes;
using LMA.Data.UI.ViewModels.ViewModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels
{
    [Validator(typeof(CreateUserViewModelValidator))]
    public class CreateUserViewModel : UserViewModel
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string TenantName { get; set; }
    }
}
