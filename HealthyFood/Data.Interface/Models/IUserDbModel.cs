namespace Data.Interface.Models
{
    public interface IUserDbModel : IDbModel
    {
        string Name { get; }
        string AvatarUrl { get; }
    }
}
