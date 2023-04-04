using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;
using HealthyFoodWeb.Models;

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

      
        public void AddGame(GetFruitConnectTwoViewModel model)
        {
            var dbmodel = new SimilarGamesDbModel()
            {
                SimilarGames = model.NameOfSimilarGame,
                Url = model.Url,
                LinkForPicture = model.LinkForPicture
            };

            _similarGameRepository.Add(dbmodel);
        }
        public void RemoveGame(int id)
        {
            _similarGameRepository.Remove(id);
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
