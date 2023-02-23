using HealthyFood;

Console.WriteLine("GAME: Guess the number");

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
    Console.WriteLine("Win");
}
else
{
    Console.WriteLine("Loos");
}

Console.WriteLine($"Cool, you spend {gameManager.AttempCount} points");
