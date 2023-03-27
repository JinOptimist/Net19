using Data.Interface.Models;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models.ModelsWiki;
using HealthyFoodWeb.Services.WikiServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {
        private IPageRecomendateServis _blockInformationServices;

        public WikiController(IPageRecomendateServis blockInformationServices)
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
            var blocks = _blockInformationServices.GetTitles();
            var pageModel = new PageModelBAA();
            foreach (IBlockModelBAA block in blocks)
            {
                pageModel.BlocksList.Add(block);
            }

            return View(pageModel);
        } 
    }
}