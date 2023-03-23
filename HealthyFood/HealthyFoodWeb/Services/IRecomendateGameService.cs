using Data.Interface.Models;

namespace HealthyFoodWeb.Services
{
    public interface IRecomendateGameService
    {
        string GetTheBestGameName();

        List<IGameModel> GetAllCheapGames();
    }
}