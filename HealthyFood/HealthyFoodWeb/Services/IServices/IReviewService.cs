using Data.Interface.Models;
using Data.Sql.DataModels;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IReviewService
    {
       List<ReviewAndInfoAboutTheirGames> GetAllReviews();
        void AddReview(ReviewViewModel model);
    }
}
