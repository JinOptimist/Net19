using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(WebContext webContext) : base(webContext)
        {

        }
        public List<ReviewAndInfoAboutTheirGames> GetReviews()
        {
            return _dbSet
                .Select(review => new ReviewAndInfoAboutTheirGames
                {
                    Date = review.Date,
                    TextReview = review.TextReview,
                    UserName = review.User.Name,
                    GamesName = review.User.CreatedGames.Select(x=>x.Name).ToList(),
                   
                }).ToList();

        }
        public override PaginatorData<Review> GetPaginator(int page, int perPage)
        {
            var initialSource = _dbSet
                .Include(x => x.User)
                .ThenInclude(x => x.CreatedGames);
            return base.GetPaginator(initialSource, page, perPage);
        }
    }
}
