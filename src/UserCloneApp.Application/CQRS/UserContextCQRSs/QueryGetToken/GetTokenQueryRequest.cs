using MediatR;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryRequest : IRequest<GetTokenQueryResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public GetTokenQueryRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
