using UserCloneApp.Application.DTOs.CQRSDTOs;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandVerifyUser
{
    public class VerifyUserCommandResponse : BaseCommandResponseDTO
    {
        public VerifyUserCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
