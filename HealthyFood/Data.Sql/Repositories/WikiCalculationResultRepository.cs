using Data.Interface.Models.WikiMc;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
	public class WikiCalculationResultRepository : BaseRepository<WikiCalculationResults>, IWikiCalculationResultRepository
	{
		public WikiCalculationResultRepository(WebContext webContext) : base(webContext) { }
	}
}
