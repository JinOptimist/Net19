using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class StoreCatalogueRepository : BaseRepository<StoreItem>, IStoreCatalogueRepository
    {
        public StoreCatalogueRepository(WebContext webContext) : base(webContext) { }


        public StoreItem GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public List<StoreItem> GetItemsWithManufacturer()
        {
            return _dbSet
                .Include(x => x.Manufacturer)
                .ToList();
               
        }

    }
}
