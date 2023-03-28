using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IUserRepository : IBaseRepository<IUserDbModel>
    {
        IUserDbModel GetByName(string name);
        void RemoveByName(string name);
    }
}
