using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Fake.Repositories
{
	public interface IProductRepository : IBaseRepository<Product>
	{
        void Add(Product product);
        Product Get(string name);
        List<Product> GetAll();
        void Remove(string name);
	}
}