using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public class RecomendateGameService : IGameService
    {
        public const decimal CHEAP_GAME_BORDER = 5;
        private IGameRepository _gameRepository;

        public RecomendateGameService(IGameRepository gameRepositoryFake)
        {
            _gameRepository = gameRepositoryFake;
        }

        public void CreateGame(GameViewModel viewModel)
        {
            var dbGameModel = new GameModel()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
            };

            _gameRepository.SaveGame(dbGameModel);
        }

        public List<IGameModel> GetAllCheapGames()
        {
            return _gameRepository
                .GetAll()
                .Where(x => x.Price < CHEAP_GAME_BORDER)
                .ToList();
        }

        public List<IGameModel> GetAllRichGames()
        {
            return _gameRepository
                 .GetAll()
                 .Where(x => x.Price >= CHEAP_GAME_BORDER)
                 .ToList();
        }

        public string GetTheBestGameName()
        {
            //do some diff logic

            return _gameRepository.GetAll().First().Name;
        }

        public void Remove(string name)
        {
            _gameRepository.RemoveByName(name);
        }
    }
}
