using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Slava_
{
    internal class StartGame
    {
        public void startGame()
        {
            ParametrsLab wallsLab = new ParametrsLab();
            СonditionLab buildLab = new СonditionLab(wallsLab);
            buildLab.BuildLaB();

            Buillderfield buillderfield = new Buillderfield(wallsLab);
            buillderfield.BuillderfielD();

            buildLab.FirstPoint();

            Console.ReadLine();
        }

    }
}
