using Data.Interface.Models;
using HealthyFoodWeb.Models.WikiMcModels;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers.API
{
    [ApiController]
	[Route("/api/wiki")]
	public class WikiApiController : Controller
	{
		private IWikiMcService _wikiMcService;

		public WikiApiController(IWikiMcService wikiMcService)
		{
			_wikiMcService = wikiMcService;
		}

		[Route("ImagesCount")]
		public WikiMcImagesCountViewModel GetImagesCount(int? year, string? tag, ImgTypeEnum type)
		{
			var viewModel = _wikiMcService.GetViewModelForImagesCount(year, tag, type);
			//Thread.Sleep(5 * 1000);
			return viewModel;
		}
	}
}
