

namespace Guess_the_number
{
    public class StartGame
    {
        
        public void Start() //Воод данных и построение правил
        {
            Build build = new Build();  //класс в ктором вводятся данные и по ним генериуются правила игры
            build.InPutAndBuild();      //строятся правила
            var rule = build.SaveRules(); //сохраняются правила
            Turn(rule);
            DoItAgain();
        }
        private void Turn(Rules rule) //ход игры
        {
            Console.WriteLine($"Кол-во попыток и максимальное колическо очков {rule.AttepmtCount}");
            int maxBonus = (int)rule.AttepmtCount;
            int resultPoint;
            int attepmtCount = 0;
            int userGuess;
            string resultGame;
            do
            {
                Console.WriteLine($"Угадвайте число в диапазоне от {rule.Min} до {rule.Max}");
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
                        if (userGuess < rule.Min || userGuess > rule.Max)
                            Console.WriteLine("Число не в диапазоне");
                    } while (!isItWasANumber || userGuess < rule.Min || userGuess > rule.Max);


                    if (userGuess == rule.TheNumber)
                    {
                        Console.WriteLine("Верно");
                        resultGame = "Вы победили!";
                    }
                    else
                    {
                        int attempt = (int)rule.AttepmtCount - attepmtCount;
                        Console.WriteLine("Не правильно");
                        resultGame = "Вы проиграли!";
                        if (attempt == 0)
                        {
                            resultPoint = 0;
                            break;
                        }
                        if (userGuess > rule.TheNumber)
                        {
                            rule.Max = userGuess;
                            rule.Max--;
                            Console.WriteLine($"Ваше число больше загаданного. Угадайте в диапазон от {rule.Min} до {rule.Max}");
                        }
                        else if (userGuess < rule.TheNumber)
                        {
                            rule.Min = userGuess;
                            rule.Min++;
                            Console.WriteLine($"Ваше число меньше нужного. Угадайте в диапазон от { rule.Min} до { rule.Max}");
                        }
                        if (attempt > 0)
                            Console.WriteLine($"Кол-во попыток {attempt}");
                    }

                }
            }
            while (rule.TheNumber != userGuess && attepmtCount < rule.AttepmtCount);

            Console.WriteLine($"Вы использовали {attepmtCount} попыток. {resultGame}. Заработано {resultPoint} очков");
            Console.ReadKey();
            Console.Clear();
        }  //ход игры
        private void DoItAgain() //хочет ли пользователь сыграть еще раз
        {
            int toContinue;
            bool toContonueBoalen;
            do
            {
                Console.WriteLine("Желаете сыграть еще? \n1. Да \n2. Нет");
                string toContinueStr = Console.ReadLine();
                toContonueBoalen = int.TryParse(toContinueStr, out toContinue);
                if (toContinue == 1)
                {
                    Console.Clear();
                    Start();
                }
                else if (toContinue == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Всего хорошего!");
                    Console.ReadKey();
                    return;
                }
            }
            while (toContinue != 2);
        } 
    }
}

