using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class StoreCatalogueRepository : BaseRepository<User>, IUserRepository
    {
        public StoreCatalogueRepository(WebContext webContext) : base(webContext) { }

        public User GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            var item = _dbSet.FirstOrDefault(_x => _x.Name == name);
            _dbSet.Remove(item);
            _webContext.SaveChanges();
        }
    }
}
