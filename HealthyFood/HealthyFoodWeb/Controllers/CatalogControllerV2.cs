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
        public IActionResult Index()
        {
            var viewModels = _gameService
                .GetAllGames()
                .ToList();

            return View(viewModels);
        }
    }
}
