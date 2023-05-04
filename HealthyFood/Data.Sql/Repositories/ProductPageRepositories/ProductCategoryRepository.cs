using Data.Interface.Models.ProductPage;
using Data.Interface.Repositories.IProductPageRepositories;
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
