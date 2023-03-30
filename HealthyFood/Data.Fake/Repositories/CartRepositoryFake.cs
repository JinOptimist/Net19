using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Fake.Models;

namespace Data.Fake.Repositories
{
    public class CartRepositoryFake : BaseRepository<ICartDbModel>, ICartRepository
    {
        public CartRepositoryFake()
        {
            FakeDbModels = new List<ICartDbModel>() {
                new CartModel{
                    Id = 1,
                    Name = "Salat",
                    Price = 10
                },
                new CartModel
                {
                    Id = 2,
                    Name = "Sup",
                    Price = 2
                },

            };
        }

        public ICartDbModel GetByName(string name)
        {
            return FakeDbModels.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            FakeDbModels.Remove(GetByName(name));
        }

    }
}
