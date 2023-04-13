using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
	public class ProductPageController : Controller
	{
		private IProductService _productService;

		public ProductPageController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			var products = _productService.GetAllProducts();
			var viewModels = products.Select(dbModel => new ProductPageViewModel
			{
				Name= dbModel.Name,
				Rating= dbModel.Rating,
				Price= dbModel.Price,

			}) ;
			return View();
		}

		[HttpGet]
		public IActionResult ProductPage(int id)
		{
			var product = _productService.GetAllProducts()
				.First(x => x.Id == id);
			var viewModel = new ProductPageViewModel()
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				Rating = product.Rating,
			};


			return View(viewModel);
		}

		[HttpPost]
		public IActionResult ProductPage(ProductPageViewModel productPageView)
		{

			_productService.UpdateRatingProduct(productPageView);
			return RedirectToAction("ProductPage");

		}
	}
}