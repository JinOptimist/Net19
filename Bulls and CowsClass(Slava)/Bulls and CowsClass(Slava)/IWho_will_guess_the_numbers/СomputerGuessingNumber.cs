using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_.who_will_guess_the_numbers
{
    public class СomputerGuessingNumber: IWho_will_guess_the_numbers
    {
        private Variables _rule;
        public СomputerGuessingNumber(Variables rule)
        {
            _rule = rule;
        }
        
        public void TheNumber()
        {
            var random = new Random();
            _rule.RandomNumberComputer = new int[_rule.RageRandomNumberComputer];
            for (int i = 0; i < _rule.RageRandomNumberComputer; i++)
            {
                _rule.RandomNumberComputer[i] = random.Next(_rule.RageNumberMin, _rule.RageNumberMax);
            }
        }

    }
}
