using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFood.RuleBuilder
{
    public class RuleBuilderBase : IRuleBuilder
    {
        public const int MIN_DEFUALT = 0;
        public const int MAX_DEFUALT = 100;
        public virtual GameRule BuildRule()
        {
            var gameRule = new GameRule();//пустышка
            return gameRule;
        }
        protected int CalcTheNumber(int min, int max)
        {
            var random = new Random();
            var theNumber = random.Next(min, max);
            return theNumber;
        }

        protected int CalcMaxAttemptCount(int min, int max)
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
