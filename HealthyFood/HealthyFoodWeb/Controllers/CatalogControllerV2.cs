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
        public IActionResult Index(int id)
        {
            var allgame = _gameService.GetGameViewModel(id);
            var recomendateGameViewModel = new GameViewModel
            {
                Id = allgame.Id,
                Name = allgame.Name,
            };
            return View(recomendateGameViewModel);
        }
    }
}
