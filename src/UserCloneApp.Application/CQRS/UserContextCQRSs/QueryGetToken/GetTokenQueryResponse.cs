using System.Text.Json.Serialization;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Token { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }

        public GetTokenQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }

        public GetTokenQueryResponse(string token)
        {
            Token = token;
        }
    }
}
