using Data.Interface.DataModels;
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
        List<GameViewModel> GetAllGames();

        void Remove(string name);

        GameAndPaginatorData GetGamesForPaginator(int page, int perPage);
        
        GameViewModel GetGameViewModel(int id);
        
        void UpdateNameAndCover(int id, string name, string coverUrl);
        void UpdateGenres(int id, List<string> genres);
    }
}