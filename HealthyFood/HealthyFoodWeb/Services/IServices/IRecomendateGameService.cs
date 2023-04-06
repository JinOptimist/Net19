using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IGameService
    {
        Game GetTheBestGameWithGenres();

        string GetTheBestGameName();

        void CreateGame(GameViewModel viewModel);

        List<Game> GetAllCheapGames();

        List<Game> GetAllRichGames();

        void Remove(string name);
        List<Game> GetGamesWhithTheirPlayers();
    }
}