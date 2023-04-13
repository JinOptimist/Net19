using Data.Fake.Repositories;
using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class GameCatalogController : Controller
    {
        private IGameCatalogService _gameCatalogService;
        private IGameFruitConnectTwoService _gameFruitConnectTwoService;
        private IReviewService _reviewService;

        public GameCatalogController(
            IGameCatalogService gameCatalog, IGameFruitConnectTwoService gameFruitConnectTwoService, IReviewService reviewService)
        {
            _gameCatalogService = gameCatalog;
            _gameFruitConnectTwoService = gameFruitConnectTwoService;
            _reviewService = reviewService;
        }

        public IActionResult GetCatalog()
        {

            var viewModels = _gameCatalogService
               .GetCatalog()
               .Select(dbModel =>
                   new GameCatalogVeiwModel
                   {
                       NameCategory = dbModel.Name
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
                    NameOfSimilarGame = dbModel.Name,
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
        public IActionResult Remove(int id)
        {
            _gameFruitConnectTwoService.RemoveGame(id);
            return RedirectToAction("GetFruitConnectTwo");
        }
       
        public IActionResult Donate()
        {

            return View();
        }
       [HttpGet]
        public IActionResult Review()
        {

            var viewModels = _reviewService
              .GetAllReviews()
              .Select(dbModel =>
                  new ReviewViewModel
                  {
                     TextReview = dbModel.TextReview
                  })
              .ToList();
            return View(viewModels);
        }
        [HttpPost]
        public IActionResult Review(ReviewViewModel viewmodel)
        {
            var ViewModel = new ReviewViewModel();
            return View(ViewModel);
        }
    }
}
