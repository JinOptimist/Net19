using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class StoreController : Controller
    {
        private ICartService _cartService;
        private IStoreCatalogueService _storeCatalogueService;

        public StoreController(ICartService cartService, IStoreCatalogueService storeCatalogueService)
        {
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
                    Img = x.ImageUrl

                }).ToList();
            viewModel.Manufacturer = _storeCatalogueService
                .GetAllManufacturer()
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
