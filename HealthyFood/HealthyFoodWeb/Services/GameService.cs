using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class GameService : IGameService
    {
        public const decimal CHEAP_GAME_BORDER = 5;
        private IGameRepository _gameRepository;
        private IAuthService _authService;

        public GameService(IGameRepository gameRepository, IAuthService authService)
        {
            _gameRepository = gameRepository;
            _authService = authService;
        }

        public void CreateGame(GameViewModel viewModel)
        {
            var user = _authService.GetUser();
            var dbGameModel = new Game()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                CoverUrl = viewModel.CoverUrl,
                Creater = user
            };

            _gameRepository.Add(dbGameModel);
        }

        public Game GetTheBestGameWithGenres()
        {
            return _gameRepository.GetTheRichGameWithGenres();
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

        public GameAndScreensData GetGameAndScreens()
        {
            return _gameRepository.GetTheScreenWithUser();
        }
    }
}
