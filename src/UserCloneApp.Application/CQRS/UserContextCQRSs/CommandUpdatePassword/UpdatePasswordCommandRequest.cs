using MediatR;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public UpdatePasswordCommandRequest(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
