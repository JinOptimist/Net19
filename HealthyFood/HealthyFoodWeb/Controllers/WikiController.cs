using HealthyFoodWeb.Models.ModelsWiki;
using HealthyFoodWeb.Services.WikiServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {
        private BlockInformationServices _blockInformationServices;

        public WikiController(BlockInformationServices blockInformationServices)
        {
            _blockInformationServices = blockInformationServices;
        }

        public IActionResult Main()
        {
            //step 1
            return View();
        }

        public IActionResult BiologicallyActiveAdditives()
        {
            var title = _blockInformationServices.BlockInformation();
            var blockInformationModels = new BlockInformationModels()
            {
                Title = title,
            };

            return View(blockInformationModels);
        } 
    }
}