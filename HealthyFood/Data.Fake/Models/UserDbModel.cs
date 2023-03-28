using Data.Interface.Models;

namespace Data.Fake.Models
{
    internal class UserDbModel : IUserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }
    }
}
