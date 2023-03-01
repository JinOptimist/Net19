namespace Healthy_Food__Eugene_.TurnHandler
{
    public class HumanGame : IGame
    {
        private GameRule _rule;

        public int AttempCount { get; private set; }

        private int _lastUserGuess;


        public HumanGame(GameRule rule)
        {
            _rule = rule;
        }

        public bool OneTurn()
        {
            bool isItWasANumber;
            do
            {
                Console.WriteLine($"What is you guess? Range: [{_rule.Min}, {_rule.Max}]. Attepts: [{AttempCount}/{_rule.MaxAttempCount}]");
                var userGuessString = Console.ReadLine();


                isItWasANumber = int.TryParse(userGuessString, out _lastUserGuess);
                if (!isItWasANumber)
                {
                    Console.WriteLine("It was not a number");
                }

                if (isItWasANumber && (_lastUserGuess > _rule.Max || _lastUserGuess < _rule.Min))
                {
                    Console.WriteLine($"You guess {_lastUserGuess} not in range [{_rule.Min}, {_rule.Max}]");
                }
            } while (!isItWasANumber || _lastUserGuess > _rule.Max || _lastUserGuess < _rule.Min);

            AttempCount++;

            if (_lastUserGuess > _rule.TheNumber)
            {
                Console.WriteLine($"Less then {_lastUserGuess}");
                _rule.Max = _lastUserGuess - 1;
            }

            if (_lastUserGuess < _rule.TheNumber)
            {
                Console.WriteLine($"Greater then {_lastUserGuess}");
                _rule.Min = _lastUserGuess + 1;
            }

            return _rule.TheNumber != _lastUserGuess && AttempCount < _rule.MaxAttempCount;
        }

        public bool IsUserWinGame()
            => _rule.TheNumber == _lastUserGuess;

        public void RunTurns()
        {
            bool isEndOfTheGame;
            do
            {
                isEndOfTheGame = !OneTurn();

            } while (!isEndOfTheGame);
        }

        public void ShowResultOfGame()
        {
            if (IsUserWinGame())
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine("Loos");
            }

            Console.WriteLine($"Cool, you spend {AttempCount} points");
        }
    }
}
