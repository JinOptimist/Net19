namespace Data.Interface.Models
{
    public class Game : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CoverUrl { get; set; }

        public virtual List<GameCategory> Genres { get; set; }
        public virtual List<User> Players { get; set; }
    }
}
