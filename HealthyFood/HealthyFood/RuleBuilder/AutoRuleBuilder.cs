using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFood.RuleBuilder
{
    public class AutoRuleBuilder : RuleBuilderBase //наследовал, чтобы потестить
    {
        public override GameRule BuildRule()
        {
            var gameRule = new GameRule();
            gameRule.Min = MIN_DEFUALT;
            gameRule.Max = MAX_DEFUALT;
            gameRule.TheNumber = CalcTheNumber(gameRule.Min, gameRule.Max);
            gameRule.MaxAttemptCount = CalcMaxAttemptCount(gameRule.Min, gameRule.Max);

            return gameRule;
        }
    }
}
