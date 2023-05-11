using Data.Sql.Models;
using HealthyFoodWeb.Models.ModelsWikiBAA;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IWikiBAAPageServices
    {
       void CreateBlock(BLockPageBaaViewModel block);

        void Remove(int id);

        IEnumerable<BLockPageBaaViewModel> GetBlocksWithAuthorAndComments();
       
        public void CreateComment(int blockeId, string comment);
    }
}