using HealthyFoodWeb.Models.ModelsWikiBAA;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;
using Data.Sql.Models;
using Data.Sql.Repositories;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class WikiBAAPageServices : IWikiBAAPageServices
    {
        private IWikiBaaRepository _wikiBaaRepository;

        private IWikiBaaCommentRepository _wikiBaaCommentRepository;

        private IAuthService _authService;

        public WikiBAAPageServices(IWikiBaaRepository wikiBaaRepository, IAuthService authService, IWikiBaaCommentRepository wikiBaaCommentRepository)
        {
            _wikiBaaRepository = wikiBaaRepository;
            _authService = authService;
            _wikiBaaCommentRepository = wikiBaaCommentRepository;
        }

        public void CreateBlock(BLockPageBaaViewModel block)
        {
            var user = _authService.GetUser();
            var dbBlockBAA = new PageWikiBlock()
            {
                Id = block.Id,
                Title = block.Title,
                Text = block.Text,
                Author = user
            };
            _wikiBaaRepository.Add(dbBlockBAA);
        }

        public void CreateComment(int blockId, string comment, int commentId)
        {
            var blockDb = _wikiBaaRepository.Get(blockId);
            var user = _authService.GetUser();
            _wikiBaaCommentRepository.CreateComment(user, blockDb, comment, commentId);
        }

        public IEnumerable<BLockPageBaaViewModel> GetBlocksWithAuthorAndComments()
        {

            return _wikiBaaRepository.GetBlocksWithAuthorComMents()
                .Select(
                x => new BLockPageBaaViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    Author = x.Author,
                    CommentAndAuthor = x.CommentAndAuthor?
                    .Select
                    (c => new CommentAndAuthorViewModel
                    {
                        Comment = c.Comment,
                        Author = c.Author.Name,
                        CommentId = c.CommentId,
                        AuthorId = c.Author.Id
                    })
                    .ToList() ?? new List<CommentAndAuthorViewModel>()
                });
        }

        public void Remove(int id)
        {
            _wikiBaaRepository.Remove(id);
        }

        public void RemoveComment(int commentId)
        {
            _wikiBaaCommentRepository.RemoveComment(commentId);
        }

        public BLockPageBaaViewModel GetBLockPageBaaViewModel(int id)
        {
            var blockPage = _wikiBaaRepository.GetBLockPageBaaViewModel(id);
            return new BLockPageBaaViewModel
            {
                Id = blockPage.Id,
                Title = blockPage.Title,
                Text = blockPage.Text,
            };
        }

        public void Updateblock(int id, string title, string text)
        {
            _wikiBaaRepository.UpdateBlock(id, title, text);
        }
    }
}
