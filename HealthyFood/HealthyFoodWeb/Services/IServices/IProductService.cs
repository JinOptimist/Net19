using Data.Interface.Models;
using Data.Sql.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
	public interface IProductService
	{
		public List<Product> GetAllProduct();
		void UpdateRatingProduct(ProductPageViewModel viewModel);

	}
}