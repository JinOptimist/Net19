using Data.Interface.Models;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;
using Data.Sql.Models;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class WikiBAAPageRecomendateServices : IWikiBAAIPageRecomendateServices
    {
        private IWikiBaaRepository _wikiRepositoryBAA;

        public WikiBAAPageRecomendateServices(IWikiBaaRepository wikiRepositoryBAA)
        {
            _wikiRepositoryBAA = wikiRepositoryBAA;
        }

        public void CreateBlock(BLockPageBaaViewModel block)
        {
            var dbBlockBAA = new PageWikiBlock()
            {
                Title = block.Title,
                Text = block.Text,
                Id = block.Id
            };
            _wikiRepositoryBAA.Add(dbBlockBAA);
        }

        public List<PageWikiBlock> GetBlocks()
        {
            return _wikiRepositoryBAA.GetAll().ToList();
        }

        public void Remove(int id)
        {
            _wikiRepositoryBAA.Remove(id);
        }
    }
}
