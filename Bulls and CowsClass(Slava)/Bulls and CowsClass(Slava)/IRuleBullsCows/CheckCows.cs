using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_.iRuleBullsCows
{
    public class CheckCows : IRuleBullsCows
    {
        private Variables _Variables;

        public CheckCows(Variables Variables)
        {
            _Variables = Variables;
        }

        public void Check()
        {
            foreach (int CheckForCows in _Variables.RandomNumberClientInt)
            {
                for (int j = 0; j < _Variables.RandomNumberClientInt.Length; j++)
                {
                    if (CheckForCows == _Variables.RandomNumberComputer[j])
                    {
                        _Variables.Cows++;
                    }
                }
            }
        }
    }
}
