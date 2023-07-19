using MediatR;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandResetPassword
{
    public class ResetPasswordCommandRequest : IRequest<ResetPasswordCommandResponse>
    {
        public string Password { get; set; }

        public ResetPasswordCommandRequest(string password)
        {
            Password = password;
        }
    }
}
