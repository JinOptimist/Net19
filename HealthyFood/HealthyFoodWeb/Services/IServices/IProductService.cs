using Data.Interface.Models;
using Data.Sql.Models;
using HealthyFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Services
{
	public interface IProductService
	{
		public List<Product> GetAllProducts();
		void UpdateRatingProduct(ProductPageViewModel viewModel);
		public void AddProduct(ProductPageViewModel viewModel);
		public IActionResult RemoveProduct(ProductPageViewModel productPageView);

    }
}