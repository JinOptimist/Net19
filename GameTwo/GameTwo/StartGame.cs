using GameTwo;

public class StartGame
{
    private Rules _rule;

    public StartGame(Rules rules)
    {
        _rule = rules;
    }
    public void Start(int significance)
    {
        int attempt = 0;
        int bull = 0;
        int cow = 0;
        int turnUserNum = 0;
        int theNumber = _rule.TheNumber;
        Console.Clear();
        Console.WriteLine($"Начнем! \nЯ загадала для тебя {significance} - значное число." +
            "\nПредлагай варианты, а я буду говорить количество быков (полное совпадение) и " +
            "коров (такая цифра есть, но стоит не на своем месте\n\nВведи число ");
        Console.WriteLine(theNumber.ToString());
        List<int> numberList = new List<int>();
        foreach (char x in theNumber.ToString())
        {
            numberList.Add(Convert.ToInt32(x));
           
        }
        while (turnUserNum != theNumber)
        {
            string turnStr = Console.ReadLine();
            bool isItNumber = int.TryParse(turnStr, out turnUserNum);
            while (!isItNumber)
            {
                Console.WriteLine("Тебе нужно ввести число!");
                turnStr = Console.ReadLine();
                isItNumber = int.TryParse(turnStr, out turnUserNum);
            }
            List<int> numberListUsersNumber = new List<int>();
            foreach (char y in turnStr)
            {
                numberListUsersNumber.Add((int)y);

            }

            for (int i = 0; i <= numberListUsersNumber.Count - 1; i++)
            {
                for (int j = 0; j < numberList.Count; j++)
                {
                    if (numberListUsersNumber[i] == numberList[j] && numberListUsersNumber[i] != numberList[i]) cow++;

                }
                //Console.WriteLine("tyt");
                if (numberListUsersNumber[i] == numberList[i]) bull++;
                
            }
            Console.WriteLine($"Быков: {bull}         Коров: {cow}") ;
            attempt++;
            cow = 0;
            bull = 0;
        }
        Console.Clear();
        Console.WriteLine($"\n\n\n\n\nУра! Вы победили! Число угадано за {attempt} попыток!");
    }
}