using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.Helpers;
using HealthyFoodWeb.Services.IServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HealthyFoodWeb.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;
        private IAuthService _authService;
        private IPagginatorService _pagginatorService;

        public CartService(ICartRepository cartRepository,
            IAuthService authService, IPagginatorService pagginatorService)
        {
            _cartRepository = cartRepository;
            _authService = authService;
            _pagginatorService = pagginatorService;
        }

        public void DeleteFromCart(int id)
        {
            _cartRepository.Remove(id);
        }

        public List<Cart> GetAllProduct()
        {
            return _cartRepository.GetAll().ToList();
        }

        public List<Cart> GetCustomerProduct()
        {
            var userId = _authService.GetUser().Id;
            var product = _cartRepository.GetAll().Where(x => x.Customer != null && x.Customer.Id == userId).ToList();

            return product;
        }

        public decimal GetTotalPrice()
        {
            decimal TotalPrice = 0;
            foreach (var product in GetCustomerProduct())
            {
                TotalPrice += product.Price;
            }
            return TotalPrice;
        }

        public void AddProductInBase(CartItemViewModel viewModel)
        {
            var user = _authService.GetUser();
            var dbCartModel = new Cart()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Customer = user,
                ImgUrl = viewModel.ImgUrl,
            };

            _cartRepository.Add(dbCartModel);
        }

        public PagginatorViewModel<CartItemViewModel> GetCartsForPaginator(int page, int perPage)
        {
            var viewModel = _pagginatorService
                            .GetPaginatorViewModel(
                                page,
                                perPage,
                                GetCustomerProduct,
                                BuildViewModelFromDbModel,
                                _cartRepository);

            return viewModel;
        }

        private CartItemViewModel BuildViewModelFromDbModel(Cart x)
        {
            return new CartItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImgUrl= x.ImgUrl,
            };
        }
    }
}
