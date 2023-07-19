using System.Text.Json.Serialization;
using UserCloneApp.Application.ViewModels.UserContextViewModels;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetProfile
{
    public class GetProfileQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserViewModel? Profile { get; set; }


        public GetProfileQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }

        public GetProfileQueryResponse(UserViewModel? profile)
        {
            Profile = profile;
        }
    }
}
