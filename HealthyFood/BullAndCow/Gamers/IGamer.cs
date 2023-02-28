namespace BullAndCow.Gamers
{
    public interface IGamer
    {
        void ShareAnswer(BullAndCowCount resultOfTry);
        List<char> TryToGuess();
    }
}