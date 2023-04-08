using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class WikiBaaRepository : IWikiBaaRepository
    {
        private WebContext _webContext;

        public WikiBaaRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
               
        public void Add(PageWikiBlock model)
        {
            _webContext.PageWikiBlocks.Add((PageWikiBlock)model);
            _webContext.SaveChanges();
        }
       
        public PageWikiBlock Get(int id)
        {
            return _webContext.PageWikiBlocks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<PageWikiBlock> GetAll()
        {
            return _webContext.PageWikiBlocks.ToList();
        }

        public void Remove(int id)
        {
            var block = _webContext.PageWikiBlocks.FirstOrDefault(_x => _x.Id == id);
            _webContext.PageWikiBlocks.Remove(block);
            _webContext.SaveChanges();
        }
    }
}
