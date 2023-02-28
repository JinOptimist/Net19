namespace Healthy_Food__Eugene_.RuleBuilders
{
    public class HumanRuleBuilder : IRuleBuilder
    {
        public const int MIN_DEFUALT = 0;
        public const int MAX_DEFUALT = 100;

        public GameRule BuildGameRule()
         
            { var gameRule = new GameRule();
                gameRule.Min = CalcMinNumber();
                gameRule.Max = CalcMaxNumber(gameRule.Min);
                gameRule.TheNumber = CalcTheNumber(gameRule.Min, gameRule.Max);
                gameRule.MaxAttempCount = CalcMaxAttemptCount();
            return gameRule;
            }

        private int CalcTheNumber(int min, int max)
        {
            bool isItWasANumber;
            int userNumber;
            do
            {
                Console.WriteLine("Enter the number to guess");
                var userNumberString = Console.ReadLine();
                isItWasANumber = Int32.TryParse(userNumberString, out userNumber);
                if (!isItWasANumber)
                {
                    Console.WriteLine("It's not a number");
                }
                else if (isItWasANumber && (userNumber > max || userNumber < min))
                {
                    Console.WriteLine($"Your number {userNumber} not in range [{min}, {max}]");
                }
            } while (!isItWasANumber || userNumber > max || userNumber < min);
            return userNumber;
        }

        private int CalcMaxAttemptCount()
        {
            bool isItWasANumber;
            int userAttemptCount;
            do
            {
                Console.WriteLine("Enter Attempt count");
                var userNumberString = Console.ReadLine();
                isItWasANumber = Int32.TryParse(userNumberString, out userAttemptCount);
                if (!isItWasANumber)
                {
                    Console.WriteLine("It's not a number");
                }else if(userAttemptCount < 0)
                {
                    Console.WriteLine("Too little attempts");
                }
            } while (!isItWasANumber || userAttemptCount < 0);

            return userAttemptCount;
        }

        private int CalcMaxNumber(int min)
        {
            bool isItWasANumber;
            int userMaxNumber;
            do
            {
                Console.WriteLine("Enter A Max Number");
                var userNumberString = Console.ReadLine();
                isItWasANumber = Int32.TryParse(userNumberString, out userMaxNumber);
                if (!isItWasANumber)
                {
                    Console.WriteLine("It's not a number");
                }else if (userMaxNumber < min)
                {
                    Console.WriteLine("Number is less then minimum number");
                }
            } while (!isItWasANumber || userMaxNumber < min);

            return userMaxNumber;
        }

        private int CalcMinNumber()
        {
            bool isItWasANumber;
            int userMinNumber;
            do
            {
                Console.WriteLine("Enter A Min Number");
                var userNumberString = Console.ReadLine();
                isItWasANumber = Int32.TryParse(userNumberString, out userMinNumber);
                if (!isItWasANumber)
                {
                    Console.WriteLine("It's not a number");
                }
            } while (!isItWasANumber);

            return userMinNumber;
        }
    }

        
  }


