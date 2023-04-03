using Data.Interface.Models;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using Data.Interface.Repositories;
using HealthyFoodWeb.Services.IServices;
using Data.Sql.Models;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class WikiBAAPageRecomendateServices : IWikiBAAIPageRecomendateServices
    {
        private IWikiRepositoryBAA _wikiRepositoryBAA;

        public WikiBAAPageRecomendateServices(IWikiRepositoryBAA wikiRepositoryBAA)
        {
            _wikiRepositoryBAA = wikiRepositoryBAA;
        }

        public void CreateBlock(BLockPageViewModelBAA block)
        {
            var dbBlockBAA = new BlockModelBAA()
            {
                Title = block.Title,
                Text = block.Text,
                Id = block.Id
            };
            _wikiRepositoryBAA.Add(dbBlockBAA);
        }

        public List<IBlockModelBAA> GetBlocks()
        {
            return _wikiRepositoryBAA.GetAll().ToList();
        }

        public void Remove(int id)
        {
            _wikiRepositoryBAA.RemoveBlock(id);
        }
    }
}
