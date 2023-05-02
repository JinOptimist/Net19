using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.Games;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                .Select(Convert)
                .ToList();

            viewModel.RichGames = _gameService
                .GetAllRichGames()
                .Select(Convert)
                .ToList();

            viewModel.TheBestGame = Convert(_gameService.GetTheBestGameWithGenres());

            return View(viewModel);
        }

        public IActionResult Games(int page = 1, int perPage = 10)
        {
            var viewModel = new GameAndPagginatorViewModel();
            var dataModel = _gameService.GetGamesForPaginator(page, perPage);
            viewModel.Games = dataModel
                .Games
                .Select(gameDb=> Convert(gameDb))
                .ToList();

            var doWeNeedOneMorePage = dataModel.TotalCount % perPage != 0;
            var totalPageCount =
                (dataModel.TotalCount / perPage)
                + (doWeNeedOneMorePage ? 1 : 0);

            viewModel.PageList = Enumerable
                .Range(1, totalPageCount)
                .ToList();
            viewModel.ActivePageNumber = page;
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
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

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

        public IActionResult Update(int id)
        {
            var viewModel = _gameService.GetGameViewModel(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(GameViewModel gameViewModel)
        {
            _gameService.UpdateNameAndCover(gameViewModel.Id, 
                gameViewModel.Name, 
                gameViewModel.CoverUrl);

            _gameService.UpdateGenres(gameViewModel.Id,
                gameViewModel.Genres);

            return RedirectToAction("Games", "Game");
        }

        private GameViewModel Convert(Game x)
        {
            return new GameViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CoverUrl = x.CoverUrl,
                Genres = x.Genres?.Select(x => x.Name).ToList() ?? new List<string>()
            };
        }
    }
}
