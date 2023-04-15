using HealthyFoodWeb.Models.ModelsWikiBAA;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;
using Data.Sql.Models;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class WikiBAAPageServices : IWikiBAAPageServices
    {
        private IWikiBaaRepository _wikiRepositoryBAA;

        private IAuthService _authService;

        public WikiBAAPageServices(IWikiBaaRepository wikiRepositoryBAA, IAuthService authService)
        {
            _wikiRepositoryBAA = wikiRepositoryBAA;
            _authService = authService;
        }

        public void CreateBlock(BLockPageBaaViewModel block)
        {
            var user = _authService.GetUser();
            var dbBlockBAA = new PageWikiBlock()
            {
                Title = block.Title,
                Text = block.Text,
                Id = block.Id,
                Author = user
            };
            _wikiRepositoryBAA.Add(dbBlockBAA);
        }

        public List<PageWikiBlock> GetBlocks()
        {
            return _wikiRepositoryBAA.GetAll().ToList();
        }

        public IEnumerable<PageWikiBlock> GetBlocksWithAuthor()
        {
            return _wikiRepositoryBAA.GetBlocksWithAuthor();
        }

        public void Remove(int id)
        {
            _wikiRepositoryBAA.Remove(id);
        }
    
	}
}
