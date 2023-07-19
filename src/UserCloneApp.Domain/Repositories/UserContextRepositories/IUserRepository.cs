using UserCloneApp.Domain.Entities.UserContextEntites;

namespace UserCloneApp.Domain.Repositories.UserContextRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        bool IsExistsWithSameEmail(string email);

        UserEntity? ValidateUser(string email, string passwordHash);

        UserEntity? FindByEmail(string email);

        bool IsVerified(bool isVerified);
    }
}
