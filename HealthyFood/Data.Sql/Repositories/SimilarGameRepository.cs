using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class SimilarGameRepository : BaseRepository<SimilarGame>, ISimilarGameRepository
    {
        private WebContext _webContext;

        public SimilarGameRepository(WebContext webContext) :base (webContext)   {    }
       
    }
}
