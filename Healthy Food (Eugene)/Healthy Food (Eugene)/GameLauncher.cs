using Healthy_Food__Eugene_.RuleBuilders;
using Healthy_Food__Eugene_.TurnHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthy_Food__Eugene_
{
    public class GameLauncher
    {
        public void StartTheGame()
        {
            Console.WriteLine("What rules do you want?");
            Console.WriteLine("[A]uto rule builder");
            Console.WriteLine("[H]uman Rule builder");
            var ruleType = Console.ReadLine();

            Console.WriteLine("Who should play?");
            Console.WriteLine("[B]ot");
            Console.WriteLine("[H]uman");
            var gameType = Console.ReadLine();


            var ruleBuild = BuildRule(ruleType);
            var rule = ruleBuild.BuildGameRule();
            var gameManager = BuildGame(gameType, rule);

            gameManager.RunTurns();
            gameManager.ShowResultOfGame();
        }

            private IRuleBuilder BuildRule(string ruleType)
            {
                switch (ruleType)
                {
                    case "A":
                        return new AutoRuleBuilder();
                    case "H":
                        return new HumanRuleBuilder();
                }

                throw new Exception("Bad user");

            }

            private IGame BuildGame(string gameType, GameRule rule)
            {
                switch (gameType)
                {
                    case "B":
                        return new BotGame(rule);
                    case "H":
                        return new HumanGame(rule);
                }

                throw new Exception("Bad user");

            }



    }

    }

