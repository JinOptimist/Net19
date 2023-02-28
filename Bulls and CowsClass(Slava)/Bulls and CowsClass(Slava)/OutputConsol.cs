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
        private Variables _Variables;

        public OutputConsol(Variables Variables)
        {
            _Variables = Variables;
        }

        public void outputConsol()
        {
            Console.WriteLine($"Helloy it is Game Bulls and Cows.\nWe guessed the number.\nConsisting of 4 numbers.Enter 4 Number between 0 to 10: ");
        }

        public void OutputNumbers()
        {
            Console.Write("You Enter: ");
            for (int i = 0; i < _Variables.RageRandomNumberClient; i++)
            {
                Console.Write($"[{_Variables.RandomNumberClientInt[i]}] ");
            }//enter 4 numberClient

            Console.WriteLine();
            Console.Write("Computer:  ");
            for (int i = 0; i < _Variables.RageRandomNumberComputer; i++)
            {
                Console.Write($"[{_Variables.RandomNumberComputer[i]}] ");
            }
            Console.WriteLine();
        }

        public void OuptupBullsCows()
        {
            Console.WriteLine();
            Console.WriteLine($"Bulls =[{_Variables.Bulls}], Cows=[{_Variables.Cows}]");
        }
    }
}
