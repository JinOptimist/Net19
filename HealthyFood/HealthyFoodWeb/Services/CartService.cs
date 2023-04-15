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
        private IAuthService _authService;

        public CartService(ICartRepository cartRepository, IAuthService authService)
        {
            _cartRepository = cartRepository;
            _authService = authService;
        }

        public void DeleteFromCart(string name)
        {
            _cartRepository.RemoveByName(name);
        }

        public List<Cart> GetAllProduct()
        {
            return _cartRepository.GetAll().ToList();
        }

        public List<Cart> GetCustomerProduct()
        {
            var user = _authService.GetUser();
            var product = _cartRepository.GetAll().Where(x => x.Customer == user).ToList();

            return product;
        }

        public void AddProductInBase(CartViewModel viewModel)
        {
            var user = _authService.GetUser();
            var dbCartModel = new Cart()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Customer = user,
            };

            _cartRepository.Add(dbCartModel);
        }

    }
}
