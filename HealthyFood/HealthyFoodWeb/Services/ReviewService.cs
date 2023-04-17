using Data.Interface.Models;
using Data.Interface.Repositories;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class ReviewService : IReviewService
    {
        IReviewRepository _reviewRepository;
        IAuthService _authService;
        public ReviewService(IReviewRepository reviewRepository, IAuthService authService)
        {
            _reviewRepository = reviewRepository;
            _authService = authService; 
        }

        public List<Review> GetAllReviews()
        {
            return _reviewRepository.GetReviews().ToList();
        }
        public void AddReview(ReviewViewModelAuthorize model)
        {
            var user = _authService.GetUser();
            var dbModel = new Review()
            {
                TextReview = model.CreatReview,
                Date = DateTime.Now,
                User = user

               
            };
            _reviewRepository.Add(dbModel);
        }
    }
}
