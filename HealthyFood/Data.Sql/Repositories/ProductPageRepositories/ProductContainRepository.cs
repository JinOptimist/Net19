using Data.Interface.Models;
using Data.Interface.Models.ProductPage;
using Data.Interface.Repositories;
using Data.Interface.Repositories.IProductPageRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.Repositories.ProductPageRepositories
{
    public class ProductContainRepository : BaseRepository<ProductContain>, IProductContainRepository
    {
        public ProductContainRepository(WebContext webContext) : base(webContext)
        {
        }

        public List<ProductContain> GetProductContain()
        {
            return _dbSet
                .Select(productContain => new ProductContain
                {
                    EnergyValue = productContain.EnergyValue,
                    Fat = productContain.Fat,
                    Carbohydrates = productContain.Carbohydrates,
                    Proteins = productContain.Proteins,
                })
                .ToList();
        }
    }
}
