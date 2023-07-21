using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Fake.Repositories
{
	public interface IProductRepository : IBaseRepository<Product>
	{
        
        void UpdateRating(int id, decimal rating);
    }
}