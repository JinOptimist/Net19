using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class WikiBaaCommentRepository : BaseRepository<WikiBlockComment>, IWikiBaaCommentRepository
    {
        public WikiBaaCommentRepository(WebContext webContext) : base(webContext) { }

        public IEnumerable<WikiBlockComment> GetComments()
        {
            return _dbSet.ToList();
        }

        public void Add(WikiBlockComment model)
        {
            _dbSet.Add((WikiBlockComment)model);
            _webContext.SaveChanges();
        }

        public void CreateComment(CommentAndAuthorData comment)
        {
            _dbSet.Add(new WikiBlockComment
            {
                Text = comment.Comment,
                Block = comment.Block,
                Author = comment.Author
            });
            _webContext.SaveChanges();
        }
    }
}
