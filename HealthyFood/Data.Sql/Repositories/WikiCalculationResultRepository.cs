using Data.Interface.Models.WikiMc;
using Data.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.Repositories
{
	public class WikiCalculationResultRepository : BaseRepository<WikiCalculationResults>, IWikiCalculationResultRepository
	{
		public WikiCalculationResultRepository(WebContext webContext) : base(webContext) { }
	}
}
