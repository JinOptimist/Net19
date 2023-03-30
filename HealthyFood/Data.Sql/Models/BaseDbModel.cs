using Data.Interface.Models;

namespace Data.Sql.Models
{
    public abstract class BaseDbModel : IDbModel
    {
        public int Id { get; set; }
    }
}
