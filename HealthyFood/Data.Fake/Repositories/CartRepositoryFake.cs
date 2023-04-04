using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Fake.Repositories
{
    public class CartRepositoryFake : BaseRepository<Cart>, ICartRepository
    {
        public CartRepositoryFake()
        {
            FakeDbModels = new List<Cart>() {
                new Cart{
                    Id = 1,
                    Name = "Salat",
                    Price = 10
                },
                new Cart
                {
                    Id = 2,
                    Name = "Sup",
                    Price = 2
                },

            };
        }

        public Cart GetByName(string name)
        {
            return FakeDbModels.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            FakeDbModels.Remove(GetByName(name));
        }

    }
}
