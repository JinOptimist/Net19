using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class GameRepositories : IGameRepository
    {
        private WebContext _webContext;

        public GameRepositories(WebContext webContext)
        {
            _webContext = webContext;
        }
        public void Add(IGameDbModel model)
        {
            _webContext.Games.Add((GameDbModel)model);
            _webContext.SaveChanges();
        }

        public IGameDbModel Get(int id)
        {
            return _webContext.Games.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<IGameDbModel> GetAll()
        {
            return _webContext.Games.ToList();
        }

        public IGameDbModel GetGameByName(string name)
        {
            return _webContext.Games.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(int id)
        {
            var game = _webContext.Games.FirstOrDefault(_x => _x.Id == id);
            _webContext.Games.Remove(game);
        }

        public void RemoveByName(string name)
        {
            var user = _webContext.Games.FirstOrDefault(_x => _x.Name == name);
            _webContext.Games.Remove(user);
        }
    }
}

