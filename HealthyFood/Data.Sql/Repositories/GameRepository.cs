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
