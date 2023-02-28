using Bulls_and_CowsClass_Slava_.who_will_guess_the_numbers;
using Bulls_and_CowsClass_Slava_.iRuleBullsCows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_
{
    public class Game
    {
        private Variables _Variables;

        public Game(Variables Variables)
        {
            _Variables = Variables;
        }
        public void game()
        {
            IWho_will_guess_the_numbers chePlayerGuesssesTheNumber = new ThePlayerGuesssesTheNumber(_Variables);
            IWho_will_guess_the_numbers computerGuessingNumber = new СomputerGuessingNumber(_Variables);
            chePlayerGuesssesTheNumber.TheNumber();
            computerGuessingNumber.TheNumber();

            IRuleBullsCows checkForBulls = new CheckForBulls(_Variables);
            IRuleBullsCows checkCows = new CheckCows(_Variables);
            checkForBulls.Check();
            checkCows.Check();
        }
    }
}
