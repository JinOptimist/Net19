using Data.Interface.Models;

namespace Data.Fake.Models
{
    public abstract class BaseDbModel : IDbModel
    {
        public int Id { get; set; }
    }
}
