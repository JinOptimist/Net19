using HealthyFood.Gamer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFood
{
    public class GuessTheNumberGame
    {
        public void StartTheGame()
        {
            Console.WriteLine("GAME: Guess the number");

            var gameRuleBuilder = new GameRuleBuilder();
            var rule = gameRuleBuilder.BuildAutoGameRule();
            IGamer gamer = CreateGamer();  

            var gameManager = new GameManager(rule, gamer);
            gameManager.LestPlay();
        }

        private IGamer CreateGamer()
        {
            Console.WriteLine("What gamer want u do?");
            Console.WriteLine("[H]uman gamer?");
            Console.WriteLine("[B]ot gamer?");
            var choiseString = Console.ReadLine();

            switch (choiseString) 
            {
                case "H":
                    return new HumanGamer();
                case "B":
                    return new BotGamer();
                default:
                    throw new Exception();
            }   
        }
    }
}
