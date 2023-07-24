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

        public StartQuizViewModel GetQuestion(int numberOfQuestion)
        {
            var infoAboutQuiz = _gamesQuizRepository.GetDbQuiz();
            if (numberOfQuestion <= infoAboutQuiz.Count)
            {
                for (int i = numberOfQuestion; ;)
                {
                    return new StartQuizViewModel
                    {
                        Ques = infoAboutQuiz[numberOfQuestion].QuestionsText,
                        Answers = infoAboutQuiz[numberOfQuestion].Answers,
                        Number = numberOfQuestion + 1,
                        IsItTrueAnswer = infoAboutQuiz[numberOfQuestion].IsItTrue
                    };
                }
            }
            else throw new Exception();


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