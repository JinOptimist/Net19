using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Data.Sql.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(WebContext webContext) : base(webContext)
        {
        }

        public Game GetGameByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public List<Game> GetGamesByUserId(int userId)
        {
            return _dbSet.Where(x => x.Creater.Id == userId).ToList();
        }

        public Game GetTheRichGameWithGenres()
        {
            return _dbSet
                .Include(x => x.Genres)
                .Include(x => x.ScreenShots)
                .OrderByDescending(x => x.Price)
                .First();
        }
        public GameAndScreensData GetTheScreenWithUser()
        {
            var game = _dbSet
                .Select(gameDb =>
                new GameAndScreensData
                {
                    GameCoverUrl = gameDb.CoverUrl,
                    GameName = gameDb.Name,
                    ScreenAndUser = gameDb.ScreenShots.Select(screenshotDb =>
                    new ScreenAndAuthorNameData
                    {
                        ScreenUrl = screenshotDb.UrlScreen,
                        AuthorName = screenshotDb.User.Name
                    }).ToList(),
                })
                .First();
            return game;
        }

        public void RemoveByName(string name)
        {
            var game = GetGameByName(name);
            Remove(game.Id);
        }
    }
}
