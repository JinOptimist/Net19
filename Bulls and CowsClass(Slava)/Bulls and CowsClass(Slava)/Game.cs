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
        private Rule _rule;

        public Game(Rule rule)
        {
            _rule = rule;
        }
        public void game() 
        {
            var random = new Random();
                _rule.RandomNumberComputer = new int[_rule.RageRandomNumberComputer];
                for (int i = 0; i < _rule.RageRandomNumberComputer; i++)
                {
                _rule.RandomNumberComputer[i] = random.Next(_rule.RageNumberMin, _rule.RageNumberMax);
                }
            
                string[] RandomNumberClient = new string[_rule.RageRandomNumberClient];
                _rule.RandomNumberClientInt = new int[_rule.RageRandomNumberClient];
                for (int i = 0; i < RandomNumberClient.Length; i++)
                {
                    bool checkingForNumber;
                    do
                    {
                        Console.Write($"Enter {i + 1} number: ");
                        RandomNumberClient[i] = Console.ReadLine();
                        checkingForNumber = int.TryParse(RandomNumberClient[i], out _rule.RandomNumberClientInt[i]);
                        checkThisNumberForClient(checkingForNumber,i);
                    } while (!checkingForNumber || _rule.RandomNumberClientInt[i] < 0 || _rule.RandomNumberClientInt[i] > 10);
                }
                 void checkThisNumberForClient(bool checkingForNumber,int i )
                 {
                    if (!checkingForNumber || _rule.RandomNumberClientInt[i] < 0 || _rule.RandomNumberClientInt[i] > 10)
                    {
                        Console.WriteLine("Enter the number between 0 to 10,please.");
                    }
                 }
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
