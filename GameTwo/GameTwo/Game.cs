using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTwo
{
    public class Game
    {
        public void start()
        {
            InPut inPut = new InPut();
            int significance = inPut.In();

            BuilderNumber builderNumber = new BuilderNumber();
            builderNumber.BuidIt(significance);

            var rule = builderNumber.Builder();
            StartGame startGame = new StartGame(rule);
            startGame.Start();
            Console.Clear();
            Console.WriteLine("Хотите сыграть еще?\n1. Да\n2. Нет");
            string playAgain = Console.ReadLine();
            switch (playAgain)
            {
                case "1":
                    start();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Всего хорошего");
                    break;
                default:
                    Console.WriteLine("Выберите один из 2 вариантов");
                    break;
            }
        }
    }
}
