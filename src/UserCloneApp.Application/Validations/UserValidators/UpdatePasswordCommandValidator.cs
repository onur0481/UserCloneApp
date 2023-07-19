using FluentValidation;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdatePassword;
using UserCloneApp.Application.Validations.Validators;

namespace UserCloneApp.Application.Validations.UserValidators
{
    public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommandRequest>
    {
        public UpdatePasswordCommandValidator()
        {
            RuleFor(x => x.CurrentPassword).CurrentPasswordValidation();

            RuleFor(x => x.NewPassword).NewPasswordValidation();
        }
    }
}
