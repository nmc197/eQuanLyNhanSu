using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EQuanLyNhanSu.ViewModel.Catalog.System
{
    public class LoginRequestValidator: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is riquired").MinimumLength(6).WithMessage("Password is at least 6 characters");
        }
    }
}
