using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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
            viewModel.AllImgByType = _wikiMCImgService
                .GetAllImgByType()
                .Select(x => new WikiMCViewModel
                {
                    ImgPath = x.ImgUrl,
                })
                .ToList();

            viewModel.AllImgByYear = _wikiMCImgService
                .GetAllImgByYear()
                .Select(x => new WikiMCViewModel
                {
                    ImgPath = x.ImgUrl,
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
		public IActionResult AddImg(WikiMCViewModel viewModel)
		{
			_wikiMCImgService.AddImg(viewModel);
			return RedirectToAction("MacronutrientCalculator");
		}
	}
}