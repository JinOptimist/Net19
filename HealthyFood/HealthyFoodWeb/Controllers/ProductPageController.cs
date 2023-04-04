using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
	public class ProductPageController : Controller
	{
		private RatingProductService _ratingProductService;

		public ProductPageController(RatingProductService ratingproductService)
		{
			_ratingProductService = ratingproductService;
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

			_ratingProductService.UpdateRatingProduct(productPageView);
			return RedirectToAction("Index");

		}
	}
}