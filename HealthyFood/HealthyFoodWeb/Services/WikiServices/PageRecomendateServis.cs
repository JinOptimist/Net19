using Data.Interface.Models;
using HealthyFoodWeb.FakeDbModels;
using HealthyFoodWeb.Services.FakeDb;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class PageRecomendateServis : IPageRecomendateServis
    {
        private WikiRepositoryBAA _wikiRepositoryBAA;

        public PageRecomendateServis(WikiRepositoryBAA wikiRepositoryBAA)
        {
            _wikiRepositoryBAA = wikiRepositoryBAA;
        }

        
        List<IBlockModelBAA> IPageRecomendateServis.GetTitles()
        {
            return _wikiRepositoryBAA.GetTitles();
        }
    }
}
