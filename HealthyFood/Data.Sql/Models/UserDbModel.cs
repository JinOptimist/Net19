using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class UserDbModel : BaseDbModel, IUserDbModel
    {
        public string Name { get; set; }

        public string AvatarUrl { get; set; }
    }
}
