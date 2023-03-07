using BullAndCow.Gamers;
using BullAndCow.Leaders;

namespace BullAndCow
{
    public class GameLauncher
    {
        public void Start()
        {
            var leader = BuildLeader();
            var gamer = BuildGamer();

            var gameManger = new GameManager(leader, gamer);
            gameManger.StartGame();
        }

        private IGamer BuildGamer()
        {
            Console.WriteLine("What Gamer do you want?");
            Console.WriteLine("1) [H]uman gamer");
            Console.WriteLine("2) [B]ot gamer");
            var gamerType = Console.ReadLine();

            switch (gamerType)
            {
                case "1":
                case "H":
                    return new HumanGamer();
                case "2":
                case "B":
                    return new BotGamer();
            }

            throw new Exception($"Unknown gamer type: {gamerType}");
        }

        private ILeader BuildLeader()
        {
            Console.WriteLine("What Leader do you want?");
            Console.WriteLine("1) [S]tupid leader");
            Console.WriteLine("2) [H]uman leader");
            Console.WriteLine("3) Suspicious Human leader");
            var leaderType = Console.ReadLine();

            switch (leaderType) {
                case "1":
                case "S":
                    return new StupidLeader();
                case "H":
                case "2":
                    return new HumanLeader();
                case "3":
                    return new SuspiciousHumanLeader();
            }

            throw new Exception($"Unknown leader type: {leaderType}");
        }
    }
}
