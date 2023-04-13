using Data.Interface.Repositories;
using Data.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class WikiBaaRepository : BaseRepository<PageWikiBlock>, IWikiBaaRepository
    {
        public WikiBaaRepository(WebContext webContext) : base(webContext) { }

        public void Add(PageWikiBlock model)
        {
            _dbSet.Add((PageWikiBlock)model);
            _webContext.SaveChanges();
        }

        public IEnumerable<PageWikiBlock> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<PageWikiBlock> GetBlocksWithAuthors()
        {
            return _dbSet
                .Include(x => x.Authors)
                .ToList();
        }

        public void Remove(int id)
        {
            var block = _dbSet.FirstOrDefault(_x => _x.Id == id);
            _dbSet.Remove(block);
            _webContext.SaveChanges();
        }
    }
}
