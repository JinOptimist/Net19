namespace BullAndCow.Leaders
{
    public class LeaderHelper
    {
        public static BullAndCowCount CalcBullAndCowCount(List<char> secretNumber, List<char> guess)
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
                if (secretNumber.Any(realSymbol => realSymbol == guessSymbol))
                {
                    var indexOfTrySymbol = secretNumber.IndexOf(guessSymbol);

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
