using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.DTOs.CQRSDTOs
{
    public abstract class BaseCommandResponseDTO
    {
        public ResponseConstantModel Response { get; set; }

        protected BaseCommandResponseDTO(ResponseConstantModel response)
        {
            Response = response;
        }
    }
}
