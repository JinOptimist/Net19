namespace BullAndCow.Leaders
{
    public class HumanLeader : ILeader
    {
        private List<char> _theSecretNumber;

        public void BuildNumber()
        {
            Console.WriteLine("Hello Leader. What is you number (4 symbols)");
            var leaderString = Console.ReadLine();
            _theSecretNumber = leaderString.ToCharArray().ToList();
            Console.Clear();
            Console.WriteLine("I'm leader. I've set a number");
        }

        public BullAndCowCount CheckGuess(List<char> guess)
            => LeaderHelper.CalcBullAndCowCount(_theSecretNumber, guess);
    }
}
