using Data.Interface.Models;
using Data.Interface.Models.ProductPage;
using HealthyFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Services
{
    public interface IProductService
	{
		public List<Product> GetAllProducts();
		void UpdateRatingProduct(ProductPageViewModel viewModel);
		public void AddProduct(ProductPageViewModel viewModel);
		public void Remove(int id);
        public Product GetExpensiveProductWithCategories();
    }
}