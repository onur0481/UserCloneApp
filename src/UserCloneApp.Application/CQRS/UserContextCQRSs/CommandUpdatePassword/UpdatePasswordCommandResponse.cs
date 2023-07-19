using UserCloneApp.Application.DTOs.CQRSDTOs;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandResponse : BaseCommandResponseDTO
    {
        public UpdatePasswordCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
