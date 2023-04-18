using Data.Interface.Models;
using Data.Sql.DataModels;

namespace Data.Interface.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Game GetGameByName(string name);

        void RemoveByName(string name);

        Game GetTheRichGameWithGenres();

        List<Game> GetGamesByUserId(int userId);
        GameAndScreensData GetTheScreenWithUser();
    }
}
