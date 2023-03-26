using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class StoreController : Controller
    {
        private ICartService _cartService;

        public StoreController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult storePageCatalogue()
        {
            return View();
        }

        public IActionResult CartPage()
        {
            var viewModel = new CartIndexViewModel();
            viewModel.Product = _cartService.
                GetAllProduct().
                Select(x => new CartViewModel
                {
                    Name = x.Name,
                    Price = x.Price
                }).ToList();

            return View(viewModel);
        }

        public IActionResult DeleteFromCart(string name)
        {
            _cartService.DeleteFromCart(name);
            return RedirectToAction("CartPage");
        }
    }
}
