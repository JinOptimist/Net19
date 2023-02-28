using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            int numberClientMin;
            int numberClientMax;

            while (true)
            {
                do
                {
                    Console.Clear();
                    bool checkingForNumberMin;
                    bool checkingForNumberMax;
                    Console.WriteLine("Helloy,Enter number range in which you want to guess!");
                    do
                    {
                        Console.Write("Enter Min value Number: ");
                        var rangeToClient = Console.ReadLine();
                        checkingForNumberMin = int.TryParse(rangeToClient, out numberClientMin);
                        checkThisNumberNoForClientMin(checkingForNumberMin);
                    }
                    while (!checkingForNumberMin);
                    do
                    {
                        Console.Write("Enter Max value Number: ");
                        var rangeToClient = Console.ReadLine();
                        checkingForNumberMax = int.TryParse(rangeToClient, out numberClientMax);
                        checkThisNumberNoForClientMax(checkingForNumberMin);
                    }
                    while (!checkingForNumberMax);
                } while (chekNumberRange(numberClientMin, numberClientMax));
                break;
            }

            int userNumber;
            var attepmtCount = 0;
            var attepmtCountMax = 1;
            var random = new Random();
            var theNumber = random.Next(numberClientMin, numberClientMax);

            attepmtCountMax = AttepmtCountMax(attepmtCountMax, numberClientMax, numberClientMin);

            do
            {
                bool isItWasANumber;
                do
                {
                    Console.WriteLine($"What is you Number? Between [{numberClientMin}] to [{numberClientMax}], You spent [{attepmtCount} to {attepmtCountMax}] Guees");
                    var userGuessString = Console.ReadLine();
                    isItWasANumber = int.TryParse(userGuessString, out userNumber);

                    checkThisNumberOrNo(numberClientMin, numberClientMax, isItWasANumber, userNumber);

                } while (!isItWasANumber || userNumber < numberClientMin || userNumber > numberClientMax);

                attepmtCount++;

                numberClientMax = increaseValue(userNumber, theNumber, numberClientMax);
                numberClientMin = decreaseValue(userNumber, theNumber, numberClientMin);

            } while (theNumber != userNumber && attepmtCount < attepmtCountMax);

            WinOrLoze(userNumber, theNumber, attepmtCount, attepmtCountMax);

            bool CheckYorNBool;
            char CheckYorN;
            do
            {
                Console.WriteLine("You want to play again.Yes-Y or No-N?:");
                var repeat = Console.ReadLine();
                CheckYorNBool = char.TryParse(repeat, out CheckYorN);
                chekClientEnterNoYorN(CheckYorNBool);
                if (CheckYorN == 'Y' || CheckYorN == 'y')
                {
                    Console.WriteLine("Let's go again!");
                    Console.Clear();
                    break;
                }
            } while (!CheckYorNBool);
            if(CheckYorN == 'n' || CheckYorN == 'N')
            {
                Console.WriteLine("Good luck!");
                Console.ReadKey();
                break;
            }
        }
    }



    public static int AttepmtCountMax(int attepmtCountMax, int numberClientMax, int numberClientMin)
    {
        int cout = 1;
        int coutAttempt = numberClientMax - numberClientMin;
        while (cout < coutAttempt)
        {
            cout *= 2;
            attepmtCountMax++;
        }
        return attepmtCountMax;
    }

    public static void checkThisNumberOrNo(int numberClientMin, int numberClientMax, bool isItWasANumber, int userNumber)
    {

        if (!isItWasANumber)
        {
            Console.WriteLine("It was not a number");
        }
        if (userNumber < numberClientMin || userNumber > numberClientMax || userNumber - 1 > numberClientMax)
        {
            Console.WriteLine($"You guess {userNumber} not in range {numberClientMin}, {numberClientMax}");

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
            Min_Value = userNumber + 1;
        }
        return Min_Value;
    }

    public static void WinOrLoze(int userNumber, int theNumber, int attepmtCount, int attepmtCountMax)
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

    public static void checkThisNumberNoForClientMin(bool checkingForNumberMin)
    {
        if (!checkingForNumberMin)
        {
            Console.WriteLine("It was not a number.Enter again");
        }
    }
    public static void checkThisNumberNoForClientMax(bool checkingForNumberMax)
    {
        if (!checkingForNumberMax)
        {
            Console.WriteLine("It was not a number.Enter again");

        }
    }
    public static bool chekNumberRange(int numberClientMin, int numberClientMax)
    {
        if (numberClientMax <= numberClientMin)
        {
            Console.WriteLine("You Enter wrong range.Start again!Press any key to continue");
            Console.ReadKey();
            return true;
        }
        else return false;

    }
    public static void chekClientEnterNoYorN(bool CheckYorNBool)
    {

        if (!CheckYorNBool)
        {
            Console.WriteLine("You wrong a number!");
        }
    }

    
}
