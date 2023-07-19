using MediatR;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Exceptions;
using UserCloneApp.Domain.Models;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstant.TokenError);

            UserEntity? userEntity = _userRepository.FindByEmail(tokenModel.Email);
            if (userEntity == null) return Task.FromResult(new ResetPasswordCommandResponse(ResponseConstant.NotRegisteredUser));

            userEntity = userEntity.CopyWith(passwordHash: EncryptionHelper.Encryption(request.Password));
            _userRepository.ReplaceOne(userEntity);

            return Task.FromResult(new ResetPasswordCommandResponse(ResponseConstant.UpdatingProcessSuccessful));
        }
    }
}
