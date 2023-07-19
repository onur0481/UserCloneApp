using MediatR;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQueryRequest, GetTokenQueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetTokenQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<GetTokenQueryResponse> Handle(GetTokenQueryRequest request, CancellationToken cancellationToken)
        {
            string passwordHash = EncryptionHelper.Encryption(request.Password);

            UserEntity? userEntity = _userRepository.ValidateUser(request.Email, passwordHash);
            if (userEntity == null) return Task.FromResult(new GetTokenQueryResponse(ResponseConstant.EmailPasswordError));

            if (userEntity.IsVerified == false) return Task.FromResult(new GetTokenQueryResponse(ResponseConstant.AccountNotVerified));

            string token = TokenHelper.Instance().CreateToken(userEntity);

            return Task.FromResult(new GetTokenQueryResponse(token));
        }
    }
}
