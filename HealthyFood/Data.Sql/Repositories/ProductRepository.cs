using Azure.Core;
using Data.Fake.Repositories;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WebContext webContext) : base(webContext)
        {
        }

        public void UpdateRating(int id, decimal rating)
        {
            var product = _dbSet.FirstOrDefault(x => x.Id == id);
            product.Rating = rating;
            _webContext.SaveChanges();

        }

    }
}
