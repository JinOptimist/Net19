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

        public List<StartQuizViewModel> GetQuestion()
        {
            var infoAboutQuiz = _gamesQuizRepository.GetDbQuiz();
            //var allQuestions = a.Questions.Select(x=>x.QuestionText).ToList();
            var newList = new List<StartQuizViewModel>();
            for (int i =1; i<infoAboutQuiz.Count; i++)
            {
                var model = new StartQuizViewModel
                {
                    Ques = infoAboutQuiz[i].QuestionsText,
                    Answers = infoAboutQuiz[i].Answers
                };
                newList.Add(model);
            }
            return newList;
           
        }
    }
}
//var viewModels = _reviewService
//             .GetAllReviews()
//             .Select(dbModel =>
//                 new ReviewViewModel
//                 {
//                     TextReview = dbModel.TextReview,
//                     Date = dbModel.Date,
//                     Author = dbModel.UserName,
//                     CreatedGame = dbModel.GamesName.ToList(),
//                      //E/*rrorMessage = errorMessage*/
//                  })
//             .ToList();