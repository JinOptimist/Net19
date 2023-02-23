var counter = 0;




while (counter < maxCounter)
{
    Console.WriteLine($"Guess the number between {min} and {max}");
    bool isItNumber;
    int userGuess;
    bool isInRange;

    do
    {
        Console.WriteLine("What is your guess?");
        Console.WriteLine($"You have {maxCounter - counter} tries left");
        var userGuessString = Console.ReadLine();

        isItNumber = Int32.TryParse(userGuessString, out userGuess);

        if (!isItNumber)
        {
            Console.WriteLine("nononono. That is not a number");
        }
        isInRange = true;
        if(userGuess < min|| userGuess > max)
        {
            isInRange = false;
            Console.WriteLine("Number out of range");
        }
    } while (!isItNumber || !isInRange);


    counter++;


    if (userGuess == theNumber)
    {
      Console.WriteLine("Yes Congratulations");
      break;
    }
    else if (userGuess < theNumber)
    {
        min = userGuess + 1;
      Console.WriteLine("More");
    }
    else if (userGuess > theNumber)
    {
        max = userGuess - 1;
        Console.WriteLine("Less");
    }else
    {
        Console.WriteLine("Something broke");
    }

    if (counter == 11)
    {
        min = userGuess;
      Console.WriteLine("You loose");
    }

    }

Console.WriteLine($"It took you {counter} tries");