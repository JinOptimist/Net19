using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {
        private IWikiMCService _wikiMCImgService;

        public WikiController(IWikiMCService wikiMCImgService)
        {
            _wikiMCImgService = wikiMCImgService;
        }

        public IActionResult Main()

        {
            //step 1
            return View();
        }

        public IActionResult BiologicallyActiveAdditives()
        {
          return View();
        }
        
        public IActionResult MacronutrientCalculator()
        {
            var viewModel = new WikiMCImgViewModel();
            viewModel.ImgByType = _wikiMCImgService
                .GetAllImgByType()
                .Select(x => new WikiMCViewModel
                {
                    ImgPath = x.Path,
                })
                .ToList();

            viewModel.ImgByYear = _wikiMCImgService
                .GetAllImgByYear()
                .Select(x => new WikiMCViewModel
                {
                    ImgPath = x.Path,
                })
                .ToList();

            return View(viewModel);
        }

    }

    
}