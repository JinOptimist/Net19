using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public abstract class BaseRepository<Model> : IBaseRepository<Model> where Model : BaseModel
    {
        protected WebContext _webContext;
        protected DbSet<Model> _dbSet;

        public BaseRepository(WebContext webContext)
        {
            _webContext = webContext;
            _dbSet = webContext.Set<Model>();
        }

        public void Add(Model model)
        {
            _dbSet.Add(model);
            _webContext.SaveChanges();
        }

        public Model Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Model> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(int id)
        {
            _dbSet.Remove(Get(id));
        }
    }

}
