
using Data.Interface.DataModels;
using Data.Interface.Models.Quizes;
using Data.Interface.Repositories.Quiz;
using Data.Sql.DataModels;

namespace Data.Sql.Repositories.Quiz
{
    public class GamesQuizRepository : BaseRepository<GamesQuiz>, IGamesQuizRepository
    {
        public GamesQuizRepository(WebContext webContext) : base(webContext)
        {
        }

        public PlayingQuiz GetAllQuestion()
        {
            var thisQuiz = _dbSet.First();

            return new PlayingQuiz
            {
                QuestionsText = thisQuiz.Questions.Select(x => x.QuestionText).ToList()
            };
        }
    }
}
