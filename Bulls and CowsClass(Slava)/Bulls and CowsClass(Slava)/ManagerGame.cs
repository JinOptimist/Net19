using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_
{
    public class ManagerGame
    {
        int RAGE_RANDOM_NAMBER_COMPUTER = 4;
        int RAGE_RANDOM_NAMBER_CLIENT = 4;
        int RAGE_NUMBER_MIN = 0;
        int RAGE_NUMBER_MAX = 10;
        int BULLS = 0;
        int COWS = 0;

        public Variables ruleGame() => new Variables
        {
            RageRandomNumberComputer = RAGE_RANDOM_NAMBER_COMPUTER,
            RageRandomNumberClient = RAGE_RANDOM_NAMBER_CLIENT,
            RageNumberMin = RAGE_NUMBER_MIN,
            RageNumberMax = RAGE_NUMBER_MAX,
            Bulls= BULLS,
            Cows= COWS
        };
    }
}
