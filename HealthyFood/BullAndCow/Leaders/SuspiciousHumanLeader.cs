namespace BullAndCow.Leaders
{
    public class SuspiciousHumanLeader : ILeader
    {
        public void BuildNumber()
        {
            //Console.WriteLine("Hello Leader. What is you number (4 symbols)");
            //var leaderString = Console.ReadLine();
            //_theSecretNumber = leaderString.ToCharArray().ToList();
            //Console.Clear();
            //Console.WriteLine("I'm leader. I've set a number");
        }

        public BullAndCowCount CheckGuess(List<char> guess)
        {
            Console.WriteLine("How many Bull and Cow do you have?");
            var answer = Console.ReadLine().Split(' ');
            var bull = int.Parse(answer[0]);
            var cow = int.Parse(answer[1]);

            return new BullAndCowCount()
            {
                Bull = bull,
                Cow = cow
            };
        }
    }
}
