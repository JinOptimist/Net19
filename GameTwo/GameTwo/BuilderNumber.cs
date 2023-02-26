namespace GameTwo
{
    internal class BuilderNumber
    {
        int theNumberForGame;
        int sign;
        string theNumberForGameString = "0000";
        public int BuidIt(int significance)
        {
            sign = significance;
            string minStr = "100";
            string maxStr = "999";

            for (int i = 4; i <= significance; i++)
            {
                minStr += "0";
                maxStr += "9";
            }
            int min = int.Parse(minStr);
            int max = int.Parse(maxStr);
            Random rnd = new Random();

            theNumberForGame = rnd.Next(min, max);
            theNumberForGameString = theNumberForGame.ToString();
            return theNumberForGame;


        }
        public Rules Builder()
       => new Rules()

       {
           TheNumber = theNumberForGame,
           Significance = sign
       };
    }
}


