using FluentValidation;
using UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetToken;
using UserCloneApp.Application.Validations.Validators;

namespace UserCloneApp.Application.Validations.UserValidators
{
    public class GetTokenQueryValidator : AbstractValidator<GetTokenQueryRequest>
    {
        public GetTokenQueryValidator()
        {
            RuleFor(x => x.Email).EmailValidation();

            RuleFor(x => x.Password).PasswordValidation();
        }
    }
}
