using Data.Interface.Models;
using Data.Sql.DataModels;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.GameCatalogController;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IReviewService
    {
       List<ReviewAndInfoAboutTheirGames> GetAllReviews();
        void AddReview(NewReviewViewModel model);
    }
}
