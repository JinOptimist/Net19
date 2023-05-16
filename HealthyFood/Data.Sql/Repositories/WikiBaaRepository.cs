using Data.Interface.DataModels;
using Data.Interface.Repositories;
using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public class WikiBaaRepository : BaseRepository<PageWikiBlock>, IWikiBaaRepository
    {
        public WikiBaaRepository(WebContext webContext) : base(webContext) { }

        public void Add(PageWikiBlock model)
        {
            _dbSet.Add((PageWikiBlock)model);
            _webContext.SaveChanges();
        }

        public IEnumerable<PageWikiBlock> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<BlockPageBaaData> GetBlocksWithAuthorComMents()
        {
            return _dbSet.Select(
                x => new BlockPageBaaData
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    Author = x.Author.Name,
                    CommentAndAuthor = x
                        .Comment
                        .Select(c => new CommentAndAuthorData
                        {
                            Comment = c.Text,
                            Author = c.Author,
                            CommentId = c.Id
                        })
                        .ToList(),
                })
                .ToList();
        }

        public void Remove(int id)
        {
            var block = _dbSet.FirstOrDefault(_x => _x.Id == id);
            _dbSet.Remove(block);
            _webContext.SaveChanges();
        }

        public BlockPageBaaData GetBLockPageBaaViewModel(int id)
        {
            var block = _dbSet.SingleOrDefault(x => x.Id == id);
            return new BlockPageBaaData
            {
                Id = block.Id,
                Title = block.Title,
                Text = block.Text,
            };
        }

        public void UpdateBlock(int id, string title, string text)
        {
            var block = Get(id);
            block.Title = title;
            block.Text = text;
            _webContext.SaveChanges();
        }
    }
}
