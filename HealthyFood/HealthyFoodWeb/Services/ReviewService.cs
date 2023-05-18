using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
using Data.Sql.Repositories;
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

        public ReviewService(
            IReviewRepository reviewRepository,
            IAuthService authService,
            IPagginatorService pagginatorService)
        {
            _reviewRepository = reviewRepository;
            _authService = authService;
            _pagginatorService = pagginatorService;
        }

        //public List<ReviewViewModel> GetAllReviews()
        //{
        //    var dbReviews = _reviewRepository.GetReviews().ToList();
        //    return dbReviews.Select(dbModel =>
        //          new ReviewViewModel
        //          {
        //              TextReview = dbModel.TextReview,
        //              Date = dbModel.Date,
        //              Author = dbModel.UserName,
        //              CreatedGame = dbModel.GamesName.ToList(),
        //          })
        //      .ToList();
        //}
        public PagginatorViewModel<ReviewViewModel> GetGamesForPaginator(int page, int perPage)
        {
            var viewModel = _pagginatorService
                .GetPaginatorViewModel(
                    page,
                    perPage,
                    GetReviewViewModel,
                    _reviewRepository);

            return viewModel;
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

        public ReviewViewModel GetReviewViewModel(Review dbModel)
        {
            return new ReviewViewModel
            {
                TextReview = dbModel.TextReview,
                Date = dbModel.Date,
                Author = dbModel.User.Name,
                CreatedGame = dbModel.User.CreatedGames.Select(g => g.Name).ToList(),
            };
        }

    }
}
