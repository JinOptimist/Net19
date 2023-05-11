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

        public void CreateComment(User Author, PageWikiBlock Block, string Text, int CommentId)
        {
            _dbSet.Add(new WikiBlockComment
            {
                Text = Text,
                Block = Block,
                Author = Author,
                Id = CommentId
            });
            _webContext.SaveChanges();
        }

        public void RemoveComment(int idComment)
        {
            var comment = _dbSet.FirstOrDefault(_x => _x.Id == idComment);
            _dbSet.Remove(comment);
            _webContext.SaveChanges();
        }
    }
}
