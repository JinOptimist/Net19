namespace BullAndCow.Leaders
{
    public class StupidLeader : ILeader
    {
        private List<char> _theSecretNumber;

        public void BuildNumber()
        {
            //TODO randomize _theNumber;
            _theSecretNumber = new List<char>() { '1', '4', '3', '7' };
        }

        public BullAndCowCount CheckGuess(List<char> guess)
        {
            var bullAndCow = new BullAndCowCount();

            for (int i = 0; i < guess.Count; i++)
            {
                var guessSymbol = guess[i];

                //var answer = false;
                //foreach (var realSymbol in _theNumber)
                //{
                //    if (realSymbol == guessSymbol)
                //    {
                //        answer = true;
                //    }
                //}
                if (_theSecretNumber.Any(realSymbol => realSymbol == guessSymbol))
                {
                    var indexOfTrySymbol = _theSecretNumber.IndexOf(guessSymbol);

                    if (indexOfTrySymbol == i)
                    {
                        bullAndCow.Bull++;
                    }
                    else
                    {
                        bullAndCow.Cow++;
                    }
                }
            }

            return bullAndCow;
        }
    }
}
