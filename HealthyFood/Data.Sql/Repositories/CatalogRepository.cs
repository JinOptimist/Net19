

using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private WebContext _webContext;

        public CatalogRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
        public void Add(ICatalogDbModel model)
        {
            _webContext.CatalogDbModels.Add((CatalogDbModel)model);
            _webContext.SaveChanges();
        }

        public ICatalogDbModel Get(int id)
        {
           return _webContext.CatalogDbModels.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var categoryForRemoveId = _webContext.CatalogDbModels.FirstOrDefault(x => x.Id == id);
            _webContext.Remove(categoryForRemoveId);
        }
        IEnumerable <ICatalogDbModel> IBaseRepository<ICatalogDbModel>.GetAll()
        {
           return _webContext.CatalogDbModels.ToList();
        }
    }


}

