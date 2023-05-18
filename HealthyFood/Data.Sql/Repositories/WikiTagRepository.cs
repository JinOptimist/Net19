using Data.Interface.Models;
using Data.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
