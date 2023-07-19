using FluentValidation;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandResetPassword;
using UserCloneApp.Application.Validations.Validators;

namespace UserCloneApp.Application.Validations.UserValidators
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommandRequest>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(x => x.Password).PasswordValidation();
        }
    }
}
