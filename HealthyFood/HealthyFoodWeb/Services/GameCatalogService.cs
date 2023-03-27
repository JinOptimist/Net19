using Data.Interface.Models;
using Data.Interface.Repositories;

namespace HealthyFoodWeb.Services
{
    public class GameCatalogService : IGameCatalogService
    {
        private ICatalogRepositories _ICatalogRepositories;

        public GameCatalogService(ICatalogRepositories iCatalogRepositories)
        {
            _ICatalogRepositories = iCatalogRepositories;
        }

        public List<ICatalog> GetCatalog()
        {
            return _ICatalogRepositories.GetCatalog();
        }
    }
}
