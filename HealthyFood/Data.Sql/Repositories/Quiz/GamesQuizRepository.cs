
using Data.Interface.Models.Quizes;
using Data.Interface.Repositories.Quiz;

namespace Data.Sql.Repositories.Quiz
{
    public class GamesQuizRepository : BaseRepository<GamesQuiz>, IGamesQuizRepository
    {
        public GamesQuizRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
