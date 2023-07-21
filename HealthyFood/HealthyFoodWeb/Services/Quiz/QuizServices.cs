using Data.Interface.Models.Quizes;
using Data.Interface.Repositories.Quiz;
using HealthyFoodWeb.Models.Quiz;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services.Quiz
{
    public class QuizServices : IQuizServices
    {
        IGamesQuizRepository _gamesQuizRepository;

        public QuizServices(IGamesQuizRepository gamesQuizRepository)
        {
            _gamesQuizRepository = gamesQuizRepository;
        }
        public QuizViewModel GetAllQuiz()
        {
            var viewmodel = new QuizViewModel
            {
                Name = _gamesQuizRepository.GetAll().Select(x => x.NameQuiz).ToList()
            };

            return viewmodel;
        }
    }
}
