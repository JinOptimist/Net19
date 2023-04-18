using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        void Add(T model);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Remove(int id);
        bool Any();
    }
}