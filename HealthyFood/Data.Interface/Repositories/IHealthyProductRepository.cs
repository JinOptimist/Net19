using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IHealthyProductRepository : IBaseRepository<IHealthyProductDbModel>
    {
        IHealthyProductDbModel GetByName(string name);
        void RemoveByName(string name);
    }
}
