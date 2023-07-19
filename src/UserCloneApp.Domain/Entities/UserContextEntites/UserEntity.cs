using UserCloneApp.Domain.Attributes;
using UserCloneApp.Domain.SeedWorks;

namespace UserCloneApp.Domain.Entities.UserContextEntites
{
    [BsonCollection("UserCollection")]
    public class UserEntity : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool IsVerified { get; set; }

        public UserEntity(string name, string surname, string email, string passwordHash, bool isVerified)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PasswordHash = passwordHash;
            IsVerified = isVerified;
        }
        public UserEntity CopyWith(
                string? name = null,
                string? surname = null,
                string? passwordHash = null,
                bool? isVerified = null
            )
        {
            UserEntity userEntity = new(
                    name: name ?? Name,
                    surname: surname ?? Surname,
                    email: Email,
                    passwordHash: passwordHash ?? PasswordHash,
                    isVerified: isVerified ?? IsVerified
                );
            userEntity.ID = ID;
            userEntity.CreatedDate = CreatedDate;
            userEntity.UpdatedDate = UpdatedDate;
            userEntity.IsDeleted = IsDeleted;

            return userEntity;
        }
    }
}
