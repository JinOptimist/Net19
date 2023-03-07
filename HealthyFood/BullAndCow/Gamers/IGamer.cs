namespace BullAndCow.Gamers
{
    public interface IGamer
    {
        void StartGame();
        void ShareAnswer(BullAndCowCount resultOfTry);
        List<char> TryToGuess();
    }
}