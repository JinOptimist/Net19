

using HealthyFood;

namespace Test
{
    public class GameRuleBuilder
    {
        Random rnd = new Random();
        public const int MIN_DEFUALT = -100;
        public const int MAX_DEFUALT = 100;
        //string userNumberStr = Console.ReadLine();
        //int userNumber = 0;
        // bool IsUserInPutNumber = int.TryParse(userNumberStr, out userNumber);
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

