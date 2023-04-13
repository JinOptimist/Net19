using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void DeleteFromCart(string name)
        {
            _cartRepository.RemoveByName(name);
        }

        public List<Cart> GetAllProduct()
        {
            return _cartRepository.GetAll().ToList();
        }

        public void AddProductInBase(CartViewModel viewModel)
        {
            var dbCartModel = new Cart()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
            };

            _cartRepository.Add(dbCartModel);
        }

    }
}
  