using Game1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game1.Controllers
{
    public class Game1Controller : Controller
    {
        public IActionResult Game1(int result = 0)
        {
            var game1 = new Game1ViewModel();
            game1.Result = result;


            return View(game1);
        }
        public IActionResult DoIt(Game1ViewModel game1)
        {
            switch (game1.TypeOfWork)
            {
                case TypeOfWork.Сложение:
                    game1.Result = game1.FirstNumber + game1.SecondNumber;
                    break;
                case TypeOfWork.Вычитание:
                    game1.Result = game1.FirstNumber - game1.SecondNumber;
                    break;
                case TypeOfWork.Умножение:
                    game1.Result = game1.FirstNumber * game1.SecondNumber;
                    break;
                case TypeOfWork.Деление:
                    game1.Result = game1.FirstNumber / game1.SecondNumber;
                    break;
            }

            return RedirectToAction("Game1", new { result = game1.Result });
        }
    }
}
