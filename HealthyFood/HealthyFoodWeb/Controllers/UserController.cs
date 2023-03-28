using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var viewModels = _userService
                .GetUserModels()
                .Select(dbModel =>
                    new UserViewModel
                    {
                        Name = dbModel.Name,
                        AvatarUrl = dbModel.AvatarUrl,
                    })
                .ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserViewModel viewModel)
        {
            _userService.AddUser(viewModel);
            return RedirectToAction("Index");
        }
    }
}
