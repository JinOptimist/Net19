using Data.Fake.Repositories;
using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class GameCatalogController : Controller
    {
        private IGameCatalogService _gameCatalogService;
        private IGameFruitConnectTwoService _gameFruitConnectTwoService;
    
        public GameCatalogController(IGameCatalogService gameCatalog, IGameFruitConnectTwoService gameFruitConnectTwoService)
        {
            _gameCatalogService = gameCatalog;
            _gameFruitConnectTwoService = gameFruitConnectTwoService;
        }

        public IActionResult GetCatalog()
        {

            var viewModels = _gameCatalogService
               .GetCatalog()
               .Select(dbModel =>
                   new GameCatalogVeiwModel
                   {
                       NameCategory = dbModel.NameCategory

                   })
               .ToList();

            return View(viewModels);

        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(GameCatalogVeiwModel viewModel)
        {
            _gameCatalogService.AddCategory(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult GetFruitConnectTwo()
        {

            var viewModels = _gameFruitConnectTwoService
                .GetSimilarGameList()
                .Select(dbModel => new GetFruitConnectTwoViewModel
                {
                    NameOfSimilarGame = dbModel.SimilarGames,
                    Url = dbModel.Url,
                    LinkForPicture = dbModel.LinkForPicture,
                    Id = dbModel.Id
                })
                .ToList();
          
            return View(viewModels);
        }
        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGame(GetFruitConnectTwoViewModel viewModel)
        {
            _gameFruitConnectTwoService.AddGame(viewModel);
            return RedirectToAction("GetFruitConnectTwo");
        }
        //public IActionResult Remove(int id)
        //{
        //    _gameFruitConnectTwoService.RemoveGame(id);
        //    return RedirectToAction("GetFruitConnectTwo");
        //}
        public IActionResult Remove(string name)
        {
            _gameFruitConnectTwoService.RemoveGame(name);
            return RedirectToAction("GetFruitConnectTwo");
        }
    }
}
