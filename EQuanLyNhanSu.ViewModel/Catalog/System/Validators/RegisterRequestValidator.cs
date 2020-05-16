using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.ViewModel.Catalog.System.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is Riquired");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is Riquired");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is Required").Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email not match");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phonenumber is Required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is Required");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password is Riquired");
            RuleFor(x => x).Custom((request, context) => {
                if(request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("ConfirmPassword is not match");
                }
            });
        }
    }
}
