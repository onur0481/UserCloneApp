using UserCloneApp.Application.DTOs.CQRSDTOs;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandResetPassword
{
    public class ResetPasswordCommandResponse : BaseCommandResponseDTO
    {
        public ResetPasswordCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
