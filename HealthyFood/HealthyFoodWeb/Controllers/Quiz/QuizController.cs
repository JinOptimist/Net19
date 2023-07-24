using HealthyFoodWeb.Models.Quiz;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers.Quiz
{
    public class QuizController : Controller
    {
        private IQuizServices _quizServices;


        public QuizController(IQuizServices quizServices)
        {
            _quizServices = quizServices;
        }
        public IActionResult Index()
        {
            var viewModel = _quizServices.GetAllQuiz();
            return View(viewModel);
        }
        
        public IActionResult StartQuiz(int numberOfQuestion = 0, bool IsRightThisAnswer = false, int conutRight = 0)
        {
            var viewModel = _quizServices.GetQuestion(numberOfQuestion, IsRightThisAnswer, conutRight);
            if (viewModel.Ques != null)
            {
                return View(viewModel);
            }
            else return RedirectToAction("EndQuiz", "Quiz", new { allCount = viewModel.CountAllQuestions, rightCount  = viewModel.CountOfTrueAnswers});
        }
       
        [HttpPost]
        public IActionResult NextStep(StartQuizViewModel model)
        {
            return RedirectToAction("StartQuiz", "Quiz", new { 
                numberOfQuestion = model.Number, 
                IsRightThisAnswer = model.IsRightThisAnswer ,
                conutRight = model.CountOfTrueAnswers
            });
         
        }
        public IActionResult EndQuiz(int allCount, int rightCount)
        {
            var viewModel = new EndQuizVIewModel
            {
                CountAllQuestion = allCount,
                CountRightAnswer = rightCount
            };
            return View(viewModel);
        }
    }
}
