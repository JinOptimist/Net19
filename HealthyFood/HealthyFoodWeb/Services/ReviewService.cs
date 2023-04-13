using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class ReviewService : IReviewService
    {
        IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;   
        }

        public List<Review> GetAllReviews()
        {
            return _reviewRepository.GetAll().ToList();
        }
    }
}
