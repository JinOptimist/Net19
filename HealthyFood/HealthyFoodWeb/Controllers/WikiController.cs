using HealthyFoodWeb.Models.ModelsWiki;
using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Models;
using Data.Sql.Models;
using Data.Interface.Models;
using Microsoft.AspNetCore.Authorization;

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
            var pageViewModels = _blockInformationServices
                .GetBlocksWithAuthor()
                .Select(
                x => new BLockPageBaaViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    Author = x.Author.Name,
                    CommentText = x.Author.Comments.Select(x => x.Text).ToList()
                })
                .ToList();

            return View(pageViewModels);
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
                    Tags = x.Tags?.Select(x => x.TagName).ToList() ?? new List<string>()
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
        public IActionResult BiologicallyActiveAdditives(string newComment, int pageId)
        {
            _blockInformationServices.CreateComment(pageId, newComment);
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
            };
        }
    }
}