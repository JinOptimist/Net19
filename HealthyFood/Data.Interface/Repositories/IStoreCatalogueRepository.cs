using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IStoreCatalogueRepository : IBaseRepository<StoreItem>
    {
        StoreItem GetByName(string name);
        List<StoreItem> GetItemsWithManufacturer();
    }
}
