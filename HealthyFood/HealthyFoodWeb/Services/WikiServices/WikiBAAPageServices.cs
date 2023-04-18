using Data.Interface.Models;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;
using Data.Sql.Models;
using Data.Interface.Models;
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

        public List<PageWikiBlock> GetBlocks()
        {
            return _wikiBaaRepository.GetAll().ToList();
        }

        public IEnumerable<PageWikiBlock> GetBlocksWithAuthor()
        {
            return _wikiBaaRepository.GetBlocksWithAuthor();
        }

        public IEnumerable<WikiBlockComment> GetComments()
        {
            return _wikiBaaCommentRepository.GetComments();
        }

        public void CreateComment(BLockPageBaaViewModel comment)
        {
            var user = _authService.GetUser();
            var dbComment = new WikiBlockComment()
            {
                Id = comment.Id,
                Text = comment.CommentText,
                Author = user
            };
            _wikiBaaCommentRepository.Add(dbComment);
        }

        public void Remove(int id)
        {
            _wikiBaaRepository.Remove(id);
        }
    }
}
