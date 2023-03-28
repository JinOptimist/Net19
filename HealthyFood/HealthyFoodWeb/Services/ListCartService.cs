using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public class ListCartService : ICartService
    {
        private ICartRepository _cartRepository;

        public ListCartService(ICartRepository cartRepositoryFake)
        {
            _cartRepository = cartRepositoryFake;
        }

        public void DeleteFromCart(string name)
        {
            _cartRepository.RemoveByName(name);
        }

        public List<ICartModel> GetAllProduct()
        {
            return _cartRepository.GetAll().ToList();
        }
    }
}
