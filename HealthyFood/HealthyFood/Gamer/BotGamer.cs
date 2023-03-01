using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFood.Gamer
{
    public class BotGamer : IGamer    
    {
        public string GamerGuess(GameRule rule)
        {
            Random random = new Random();    
            var gamerGuess = random.Next(rule.Min, rule.Max).ToString();
            Console.WriteLine(gamerGuess);

            return gamerGuess;
        }
    }
}
