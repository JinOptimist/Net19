namespace MyCustomLinq.Models
{
    public class UserGenerator
    {
        private Random _random = new Random();

        public User BuildRandomUser()
        {
            var user = new User();

            user.Height = _random.Next(100, 200);
            
            var year = _random.Next(1940, 2022);
            var month = _random.Next(1, 12);
            var day = _random.Next(1, 25);
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
