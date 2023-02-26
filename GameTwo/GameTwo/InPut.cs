

namespace GameTwo
{
    public class InPut
    {
        public int Number { get; private set; }
        public int In()
        {
            Console.WriteLine("Угадай число, после каждой попытки я буду говорить число быков и коров" +
                "для начала укажи значность угадываемого чилса (не меньше 3)");
            int theNumberForGame;
            while (true)
            {
                string zn = Console.ReadLine();
                bool isItNumber = int.TryParse(zn, out theNumberForGame);
                if (!isItNumber)
                {
                    Console.WriteLine("Вы ввели не число. Попробуйте еще раз.");
                }
                else if (isItNumber && theNumberForGame < 3)
                {
                    Console.WriteLine("Число должно быть не меньше трехзначного");
                }
                else if (theNumberForGame > 10)
                {
                    Console.WriteLine("Мне не жалко, но это слишком много");
                }
                else
                {
                    Number = theNumberForGame;
                    break;
                }
            }
            return Number;
        }
    }
}



//return theNumberForGame;


//public Rules Builder()
//{
//    Rules rule = new Rules();
//    return rule; 
//}

