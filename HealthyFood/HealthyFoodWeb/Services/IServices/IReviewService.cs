using Data.Interface.Models;
using Data.Sql.DataModels;
using HealthyFoodWeb.Models;


namespace HealthyFoodWeb.Services.IServices
{
    public interface IReviewService
    {
        //List<ReviewViewModel> GetAllReviews();
        void AddReview(GeneralReviewViewModel model);
        PagginatorViewModel<ReviewViewModel> GetGamesForPaginator(int page, int perPage);
    }

}
