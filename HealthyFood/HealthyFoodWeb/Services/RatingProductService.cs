using Data.Fake.Repositories;
using Data.Interface.Repositories;
using Data.Sql.Models;
using HealthyFoodWeb.Models;


namespace HealthyFoodWeb.Services
{
    public class RatingProductService
    {
        public const decimal RATINGPRODUCT_DEFAULT = 4;
        private ProductRepositoryFake _productRepositoryFake;

        public RatingProductService(ProductRepositoryFake productRepositoryFake)
        {
            _productRepositoryFake = productRepositoryFake;
        }

        public void UpdateRatingProduct(ProductPageViewModel viewModel)
        {
            var dbProductModel = new ProductDbModel()
            {
                Rating = viewModel.Rating,
            };

         }

        //List<ProductModel> GetProductMidRating();
        //List<ProductModel> GetProductLowRating();
        //List<ProductModel> GetProductHighRating();


    }
}
