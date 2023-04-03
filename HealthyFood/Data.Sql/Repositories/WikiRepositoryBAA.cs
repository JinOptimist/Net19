using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class WikiRepositoryBAA : IWikiRepositoryBAA
    {
        private WebContext _webContext;

        public WikiRepositoryBAA(WebContext webContext)
        {
            _webContext = webContext;
        }
               
        public void Add(IBlockModelBAA model)
        {
            _webContext.Blocks.Add((BlockModelBAA)model);
            _webContext.SaveChanges();
        }
       
        public IBlockModelBAA Get(int id)
        {
            return _webContext.Blocks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<IBlockModelBAA> GetAll()
        {
            return _webContext.Blocks.ToList();
        }

        public void Remove(int id)
        {
            var block = _webContext.Blocks.FirstOrDefault(_x => _x.Id == id);
            _webContext.Blocks.Remove(block);
        }

        public IBlockModelBAA GetBlockId(int id)
        {
            return _webContext.Blocks.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveBlock(int id)
        {
            _webContext.Remove(GetBlockId(id));
            _webContext.SaveChanges();
        }
    }
}
