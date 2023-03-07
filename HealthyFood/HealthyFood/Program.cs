using HealthyFood;

Console.WriteLine("GAME: Guess the number 2");

var gameRuleBuilder = new GameRuleBuilder();
var rule = gameRuleBuilder.BuildAutoGameRule();

var gameManager = new GameManager(rule);

bool isEndOfTheGame;
do
{
    isEndOfTheGame = !gameManager.OneTurn();
} while (!isEndOfTheGame);

if (gameManager.IsUserWinGame())
{
    Console.WriteLine("Win 2");
}
else
{
    Console.WriteLine("Loos 2");
}

Console.WriteLine($"Cool, you spend {gameManager.AttempCount} points");

