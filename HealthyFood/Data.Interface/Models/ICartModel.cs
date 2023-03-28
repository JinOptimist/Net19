namespace Data.Interface.Models
{
    public interface ICartModel
    {
        int Id { get; set; }
        string Name { get; }
        decimal Price { get; }
    }
}
