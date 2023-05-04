using Data.Fake.Repositories;
using Data.Interface.Models.ProductPage;
using Data.Interface.Repositories.IProductPageRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;   
namespace Data.Sql.Repositories.ProductPageRepositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(WebContext webContext) : base(webContext)
        {
        }

        public ProductCategory Get(string name)
        {
            return _dbSet.SingleOrDefault(x => x.Name == name);
        }
    }
}
