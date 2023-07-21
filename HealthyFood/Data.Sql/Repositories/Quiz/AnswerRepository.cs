

using Data.Interface.Models.Quizes;
using Data.Interface.Repositories.Quiz;

namespace Data.Sql.Repositories.Quiz
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
