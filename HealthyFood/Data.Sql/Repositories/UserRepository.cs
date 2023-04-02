using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private WebContext _webContext;

        public UserRepository(WebContext webContext)
        {
            _webContext = webContext;
        }

        public void Add(IUserDbModel model)
        {
            _webContext.Users.Add((UserDbModel)model);
            _webContext.SaveChanges();
        }

        public IUserDbModel Get(int id)
        {
            return _webContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<IUserDbModel> GetAll()
        {
            return _webContext.Users.ToList();
        }

        public IUserDbModel GetByName(string name)
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
