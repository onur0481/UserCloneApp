using AutoMapper;
using UserCloneApp.Application.ViewModels.UserContextViewModels;
using UserCloneApp.Domain.Entities.UserContextEntites;

namespace UserCloneApp.Application.Mappings
{
    public class EntityToViewModelMappings : Profile
    {
        public EntityToViewModelMappings() 
        {
            CreateMap<UserEntity, UserViewModel>();
        }
    }
}
