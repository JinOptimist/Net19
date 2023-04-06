using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WebContext webContext) : base(webContext) { }

        public User GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public void RemoveByName(string name)
        {
            var user = _dbSet.FirstOrDefault(_x => _x.Name == name);
            _dbSet.Remove(user);
            _webContext.SaveChanges();
        }
    }
}
