using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult storePageCatalogue()
        {
            return View();
        }

    }
}

