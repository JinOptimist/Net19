namespace Data.Interface.Models
{
    public interface IUserModel
    {
        int Id { get; set; }
        string Name { get; }
        string AvatarUrl { get; }
    }
}
