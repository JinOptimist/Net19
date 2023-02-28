using Class;
namespace Class
{
    public class RandomOrNot
    {

        public const int MIN_DEFUALT = -100;
        public const int MAX_DEFUALT = 100;
        public const int MIN_ATTEMPT = 4;
        public const int MAX_ATTEMPT = 12;
        public int maxNumber { get; private set; }
        public int minNumber { get; private set; }
        public int maxAttempt { get; private set; } = 5;
        public int theNumber { get; private set; }
        //minNumber;

        Random rnd = new Random();
        public void MakeIt(int userInput)
        {

            if (userInput == 1) BuildNumbersRandom();
            else if (userInput == 2) BuildNumbersWhithUser();

            theNumber = rnd.Next(minNumber, maxNumber);
        }
        private (int minNumber, int maxNumber, int maxAttempt) BuildNumbersRandom()
        {
            minNumber = rnd.Next(MIN_DEFUALT, MAX_DEFUALT);
            maxNumber = rnd.Next(minNumber, MAX_DEFUALT);
            maxAttempt = rnd.Next(MIN_ATTEMPT, MAX_ATTEMPT);
            return (minNumber, maxNumber, maxAttempt);

        }
        private (int minNumber, int maxNumber) BuildNumbersWhithUser()
        {
            while (true)
            {
                bool minStrIsNubmer;
                do
                {
                    Console.WriteLine("Задайте минимальное значение");
                    string minStr = Console.ReadLine();
                    int min;
                    minStrIsNubmer = int.TryParse(minStr, out min);
                    if (!minStrIsNubmer)
                    {
                        Console.WriteLine("Это не число");
                    }
                    else minNumber = min;
                }
                while (!minStrIsNubmer);
                bool maxStrIsNubmer;
                do
                {
                    int max;
                    Console.WriteLine("Задайте максимальное значение");
                    string maxStr = Console.ReadLine();
                    maxStrIsNubmer = int.TryParse(maxStr, out max);
                    if (!maxStrIsNubmer)
                    {
                        Console.WriteLine("Это не число");
                    }
                    else maxNumber = max;
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
            return (minNumber, maxNumber);
        }
    }
}