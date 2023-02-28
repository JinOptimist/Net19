using Bulls_and_CowsClass_Slava_.who_will_guess_the_numbers;
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
        private Variables _rule;

        public Game(Variables rule)
        {
            _rule = rule;
        }
        public void game()
        {
            IWho_will_guess_the_numbers ThePlayerGuesssesTheNumber = new ThePlayerGuesssesTheNumber(_rule);
            IWho_will_guess_the_numbers СomputerGuessingNumber = new СomputerGuessingNumber(_rule);

            ThePlayerGuesssesTheNumber.TheNumber();
            СomputerGuessingNumber.TheNumber();

            CheckForBulls();
            CheckCows();

        }

        void CheckCows()
        {
            foreach (int CheckForCows in _rule.RandomNumberClientInt)
            {
                for (int j = 0; j < _rule.RandomNumberClientInt.Length; j++)
                {
                    if (CheckForCows == _rule.RandomNumberComputer[j])
                    {
                        _rule.Cows++;
                    }
                }
            }
        }
        void CheckForBulls()
        {
            for (int i = 0; i < _rule.RandomNumberClientInt.Length; i++)
            {
                if (_rule.RandomNumberClientInt[i] == _rule.RandomNumberComputer[i])
                {
                    _rule.Bulls++;
                }
            }
        }
    }
}
