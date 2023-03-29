using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models;
using System.Xml.Linq;

namespace HealthyFoodWeb.Services
{
    public class ProductRepositoryFake
    {
        public static List<ProductModel> FakeDbProduct =
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
            return FakeDbProduct;
        }

        public ProductModel GetProductByRating(decimal rating)
        {
            return FakeDbProduct.FirstOrDefault(x => x.Rating == rating);
        }

        public void RemoveByRating(decimal rating)
        {
            FakeDbProduct.Remove(GetProductByRating(rating));
        }

        public void SaveProduct(ProductModel product)
        {
            var maxExistedId = FakeDbProduct.Max(x => x.Id);
            product.Id = maxExistedId + 1;
            FakeDbProduct.Add(product);
        }
    }
}
