using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class GameFruitController : Controller
    {
        private IGameCatalogService _gameCatalogService;

        public GameFruitController(IGameCatalogService gameCatalog)
        {
            _gameCatalogService = gameCatalog;
        }

        public IActionResult GameFruit()
        {
            List<ICatalog> catalogs = _gameCatalogService.GetCatalog();
            var gameFruitVeiwModel = new GameFruitVeiwModel();
            gameFruitVeiwModel.catalog = _gameCatalogService.GetCatalog().Select(x => new CatalogModel
            {
                NameCategory = x.NameCategory,
            }).ToList();
            return View(gameFruitVeiwModel);
        }
    }
}
