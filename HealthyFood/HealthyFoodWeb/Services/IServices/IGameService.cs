using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IGameService
    {
        string GetTheBestGameName();

        void CreateGame(GameViewModel viewModel);

        List<IGameDbModel> GetAllCheapGames();

        List<IGameDbModel> GetAllRichGames();

        void Remove(string name);
    }
}