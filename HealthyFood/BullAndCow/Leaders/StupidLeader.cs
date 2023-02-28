namespace BullAndCow.Leaders
{
    public class StupidLeader : ILeader
    {
        private List<char> _theSecretNumber;

        public void BuildNumber()
        {
            //TODO randomize _theNumber;
            _theSecretNumber = new List<char>() { '1', '4', '3', '7' };
            Console.WriteLine("I'm bot. I've set a number");
        }

        public BullAndCowCount CheckGuess(List<char> guess)
            => LeaderHelper.CalcBullAndCowCount(_theSecretNumber, guess);
    }
}
