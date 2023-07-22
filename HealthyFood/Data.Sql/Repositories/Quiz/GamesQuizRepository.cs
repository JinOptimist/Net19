
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
            var thisQuiz = _dbSet.Where(x => x.Id == 2);
            var a = thisQuiz.FirstOrDefault();
            var c = a.Questions.Select(x => x.QuestionText).ToList();
           return new PlayingQuiz
            {
                QuestionsText = a.Questions.Select(x => x.QuestionText).ToList()                     
            };
        }
    }
}
