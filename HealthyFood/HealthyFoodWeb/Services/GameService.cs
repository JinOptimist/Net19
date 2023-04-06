using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class GameService : IGameService
    {
        public const decimal CHEAP_GAME_BORDER = 5;
        private IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void CreateGame(GameViewModel viewModel)
        {
            var dbGameModel = new Game()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
            };

            _gameRepository.Add(dbGameModel);
        }

        public Game GetTheBestGameWithGenres()
        {
            return _gameRepository.GetTheRichGameWithGenres();
        }
        public List<Game> GetGamesWhithTheirPlayers()
        {
            return _gameRepository.GetPlayers();
        }

        public List<Game> GetAllCheapGames()
        {
            return _gameRepository
                .GetAll()
                .Where(x => x.Price < CHEAP_GAME_BORDER)
                .ToList();
        }

        public List<Game> GetAllRichGames()
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
