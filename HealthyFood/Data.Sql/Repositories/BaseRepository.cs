using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public abstract class BaseRepository<SomeModel> 
        : IBaseRepository<SomeModel> where SomeModel : BaseModel
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

        public void Update(SomeModel model)
        {
            _dbSet.Update(model);
            _webContext.SaveChanges();
        }

        public bool Any()
            => _dbSet.Any();

        public int Count()
            => _dbSet.Count();

        public SomeModel Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SomeModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(int id)
        {
            _dbSet.Remove(Get(id));
        }
    }

}
