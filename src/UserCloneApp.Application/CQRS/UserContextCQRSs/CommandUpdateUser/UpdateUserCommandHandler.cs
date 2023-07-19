using AutoMapper;
using MediatR;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Exceptions;
using UserCloneApp.Domain.Models;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstant.TokenError);

            UserEntity? userEntity = _userRepository.FindById(tokenModel.UserID);
            if (userEntity.IsVerified == false) return Task.FromResult(new UpdateUserCommandResponse(ResponseConstant.AccountNotVerified));

            _mapper.Map(request, userEntity);
            _userRepository.ReplaceOne(userEntity);

            return Task.FromResult(new UpdateUserCommandResponse(ResponseConstant.UpdatingProcessSuccessful));
        }
    }
}
