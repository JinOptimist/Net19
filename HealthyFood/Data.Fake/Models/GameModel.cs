using Data.Interface.Models;

namespace Data.Fake.Models
{
    public class GameModel : BaseDbModel, IGameDbModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CoverUrl { get; set; }
    }
}
