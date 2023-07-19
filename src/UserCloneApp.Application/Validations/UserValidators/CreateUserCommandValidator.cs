using FluentValidation;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandCreateUser;
using UserCloneApp.Application.Validations.Validators;

namespace UserCloneApp.Application.Validations.UserValidators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NameValidation();

            RuleFor(x => x.Surname).SurnameValidation();

            RuleFor(x => x.Email).EmailValidation();

            RuleFor(x => x.Password).PasswordValidation();
        }
    }
}
