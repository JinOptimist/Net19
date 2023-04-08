
using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private WebContext _webContext;

        public QuizRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
        
        public IEnumerable<Quiz> GetInfoAboitQuizGamed()
        {
           
            return _webContext.Quizes.ToList();
        
        }

    }
}
