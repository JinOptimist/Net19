using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface ICartRepository : IBaseRepository<ICartDbModel>
    {
        ICartDbModel GetByName(string name);
        void RemoveByName(string name);
    }
}
