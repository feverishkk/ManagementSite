using FluentValidation;
using Management.Application.Dto.Account;

namespace Management.Application.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().NotNull().WithMessage("Cannot be null or empty");

            RuleFor(x => x.Email).NotEmpty().NotNull()
                                 .WithMessage("Please write Email Address")
                                 .EmailAddress()
                                 .WithMessage("Invalid Email Format!");
                                 //.WithMessage("Email has already taken");

            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password Cannot be null");

            RuleFor(x => x.ConfirmPassword).ComparePassword();

            RuleFor(x => x.Department).NotEmpty().NotNull().WithMessage("Write Where you belong into");
            RuleFor(x => x.DepartmentNumber).NotEmpty().NotNull().WithMessage("Write your Department number");

            RuleFor(x => x.FamilyName).CheckName().NotEmpty().NotNull().WithMessage("Write your Family Name");
                                      
            RuleFor(x => x.GivenName).CheckName().NotEmpty().NotNull().WithMessage("Write your Given Name");

        }

    }
}
