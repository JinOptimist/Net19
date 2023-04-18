using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class StoreController : Controller
    {
        private ICartService _cartService;
        private IUserService _userService;
        private IAuthService _authService;
        private IStoreCatalogueService _storeCatalogueService;

        public StoreController(ICartService cartService, IUserService userService, IAuthService authService, IStoreCatalogueService storeCatalogueService)
        {
            _userService = userService;
            _authService = authService;
            _cartService = cartService;
            _storeCatalogueService = storeCatalogueService;
        }

        public IActionResult storePageCatalogue()
        {
            var viewModel = new StoreCatalogueViewModel();
            viewModel.Items = _storeCatalogueService
                .GetAllItems()
                .Select(x => new StoreItemViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Img = x.ImageUrl,
                    Manufacturer = x.Manufacturer.Name,

                }).ToList();
            viewModel.Manufacturer = _storeCatalogueService
                .GetAllManufacturers()
                .Select(x => new ManufacturerViewModel
                {
                    Name = x.Name,
                }).ToList();

            return View(viewModel);
        }

        public IActionResult CartPage()
        {
            var viewModel = new CartIndexViewModel();

            viewModel.Product = _cartService.
                GetCustomerProduct().
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


        [HttpGet]
        public IActionResult AddProductInBase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductInBase(CartViewModel viewModel)
        {
            _cartService.AddProductInBase(viewModel);
            return RedirectToAction("CartPage");
        }

    }
}
