using HealthyFood;
namespace Test
{
    internal class MakeMinAndMaxNumbers
    {

        public GameRule rule { get; set; }
        Random rnd = new Random();
        public const int MIN_DEFUALT = -100;
        public const int MAX_DEFUALT = 100;
        int choice;
        public GameRule Rule
        {
            set { rule = value; }
        }
        //public void MinAndMax()
        // {
        //     Makeit();
        //     MakeTheNumbers(choice);
        // }
        //private GameRule _rule;
        //public MakeMinAndMaxNumbers(GameRule rule)
        //{
        //    _rule = rule;
        //}
        public UsersInput Makeit()
        {
            var userinp = new UsersInput();
            choice = userinp.InPut();

            MakeTheNumbers(choice);
           //Console.WriteLine(_rule.Min.ToString() + _rule.Max.ToString());
            return userinp;
        }

        public void MakeTheNumbers(int choice)
        {
            switch (choice)
            {
                case 1:
                    BuildAutoGameRuleRandom();
                   
                    break;
                case 2:
                    //BuildAutoGameRuleWhithUser();
                    break;

                default:
                    //Console.WriteLine("Введите правильно число!!!");
                    //UsersInput usersInput = new UsersInput();
                    //usersInput.InPut();
                    break;
            }
            //return rnd.Next(MIN_DEFUALT);
        }
        
        public GameRule BuildAutoGameRuleRandom()
        {
            var rule = new GameRule();
            rule.Min = rnd.Next(MIN_DEFUALT, MAX_DEFUALT);
            rule.Max = rnd.Next(rule.Min, MAX_DEFUALT);
            
            //rule.TheNumber = CalcTheNumber(MIN_DEFUALT, MAX_DEFUALT);
            //rule.MaxAttempCount = CalcMaxAttemptCount(MIN_DEFUALT, MAX_DEFUALT);

            return rule;
        }
        //public GameRule BuildAutoGameRuleWhithUser()
        //{

        //}
    }
}
