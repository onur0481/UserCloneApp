using MongoDB.Driver;
using UserCloneApp.Domain.Configurations;
using UserCloneApp.Domain.Entities.UserContextEntites;
using UserCloneApp.Domain.Repositories.UserContextRepositories;

namespace UserCloneApp.Infrastructure.Repositories.UserContextRepositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
        }

        public UserEntity? FindByEmail(string email)
        {
            return _collection.Find(x => x.Email == email).FirstOrDefault();
        }

        public bool IsExistsWithSameEmail(string email)
        {
            return _collection.Find(x => x.Email == email).Any();
        }

        public bool IsVerified(bool isVerified)
        {
            return _collection.Find(x => x.IsVerified == isVerified).Any();
        }

        public UserEntity? ValidateUser(string email, string passwordHash)
        {
            return _collection.Find(x => x.Email == email && x.PasswordHash == passwordHash).FirstOrDefault();
        }
    }
}
