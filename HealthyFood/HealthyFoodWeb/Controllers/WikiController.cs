using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Models;
using Data.Sql.Models;
using Microsoft.AspNetCore.Authorization;

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {
        private IWikiBAAPageServices _blockInformationServices;

        private IWikiMcService _wikiMCImgService;

        public WikiController(IWikiBAAPageServices blockInformationServices, IWikiMcService wikiMCImgService)
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
                .GetBlocksWithAuthorAndComments()
                .Select(
                x => new BLockPageBaaViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    Author = x.Author.Name,
                    CommentText = x.Comment?.Select(x => x.Text).ToList() ?? new List<string>()
                })
                .ToList();

            return View(pageViewModels);
        }

        public IActionResult MacronutrientCalculator()
        {
            var viewModel = new WikiMcImgViewModel();
            viewModel.AllImgByType = _wikiMCImgService
                .GetAllImgByType()
                .Select(x => new WikiMcViewModel
                {
                    ImgPath = x.ImgUrl,
                })
                .ToList();

            viewModel.AllImgByYear = _wikiMCImgService
                .GetAllImgByYear()
                .Select(x => new WikiMcViewModel
                {
                    ImgPath = x.ImgUrl,
                    UserTags = x.Tags?.Select(x => x.TagName).ToList() ?? new List<string>()
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
        public IActionResult BiologicallyActiveAdditives(string newComment, int blockId)
        {
            _blockInformationServices.CreateComment(blockId, newComment);
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
		public IActionResult AddImg(WikiMcViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

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
				.Select(imageDb => new WikiMcViewModel
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