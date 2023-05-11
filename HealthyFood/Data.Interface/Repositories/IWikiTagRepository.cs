using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiTagRepository : IBaseRepository<WikiTags>
    {
        public WikiTags Get(string tag);
    }
}
