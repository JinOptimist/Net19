using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Services.Helpers;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Services
{
    public class ReviewService : IReviewService
    {
        IReviewRepository _reviewRepository;
        IAuthService _authService;
        IPagginatorService _pagginatorService;
        public ReviewService(IReviewRepository reviewRepository, IAuthService authService, IPagginatorService pagginatorService)
        {
            _reviewRepository = reviewRepository;
            _authService = authService;
            _pagginatorService = pagginatorService;
        }



        public PagginatorViewModel<ReviewViewModel> GetReviewsForPuginator(int page, int perPage)
        {
            var viewModel = _pagginatorService.
                GetPaginatorViewModel(
                    page,
                    perPage,
                    BuildOneModel,
                    _reviewRepository);

            return viewModel;
        }

        public ReviewViewModel BuildOneModel(Review x)
        {
            return new ReviewViewModel
            {
                TextReview = x.TextReview,
                Date = x.Date,
                Author = x.User.Name,
                CreatedGame = x.User.CreatedGames.Select(x => x.Name).ToList()
            };
        }

        public GeneralReviewViewModel BuildViewModelFromDbModel()
        {
            var allReviewes = _reviewRepository.GetReviews().ToList().Select(
                x =>
                new ReviewViewModel
                {
                    TextReview = x.TextReview,
                    Date = x.Date,
                    Author = x.UserName,
                    CreatedGame = x.GamesName.ToList(),

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
