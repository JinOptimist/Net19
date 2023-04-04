
using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public abstract class BaseRepository<SomeModel> : IBaseRepository<SomeModel> where SomeModel : BaseModel
    {
        protected WebContext _webContext;
        protected DbSet<SomeModel> _dbSet;
        public BaseRepository(WebContext webContext)
        {
            _webContext = webContext;
            _dbSet = webContext.Set<SomeModel>();
        }
       

        public void Add(SomeModel model)
        {

            _dbSet.Add(model);
            _webContext.SaveChanges();
        }

        public SomeModel Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

       

        public void Remove(int id)
        {
            var categoryForRemoveId = _dbSet.FirstOrDefault(x => x.Id == id);
            _dbSet.Remove(categoryForRemoveId);
        }

       

        IEnumerable<SomeModel> IBaseRepository<SomeModel>.GetAll()
        {

            return _dbSet.ToList();
        }
    }
}

