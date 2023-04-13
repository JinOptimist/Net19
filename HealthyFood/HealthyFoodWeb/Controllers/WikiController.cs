using HealthyFoodWeb.Models.ModelsWiki;
using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Models;
using Data.Sql.Models;

namespace HealthyFoodWeb.Controllers
{
	public class WikiController : Controller
	{

		private IWikiBAAPageServices _blockInformationServices;

		private IWikiMCService _wikiMCImgService;

		public WikiController(IWikiBAAPageServices blockInformationServices, IWikiMCService wikiMCImgService)
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

			PageViewModel.BlocksList = _blockInformationServices.GetBlocks().Select(Convert).ToList();

			PageViewModel.BlocksListWithAuthors = _blockInformationServices.GetBlocksWithAuthors().Select(Convert).ToList();

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
            viewModel.AllImgByYear = _wikiMCImgService
                .GetAllImgByYear()
                .Select(x => new WikiMCViewModel
                {
                    ImgPath = x.ImgUrl,
                })
                .ToList();
            viewModel.GetTags = _wikiMCImgService
                .GetTags()
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

		private BLockPageBaaViewModel Convert(PageWikiBlock x)
		{
			return new BLockPageBaaViewModel
			{
				Id = x.Id,
				Text = x.Text,
				Title = x.Title,
				Authors = x.Authors?.Select(x => x.Name).ToList()
			};
		}
	}
}