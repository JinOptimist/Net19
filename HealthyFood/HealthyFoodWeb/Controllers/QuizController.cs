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
                .ToList().First();

            return View(viewModel);
        }
    }
}
