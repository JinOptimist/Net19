using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class GameRepository : IGameRepository
    {
        private WebContext _webContext;

        public GameRepository(WebContext webContext)
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

        public IGameDbModel GetByName(string name)
        {
            return _webContext.Games.FirstOrDefault(x => x.Name == name);
        }

        public IGameDbModel GetGameByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var game = _webContext.Games.FirstOrDefault(_x => _x.Id == id);
            _webContext.Games.Remove(game);
        }

        public void RemoveByName(string name)
        {
            var game = _webContext.Games.FirstOrDefault(_x => _x.Name == name);
            _webContext.Games.Remove(game);
        }
    }
}

