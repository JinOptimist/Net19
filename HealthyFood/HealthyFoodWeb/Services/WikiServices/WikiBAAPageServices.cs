using HealthyFoodWeb.Models.ModelsWikiBAA;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;
using Data.Sql.Models;
using Data.Interface.Models;
using Data.Sql.Repositories;
using Data.Interface.DataModels;

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

        public void CreateComment(int blockeId, string comment)
        {
            var block = _wikiBaaRepository.Get(blockeId);
            var user = _authService.GetUser();
            var dbComment = new WikiBlockComment()
            {
                Block = block,
                Text = comment,
                Author = user,
            };
            _wikiBaaCommentRepository.Add(dbComment);
        }

        public IEnumerable<BLockPageBaaViewModel> GetBlocksWithAuthorAndComments()
        {

            return _wikiBaaRepository.GetBlocksWithAuthorComMents()
                .Select(
                x => new BLockPageBaaViewModel
                {
                    Id = x.Id,
                    Text = x.Text,
                    Title = x.Title,
                    Author = x.Author,
                    CommentAndAuthor = x.CommentAndAuthor?
                    .Select
                    (c => new CommentAndAuthorViewModel
                    {
                        Comment = c.Comment,
                        Author = c.Author
                    })
                    .ToList() ?? new List<CommentAndAuthorViewModel>()
                });
        }

        public void Remove(int id)
        {
            _wikiBaaRepository.Remove(id);
        }
    }
}
