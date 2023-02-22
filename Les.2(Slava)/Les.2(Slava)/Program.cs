using System.Diagnostics.Metrics;
Console.WriteLine("Guess the number");


int userNumber;
var attepmtCount = 0;
int Max_Attept = 10;
int Max_Value = 100;
int Min_Value = 0;
var random = new Random();
var theNumber = random.Next(Min_Value, Max_Value);

do
{
    bool isItWasANumber;
    do
    {
        Console.WriteLine($"What is you Number? Between [{Min_Value}] to [{Max_Value}], You spent [{attepmtCount} to {Max_Attept}] Guees");
        var userGuessString = Console.ReadLine();

        isItWasANumber = Int32.TryParse(userGuessString, out userNumber);
        if (!isItWasANumber)
        {
            Console.WriteLine("It was not a number");
        }
        if (userNumber < Min_Value || userNumber > Max_Value)
        {
            Console.WriteLine($"You guess {userNumber} not in range {Min_Value}, {Max_Value}");
        }
    } while (!isItWasANumber|| userNumber < Min_Value|| userNumber > Max_Value);

    attepmtCount++;

   if(userNumber > theNumber)
    {
        Max_Value = userNumber - 1;
    }
    if (userNumber < theNumber)
    {
        Min_Value = userNumber + 1;
    }

} while (theNumber != userNumber && attepmtCount< Max_Attept);
if (userNumber == theNumber)
{
    Console.WriteLine($"Yes,You spent [{attepmtCount} to {Max_Attept}] Guees");
}
else
{
    Console.WriteLine("Sorry,you loze");
    
}
Console.WriteLine($"You spend {Max_Attept - attepmtCount} points");
Console.ReadLine();