using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {
        public IActionResult Main()

        {
            //step 1
            return View();
        }

        public IActionResult BiologicallyActiveAdditives()
        {
          return View();
        }
    }

    
}