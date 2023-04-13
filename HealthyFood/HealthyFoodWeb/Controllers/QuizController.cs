using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers
{
    public class QuizController : Controller
    {
        private IQuizService _quizService;
       
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        public IActionResult Index()
        {

            var viewModel = _quizService
                .GetInfo()
                .Select(x => new QuizViewModel
                {
                    QtyGames = x.QuantityOfPlayers,
                    QtyWinner = x.QuantityOfWinner,
                    QtyСorrect_answer = x.QuantityСorrect_answer
                })
                .First();
            _quizService.AddGame();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult StartQuiz()
        {
            
            var viewModel = new StartQuizViewModel()
            {
                Question = _quizService.Start(1).Question,
                AnswerOne = _quizService.Start(1).VariantOne,
                AnswerTwo = _quizService.Start(1).VariantTwo,
                AnswerThree = _quizService.Start(1).VariatThree,
                NumberOfQuestion = 1
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult StartQuiz(StartQuizViewModel viewModel)
        {
            


            return RedirectToAction("StartQuiz");
        }
    }
}
