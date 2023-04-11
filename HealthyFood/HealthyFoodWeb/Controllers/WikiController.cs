using HealthyFoodWeb.Models.ModelsWiki;
using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {

        private IWikiBAAIPageRecomendateServices _blockInformationServices;
        private IWikiMCService _wikiMCImgService;

        public WikiController(IWikiBAAIPageRecomendateServices blockInformationServices, IWikiMCService wikiMCImgService)
        {
            _blockInformationServices = blockInformationServices;
            _wikiMCImgService = wikiMCImgService;
        }

        public IActionResult Main()
        {
            //step 1
            return View();
        }

        public IActionResult BiologicallyActiveAdditives()
        {
            var PageViewModel = new PageBaaViewModel();
            PageViewModel.BlocksList = _blockInformationServices.GetBlocks().Select(x => new BLockPageBaaViewModel
            {
                Text = x.Text,
                Title = x.Title,
                Id=x.Id
            }).ToList();

            return View(PageViewModel);
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
        public IActionResult CreateBlockInformatoin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlockInformatoin(BLockPageBaaViewModel block)
        {
            _blockInformationServices.CreateBlock(block);
            return RedirectToAction("BiologicallyActiveAdditives");
        }

        
        public IActionResult Remove(int id)
        {
            _blockInformationServices.Remove(id);
            return RedirectToAction("BiologicallyActiveAdditives");
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