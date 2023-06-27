using Data.Interface.Models.WikiMc;
using HealthyFoodWeb.Models.WikiMcModels;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers.API
{
    [ApiController]
    [Route("/api/wiki")]
    public class WikiApiController : Controller
    {
        private IWikiMcService _wikiMcService;
        private IWikiBAAPageServices _wikiBAAPageServices;

        public WikiApiController(
            IWikiMcService wikiMcService,
            IWikiBAAPageServices wikiBAAPageServices)
        {
            _wikiMcService = wikiMcService;
            _wikiBAAPageServices = wikiBAAPageServices;
        }

        [Route("ImagesCount")]
        public WikiMcImagesCountViewModel GetImagesCount(int? year, string? tag, ImgTypeEnum type)
        {
            var viewModel = _wikiMcService.GetViewModelForImagesCount(year, tag, type);
            return viewModel;
        }

        [Route("AddComment")]
        public int AddComment(string comment, int blockId)
        {
            var commentId = _wikiBAAPageServices.CreateComment(blockId, comment);
            return commentId;

        }

        [Route("RemoveComment")]
        public void RemoveComment(int id)
        {
            _wikiBAAPageServices.RemoveComment(id);
        }
    }
}
