using FluentValidation;
using UserCloneApp.Domain.Constants;

namespace UserCloneApp.Application.Validations.Validators
{
    public static partial class UserValidators
    {
        public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().NotEmpty().WithMessage(ValidationConstants.NameFieldNotNullNotEmpty.ToString())
            .Matches(RegexConstants.OnlyLetterRegex()).WithMessage(ValidationConstants.NameFieldOnlyLetters.ToString())
                .MinimumLength(3).WithMessage(ValidationConstants.NameFieldMinimumLength.ToString())
                .MaximumLength(50).WithMessage(ValidationConstants.NameFieldMaximumLength.ToString());
        }

        public static IRuleBuilderOptions<T, string> SurnameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().NotEmpty().WithMessage(ValidationConstants.SurnameFieldNotNullNotEmpty.ToString())
            .Matches(RegexConstants.OnlyLetterRegex()).WithMessage(ValidationConstants.SurnamFieldOnlyLetters.ToString())
                .MinimumLength(3).WithMessage(ValidationConstants.SurnamFieldMinimumLength.ToString())
                .MaximumLength(50).WithMessage(ValidationConstants.SurnamFieldMaximumLength.ToString());
        }

        public static IRuleBuilderOptions<T, string> EmailValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
               .NotNull().WithMessage(ValidationConstants.EmailFieldNotNullNotEmpty.ToString())
            .Matches(RegexConstants.EmailFormatRegex()).WithMessage(ValidationConstants.EmailFieldFormat.ToString());
        }

        public static IRuleBuilderOptions<T, string> PasswordValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
               .NotNull().WithMessage(ValidationConstants.PasswordFieldNotNullNotEmpty.ToString())
               .MinimumLength(8).WithMessage(ValidationConstants.PasswordFieldMinimumLength.ToString());
        }

        public static IRuleBuilderOptions<T, string> CurrentPasswordValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
               .NotNull().WithMessage(ValidationConstants.CurrentPasswordFieldNotNullNotEmpty.ToString())
               .MinimumLength(8).WithMessage(ValidationConstants.CurrentPasswordFieldNotNullNotEmpty.ToString());
        }

        public static IRuleBuilderOptions<T, string> NewPasswordValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
               .NotNull().WithMessage(ValidationConstants.NewPasswordFieldNotNullNotEmpty.ToString())
               .MinimumLength(8).WithMessage(ValidationConstants.NewPasswordFieldMinimumLength.ToString());
        }
    }
}
