using Healthy_Food__Eugene_.RuleBuilders;
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
            Console.WriteLine("What Leader do you want?");
            Console.WriteLine("[A]uto rule builder");
            Console.WriteLine("[H]uman Rule builder");
            var ruleType = Console.ReadLine();
            var ruleBuild = BuildRule(ruleType);
            var rule = ruleBuild.BuildGameRule();
            var gameManager = new GameManager(rule);
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
            
       

        }

    }

