using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_.who_will_guess_the_numbers
{
    public class СomputerGuessingNumber: IWho_will_guess_the_numbers
    {
        private Variables _Variables;
        public СomputerGuessingNumber(Variables Variables)
        {
            _Variables = Variables;
        }
        
        public void TheNumber()
        {
            var random = new Random();
            _Variables.RandomNumberComputer = new int[_Variables.RageRandomNumberComputer];
            for (int i = 0; i < _Variables.RageRandomNumberComputer; i++)
            {
                _Variables.RandomNumberComputer[i] = random.Next(_Variables.RageNumberMin, _Variables.RageNumberMax);
            }
        }

    }
}
