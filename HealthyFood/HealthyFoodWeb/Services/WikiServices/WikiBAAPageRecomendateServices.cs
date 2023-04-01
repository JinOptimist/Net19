using Data.Interface.Models;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.FakeDb;

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
                Id= block.Id
            };
             _wikiRepositoryBAA.CreateBlock(dbBlockBAA);                       
        }

        public List<IBlockModelBAA> GetBlocks()
        {
            return _wikiRepositoryBAA.GetBlocks();
        }

        public void Remove(int id)
        {
             _wikiRepositoryBAA.RemoveBlock(id);
        }
    }
}
