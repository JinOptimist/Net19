using HealthyFoodWeb.FakeDbModels;
using Data.Interface.Models;
using HealthyFoodWeb.Models.ModelsWikiBAA;

namespace HealthyFoodWeb.Models.ModelsWiki
{
    public class PageViewModelBAA
    {
        public List<BLockPageViewModelBAA> BlocksList { get; set; } = new List<BLockPageViewModelBAA>();
    }
}

