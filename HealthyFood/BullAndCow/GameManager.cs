namespace BullAndCow
{
    public class GameManager
    {
        private readonly Leader _leader;
        private readonly Gamer _gamer;

        public GameManager(Leader leader, Gamer gamer)
        {
            _leader = leader;
            _gamer = gamer;
        }

        public void StartGame()
        {
            _leader.BuildNumber();

            BullAndCowCount answerFromLeader;

            do
            {
                var guess = _gamer.TryToGuess();

                answerFromLeader = _leader.CheckGuess(guess);

                _gamer.ShareAnswer(answerFromLeader);
            } while (answerFromLeader.Bull != 4);
        }
    }
}
