using System.Data;

namespace HealthyFood
{
    public class GameRuleBuilder
    {
        public const int MIN_DEFUALT = 0;
        public const int MAX_DEFUALT = 100;

        public GameRule BuildAutoGameRule() 
        {
            var gameRule = new GameRule();
            gameRule.Min = MIN_DEFUALT;
            gameRule.Max = MAX_DEFUALT;
            gameRule.TheNumber = CalcTheNumber(gameRule.Min, gameRule.Max);
            gameRule.MaxAttempCount = CalcMaxAttemptCount(gameRule.Min, gameRule.Max);

            return gameRule;
        }

        private int CalcTheNumber(int min, int max)
        {
            var random = new Random();
            var theNumber = random.Next(min, max);
            return theNumber;
        }

        private int CalcMaxAttemptCount(int min, int max)
        {
            var rangeOfTheNumbers = max - min;
            var maxAttempCount = 1;
            var currentDistance = 1;
            while (currentDistance < rangeOfTheNumbers)
            {
                currentDistance = currentDistance * 2;
                maxAttempCount++;
            }

            return maxAttempCount;
        }
    }
}
