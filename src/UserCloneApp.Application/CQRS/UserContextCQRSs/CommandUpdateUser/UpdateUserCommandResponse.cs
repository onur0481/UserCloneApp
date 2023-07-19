using UserCloneApp.Application.DTOs.CQRSDTOs;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdateUser
{
    public class UpdateUserCommandResponse : BaseCommandResponseDTO
    {
        public UpdateUserCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
