using MediatR;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandVerifyUser
{
    public class VerifyUserCommandRequest : IRequest<VerifyUserCommandResponse>
    {
        public VerifyUserCommandRequest()
        {
            
        }
    }
}
