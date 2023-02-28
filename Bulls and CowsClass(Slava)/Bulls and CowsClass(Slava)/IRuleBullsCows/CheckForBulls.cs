using System.Text;
using System.Threading.Tasks;

namespace Bulls_and_CowsClass_Slava_.iRuleBullsCows
{
    public class CheckForBulls : IRuleBullsCows
    {
        private Variables _Variables;

        public CheckForBulls(Variables Variables)
        {
            _Variables = Variables;
        }

        public void Check()
        {
            for (int i = 0; i < _Variables.RandomNumberClientInt.Length; i++)
            {
                if (_Variables.RandomNumberClientInt[i] == _Variables.RandomNumberComputer[i])
                {
                    _Variables.Bulls++;
                }
            }
        }
    }
}
