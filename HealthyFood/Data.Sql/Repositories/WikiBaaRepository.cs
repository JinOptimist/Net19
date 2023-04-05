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
               
        public void Add(Block model)
        {
            _webContext.Blocks.Add((Block)model);
            _webContext.SaveChanges();
        }
       
        public Block Get(int id)
        {
            return _webContext.Blocks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Block> GetAll()
        {
            return _webContext.Blocks.ToList();
        }

        public void Remove(int id)
        {
            var block = _webContext.Blocks.FirstOrDefault(_x => _x.Id == id);
            _webContext.Blocks.Remove(block);
        }
        
        public void RemoveBlock(int id)
        {
            _webContext.Remove(Get(id));
            _webContext.SaveChanges();
        }
    }
}
