using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFood.RuleBuilder
{
    public class HumanRuleBuilder : RuleBuilderBase //наследовал, чтобы потестить
    {
        public override GameRule BuildRule()
        {
            var gameRule = new GameRule();
            Console.WriteLine("Write a min");
            gameRule.Min = Int32.Parse(Console.ReadLine());//не запаривался с валидацией

            Console.WriteLine("Write a max");
            gameRule.Max = Int32.Parse(Console.ReadLine());//не запаривался с валидацией

            Console.WriteLine("Write the number");
            gameRule.TheNumber = Int32.Parse(Console.ReadLine());//не запаривался с валидацией

            Console.WriteLine("Write max attempt");
            gameRule.MaxAttemptCount = Int32.Parse(Console.ReadLine());//не запаривался с валидацией

            return gameRule;
        }
    }
}
