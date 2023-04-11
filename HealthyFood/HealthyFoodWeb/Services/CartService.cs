using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepositoryFake)
        {
            _cartRepository = cartRepositoryFake;
        }

        public void DeleteFromCart(string name)
        {
            _cartRepository.RemoveByName(name);
        }

        public List<Cart> GetAllProduct()
        {
            return _cartRepository.GetAll().ToList();
        }
    }
}
