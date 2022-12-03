using FluentValidation;
using LMA.Data.UI.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModelValidators
{
    public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserViewModelValidator()
        {
            RuleFor(x => x.Password)
                .NotNull().WithMessage("'Password' must not be empty")
                .MinimumLength(8).WithMessage("'Password' must include at least 8 characters")
                .MaximumLength(50).WithMessage("'Password' must not include more than 50 characters");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("'Confirm Password' do not match");
            RuleFor(x => x.Name)
                .NotNull().WithMessage("'First Name' must not be empty")
                .Length(1, 50).WithMessage("'First Name' must not include more than 50 characters");
            RuleFor(x => x.Surname)
                .NotNull().WithMessage("'Surname' must not be empty")
                .Length(1, 50).WithMessage("'Surname' must not include more than 50 characters");
            RuleFor(x => x.Email)
                .NotNull().WithMessage("'Email' must not be empty")
                .EmailAddress().WithMessage("'Email' not valid")
                .Must(email => IsValidEmail(email)).WithMessage("'Email' does not exists");
            //RuleFor(x => x.TenantName)
            //    .NotNull().WithMessage("'TenantName' must not be empty");
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
