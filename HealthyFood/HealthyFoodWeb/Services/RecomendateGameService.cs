using Data.Fake.Models;
using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

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
                CoverUrl = viewModel.CoverUrl
            };

            _gameRepository.Add(dbGameModel);
        }

        public List<IGameDbModel> GetAllCheapGames()
        {
            return _gameRepository
                .GetAll()
                .Where(x => x.Price < CHEAP_GAME_BORDER)
                .ToList();
        }

        public List<IGameDbModel> GetAllRichGames()
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
