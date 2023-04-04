using Data.Fake.Models;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Fake.Repositories
{
    public class ProductRepositoryFake
    {
        public static List<ProductDbModel> FakeDbProduct =
            new List<ProductDbModel>() {
                new ProductDbModel
                {
                    Id = 1,
                    Name = "Cabage",
                    Price = 4,
                    Rating = 3.8m
                },
                new ProductDbModel
                {
                    Id = 2,
                    Name = "Cabage2",
                    Price = 3,
                    Rating = 3
                },
                new ProductDbModel
                {
                    Id = 3,
                    Name = "Cabage3",
                    Price = 6,
                    Rating = 3.5m
                },
                new ProductDbModel
                {
                    Id = 4,
                    Name = "Cabage4",
                    Price = 7,
                    Rating = 4
                },
                new ProductDbModel
                {
                    Id = 5,
                    Name = "Cabage5",
                    Price = 1,
                    Rating = 5
                },
                new ProductDbModel
                {
                    Id = 6,
                    Name = "Cabage6",
                    Price = 2,
                    Rating = 4.5m,
                },
            };

        public List<ProductDbModel> GetAll()
        {
            return FakeDbProduct;
        }

        public ProductDbModel GetProductByRating(decimal rating)
        {
            return FakeDbProduct.FirstOrDefault(x => x.Rating == rating);
        }

        public void RemoveByRating(decimal rating)
        {
            FakeDbProduct.Remove(GetProductByRating(rating));
        }

        public void SaveProduct(ProductDbModel product)
        {
            var maxExistedId = FakeDbProduct.Max(x => x.Id);
            product.Id = maxExistedId + 1;
            FakeDbProduct.Add(product);
        }
    }
}
