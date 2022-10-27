using FluentValidation;
using Management.Application.Dto.Account;
using ManagementDbContext.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Validator
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress()
                               .WithMessage("Email Address cannot be null,empty or not normal Email address , Try again");

            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password cannot be null");
                
        }


    }
}
