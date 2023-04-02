using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace HealthyFoodWeb.Services
{
    public class GameFruitConnectTwoService : IGameFruitConnectTwoService
    {
        private ISimilarGameRepository _similarGameRepository;
        public GameFruitConnectTwoService(ISimilarGameRepository similarGameRepository)
        {
            _similarGameRepository = similarGameRepository;
        }

        public List<ISimilarGamesDbModel> GetSimilarGameList()
        {
            return _similarGameRepository.GetAll().ToList();
        }
        public void AddGame(ISimilarGamesDbModel model)
        {
            var dbmodel = new SimilarGamesDbModel()
            {
                SimilarGames = model.SimilarGames
            };

            _similarGameRepository.Add(dbmodel);
        }

    }
    //public class GameCatalogService : IGameCatalogService
    //{
    //    private ICatalogRepository _catalogRepository;

    //    public GameCatalogService(ICatalogRepository catalogRepositories)
    //    {
    //        _catalogRepository = catalogRepositories;
    //    }

    //    public List<ICatalogDbModel> GetCatalog()
    //    {
    //        return _catalogRepository.GetAll().ToList();
    //    }

    //    public void AddCategory(GameCatalogVeiwModel viewModel)
    //    {

    //        var catalogDbModel = new CatalogDbModel
    //        {
    //            NameCategory = viewModel.NameCategory
    //        };
    //        _catalogRepository.Add(catalogDbModel);
    //    }
    //}
}
