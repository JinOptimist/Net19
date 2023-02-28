using BullAndCow.Gamers;
using BullAndCow.Leaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullAndCow
{
    public class GameLauncher
    {
        public void Start()
        {
            Console.WriteLine("What Leader do you want?");
            Console.WriteLine("[S]tupid leader");
            Console.WriteLine("[H]uman leader");
            var leaderType = Console.ReadLine();
            var leader = BuildLeader(leaderType);

            Console.WriteLine("What Gamer do you want?");
            Console.WriteLine("[H]uman gamer");
            Console.WriteLine("[B]ot gamer");
            var gamerType = Console.ReadLine();
            var gamer = BuildGamer(gamerType);

            var gameManger = new GameManager(leader, gamer);
            gameManger.StartGame();
        }

        private IGamer BuildGamer(string gamerType)
        {
            switch (gamerType)
            {
                case "B":
                    return new BotGamer();
                case "H":
                    return new HumanGamer();
            }

            throw new Exception("Bad user");
        }

        private ILeader BuildLeader(string leaderType)
        {
            switch(leaderType) {
                case "S":
                    return new StupidLeader();
                case "H":
                    return new HumanLeader();
            }

            throw new Exception("Bad user");
        }
    }
}
