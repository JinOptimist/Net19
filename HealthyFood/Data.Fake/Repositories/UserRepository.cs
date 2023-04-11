using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Fake.Repositories
{
    public class UserRepositoryFake : BaseRepository<User>, IUserRepository
    {
        public UserRepositoryFake()
        {
            FakeDbModels =
                new List<User>() {
                    new User
                    {
                        Id = 1,
                        Name = "Pol",
                        AvatarUrl = "https://st3.depositphotos.com/1767687/16607/v/600/depositphotos_166074422-stock-illustration-default-avatar-profile-icon-grey.jpg"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Anna",
                    },
                     new User
                     {
                         Id = 3,
                         Name = "Nikita",
                         AvatarUrl = "https://st3.depositphotos.com/1767687/16607/v/600/depositphotos_166074422-stock-illustration-default-avatar-profile-icon-grey.jpg"
                     },
                };
        }

        public User GetByName(string name)
        {
            return FakeDbModels.First(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            FakeDbModels.Remove(GetByName(name));
        }
    }
}
