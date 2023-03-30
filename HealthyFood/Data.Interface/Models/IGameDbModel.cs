namespace Data.Interface.Models
{
    public interface IGameDbModel : IDbModel
    {
        string Name { get; }
        string CoverUrl { get; }
        decimal Price { get; }
    }
}
