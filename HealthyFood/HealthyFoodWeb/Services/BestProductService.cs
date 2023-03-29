using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
    public class BestProductService
    {
        
        void UpRatingProduct(ProductPageViewModel viewModel);

        void DownRatingProduct(ProductPageViewModel viewModel);

        List<ProductModel> GetProductMidRating();
        List<ProductModel> GetProductLowRating();
        List<ProductModel> GetProductHighRating();


    }
}
