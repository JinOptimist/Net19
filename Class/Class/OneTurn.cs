using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class GameManager
    {

        private GameRule _rule;
        public GameManager(GameRule rule) 
        {
            _rule = rule;
        }

        public void OneTurn()
        {
            
            int attepmtCount = 0;
            string resultGame;
            Console.WriteLine($"Кол-во попыток и максимальное колическо очков {_rule.MaxAttemptInGame}");
            int maxBonus = _rule.MaxAttemptInGame;
            int resultPoint;
            int userGuess;
            do
            {
                Console.WriteLine($"Угадвайте число в диапазоне от {_rule.Min} до {_rule.Max}");
                {
                    resultPoint = maxBonus - attepmtCount;
                    attepmtCount++;
                    bool isItWasANumber;
                    do
                    {

                        Console.WriteLine("Какое ваше число?");
                        var userGuessString = Console.ReadLine();
                        isItWasANumber = Int32.TryParse(userGuessString, out userGuess);
                        if (!isItWasANumber)
                        {
                            Console.WriteLine("Это не число");
                        }
                        if (userGuess < _rule.Min || userGuess > _rule.Max)
                            Console.WriteLine("Число не в диапазоне");
                    } while (!isItWasANumber || userGuess < _rule.Min || userGuess > _rule.Max);


                    if (userGuess == _rule.ThisNubmerInGame)
                    {
                        Console.WriteLine("Верно");
                        resultGame = "Вы победили!";
                    }
                    else
                    {
                        int attempt = (int)_rule.MaxAttemptInGame - attepmtCount;
                        Console.WriteLine("Не правильно");
                        resultGame = "Вы проиграли!";
                        if (attempt == 0)
                        {
                            resultPoint = 0;
                            break;
                        }
                        if (userGuess > _rule.ThisNubmerInGame)
                        {
                            _rule.Max = userGuess;
                            _rule.Max--;
                            Console.WriteLine($"Ваше число больше загаданного. Угадайте в диапазон от {_rule.Min} до {_rule.Max}");
                        }
                        else if (userGuess < _rule.ThisNubmerInGame)
                        {
                            _rule.Min = userGuess;
                            _rule.Min++;
                            //почему не работает вариант  _rule.Min = userGuess++;
                            Console.WriteLine($"Ваше число меньше нужного. Угадайте в диапазон от { _rule.Min} до { _rule.Max}");
                        }
                        if (attempt > 0)
                            Console.WriteLine($"Кол-во попыток {attempt}");
                    }

                }
            }
            while (_rule.ThisNubmerInGame != userGuess && attepmtCount < _rule.MaxAttemptInGame);
            Console.WriteLine($"Вы использовали {attepmtCount} попыток {resultGame}. Заработано {resultPoint} очков");
        }
        
    }
}

