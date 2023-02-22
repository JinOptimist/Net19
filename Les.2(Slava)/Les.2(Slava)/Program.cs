using System.Diagnostics.Metrics;
internal class Program
{
    private static void Main(string[] args)
    {
        int userNumber;
        var attepmtCount = 0;
        var attepmtCountMax = 1;
        int Max_Value = 100;
        int Min_Value = 0;
        var random = new Random();
        var theNumber = random.Next(Min_Value, Max_Value);

        attepmtCountMax = AttepmtCountMax(attepmtCountMax, Max_Value, Min_Value);

        Console.WriteLine("Guess the number");

        do
        {
            bool isItWasANumber;
            do
            {
                Console.WriteLine($"What is you Number? Between [{Min_Value}] to [{Max_Value}], You spent [{attepmtCount} to {attepmtCountMax}] Guees");
                var userGuessString = Console.ReadLine();
                isItWasANumber = int.TryParse(userGuessString, out userNumber);

                checkThisNumberOrNo(Min_Value, Max_Value, isItWasANumber, userNumber);

            } while (!isItWasANumber || userNumber < Min_Value || userNumber > Max_Value);

            attepmtCount++;

            Max_Value = increaseValue(userNumber, theNumber, Max_Value);
            Min_Value = decreaseValue(userNumber, theNumber, Min_Value);

        } while (theNumber != userNumber && attepmtCount < attepmtCountMax);

        WinOrLoze(userNumber,theNumber,attepmtCount,attepmtCountMax);
        Console.ReadLine();
    }



    public static int AttepmtCountMax(int attepmtCountMax, int Max_Value, int Min_Value)
    {
        int cout = 1;
        int coutAttempt = Max_Value - Min_Value;
        while (cout < coutAttempt)
        {
            cout *= 2;
            attepmtCountMax++;
        }
        return attepmtCountMax;
    }

    public static void checkThisNumberOrNo(int Min_Value, int Max_Value, bool isItWasANumber, int userNumber)
    {

        if (!isItWasANumber)
        {
            Console.WriteLine("It was not a number");
        }
        if (userNumber < Min_Value || userNumber > Max_Value|| userNumber-1 > Max_Value)
        {
            Console.WriteLine($"You guess {userNumber} not in range {Min_Value}, {Max_Value}");

        };
    }

    public static int increaseValue(int userNumber, int theNumber, int Max_Value)
    {
        if (userNumber > theNumber)
        {
            Max_Value = userNumber - 1;
        }
        return Max_Value;
    }

    public static int decreaseValue(int userNumber, int theNumber, int Min_Value)
    {
        if (userNumber < theNumber)
        {
            Min_Value = userNumber - 1;
        }
        return Min_Value;
    }

    public static void WinOrLoze(int userNumber,int theNumber,int attepmtCount,int attepmtCountMax) 
    {
        if (userNumber == theNumber)
        {
            Console.WriteLine($"Yes,You spent [{attepmtCount} to {attepmtCountMax}] Guees");
        }
        else
        {
            Console.WriteLine("Sorry,you loze");

        }
        Console.WriteLine($"You spend {attepmtCountMax - attepmtCount} points");
    }
}
