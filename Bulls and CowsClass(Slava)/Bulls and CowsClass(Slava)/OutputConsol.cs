using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_
{
    public class OutputConsol
    {
        private Rule _rule;

        public OutputConsol(Rule rule)
        {
            _rule = rule;
        }

        public void outputConsol()
        {
            Console.WriteLine($"Helloy it is Game Bulls and Cows.\nWe guessed the number.\nConsisting of 4 numbers.Enter 4 Number between 0 to 10: ");
        }

        public void outputNumbers()
        {
            Console.Write("You Enter: ");
            for (int i = 0; i < _rule.RageRandomNumberClient; i++)
            {
                Console.Write($"[{_rule.RandomNumberClientInt[i]}] ");
            }//enter 4 numberClient

            Console.WriteLine();
            Console.Write("Computer:  ");
            for (int i = 0; i < _rule.RageRandomNumberComputer; i++)
            {
                Console.Write($"[{_rule.RandomNumberComputer[i]}] ");
            }
            Console.WriteLine();
        }

        public void ouptupBullsCows()
        {
            Console.WriteLine();
            Console.WriteLine($"Bulls =[{_rule.Bulls}], Cows=[{_rule.Cows}]");
        }
    }
}
