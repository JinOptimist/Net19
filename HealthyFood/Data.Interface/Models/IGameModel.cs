namespace Data.Interface.Models
{
    public interface IGameModel
    {
        int Id { get; set; }
        string Name { get; }
        decimal Price { get; }
    }
}
