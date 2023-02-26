using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTwo
{
    public class Game
    {
        public void start()
        {
            InPut inPut = new InPut();
            int significance = inPut.In();

            BuilderNumber builderNumber = new BuilderNumber();
            builderNumber.BuidIt(significance);

            var rule = builderNumber.Builder();
            StartGame startGame = new StartGame(rule);
            startGame.Start();
        }
    }
}
