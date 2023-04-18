using Data.Interface.Models;
using Data.Sql.DataModels;

namespace Data.Interface.Repositories
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        List<ReviewAndInfoAboutTheirGames> GetReviews();
    }
}
