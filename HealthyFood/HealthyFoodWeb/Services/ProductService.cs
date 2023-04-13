using Data.Fake.Repositories;
using Data.Interface.Repositories;
using Data.Sql.Models;
using HealthyFoodWeb.Models;


namespace HealthyFoodWeb.Services
{
	public class ProductService : IProductService
	{
		public const decimal RATINGPRODUCT_DEFAULT = 4;
		private IProductRepository _productRepository;

		public ProductService(IProductRepository productRepositoryFake)
		{
			_productRepository = productRepositoryFake;
		}

		public List<Product> GetAllProducts()
		{
			return _productRepository.GetAll().ToList();
		}

		public void UpdateRatingProduct(ProductPageViewModel viewModel)
		{
			var productModel = new Product()
			{
				Rating = viewModel.Rating + 1,
			};

		}
	}
}
