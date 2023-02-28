namespace BullAndCow
{
    public class Gamer
    {
        public List<char> TryToGuess()
        {
            Console.WriteLine("Gamer try to guess");
            var someString = Console.ReadLine();
            return someString.ToCharArray().ToList();
        }

        public void ShareAnswer(BullAndCowCount resultOfTry)
        {
            Console.WriteLine($"Bull: {resultOfTry.Bull} Cow: {resultOfTry.Cow}");
        }
    }
}