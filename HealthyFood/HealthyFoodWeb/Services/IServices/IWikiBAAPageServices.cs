using HealthyFoodWeb.Models.ModelsWikiBAA;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IWikiBAAPageServices
    {
        void CreateBlock(BLockPageBaaViewModel block);

        void Remove(int id);

        IEnumerable<BLockPageBaaViewModel> GetBlocksWithAuthorAndComments();
       
        void CreateComment(int blockId, string comment, int CommentId);

        void RemoveComment(int commentId);

        BLockPageBaaViewModel GetBLockPageBaaViewModel(int id);

        void Updateblock(int id, string title, string text);
    }
}