using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;

namespace HealthyFoodWeb.Services
{
    public class CartRepositoryFake : ICartRepository
    {
        public static List<ICartModel> FakeDbCart =
            new List<ICartModel>() {
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

        public List<ICartModel> GetAll()
        {
            return FakeDbCart;
        }

        public ICartModel GetByName(string name)
        {
            return FakeDbCart.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            FakeDbCart.Remove(GetByName(name));
        }

    }
}
