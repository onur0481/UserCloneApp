using AutoMapper;
using MediatR;
using UserCloneApp.Application.Helpers;
using UserCloneApp.Application.ViewModels.UserContextViewModels;
using UserCloneApp.Domain.Constants;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Exceptions;
using UserCloneApp.Domain.Models;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQueryRequest, GetProfileQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<GetProfileQueryResponse> Handle(GetProfileQueryRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstant.TokenError);

            UserEntity userEntity = _userRepository.FindById(tokenModel.UserID);
            if (userEntity.IsVerified == false) return Task.FromResult(new GetProfileQueryResponse(ResponseConstant.AccountNotVerified));

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(userEntity);

            return Task.FromResult(new GetProfileQueryResponse(userViewModel));

        }
    }
}
