using Data.Interface.Models;

namespace HealthyFoodWeb.Services
{
    public interface IGameFruitConnectTwoService
    {
        public List<ISimilarGamesDbModel> GetSimilarGameList();

        public void AddGame(ISimilarGamesDbModel model);
       
    }
}