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

        public IActionResult Profile(string name = "Ivan",int kalkulatedNumberOne = 0, int kalkulatedNumberTwo = 0,int kalkulatedResult = 0)
        {
            var model = new ProfileViewModel()
            {
                Name = name,
                Operator = MathOperationEnum.Plus,
                KalkulatedNumberOne = kalkulatedNumberOne,
                KalkulatedNumberTwo = kalkulatedNumberTwo,
                KalkulatedResult = kalkulatedResult,
            };
            
            if (name == "admin")
            {
                model.Coins = 1000;
            }
            else
            {
                model.Coins = 10;
            }

            model.KalkulatedResult = model.KalkulatedNumberOne + model.KalkulatedNumberTwo;

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateName(ProfileViewModel model)
        {
            return RedirectToAction("Profile", new { name = model.ActualName });
        }

        [HttpPost]
        public IActionResult kalkulated(ProfileViewModel model)
        {
            return RedirectToAction("Profile", new { kalkulatedNumberOne = model.KalkulatedNumberOne,
                kalkulatedNumberTwo = model.KalkulatedNumberTwo,
                kalkulatedResult = model.KalkulatedResult});
        }
     
        
    }
}