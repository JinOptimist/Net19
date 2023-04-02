namespace Data.Interface.Models
{
    public interface IBlockModelBAA : IDbModel
    {
        string Title { get; }
        string Text { get; }
    }
}