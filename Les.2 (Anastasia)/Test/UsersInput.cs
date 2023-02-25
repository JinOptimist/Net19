
using HealthyFood;
namespace HealthyFood
{
    public class UsersInput //из метода InPut получим число
    {
       
        int userNumber = 0;
        public int UserNumber
        {
            get { return userNumber; }
            set { userNumber = value; }
        }
        public int InPut()
        {
            string userNumberStr = Console.ReadLine();
            bool isUserInPutNumber = int.TryParse(userNumberStr, out userNumber);

            return userNumber;

        }
    }
}
//class Pers