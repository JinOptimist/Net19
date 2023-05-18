using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class CatalogControllerV2 : Controller
    {
        private IGameService _gameService;

        public CatalogControllerV2(IGameService gameService)
        {
            _gameService = gameService;
        }
        //public IActionResult Index()
        //{
        //    var viewModels = _gameService
        //        .AllGames()
        //        .ToList();

        //    return View(viewModels);
        //}
        public IActionResult Index(int page = 1, int perPage = 9)
        {
            var viewModel = _gameService.GetGamesForPaginator(page, perPage);
            return View(viewModel);
        }
    }
}
