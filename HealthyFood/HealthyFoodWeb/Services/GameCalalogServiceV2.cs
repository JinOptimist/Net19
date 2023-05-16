using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class GameCalalogServiceV2 : IGameService
    {
        private IGameRepository _gameRepository;
        private IGameCategoryRepository _gameCategoryRepository;
        private IAuthService _authService;
        public GameCalalogServiceV2(IGameRepository gameRepository,
    IAuthService authService,
    IGameCategoryRepository gameCategoryRepository)
        {
            _gameRepository = gameRepository;
            _authService = authService;
            _gameCategoryRepository = gameCategoryRepository;
        }
        public void CreateGame(GameViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllCheapGames()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllRichGames()
        {
            throw new NotImplementedException();
        }

        public GameAndPaginatorData GetGamesForPaginator(int page, int perPage)
        {
            throw new NotImplementedException();
        }

        public GameViewModel GetGameViewModel(int id)
        {
            var gameDb = _gameRepository.GetGameAndGenres(id);
            var genres = _gameCategoryRepository
                .GetAll()
                .Select(x => x.Name)
                .ToList();

            return new GameViewModel
            {
                Id = gameDb.Id,
                Name = gameDb.Name,
                CoverUrl = gameDb.CoverUrl,
                Price = gameDb.Price,
                AvailableGenres = genres,
                Genres = gameDb.Genres.Select(x => x.Name).ToList()
            };
        }

        public string GetTheBestGameName()
        {
            throw new NotImplementedException();
        }

        public Game GetTheBestGameWithGenres()
        {
            throw new NotImplementedException();
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateGenres(int id, List<string> genres)
        {
            throw new NotImplementedException();
        }

        public void UpdateNameAndCover(int id, string name, string coverUrl)
        {
            throw new NotImplementedException();
        }
    }
}
