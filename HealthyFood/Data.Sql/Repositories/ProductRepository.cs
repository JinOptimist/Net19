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
        private WebContext _webContext;

        public ProductRepository(WebContext webContext) : base(webContext)
        {
            _webContext = webContext;
        }

        public Product Get(string name)
        {
            return _webContext.Products.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            var product = Get(name);
            Remove(product.Name);
        }

        List<Product> IProductRepository.GetAll()
        {
            return _webContext.Products.ToList();
        }
    }
}
