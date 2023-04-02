using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public class GameCatalogService : IGameCatalogService
    {
        private ICatalogRepository _catalogRepository;

        public GameCatalogService(ICatalogRepository catalogRepositories)
        {
            _catalogRepository = catalogRepositories;
        }

        public List<ICatalogDbModel> GetCatalog()
        {
            return _catalogRepository.GetAll().ToList();
        }
     
        public void AddCategory(GameCatalogVeiwModel viewModel)
        {

            var catalogDbModel = new CatalogDbModel
            {
                NameCategory = viewModel.NameCategory
            };
            _catalogRepository.Add(catalogDbModel);
        }
    }
}

