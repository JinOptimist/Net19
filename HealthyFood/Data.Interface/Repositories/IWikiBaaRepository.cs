using Data.Interface.DataModels;
using Data.Sql.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiBaaRepository : IBaseRepository<PageWikiBlock> 
    {
		IEnumerable<BlockPageBaaData> GetBlocksWithAuthorComMents();
    }
}