﻿using Data.Interface.Models;
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

        public StoreController(ICartService cartService, IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
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
