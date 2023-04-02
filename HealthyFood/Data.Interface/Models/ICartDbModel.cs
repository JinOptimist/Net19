namespace Data.Interface.Models
{
    public interface ICartDbModel : IDbModel
    {
        string Name { get; }
        decimal Price { get; }
    }
}
