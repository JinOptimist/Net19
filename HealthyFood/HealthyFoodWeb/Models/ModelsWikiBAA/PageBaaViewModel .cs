using HealthyFoodWeb.Models.ModelsWikiBAA;

namespace HealthyFoodWeb.Models.ModelsWiki
{
    public class PageBaaViewModel
    {
        public List<BLockPageBaaViewModel> BlocksList { get; set; } = new List<BLockPageBaaViewModel>();

		public List<BLockPageBaaViewModel> BlocksListWithAuthor { get; set; } = new List<BLockPageBaaViewModel>();
	}
}

