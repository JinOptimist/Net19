

namespace Class
{
    public class InPutUser
    {
        public int userNumber { get; set; } = 0;
        //int userNumber = 0;        
        public int UserNumber
        {
            get { return userNumber; }
            set { userNumber = value; }
        }
        public int InPut()
        {
            while(true)
            {
                Console.WriteLine("Зададим правила игры. Введите число с вариантом игры:" +
        "\n1. Рандомный выбор диапазона и количества попыток" +
        "\n2. Задать диапазон вручную с авторассчетом попыток");
                string userNumberStr = Console.ReadLine();
                int convertedNumber =0;                
                bool isUserInPutNumber = int.TryParse(userNumberStr, out convertedNumber);
                userNumber = convertedNumber;
                if (userNumber == 1 | userNumber == 2) break;
                else
                {
                    if (isUserInPutNumber)
                    {
                        Console.Clear();
                        Console.WriteLine("Неверно! Выберите один из вариантов");
                    }
                    if (!isUserInPutNumber)
                    {
                        Console.Clear();
                        Console.WriteLine("Это не число");
                    }
                }
            }
            
            return userNumber;

        }
    }
}
