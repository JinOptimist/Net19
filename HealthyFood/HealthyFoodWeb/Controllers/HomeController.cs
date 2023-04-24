using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IAuthService _authService;

        public HomeController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            var user = _authService.GetUser();

            var viewModel = new ProfileViewModel();

            viewModel.Name = user?.Name ?? "Гость";

            return View(viewModel);
        }

        public IActionResult Profile(string name = "Ivan")
        {
            var model = new ProfileViewModel()
            {
                Name = name,
                Operator = MathOperationEnum.Plus
            };
            
            if (name == "admin")
            {
                model.Coins = 1000;
            }
            else
            {
                model.Coins = 10;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateName(ProfileViewModel model)
        {
            return RedirectToAction("Profile", new { name = model.ActualName });
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}