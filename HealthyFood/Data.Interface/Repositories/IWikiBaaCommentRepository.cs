using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public interface IWikiBaaCommentRepository : IBaseRepository<WikiBlockComment>
    {
        int CreateComment(User Author, PageWikiBlock Block, string Comment);

        void RemoveComment(int idComment);

        CommentAndAuthorData GetBlockCommentPageBaaViewModel(int commentId);

        void UpdateBlockComment(int Id, string Text);
    }
}