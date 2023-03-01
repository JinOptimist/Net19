
using HealthyFood.Gamer;
using HealthyFood.RuleBuilder;
using System.Data;

namespace HealthyFood
{
    public class GameRuleBuilder
    {
        public GameRule BuildAutoGameRule() 
        {
            var ruleBuilder = CreateRuleBuilder();  
            return ruleBuilder.BuildRule(); 
        }

        public IRuleBuilder CreateRuleBuilder()
        {
            Console.WriteLine("What rule want u do?");
            Console.WriteLine("[H]uman rule?");
            Console.WriteLine("[A]uto rule?");
            var choiseString = Console.ReadLine();

            switch (choiseString)
            {
                case "H":
                    return new HumanRuleBuilder();
                case "A":
                    return new AutoRuleBuilder();
                default:
                    throw new Exception();
            }
        }
        
    }
}
