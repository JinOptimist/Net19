using Data.Interface.Models;

namespace Data.Fake.Models
{
    public class GameModel : IGameModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CoverUrl { get; set; }
    }
}
