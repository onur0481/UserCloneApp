using UserCloneApp.Application.DTOs.CQRSDTOs;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandCreateUser
{
    public class CreateUserCommandResponse : BaseCommandResponseDTO
    {
        public CreateUserCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
