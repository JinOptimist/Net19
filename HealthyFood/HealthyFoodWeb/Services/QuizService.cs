using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class QuizService : IQuizService
    {
        private IQuizRepository _quizRepository;
        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public List<Quiz> GetInfo()
        {
          return _quizRepository.GetInfoAboitQuizGamed().ToList();
        }
    }
}
