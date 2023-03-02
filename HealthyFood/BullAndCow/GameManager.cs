using BullAndCow.Gamers;
using BullAndCow.Leaders;

namespace BullAndCow
{
    public class GameManager
    {
        public const int SYMBOLS_COUNT = 4;
        private readonly ILeader _leader;
        private readonly IGamer _gamer;

        public GameManager(ILeader leader, IGamer gamer)
        {
            _leader = leader;
            _gamer = gamer;
        }

        public void StartGame()
        {
            _leader.BuildNumber();
            _gamer.StartGame();

            BullAndCowCount answerFromLeader;

            do
            {
                var guess = _gamer.TryToGuess();

                answerFromLeader = _leader.CheckGuess(guess);

                _gamer.ShareAnswer(answerFromLeader);
            } while (answerFromLeader.Bull != SYMBOLS_COUNT);
        }
    }
}
