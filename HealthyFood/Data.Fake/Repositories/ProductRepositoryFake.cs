using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Fake.Repositories
{
	public class ProductRepositoryFake : IProductRepository
	{
		public static List<ProductModel> Product =
			new List<ProductModel>() {
				new ProductModel
				{
					Id = 1,
					Name = "Cabage",
					Price = 4,
					Rating = 3.8m
				},
				new ProductModel
				{
					Id = 2,
					Name = "Cabage2",
					Price = 3,
					Rating = 3
				},
				new ProductModel
				{
					Id = 3,
					Name = "Cabage3",
					Price = 6,
					Rating = 3.5m
				},
				new ProductModel
				{
					Id = 4,
					Name = "Cabage4",
					Price = 7,
					Rating = 4
				},
				new ProductModel
				{
					Id = 5,
					Name = "Cabage5",
					Price = 1,
					Rating = 5
				},
				new ProductModel
				{
					Id = 6,
					Name = "Cabage6",
					Price = 2,
					Rating = 4.5m,
				},
			};

		public List<ProductModel> GetAll()
		{
			return Product;
		}

		public ProductModel GetProductByRating(decimal rating)
		{
			return Product.FirstOrDefault(x => x.Rating == rating);
		}

		public void RemoveByRating(decimal rating)
		{
			Product.Remove(GetProductByRating(rating));
		}

		public void SaveProduct(ProductModel product)
		{
			var maxExistedId = Product.Max(x => x.Id);
			product.Id = maxExistedId + 1;
			Product.Add(product);
		}
	}
}
