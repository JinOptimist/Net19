namespace MyCustomLinq.Models
{
    public class UserGenerator
    {
        public User BuildRandomUser()
        {
            var random = new Random();

            var user = new User();

            user.Height = random.Next(100, 200);
            
            var year = random.Next(1940, 2022);
            var month = random.Next(1, 12);
            var day = random.Next(1, 25);
            user.Birthday = new DateTime(year, month, day);

            return user;
        }

        public List<User> BuildRandomUsers(int count = 10)
        {
            var list = new List<User>();

            for (int i = 0; i < count; i++)
            {
                list.Add(BuildRandomUser());
            }

            return list;
        }
    }
}
