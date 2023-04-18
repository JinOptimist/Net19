using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class GameCategoryRepository : BaseRepository<GameCategory>, IGameCategoryRepository
    {
        public GameCategoryRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}

