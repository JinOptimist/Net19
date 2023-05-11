using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
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
                Name = dbModel.Name,
                Rating = dbModel.Rating,
                Price = dbModel.Price,
                ProductCategories = dbModel.Categories?.Select(dbModel => dbModel.Name).ToList(),
            });

            return View();
        }

        [HttpGet]
        public IActionResult ProductPage()
        {
            var product = _productService.GetAllProducts();
            var viewModel = new ProductPageIndexViewModel()
            {
                Products = product.Select(dbModel => new ProductPageViewModel
                {
                    Name = dbModel.Name,
                    Rating = dbModel.Rating,
                    Price = dbModel.Price,
                    Id = dbModel.Id,
                }).ToList(),

            };


            return View(viewModel);
        }

        [HttpGet]
        public IActionResult UpdateRating()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateRating(ProductPageViewModel productPageView)
        {

            _productService.UpdateRatingProduct(productPageView);
            return RedirectToAction("ProductPage");

        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductPageViewModel productPageView)
        {
            _productService.AddProduct(productPageView);
            return RedirectToAction("ProductPage");
        }
        public IActionResult Remove(int id)
        {
            _productService.Remove(id);
            return RedirectToAction("ProductPage");
        }
    }
}