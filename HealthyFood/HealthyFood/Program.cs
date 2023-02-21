<<<<<<< HEAD
﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
=======
﻿Console.WriteLine("Guess the number");

var theNumber = 7;

Console.WriteLine("What is you guess?");

var userGuessString = Console.ReadLine();
//var userGuess = Int32.Parse(userGuessString);
int userGuess;
var isItWasANumber = Int32.TryParse(userGuessString, out userGuess);
if (!isItWasANumber)
{
    Console.WriteLine("You are bad persone. It was not a number");
    return;
}

if (userGuess == theNumber)
{
    Console.WriteLine("Win");
}
else
{
    Console.WriteLine("Looser");
}

Console.WriteLine($"Cool, you spend {attepmtCount} points");
