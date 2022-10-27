using FluentValidation;
using Management.Application.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Validator
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Please Write your email address");
        }
    }
}
