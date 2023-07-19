using AutoMapper;
using MediatR;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.CommandCreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (_userRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new CreateUserCommandResponse(ResponseConstant.CreatingProcessExistUserWithSameEmail));

            UserEntity userEntity = _mapper.Map<UserEntity>(request);
            userEntity = userEntity.CopyWith(passwordHash: EncryptionHelper.Encryption(request.Password));
            _userRepository.InsertOne(userEntity);

            return Task.FromResult(new CreateUserCommandResponse(ResponseConstant.CreatingProcessSuccessful));
        }
    }
}
