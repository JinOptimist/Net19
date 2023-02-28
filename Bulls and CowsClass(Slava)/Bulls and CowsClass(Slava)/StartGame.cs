using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_
{
    public class StartGame
    {
        public void BullCows()
        {
            bool CheckYorNBool;
            char CheckYorN;

            while (true)
            {
                ManagerGame managerGame = new ManagerGame();
                Variables rule = managerGame.ruleGame();//Создаем константы и инициализируем их

                OutputConsol outputConsole = new OutputConsol(rule);
                outputConsole.outputConsol();//Выводим на экран приветсвие

                Game game = new Game(rule);
                game.game();// Основной код игры

                outputConsole.OutputNumbers();//Выводим количество коров и быков
                outputConsole.OuptupBullsCows();

                do
                {
                    Console.WriteLine("You want to play again.Yes-Y or No-N?:");
                    var repeat = Console.ReadLine();
                    CheckYorNBool = char.TryParse(repeat, out CheckYorN);

                    if (CheckYorN == 'Y' || CheckYorN == 'y')
                    {
                        Console.WriteLine("Let's go again!.Press any button to continue ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (CheckYorN == 'n' || CheckYorN == 'N')
                    {
                        Console.WriteLine("Thanks For Game!");
                        Console.ReadKey();
                        Process.GetCurrentProcess().Kill();
                    }
                    else
                    {
                        Console.WriteLine("You write no Y or N");
                        CheckYorNBool = false;
                    }

                } while (!CheckYorNBool);//Хотите ли вы сыграть еще раз
            }
        }

        public static bool chekClientEnterNoYorN(char CheckYorN)
        {

            if (CheckYorN != 'Y' || CheckYorN != 'y' || CheckYorN != 'N' || CheckYorN != 'n')
            {
                Console.WriteLine("Enter Y or N");
                return false;
            }
            return true;
        }

    }
}
