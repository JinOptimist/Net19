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
        
        public IActionResult StartQuiz(int numberOfQuestion = 0)
        {
            var viewModel = _quizServices.GetQuestion(numberOfQuestion);
            return View(viewModel);
        }
        //[HttpPost]
        //public IActionResult StartQuiz(RouteValueDictionary numberOfQuestion)
        //{

        //    var viewModel = _quizServices.GetQuestion(Convert.ToInt32(numberOfQuestion));
        //    return View(viewModel);
        //}
        [HttpPost]
        public IActionResult NextStep(StartQuizViewModel model)
        {
            //var routeValues = new RouteValueDictionary
            //{
            //      { "numberOgQuestion", model.Number }
            //};
            var a = new StartQuizViewModel
            {
                //IsItTrueAnswer = model.IsItTrueAnswer,
                Number = model.Number
            };
            //return View(a);
            return RedirectToAction("StartQuiz", "Quiz", new { numberOfQuestion = model.Number });
            //return RedirectToAction("StartQuiz", new {numberOfQuestion = model.Number });
        }
    }
}
