namespace Healthy_Food__Eugene_.TurnHandler
{
    public interface IGame
    {
        int AttempCount { get; }

        bool IsUserWinGame();
        bool OneTurn();
        void RunTurns();
        void ShowResultOfGame();
    }
}