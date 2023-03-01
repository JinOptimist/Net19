using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFood.Gamer
{
    public class HumanGamer : IGamer
    {
        public string GamerGuess(GameRule rule)
        {
            var gamerGuess = Console.ReadLine();

            return gamerGuess;
        }
    }
}
