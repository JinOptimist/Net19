using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public GameAndPaginatorData GetGamesForPaginator(int page, int perPage)
        {
            var dataModel = new GameAndPaginatorData();
            var games = _dbSet
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();
            dataModel.Games = games;
            dataModel.TotalCount = _dbSet.Count();
            return dataModel;
        }

        public Game GetTheRichGameWithGenres()
        {
            return _dbSet
                .Include(x => x.Genres)
                .OrderByDescending(x => x.Price)
                .First();
        }

        public void RemoveByName(string name)
        {
            var game = GetGameByName(name);
            Remove(game.Id);
        }
    }
}
