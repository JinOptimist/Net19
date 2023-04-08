using Data.Sql.Models;

namespace Data.Fake.Repositories
{
	public interface IProductRepository
	{
		List<Product> GetAll();
		Product GetProductByRating(decimal rating);
		void RemoveByRating(decimal rating);
		void SaveProduct(Product product);
	}
}