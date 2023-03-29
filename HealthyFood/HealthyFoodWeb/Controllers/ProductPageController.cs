using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class ProductPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductPage()
        {
            return View();
        }
    }
}
