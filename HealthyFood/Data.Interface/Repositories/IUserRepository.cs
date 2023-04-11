using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByName(string name);
        void RemoveByName(string name);
    }
}
