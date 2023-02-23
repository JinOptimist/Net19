Console.WriteLine("GAME: Guess the number");

var min = 0;
var max = 200;

var random = new Random();
var theNumber = random.Next(min, max);

int userGuess;
var attepmtCount = 0;

var rangeOfTheNumbers = max - min;
var attemptMaxCount = 1;
var currentDistance = 1;
while (currentDistance < rangeOfTheNumbers)
{
    currentDistance = currentDistance * 2;
    attemptMaxCount++;
}

do
{
    bool isItWasANumber;
    do
    {
        Console.WriteLine($"What is you guess? Range: [{min}, {max}]. Attepts: [{attepmtCount}/{attemptMaxCount}]");
        var userGuessString = Console.ReadLine();

        isItWasANumber = Int32.TryParse(userGuessString, out userGuess);
        if (!isItWasANumber)
        {
            Console.WriteLine("It was not a number");
        }

        if (isItWasANumber && (userGuess > max || userGuess < min))
        {
            Console.WriteLine($"You guess {userGuess} not in range [{min}, {max}]");
        }
    } while (!isItWasANumber || userGuess > max || userGuess < min);

    attepmtCount++;

    if (userGuess > theNumber)
    {
        Console.WriteLine($"Less then {userGuess}");
        max = userGuess - 1;
    }

    if (userGuess < theNumber)
    {
        Console.WriteLine($"Greater then {userGuess}");
        min = userGuess + 1;
    }
} while (theNumber != userGuess && attepmtCount < attemptMaxCount);

if (theNumber == userGuess)
{
    Console.WriteLine("Win");
}
else
{
    Console.WriteLine("Loos");
}

Console.WriteLine($"Cool, you spend {attepmtCount} points");
Console.ReadKey();