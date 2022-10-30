using FluentValidation;
using Management.Application.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Validator
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordViewModel>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty().NotNull()
                                       .WithMessage("Old password cannot be empty or null");

            RuleFor(x => x.NewPassword).ComparePassword().NotEmpty().NotNull()
                                       .WithMessage("new password cannot be empty or null");

            RuleFor(x => x.ConfirmNewPassword).ComparePassword().NotEmpty().NotNull()
                                              .Equal(x=>x.NewPassword).WithMessage("please try again");
        }

    }
}
