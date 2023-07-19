using FluentValidation;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdateUser;
using UserCloneApp.Application.Validations.Validators;

namespace UserCloneApp.Application.Validations.UserValidators
{
    public class UpdateUserCommandRequestValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandRequestValidator()
        {
            RuleFor(x => x.Name).NameValidation();

            RuleFor(x => x.Surname).SurnameValidation();
        }
    }
}
