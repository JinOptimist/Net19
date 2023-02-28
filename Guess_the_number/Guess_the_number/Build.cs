global using Guess_the_number;

namespace Guess_the_number
{
    public class Build
    {

        int minNumber;
        int maxNumber;
        int number;
        int maxAttempt = 5;

        Random rnd = new Random();
        public void InPutAndBuild()  //пользователь выбирает вариант игры + проверка на его ввод
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Зададим правила игры. Введите число с вариантом игры:" + 
"\n1. Рандомный выбор диапазона и количества попыток" +
"\n2. Задать диапазон вручную с авторассчетом попыток");
                var ruleStr = Console.ReadLine();
                bool ruleBool = int.TryParse(ruleStr, out choice);
                if (choice == 1 || choice == 2)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введите правильно число!!!");
                }
            }

            //генерация чисел и сохранение правил игры
            if (choice == 1) BuildRandom();
            else if (choice == 2) BuildWhithUser();
            SaveRules();


        }
        private (int number, int maxAttempt) BuildRandom()
        {
            const int MIN = -100;
            const int MAX = 100;
            minNumber = rnd.Next(MIN, MAX);
            maxNumber = rnd.Next(minNumber, MAX);
            number = rnd.Next(maxNumber, maxNumber);
            maxAttempt = rnd.Next(4, 12);
            //theNumber = rnd.Next(minNumber, maxNumber);
            //int diapason = maxNumber - minNumber;
            //Console.WriteLine($"{minNumber} {maxNumber}");
            return (number, maxAttempt);
        } //рандомный выбор диапазона и генерация числа в нем
        private int BuildWhithUser()
        {
            while (true)
            {
                bool minStrIsNubmer;
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
                    number = rnd.Next(minNumber, maxNumber);
                    int diapason = maxNumber - minNumber;
                    return number;
                }
            }
        }  //генерация рандомного числа из диапазона который ввел пользователь
        public Rules SaveRules()
        {
            Rules rules = new Rules();
            rules.Min = minNumber;
            rules.Max = maxNumber;
            rules.TheNumber = number;
            rules.AttepmtCount = maxAttempt;
            return rules;
        }  //сохранение значений в класс для хранения
    }
}
