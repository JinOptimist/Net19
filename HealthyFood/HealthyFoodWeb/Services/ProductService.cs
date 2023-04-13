using Data.Fake.Repositories;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;
using Data.Sql.Repositories;
using HealthyFoodWeb.Models;


namespace HealthyFoodWeb.Services
{
    public class ProductService : IProductService
    {
        public const decimal RATINGPRODUCT_DEFAULT = 4;
        private IProductRepository _productRepository;

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
    }
}
