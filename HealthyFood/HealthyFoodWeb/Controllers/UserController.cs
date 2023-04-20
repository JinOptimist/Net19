using Data.Sql;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userService.Login(viewModel.Login, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(viewModel.Login), "Wrong login. Or password. Or both");

                return View(viewModel);
            }

            var claims = new List<Claim>() {
                    new Claim(AuthService.AUTH_CLAIMS_ID_NAME, user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim(ClaimTypes.AuthenticationMethod, AuthService.AUTH_NAME)
                };

            var identity = new ClaimsIdentity(claims, AuthService.AUTH_NAME);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
