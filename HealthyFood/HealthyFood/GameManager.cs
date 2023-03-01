using HealthyFood.Gamer;
using System.Data;

namespace HealthyFood
{
    public class GameManager
    {
        private GameRule _rule;
        private IGamer _gamer;

        public int AttempCount { get; private set; }

        private int _lastUserGuess;


        public GameManager(GameRule rule, IGamer gamer)
        {
            _rule = rule;
            _gamer = gamer;
        }

        public bool OneTurn()
        {
            bool isItWasANumber;
            do
            {
                Console.WriteLine($"What is you guess? Range: [{_rule.Min}, {_rule.Max}]. Attepts: [{AttempCount}/{_rule.MaxAttemptCount}]");
                var gamerGuessString = _gamer.GamerGuess(_rule);

                
                isItWasANumber = Int32.TryParse(gamerGuessString, out _lastUserGuess);
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

            return _rule.TheNumber != _lastUserGuess && AttempCount < _rule.MaxAttemptCount;
        }

        public void LestPlay()
        {
            bool isEndOfTheGame;
            do
            {
                isEndOfTheGame = !OneTurn();
            } while (!isEndOfTheGame);

            if (IsUserWinGame())
            {
                Console.WriteLine("Win 2");
            }
            else
            {
                Console.WriteLine("Loos 2");
            }

            Console.WriteLine($"Cool, you spend {AttempCount} points");
        }

        public bool IsUserWinGame()
            => _rule.TheNumber == _lastUserGuess;
    }
}
