using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class GameCatalogService : IGameCatalogService
    {
        private IGameCategoryRepository _catalogRepository;

        public GameCatalogService(IGameCategoryRepository catalogRepositories)
        {
            _catalogRepository = catalogRepositories;
        }

        public List<GameCategory> GetCatalog()
        {
            return _catalogRepository.GetAll().ToList();
        }
     
        public void AddCategory(GameCatalogVeiwModel viewModel)
        {

            var catalogDbModel = new GameCategory
            {
                Name = viewModel.NameCategory
            };
            _catalogRepository.Add(catalogDbModel);
        }
    }
}

