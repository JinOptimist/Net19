using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private WebContext _webContext;

        public UserRepository(WebContext webContext)
        {
            _webContext = webContext;
        }

        public void Add(User model)
        {
            _webContext.Users.Add((User)model);
            _webContext.SaveChanges();
        }

        public User Get(int id)
        {
            return _webContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _webContext.Users.ToList();
        }

        public User GetByName(string name)
        {
            return _webContext.Users.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(int id)
        {
            var user = _webContext.Users.FirstOrDefault(_x => _x.Id == id);
            _webContext.Users.Remove(user);
        }

        public void RemoveByName(string name)
        {
            var user = _webContext.Users.FirstOrDefault(_x => _x.Name == name);
            _webContext.Users.Remove(user);
        }
    }
}
