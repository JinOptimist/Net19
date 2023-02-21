Console.WriteLine("Guess the number");

var theNumber = 7;
int userGuess;
var attepmtCount = 0;

do
{
    bool isItWasANumber;
    do
    {
        Console.WriteLine("What is you guess?");
        var userGuessString = Console.ReadLine();
        

        isItWasANumber = Int32.TryParse(userGuessString, out userGuess);
        if (!isItWasANumber)
        {
            Console.WriteLine("It was not a number");
        }
    } while (!isItWasANumber);

    attepmtCount++;

    if (userGuess == theNumber)
    {
        Console.WriteLine("Yes");
    }
    else
    {
        Console.WriteLine("No");
    }
} while (theNumber != userGuess);

Console.WriteLine($"Cool, you spend {attepmtCount} points");
