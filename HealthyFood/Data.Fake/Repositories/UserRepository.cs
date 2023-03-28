using Data.Fake.Models;
using Data.Interface.Models;
using Data.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Fake.Repositories
{
    public class UserRepositoryFake : BaseRepository<IUserDbModel>, IUserRepository
    {
        public UserRepositoryFake()
        {
            FakeDbModels =
                new List<IUserDbModel>() {
                    new UserDbModel
                    {
                        Id = 1,
                        Name = "Pol",
                        AvatarUrl = "https://st3.depositphotos.com/1767687/16607/v/600/depositphotos_166074422-stock-illustration-default-avatar-profile-icon-grey.jpg"
                    },
                    new UserDbModel
                    {
                        Id = 2,
                        Name = "Anna",
                    },
                     new UserDbModel
                     {
                         Id = 3,
                         Name = "Nikita",
                         AvatarUrl = "https://st3.depositphotos.com/1767687/16607/v/600/depositphotos_166074422-stock-illustration-default-avatar-profile-icon-grey.jpg"
                     },
                };
        }

        public IUserDbModel GetByName(string name)
        {
            return FakeDbModels.First(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            FakeDbModels.Remove(GetByName(name));
        }
    }
}
