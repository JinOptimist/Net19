using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class GameDbModel : BaseDbModel, IGameDbModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CoverUrl { get; set; }
    }
}
