using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExample
{
    public class TaskConsoleLazy
    {
        public static char MySymbol = 'A';
        public static object SyncObj = new object();

        public void Start()
        {
            var taskForMinus = new Task(() =>
            {
                Write('-', false);
            });
            var taskForAster = new Task(() =>
            {
                Write('*', false);
            });

            taskForMinus.Start();
            taskForAster.Start();

            while (true)
            {
                // Console.Write("    " + MySymbol + "    ");
            }
        }

        public void Write(char symbol, bool isGood)
        {
            while (true)
            {
                lock (SyncObj)
                {
                    MySymbol = symbol;
                    if (MySymbol != symbol)
                    {
                        throw new Exception("qwe");
                    }

                    Console.Write(symbol);
                }
            }
        }

        public string Sum(char a, int b)
        {
            return "" + a + b;
        }
    }
}
