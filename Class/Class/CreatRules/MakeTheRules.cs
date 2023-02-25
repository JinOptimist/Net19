
using Class;
namespace Class
{
    public class MakeTheRules
    {
             
        public GameRule BuildAutoGameRule()
        {
            GameRule ruleForThisGame = new GameRule();
            RandomOrNot randomOrNot = new RandomOrNot();
            InPutUser inPutUser = new InPutUser();
            inPutUser.InPut();
            int choise = inPutUser.UserNumber;
           
            randomOrNot.MakeIt(choise);
            ruleForThisGame.Min = randomOrNot.minNumber;
            ruleForThisGame.Max = randomOrNot.maxNumber;
            ruleForThisGame.ThisNubmerInGame = randomOrNot.theNumber;
            ruleForThisGame.MaxAttemptInGame = randomOrNot.maxAttempt;
           
            return ruleForThisGame;
        }
    }
}
