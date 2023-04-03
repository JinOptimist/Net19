using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public interface IGameFruitConnectTwoService
    {
        public List<ISimilarGamesDbModel> GetSimilarGameList();

        public void AddGame(GetFruitConnectTwoViewModel model);
        public void RemoveGame(int id);
        public void RemoveGame(string name);
    }
}