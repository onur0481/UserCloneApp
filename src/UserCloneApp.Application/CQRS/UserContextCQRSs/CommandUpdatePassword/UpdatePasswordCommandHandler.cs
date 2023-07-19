using MediatR;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Exceptions;
using UserCloneApp.Domain.Models;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdatePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstant.TokenError);

            UserEntity userEntity = _userRepository.FindById(tokenModel.UserID);
            if (userEntity == null) return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstant.NotRegisteredUser));

            if(userEntity.PasswordHash != EncryptionHelper.Encryption(request.CurrentPassword)) return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstant.CurrentPasswordError));

            userEntity = userEntity.CopyWith(passwordHash: EncryptionHelper.Encryption(request.NewPassword));
            _userRepository.ReplaceOne(userEntity);

            return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstant.UpdatingProcessSuccessful));

        }
    }
}
