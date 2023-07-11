using Data.Interface.Models;
using Data.Sql.DataModels;
using HealthyFoodWeb.Models;


namespace HealthyFoodWeb.Services.IServices
{
    public interface IReviewService
    {
        //List<ReviewAndInfoAboutTheirGames> GetAllReviews();
        void AddReview(GeneralReviewViewModel model);
        GeneralReviewViewModel BuildViewModelFromDbModel();
        PagginatorViewModel<ReviewViewModel> GetReviewsForPuginator(int page, int perPage);
        ReviewViewModel BuildOneModel(Review x);
    }
}
