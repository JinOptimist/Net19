using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        void Add(DbModel model);
        DbModel Get(int id);
        IEnumerable<DbModel> GetAll();
        void Remove(int id);
    }
}