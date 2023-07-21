
using Data.Interface.Models.Quizes;
using Data.Interface.Repositories.Quiz;

namespace Data.Sql.Repositories.Quiz
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
