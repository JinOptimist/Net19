using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult storePageCatalogue()
        {
            return View();
        }


        public IActionResult CartPage()
        {
            return View();
        }

    }
}
