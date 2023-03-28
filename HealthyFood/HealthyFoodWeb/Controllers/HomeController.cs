using HealthyFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //step 1
            return View();
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
    }

    
}