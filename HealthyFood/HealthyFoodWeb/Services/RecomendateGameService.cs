using Data.Interface.Models;
using Data.Interface.Repositories;

namespace HealthyFoodWeb.Services
{
    public class RecomendateGameService : IRecomendateGameService
    {
        private IGameRepository _gameRepository;

        public RecomendateGameService(IGameRepository gameRepositoryFake)
        {
            _gameRepository = gameRepositoryFake;
        }

        public List<IGameModel> GetAllCheapGames()
        {
            return _gameRepository
                .GetAll()
                .Where(x => x.Price < 5)
                .ToList();
        }

        public string GetTheBestGameName()
        {
            //do some diff logic

            return _gameRepository.GetAll().First().Name;
        }
    }
}
