namespace Data.Interface.Models
{
    public interface IGameModel
    {
        int Id { get; set; }
        string Name { get; }
        string CoverUrl { get; }
        decimal Price { get; }
    }
}
