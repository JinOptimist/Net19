

using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Fake.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        public void Add(ICatalogDbModel model)
        {
            throw new NotImplementedException();
        }

        public ICatalogDbModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ICatalogDbModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }


}

