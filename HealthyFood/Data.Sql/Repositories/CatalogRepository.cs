using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class GameCategoryRepository : IGameCategoryRepository
    {
        private WebContext _webContext;

        public GameCategoryRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
        public void Add(GameCategory model)
        {
            _webContext.GameCategories.Add((GameCategory)model);
            _webContext.SaveChanges();
           
        }

        public GameCategory Get(int id)
        {
           return _webContext.GameCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var categoryForRemoveId = _webContext.GameCategories.FirstOrDefault(x => x.Id == id);
            _webContext.Remove(categoryForRemoveId);
        }
        IEnumerable <GameCategory> IBaseRepository<GameCategory>.GetAll()
        {
            
            return _webContext.GameCategories.ToList();
        }
    }


}

