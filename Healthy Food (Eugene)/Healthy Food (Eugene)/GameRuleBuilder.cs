namespace Healthy_Food__Eugene_
{
    public class GameRuleBuilder
    {
        public const int MIN_DEFUALT = 0;
        public const int MAX_DEFUALT = 100;

        public GameRule BuildAutoGameRule()
            => new GameRule
            {
                Min = MIN_DEFUALT,
                Max = MAX_DEFUALT,
                TheNumber = CalcTheNumber(MIN_DEFUALT, MAX_DEFUALT),
                MaxAttempCount = CalcMaxAttemptCount(MIN_DEFUALT, MAX_DEFUALT)
            };

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
