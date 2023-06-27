using Data.Interface.Models.WikiMc;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public class WikiTagRepository : BaseRepository<WikiTags>, IWikiTagRepository
    {
        public WikiTagRepository(WebContext webContext) : base(webContext) { }

        public WikiTags Get(string tag)
        {
            return _dbSet.SingleOrDefault(x => x.TagName == tag);
        }
    }
}
