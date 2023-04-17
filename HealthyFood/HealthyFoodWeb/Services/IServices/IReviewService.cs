using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IReviewService
    {
       List<Review> GetAllReviews();
        void AddReview(ReviewViewModelAuthorize model);
    }
}
