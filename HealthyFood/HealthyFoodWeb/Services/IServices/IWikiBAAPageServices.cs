using HealthyFoodWeb.Models.ModelsWikiBAA;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IWikiBAAPageServices
    {
       void CreateBlock(BLockPageBaaViewModel block);

        void Remove(int id);

        IEnumerable<BLockPageBaaViewModel> GetBlocksWithAuthorAndComments();
       
        public void CreateComment(int blockId, string comment, int CommentId);

        void RemoveComment(int id);
    }
}