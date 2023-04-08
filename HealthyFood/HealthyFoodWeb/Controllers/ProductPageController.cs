using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
	public class ProductPageController : Controller
	{
		private ProductService _productService;

		public ProductPageController(ProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult ProductPage()
		{

			return View();
		}
		[HttpPost]
		public IActionResult ProductPage(ProductPageViewModel productPageView)
		{

			_productService.UpdateRatingProduct(productPageView);
			return RedirectToAction("Index");

		}
	}
}