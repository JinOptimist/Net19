using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Authorize]
        public IActionResult CartPage(int page = 1, int perPage = 4)
        {
            var paginatorViewModel = _cartService.GetCartsForPaginator(page, perPage);
            var cartViewModel = new CartViewModel(paginatorViewModel);
            cartViewModel.TotalPrice = _cartService.GetTotalPrice();

            return View(cartViewModel);
        }

        public IActionResult DeleteFromCart(int id)
        {
            _cartService.DeleteFromCart(id);
            return RedirectToAction("CartPage");
        }


        [HttpGet]
        public IActionResult AddProductInBase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductInBase(CartItemViewModel viewModel)
        {
            _cartService.AddProductInBase(viewModel);
            return RedirectToAction("CartPage");
        }


        [HttpGet]
        public IActionResult AddProductInCatalogue()
        {
            var manufacturers = _storeCatalogueService
                .GetAllManufacturers();
            var viewModel = new StoreItemViewModel
            {
                AllManufacturers = manufacturers.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name,
                })
                .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddProductInCatalogue(StoreItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var manufacturers = _storeCatalogueService
                .GetAllManufacturers();
                viewModel.AllManufacturers = manufacturers.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name,
                })
                    .ToList();
                return View(viewModel);
            }
            _storeCatalogueService.AddStoreItem(viewModel);
            return RedirectToAction("storePageCatalogue");
        }

    }
}
