using Data.Sql.Models;

namespace Data.Fake.Repositories
{
	public interface IProductRepository
	{
		List<ProductModel> GetAll();
		ProductModel GetProductByRating(decimal rating);
		void RemoveByRating(decimal rating);
		void SaveProduct(ProductModel product);
	}
}