using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public interface IGameService
    {
        string GetTheBestGameName();

        void CreateGame(GameViewModel viewModel);

        List<IGameModel> GetAllCheapGames();

        List<IGameModel> GetAllRichGames();
    }
}