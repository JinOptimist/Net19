using Data.Interface.Models;
using Data.Sql.Models;
using HealthyFoodWeb.Models.ModelsWikiBAA;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IWikiBAAPageServices
    {
        List<PageWikiBlock> GetBlocks();

        void CreateBlock(BLockPageBaaViewModel block);

        void Remove(int id);

        public List<PageWikiBlock> GetBlocksWithAuthors();

	}
}