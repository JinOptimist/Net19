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
            var gameRuleBuilder = new GameRuleBuilder();
            var rule = gameRuleBuilder.BuildAutoGameRule();
            var gameManager = new GameManager(rule);
            gameManager.RunTurns();
            gameManager.CheckTurns();

        }

    }
}
