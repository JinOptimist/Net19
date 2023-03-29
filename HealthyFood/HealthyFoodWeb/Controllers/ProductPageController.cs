using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class ProductPageController : Controller
     {
        private RatingProductService _RatingProductService;

        public ProductPageController(RatingProductService productService)
        {
            _RatingProductService = RatingProductService;
        }
        public IActionResult ChangeRatingProduct(GameViewModel viewModel)
        {
            _gameService.CreateGame(viewModel);
            return RedirectToAction("Index");
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

                _gameService.CreateGame(viewModel);
                return RedirectToAction("Index");
            
            return View();
        }
    }
}