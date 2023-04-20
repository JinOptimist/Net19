using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class GameController : Controller
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new GameIndexViewModel();

            viewModel.CheapGames = _gameService
                .GetAllCheapGames()
                .Select(Conver)
                .ToList();

            viewModel.RichGames = _gameService
                .GetAllRichGames()
                .Select(Conver)
                .ToList();

            viewModel.TheBestGame = Conver(_gameService.GetTheBestGameWithGenres());

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateGame(GameViewModel viewModel)
        {
            _gameService.CreateGame(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            _gameService.Remove(name);
            return RedirectToAction("Index");
        }

        public IActionResult RecomendateGame()
        {
            var bestGameName = _gameService.GetTheBestGameName();
            var recomendateGameViewModel = new GameViewModel
            {
                Name = bestGameName,
            };
            return View(recomendateGameViewModel);
        }

        private GameViewModel Conver(Game x)
        {
            return new GameViewModel
            {
                Name = x.Name,
                CoverUrl = x.CoverUrl,
                Genres = x.Genres?.Select(x => x.Name).ToList() ?? new List<string>(),
                UrlScreenShots = x.ScreenShots?.Select(e => e.UrlScreen).ToList() ?? new List<string>(),
            };
        }
        //public IActionResult GameWithScreenAndAuthorName() 
        //{
        //    var authorScreen = _gameService.GetGameAndScreens();
        //    var screenAndAuthorNameModel = new ScreenAndAuthorNameViewModel
        //    {
        //        AuthorName = authorScreen.ScreenAndUser.,
        //    };
        //}
    }
}
