using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        bool CheckYorNBool;
        char CheckYorN;
        bool checkingForNumber;
        int Bulls = 0;
        int Cows = 0;
        while (true)
        {
            Console.WriteLine($"Helloy it is Game Bulls and Cows.\nWe guessed the number.\nConsisting of 4 numbers.Enter 4 Number between 0 to 10: ");
            var random = new Random();
            int[] RandomNumberComputer = { random.Next(0, 10), random.Next(0, 10), random.Next(0, 10), random.Next(0, 10) };
            string[] RandomNumberClient = new string[4];
            int[] RandomNumberClientInt = new int[4];
            for (int i = 0; i < RandomNumberClient.Length; i++)
            {
                do
                {
                    Console.Write($"Enter {i + 1} number: ");
                    RandomNumberClient[i] = Console.ReadLine();
                    checkingForNumber = int.TryParse(RandomNumberClient[i], out RandomNumberClientInt[i]);
                    checkThisNumberForClient(checkingForNumber, RandomNumberClientInt[i]);
                } while (!checkingForNumber || RandomNumberClientInt[i] < 0 || RandomNumberClientInt[i] > 10);
            }//Client enter 4 number

            Console.Write("You Enter: ");
            for (int i = 0; i < RandomNumberComputer.Length; i++)
            {
                Console.Write($"[{RandomNumberClient[i]}] ");
            }//enter 4 numberComputer

            Console.WriteLine();
            Console.Write("Computer:  ");
            for (int i = 0; i < RandomNumberComputer.Length; i++)
            {
                Console.Write($"[{RandomNumberComputer[i]}] ");
            }
            Console.WriteLine();

            Bulls = CheckForBulls(Bulls, RandomNumberComputer, RandomNumberClientInt);
            Cows = CheckCows(Cows, RandomNumberComputer, RandomNumberClientInt);
            Console.WriteLine();
            Console.WriteLine($"Bulls =[{Bulls}], Cows=[{Cows}]");

            do
            {
                Console.WriteLine("You want to play again.Yes-Y or No-N?:");
                var repeat = Console.ReadLine();
                CheckYorNBool = char.TryParse(repeat, out CheckYorN);

                if (CheckYorN == 'Y' || CheckYorN == 'y')
                {
                    Console.WriteLine("Let's go again!.Press any button to continue ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (CheckYorN == 'n' || CheckYorN == 'N')
                {
                    Console.WriteLine("Thanks For Game!");
                    Console.ReadKey();
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Console.WriteLine("You write no Y or N");
                    CheckYorNBool = false;
                }

            } while (!CheckYorNBool);
        }
    } 

    private static int CheckCows(int Cows, int[] RandomNumberComputer, int[] RandomNumberClientInt)
    {
        foreach (int CheckForCows in RandomNumberClientInt)
        {
            for (int j = 0; j < RandomNumberClientInt.Length; j++)
            {
                if (CheckForCows == RandomNumberComputer[j])
                {
                    Cows++;
                }
            }
        }

        return Cows;
    }

    private static int CheckForBulls(int Bulls, int[] RandomNumberComputer, int[] RandomNumberClientInt)
    {
        for (int i = 0; i < RandomNumberClientInt.Length; i++)
        {
            if (RandomNumberClientInt[i] == RandomNumberComputer[i])
            {
                Bulls++;
            }
        }

        return Bulls;
    }

    public static void checkThisNumberForClient(bool checkingForNumber,int RandomNumberClientInt)
    {
        if (!checkingForNumber || RandomNumberClientInt < 0 || RandomNumberClientInt > 10)
        {
            Console.WriteLine("It was not a number.Enter again");
        }
    }

    public static bool chekClientEnterNoYorN(char CheckYorN)
    {

        if (CheckYorN != 'Y' || CheckYorN != 'y' || CheckYorN != 'N' || CheckYorN != 'n')
        {
            Console.WriteLine("Enter Y or N");
            return false;
        }
        return true;
    }

}