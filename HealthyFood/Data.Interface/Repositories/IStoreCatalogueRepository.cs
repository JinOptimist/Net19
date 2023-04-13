using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IStoreCatalogueRepository : IBaseRepository<Cart>
    {
        Cart GetByName(string name);
        void RemoveByName(string name);
    }
}
