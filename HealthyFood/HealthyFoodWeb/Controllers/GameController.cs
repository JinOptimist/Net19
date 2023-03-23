using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class GameController : Controller
    {
        private IRecomendateGameService _recomendateGameService;

        public GameController(IRecomendateGameService recomendateGameService)
        {
            _recomendateGameService = recomendateGameService;
        }

        public IActionResult Index()
        {
            var viewModels = _recomendateGameService
                .GetAllCheapGames()
                .Select(x => new GameViewModel
                {
                    GameName = x.Name,
                })
                .ToList();

            return View(viewModels);
        }

        public IActionResult RecomendateGame()
        {
            var bestGameName = _recomendateGameService.GetTheBestGameName();
            var recomendateGameViewModel = new GameViewModel
            {
                GameName = bestGameName,
            };
            return View(recomendateGameViewModel);
        }
    }
}
