using AutoMapper;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandCreateUser;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdatePassword;
using UserCloneApp.Application.CQRS.UserContextCQRSs.CommandUpdateUser;
using UserCloneApp.Domain.Entities.UserContextEntites;

namespace UserCloneApp.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings() 
        {
            CreateMap<CreateUserCommandRequest, UserEntity>()
                .ForMember(acs => acs.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ConstructUsing(src => new UserEntity(src.Name, src.Surname, src.Email, src.Password, true));
            CreateMap<UpdateUserCommandRequest, UserEntity>();
            CreateMap<UpdatePasswordCommandRequest, UserEntity>()
               .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.NewPassword));
        }
    }
}
