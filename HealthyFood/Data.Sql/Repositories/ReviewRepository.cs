using Data.Interface.Models;
using Data.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(WebContext webContext) : base(webContext)
        {
            
        }
       public List<Review> GetReviews()
        {
            return _dbSet.Include(x => x.User).Include(x => x.User.CreatedGames).ToList();
        }

      
    }
}
