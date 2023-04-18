using HealthyFoodWeb.Models.ModelsWiki;
using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Models;
using Data.Sql.Models;
using Data.Interface.Models;
using Data.Interface.Models;
using Microsoft.AspNetCore.Authorization;
using static System.Net.Mime.MediaTypeNames;

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

        [HttpGet]
        public IActionResult BiologicallyActiveAdditives()
        {
            var PageViewModel = new BLockPageBaaViewModel();
            PageViewModel.pageBaaViewModel = new Models.ModelsWiki.PageBaaViewModel();

            PageViewModel.pageBaaViewModel.BlocksList = _blockInformationServices.GetBlocks().Select(Convert).ToList();

			PageViewModel.BlocksListWithAuthors = _blockInformationServices.GetBlocksWithAuthors().Select(Convert).ToList();
            PageViewModel.pageBaaViewModel.BlocksListWithAuthor = _blockInformationServices.GetBlocksWithAuthor().Select(Convert).ToList();

            PageViewModel.pageBaaViewModel.AuthorWithComments = _blockInformationServices.GetComments().Select(x => new BLockPageBaaViewModel
            {
                CommentText=x.Text
            }).ToList();

            return View(PageViewModel);
        }

		public IActionResult MacronutrientCalculator()
		{
			var viewModel = new WikiMCImgViewModel();

			viewModel.AllImgByType = _wikiMCImgService
				.GetAllImgByType()
				.Select(imageDb => new WikiMCViewModel
                {
					ImgPath = imageDb.ImgUrl,
                    Tags = imageDb.Tags?.Select(t => t.Tag).ToList() ?? new List<string>()
                })
				.ToList();

			viewModel.AllImgByYear = _wikiMCImgService
				.GetAllImgByYear()
				.Select(imageDb => new WikiMCViewModel
				{
					ImgPath = imageDb.ImgUrl,
					Tags = imageDb.Tags?.Select(t => t.Tag).ToList() ?? new List<string>()
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

        [HttpPost]
        public IActionResult BiologicallyActiveAdditives(BLockPageBaaViewModel comment)
        {
            _blockInformationServices.CreateComment(comment);
            return RedirectToAction("BiologicallyActiveAdditives");
        }

        public IActionResult Remove(int id)
        {
            _blockInformationServices.Remove(id);
            return RedirectToAction("BiologicallyActiveAdditives");
        }

		[HttpGet]
		[Authorize]
		public IActionResult AddImg()
        {
            return View();
        }

		[HttpPost]
		[Authorize]
		public IActionResult AddImg(WikiMCViewModel viewModel)
		{
			_wikiMCImgService.AddImg(viewModel);
			return RedirectToAction("AddImg");

		}

        [HttpGet]
        [Authorize]
        public IActionResult ShowUploadedImages()
        {
            var viewModel = new WikiUserImagesViewModel();

            viewModel.UserImages = _wikiMCImgService
                .GetUserImages()
                .Select(imageDb => new WikiMCViewModel
                {
                    ImgPath = imageDb.ImgUrl,
                })
                .ToList();

            return View(viewModel);
        }

        private BLockPageBaaViewModel Convert(PageWikiBlock x)
		{
			return new BLockPageBaaViewModel
			{
				Id = x.Id,
				Text = x.Text,
				Title = x.Title,
				Author = x.Author?.Name,
				pageBaaViewModel = new Models.ModelsWiki.PageBaaViewModel()
			};
		}
	}
}