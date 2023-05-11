using Data.Interface.Models;
using Data.Interface.Models.ProductPage;
using Data.Interface.Repositories;
using Data.Interface.Repositories.IProductPageRepositories;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models.ProductPageViewModels;
using HealthyFoodWeb.Services.IServices;


namespace HealthyFoodWeb.Services.ProductPageServices
{
    public class ProductService : IProductService
    {
        public const decimal RATINGPRODUCT_DEFAULT = 4;
        private IProductRepository _productRepository;
        private IAuthService _authService;

        public ProductService(IProductRepository productRepository, IAuthService authService)
        {
            _productRepository = productRepository;
            _authService = authService;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public void UpdateRatingProduct(ProductPageViewModel viewModel)
        {
            _productRepository.UpdateRating(viewModel.Id, viewModel.Rating);
        }
        public void AddProduct(ProductPageViewModel viewModel)
        {
            var dbProductModel = new Product()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Rating = viewModel.Rating,
            };

            _productRepository.Add(dbProductModel);
        }

        public void Remove(int id)
        {
            _productRepository.Remove(id);
        }

        public Product GetExpensiveProductWithCategories()
        {
            return _productRepository.GetExpensiveProductWithCategories();
        }

    }
}
