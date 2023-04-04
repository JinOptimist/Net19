<<<<<<< HEAD
﻿using Data.Fake.Models;
using HealthyFoodWeb.Models.ModelsWiki;
using Data.Interface.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;
=======
﻿using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
>>>>>>> main

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {
<<<<<<< HEAD
        private IWikiBAAIPageRecomendateServices _blockInformationServices;
=======
        private IWikiMCService _wikiMCImgService;

        public WikiController(IWikiMCService wikiMCImgService)
        {
            _wikiMCImgService = wikiMCImgService;
        }

        public IActionResult Main()
>>>>>>> main


        public WikiController(IWikiBAAIPageRecomendateServices blockInformationServices)
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
            var PageViewModel = new PageViewModelBAA();
            PageViewModel.BlocksList = _blockInformationServices.GetBlocks().Select(x => new BLockPageViewModelBAA
            {
                Text = x.Text,
                Title = x.Title,
                Id=x.Id
            }).ToList();

            return View(PageViewModel);
        }

        [HttpGet]
        public IActionResult CreateBlockInformatoin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlockInformatoin(BLockPageViewModelBAA block)
        {
            _blockInformationServices.CreateBlock(block);
            return RedirectToAction("BiologicallyActiveAdditives");
        }

        
        public IActionResult Remove(int id)
        {
            _blockInformationServices.Remove(id);
            return RedirectToAction("BiologicallyActiveAdditives");
        }
<<<<<<< HEAD
    }
=======
        
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
>>>>>>> main
}