using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Fake.Repositories
{
	public class ProductRepositoryFake : IProductRepository
	{
		public static List<Product> FakeDbProduct =
			new List<Product>() {
				new Product
				{
					Id = 1,
					Name = "Cabage",
					Price = 4,
					Rating = 3.8m
				},
				new Product
				{
					Id = 2,
					Name = "Cabage2",
					Price = 3,
					Rating = 3
				},
				new Product
				{
					Id = 3,
					Name = "Cabage3",
					Price = 6,
					Rating = 3.5m
				},
				new Product
				{
					Id = 4,
					Name = "Cabage4",
					Price = 7,
					Rating = 4
				},
				new Product
				{
					Id = 5,
					Name = "Cabage5",
					Price = 1,
					Rating = 5
				},
				new Product
				{
					Id = 6,
					Name = "Cabage6",
					Price = 2,
					Rating = 4.5m,
				},
			};

		public List<Product> GetAll()
		{
			return FakeDbProduct;
		}

		public Product GetProductByRating(decimal rating)
		{
			return FakeDbProduct.FirstOrDefault(x => x.Rating == rating);
		}

		public void RemoveByRating(decimal rating)
		{
			FakeDbProduct.Remove(GetProductByRating(rating));
		}

		public void SaveProduct(Product product)
		{
			var maxExistedId = FakeDbProduct.Max(x => x.Id);
			product.Id = maxExistedId + 1;
			FakeDbProduct.Add(product);
		}
	}
}
