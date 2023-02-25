
using HealthyFood;
using Test;

MakeMinAndMaxNumbers makeMinAndMaxNumbers = new MakeMinAndMaxNumbers();
makeMinAndMaxNumbers.Makeit();
//var rule = makeMinAndMaxNumbers.Makeit();
;
//GameRule gameRule = new();
Console.WriteLine("Записано значение" + makeMinAndMaxNumbers.rule.Min.ToString());


Game();
void Game()
{
    bool good = false;
    int rule;
    do
    {
        Console.WriteLine("Зададим правила игры. Введите число с вариантом игры:" +
        "\n1. Рандомный выбор диапазона и количества попыток" +
        "\n2. Задать диапазон вручную с авторассчетом попыток");
        var ruleStr = Console.ReadLine();
        bool ruleBool = int.TryParse(ruleStr, out rule);
        if (rule == 1 || rule == 2)
        { good = true; }
        else
        {
            Console.Clear();
            Console.WriteLine("Введите правильно число!!!");
        }
    }
    while (!good);
    Random rnd = new Random();

    int userGuess;
    int minNumber;
    int maxNumber;
    var attepmtCount = 0;
    string resultGame;
    bool minStrIsNubmer;
    double maxAttempt = 1;
    //int theNumber = 0;
    if (rule == 1)
    {
        minNumber = rnd.Next(-1000, 1000);
        maxNumber = rnd.Next(minNumber, 1000);
        maxAttempt = rnd.Next(4, 12);
        //theNumber = rnd.Next(minNumber, maxNumber);
        //int diapason = maxNumber - minNumber;
        Console.WriteLine($"{minNumber} {maxNumber}");
    }

    else
    {
        while (true)
        {
            do
            {
                Console.WriteLine("Задайте минимальное значение");
                string minStr = Console.ReadLine();
                minStrIsNubmer = int.TryParse(minStr, out minNumber);
                if (!minStrIsNubmer)
                {
                    Console.WriteLine("Это не число");
                }
            }
            while (!minStrIsNubmer);
            bool maxStrIsNubmer;
            do
            {
                Console.WriteLine("Задайте максимальное значение");
                string maxStr = Console.ReadLine();
                maxStrIsNubmer = int.TryParse(maxStr, out maxNumber);
                if (!maxStrIsNubmer)
                {
                    Console.WriteLine("Это не число");
                }
            }
            while (!maxStrIsNubmer);

            if (minNumber > maxNumber)
            {
                Console.WriteLine("Неверно указан диапазон!");
            }
            else
            {
                break;
            }

        }

    }
    Console.Clear();

    int theNumber = rnd.Next(minNumber, maxNumber);
    int diapason = maxNumber - minNumber;
    if (rule == 2)
    {
        double x = 0;
        //maxAttempt = 1;
        while (x <= diapason)
        {

            x = Math.Pow(2, maxAttempt);
            maxAttempt++;
        }
    }
    Console.WriteLine($"Кол-во попыток и максимальное колическо очков {maxAttempt}");
    int maxBonus = (int)maxAttempt;
    int resultPoint;
    do
    {
        Console.WriteLine($"Угадвайте число в диапазоне от {minNumber} до {maxNumber}");
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
                if (userGuess < minNumber || userGuess > maxNumber)
                    Console.WriteLine("Число не в диапазоне");
            } while (!isItWasANumber || userGuess < minNumber || userGuess > maxNumber);


            if (userGuess == theNumber)
            {
                Console.WriteLine("Верно");
                resultGame = "Вы победили!";
            }
            else
            {
                int attempt = (int)maxAttempt - attepmtCount;
                Console.WriteLine("Не правильно");
                resultGame = "Вы проиграли!";
                if (attempt == 0)
                {
                    resultPoint = 0;
                    break;
                }
                if (userGuess > theNumber)
                {
                    maxNumber = userGuess;
                    Console.WriteLine($"Ваше число больше загаданного. Угадайте в диапазон от {minNumber} до {maxNumber}");
                }
                else if (userGuess < theNumber)
                {
                    minNumber = userGuess;
                    Console.WriteLine($"Ваше число меньше нужного. Угадайте в диапазон от { minNumber} до { maxNumber}");
                }
                if (attempt > 0)
                    Console.WriteLine($"Кол-во попыток {attempt}");
            }

        }
    }
    while (theNumber != userGuess && attepmtCount < maxAttempt);

    Console.WriteLine($"Вы использовали {attepmtCount} попыток. {resultGame}. Заработано {resultPoint} очков");
    Console.ReadKey();
    Console.Clear();
}


//Console.WriteLine("Желаете сыграть еще? \n1. Да \n2. Нет");
//string toContinueStr = Console.ReadLine();
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
        Game();
    }
    else if (toContinue == 2)
    {
        Console.Clear();
        Console.WriteLine("Всего хорошего!");
        Console.ReadKey();
    }
}
while (toContinue != 2);