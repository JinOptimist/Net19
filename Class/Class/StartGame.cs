using Class;
namespace Class
{
    public class StartGame
    {
        public void Start()
        {
            MakeTheRules makeTheRules = new MakeTheRules();

            var rule = makeTheRules.BuildAutoGameRule();
            GameManager gameManager = new GameManager(rule);
            gameManager.OneTurn();

            while (true)
            {
                int toContinue;
                Console.WriteLine("Желаете сыграть еще? \n1. Да \n2. Нет");
                string toContinueStr = Console.ReadLine();
                bool toContonueBoalen = int.TryParse(toContinueStr, out toContinue);
                if (toContinue == 1)
                {
                    Console.Clear();
                    Start();
                }
                else if (toContinue == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Всего хорошего!");                  
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
