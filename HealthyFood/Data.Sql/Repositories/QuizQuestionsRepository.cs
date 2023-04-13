using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class QuizQuestionsRepository : IQuizQuestionsRepository
    {
        private WebContext _webContext;
        public QuizQuestionsRepository(WebContext webContext)
        {
            _webContext = new WebContext();
        }
        public QuizQuestion Get(int id)
        {
            return _webContext.QuizQuestions.First(x=> x.Id == id);
        }
        public void Add(QuizPlayer model) //пока нет авторизации ид будет 1, потом будет меняться по пользователям
        {
            var thisGameNow = _webContext.QuizPlayers.First(x => x.Id == 1);
            thisGameNow.NumberQuestion = 1;
            _webContext.QuizPlayers.Update(thisGameNow);
            _webContext.SaveChanges();
        }
        public void Update(int id) //перейти к следующему вопросу
        {
            var thisGameNow = _webContext.QuizPlayers.First(x => x.Id == id);
            thisGameNow.NumberQuestion++;
            _webContext.QuizPlayers.Update(thisGameNow);
            _webContext.SaveChanges();
        }
        public QuizPlayer GetNubmerOfQuestion()
        {
            _webContext.
        }
    }
}
