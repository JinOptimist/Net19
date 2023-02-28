namespace BullAndCow.Leaders
{
    public interface ILeader
    {
        void BuildNumber();
        BullAndCowCount CheckGuess(List<char> guess);
    }
}