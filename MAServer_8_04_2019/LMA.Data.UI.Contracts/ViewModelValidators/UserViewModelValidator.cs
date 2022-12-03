using FluentValidation;
using LMA.Data.UI.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModelValidators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("'First Name' must not be empty")
                .Length(1, 50).WithMessage("'First Name' must not include more than 50 characters");
            RuleFor(x => x.Surname)
                .NotNull().WithMessage("'Surname' must not be empty")
                .Length(1, 50).WithMessage("'Surname' must not include more than 50 characters");
            RuleFor(x => x.Email)
                .NotNull().WithMessage("'Email' must not be empty")
                .EmailAddress();
        }
    }
}
