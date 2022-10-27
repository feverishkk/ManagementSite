using FluentValidation;

namespace Management.Application.Validator
{
    public static class RuleBuilderExtension
    {


        public static IRuleBuilder<T, string> ComparePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var result = ruleBuilder.NotEmpty().NotEmpty().NotNull().WithMessage("Password cannot be empty")
                                    .MinimumLength(3).WithMessage("Password should longer than 3 words")
                                    .MaximumLength(15).WithMessage("Password should less than 15 words")
                                    .Matches(@"[A-Z]+").WithMessage("Password have to contain 1 Uppercase at least")
                                    .Matches(@"[a-z]+").WithMessage("Password have to contain 1 lowercase at least")
                                    .Matches(@"[0-9]+").WithMessage("Password have to contain 1 number at least")
                                    .Matches(@"[\!\?\*\.]+").WithMessage("Password have to contain 1 ( ! ? * . )");
            return result;
        }

        public static IRuleBuilder<T, string> CheckName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var result = ruleBuilder.Matches(@"[A-Z]+").WithMessage("Password have to contain 1 Uppercase at least")
                                    .Matches(@"[a-z]+").WithMessage("Password have to contain 1 lowercase at least");
            return result;
        }





    }
}
