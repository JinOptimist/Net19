using Data.Interface.Models.WikiMc;

namespace Data.Interface.Repositories
{
    public interface IWikiTagRepository : IBaseRepository<WikiTags>
    {
        public WikiTags Get(string tag);

        public IEnumerable<WikiTags> GetAllUserTags(int userId);
	}
}
