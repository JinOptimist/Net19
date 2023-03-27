using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.Wiki;
using HealthyFoodWeb.Models.WikiModels;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class WikiMacronutrientCalculatorController : Controller
    {
        private IWikiMCImgService _wikiMCImgService;

        public WikiMacronutrientCalculatorController(IWikiMCImgService wikiMCImgService)
        {
            _wikiMCImgService = wikiMCImgService;
        }

        public IActionResult Index()
        {
            var viewModel = new ImgMCWikiViewModel();
            viewModel.ImgByType = _wikiMCImgService
                .GetAllImgByType()
                .Select(x => new MacronutrientCalculatorIMGViewModel
                {
                    Type = x.Type,
                })
                .ToList();

            viewModel.ImgByYear = _wikiMCImgService
                .GetAllImgByYear()
                .Select(x => new MacronutrientCalculatorIMGViewModel
                {
                    Year = x.Year,
                })
                .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddImg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImg(MacronutrientCalculatorIMGViewModel viewModel)
        {
            _wikiMCImgService.AddImg(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveImgByYear(int year)
        {
            _wikiMCImgService.RemoveByYear(year);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveImgByType(string type)
        {
            _wikiMCImgService.RemoveByType(type);
            return RedirectToAction("Index");
        }

        //public IActionResult AllImgByType()
        //{
        //    var imgByType = _wikiMCImgService.GetAllImgByType();
        //    var imgViewModel = new MacronutrientCalculatorIMGViewModel
        //    {
        //        Type =,
        //    };
        //    return View(imgViewModel);
        //}
    }
}
