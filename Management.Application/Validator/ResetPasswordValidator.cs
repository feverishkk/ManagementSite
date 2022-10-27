using FluentValidation;
using Management.Application.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Validator
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().NotNull().WithMessage("Email cannot be empty, null or wrong mail");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password cannot be null or empty");
            RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty().Equal(x => x.Password)
                                           .WithMessage("Password cannot be null, empty or do not match");
        }


    }
}
