using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
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

        
        public GeneralReviewViewModel BuildViewModelFromDbModel()
        {
           var allReviewes = _reviewRepository.GetReviews().ToList().Select(
               dbModel =>
               new ReviewViewModel
               {
                   TextReview = dbModel.TextReview,
                   Date = dbModel.Date,
                   Author = dbModel.UserName,
                   CreatedGame = dbModel.GamesName.ToList(),

               })
                 .ToList();

            var generalReviewViewModel = new GeneralReviewViewModel
            {
                ReviewViewModels = allReviewes,
                //TextError = errorMessage
            };
            return generalReviewViewModel;
        }
        public void AddReview(GeneralReviewViewModel model)
        {
            var user = _authService.GetUser();
            var dbModel = new Review()
            {
                TextReview = model.NewReview,
                Date = DateTime.Now,
                User = user
            };
            _reviewRepository.Add(dbModel);
        }
    }
}
