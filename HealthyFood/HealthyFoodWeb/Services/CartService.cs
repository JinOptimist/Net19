using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.Games;
using HealthyFoodWeb.Services.Helpers;
using HealthyFoodWeb.Services.IServices;
using System.Linq;

namespace HealthyFoodWeb.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;
        private IAuthService _authService;
        private IPagginatorService _pagginatorService;
        private ICartTagRepository _cartTagRepository;


        public CartService(ICartRepository cartRepository,
            IAuthService authService, IPagginatorService pagginatorService, ICartTagRepository cartTagRepository)
        {
            _cartRepository = cartRepository;
            _authService = authService;
            _pagginatorService = pagginatorService;
            _cartTagRepository = cartTagRepository;
        }

        public void DeleteFromCart(int id)
        {
            _cartRepository.Remove(id);
        }

        public void UpdateTag(int id, List<string> newTagsNames)
        {
            var cartItem = _cartRepository.GetCartAndTags(id);
            if (cartItem.Tags == null)
            {
                cartItem.Tags = new List<CartTags>();
            }

            var newTags = _cartTagRepository
                .GetAll()
                .Where(x => newTagsNames.Contains(x.Name))
                .ToList();

            cartItem.Tags.RemoveAll(x => true);
            newTags.ForEach(x => cartItem.Tags.Add(x));
            _cartRepository.Update(cartItem);
        }

        public List<Cart> GetAllProduct()
        {
            return _cartRepository.GetAll().ToList();
        }

        public List<Cart> GetCustomerProduct()
        {
            var userId = _authService.GetUser().Id;
            var product = _cartRepository.GetAllWithTags().Where(x => x.Customer != null && x.Customer.Id == userId).ToList();

            return product;
        }

        public ProductCountViewModel GetViewModelForProductCount(string userTag)
        {
            var dataModel = GetCustomerProduct()
                .Where(x => x.Tags != null && x.Tags.Any(x => x.Name == userTag))
                .ToList();

            return new ProductCountViewModel
            {
                TotalProductCount = dataModel.Count,
                ProductNames = dataModel.Select(x => x.Name).ToList(),
            };
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

        public void AddProductInCart(CartItemViewModel viewModel)
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
            var cartDb = _cartRepository.GetCartAndTags(x.Id);
            var tags = _cartTagRepository.GetAll().Select(x => x.Name).ToList();
            return new CartItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImgUrl = x.ImgUrl,
                AvailableTags = tags,
                Tags = cartDb.Tags.Select(x => x.Name).ToList()
            };
        }

        public CartItemViewModel GetCartViewModel(int id)
        {
            var cartDb = _cartRepository.GetCartAndTags(id);
            var tags = _cartTagRepository.GetAll().Select(x => x.Name).ToList();
            return new CartItemViewModel
            {
                Id = cartDb.Id,
                Name = cartDb.Name,
                Price = cartDb.Price,
                ImgUrl = cartDb.ImgUrl,
                AvailableTags = tags,
                Tags = cartDb.Tags.Select(x => x.Name).ToList()
            };
        }

    }
}

