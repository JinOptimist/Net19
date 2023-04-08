namespace Data.Interface.Models
{
<<<<<<<< HEAD:HealthyFood/Data.Interface/Models/GameDbModel.cs
    public class GameDbModel : BaseDbModel, IGameDbModel
========
    public class Game : BaseModel
>>>>>>>> main:HealthyFood/Data.Interface/Models/Game.cs
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CoverUrl { get; set; }

        public virtual List<GameCategory> Genres { get; set; }

        public virtual List<GameCategory> SecondaryGenres { get; set; }
    }
}
