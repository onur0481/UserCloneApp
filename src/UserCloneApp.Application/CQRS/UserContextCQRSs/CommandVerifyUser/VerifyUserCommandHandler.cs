using MediatR;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Exceptions;
using UserCloneApp.Domain.Models;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandVerifyUser
{
    public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommandRequest, VerifyUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public VerifyUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<VerifyUserCommandResponse> Handle(VerifyUserCommandRequest request, CancellationToken cancellationToken)
        {

            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstant.TokenError);

            UserEntity? userEntity = _userRepository.FindByEmail(tokenModel.Email);
            if (userEntity == null) return Task.FromResult(new VerifyUserCommandResponse(ResponseConstant.NotRegisteredUser));

            userEntity = userEntity.CopyWith(isVerified: true);
            _userRepository.ReplaceOne(userEntity);

            return Task.FromResult(new VerifyUserCommandResponse(ResponseConstant.AccountVerified));
        }
    }
}
