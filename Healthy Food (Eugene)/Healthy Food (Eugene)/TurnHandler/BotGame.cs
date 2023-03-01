using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthy_Food__Eugene_.TurnHandler
{
    public class BotGame : IGame
    {
        private GameRule _rule;

        public int AttempCount { get; private set; }

        private int _lastBotGuess;


        public BotGame(GameRule rule)
        {
            _rule = rule;
        }

        public bool OneTurn()
        {
            Console.WriteLine($"What is you guess? Range: [{_rule.Min}, {_rule.Max}]. Attepts: [{AttempCount}/{_rule.MaxAttempCount}]");
            _lastBotGuess = CalcTheAnswer();
            AttempCount++;

            if (_lastBotGuess > _rule.TheNumber)
            {
                Console.WriteLine($"Less then {_lastBotGuess}");
                _rule.Max = _lastBotGuess - 1;
            }

            if (_lastBotGuess < _rule.TheNumber)
            {
                Console.WriteLine($"Greater then {_lastBotGuess}");
                _rule.Min = _lastBotGuess + 1;
            }

            return _rule.TheNumber != _lastBotGuess && AttempCount < _rule.MaxAttempCount;
        }

        public bool IsUserWinGame()
            => _rule.TheNumber == _lastBotGuess;

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

        private int CalcTheAnswer()
        {
            int range = _rule.Max - _rule.Min;
            int halfrange = range / 2;
            int answer;
            answer = _rule.Min + halfrange;
            Console.WriteLine(answer);
            
            return answer;
        }
    }
}
