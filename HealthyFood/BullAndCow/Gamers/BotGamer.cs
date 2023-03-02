using BullAndCow.Leaders;
using Microsoft.VisualBasic;

namespace BullAndCow.Gamers
{
    public class BotGamer : IGamer
    {
        private List<List<char>> _listOfGuess;
        private List<char> _lastGuess;
        private List<char> allSymbols = new List<char>
        {
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '0'
        };

        public BotGamer()
        {
            _listOfGuess = new List<List<char>>();
        }

        public void ShareAnswer(BullAndCowCount resultOfTry)
        {
            Console.WriteLine($"Bull: {resultOfTry.Bull} Cow: {resultOfTry.Cow}");

            // _lastGuess = ['1','2','3','7']
            // resultOfTry Bull: 0, Cow: 0

            var newAnswerList = new List<List<char>>();

            foreach (var oneGuess in _listOfGuess)
            {
                // oneGuess = ['1', '2', '3', '4']
                // oneGuess = ['1', '2', '3', '5']
                // oneGuess = ['1', '2', '3', '6']
                // ---- oneGuess = ['1', '2', '3', '7']
                // ---- oneGuess = ['5', '1', '2', '3']
                var oneGuessBullCow = LeaderHelper.CalcBullAndCowCount(oneGuess, _lastGuess);
                if (oneGuessBullCow.Cow == resultOfTry.Cow
                    && oneGuessBullCow.Bull == resultOfTry.Bull)
                {
                    newAnswerList.Add(oneGuess);
                }
            }

            _listOfGuess = newAnswerList;
        }

        public void StartGame()
        {
            //Генерим массив из всех возможных ответов
            _listOfGuess = Recursion(new List<char>());
        }

        private List<List<char>> Recursion(List<char> guess)
        {
            var availableSymbols = allSymbols
                .Where(availableSymbol => !guess
                    .Any(guessSymbol => guessSymbol == availableSymbol));

            var answer = new List<List<char>>();

            foreach (var availableSymbol in availableSymbols)
            {
                //Create a copy of guess
                var oneMoreGuess = guess.ToList();//['0']
                oneMoreGuess.Add(availableSymbol);//['0', '1', '7' , '8']

                if (oneMoreGuess.Count < 4)
                {
                    var listOfGuess = Recursion(oneMoreGuess);
                    answer = answer.Concat(listOfGuess).ToList();
                }
                else
                {
                    answer.Add(oneMoreGuess);
                }
            }

            return answer;
        }

        public List<char> TryToGuess()
        {
            _lastGuess = _listOfGuess.First();
            Console.WriteLine($"G: {string.Join(' ', _lastGuess)} . Options: {_listOfGuess.Count()}");
            return _lastGuess;
        }
    }
}
