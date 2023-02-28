using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_.who_will_guess_the_numbers
{
    public class ThePlayerGuesssesTheNumber: IWho_will_guess_the_numbers
    {
        private Variables _Variables;
        public ThePlayerGuesssesTheNumber(Variables Variables)
        {
            _Variables = Variables;
        }

        public void TheNumber()
        {
            string[] RandomNumberClient = new string[_Variables.RageRandomNumberClient];
            _Variables.RandomNumberClientInt = new int[_Variables.RageRandomNumberClient];
            for (int i = 0; i < RandomNumberClient.Length; i++)
            {
                bool checkingForNumber;
                do
                {
                    Console.Write($"Enter {i + 1} number: ");
                    RandomNumberClient[i] = Console.ReadLine();
                    checkingForNumber = int.TryParse(RandomNumberClient[i], out _Variables.RandomNumberClientInt[i]);
                    checkThisNumberForClient(checkingForNumber, i);
                } while (!checkingForNumber || _Variables.RandomNumberClientInt[i] < 0 || _Variables.RandomNumberClientInt[i] > 10);
            }
            void checkThisNumberForClient(bool checkingForNumber, int i)
            {
                if (!checkingForNumber || _Variables.RandomNumberClientInt[i] < 0 || _Variables.RandomNumberClientInt[i] > 10)
                {
                    Console.WriteLine("Enter the number between 0 to 10,please.");
                }
            }
        }
    }
}
